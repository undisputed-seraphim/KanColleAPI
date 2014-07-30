using KanColle;
using KanColle.Member;
using KanColle.Request.Hensei;
using KanColle.Request.Hokyu;
using KanColle.Request.Map;
using KanColle.Request.Sortie;
using Newtonsoft.Json;
using System;
using System.IO;
using System.Text;
using System.Threading;

namespace Sparkler {

	class Sparkler {

		private const int ONE_SECOND = 1 * 1000;
		private const int FIVE_SECONDS = 5 * 1000;
		private const int TEN_SECONDS = 10 * 1000;

		private KanColleProxy kcp;
		private int fleet_id;
		private string member_id;
		private string ship_list_string;
		private int[] ship_list_array;
		private bool no_wait { get; set; }

		private Port portData;

		static void Main (string[] args) {
			Console.OutputEncoding = Encoding.Unicode;

			StreamReader reader = new StreamReader("api_token.txt");
			string full_api_token = reader.ReadLine();
			reader.Close();

			int fleet_id = Convert.ToInt32(args[0]),
				run_times = Convert.ToInt32(args[1]);

			fleet_id = Math.Abs(fleet_id);
			run_times = Math.Abs(run_times);

			Sparkler sparkler = new Sparkler(full_api_token, fleet_id);
			sparkler.run(run_times);
		}

		public Sparkler (string full_api_token, int fleet_id) {
			this.kcp = new KanColleProxy(full_api_token);
			this.fleet_id = fleet_id;

			this.member_id = getMemberId();
			this.ship_list_array = getShipListArray(this.fleet_id);
		}

		// General procedure: Remove all but flag, then run and replace each iteration.
		public void run (int run_times) {
			Console.WriteLine("LIST OF ALL SHIPS IN FLEET THAT WILL BE SPARKLED: " + string.Join(",", this.ship_list_array));
			string context = Hensei.CHANGE;
			string param = Hensei.RemoveAll(this.fleet_id);
			this.kcp.proxy(context, param);

			for (int i = 0; i < this.ship_list_array.Length; i++) {
				if (this.ship_list_array[i] <= 0) {
					continue;
				}

				runForOneShip(this.ship_list_array[i], run_times);

				if (i == this.ship_list_array.Length - 1) {
					Console.WriteLine("FLEET SPARKLING DONE!");
					break;
				}
				param = Hensei.Change(this.ship_list_array[i + 1], 1, this.fleet_id);
				this.kcp.proxy(context, param);
				Thread.Sleep(FIVE_SECONDS);
				Console.WriteLine("\n\nNEXT SHIP.");
			}

			Console.WriteLine("Rebuilding fleet...");
			for (int j = 0; j < this.ship_list_array.Length; j++) {
				param = Hensei.Change(this.ship_list_array[j], j + 1, this.fleet_id);
				Thread.Sleep(ONE_SECOND);
				this.kcp.proxy(context, param);
			}

			Console.WriteLine("ALL JOBS COMPLETED");
		}

		public void runForOneShip (int ship_id, int run_times) {
			int morale = getMorale(this.portData, ship_id);
			Console.WriteLine("KANMUSU'S ID: " + ship_id);
			Console.WriteLine("INITIAL MORALE: " + morale);

			if (morale >= 81) {
				Console.WriteLine("Morale is " + morale + ". Skipping...");
				return;
			}
			
			int run_count = 0;
			while (run_times != run_count) {
				if (morale >= 81) {
					Console.WriteLine("Morale is " + morale + ". Skipping the rest of iterations...");
					break;
				}

				this.kcp.proxy(MapInfo.MAPINFO);
				Console.WriteLine("MapInfo done.");
				this.kcp.proxy(MapCell.MAPCELL, MapCell.Get(1, 1));
				Console.WriteLine("MapCell done.");

				this.kcp.proxy(Map.START, Map.Start(1, this.fleet_id, 1, 1));
				Console.WriteLine("STARTED.");

				Thread.Sleep(ONE_SECOND);
				this.kcp.proxy(Sortie.BATTLE, Sortie.Battle(1, 0));
				Console.WriteLine("First battle done.");
				Thread.Sleep(TEN_SECONDS);
				this.kcp.proxy(Sortie.BATTLERESULT);
				Console.WriteLine("First battle results get.");
				Thread.Sleep(FIVE_SECONDS);

				this.kcp.proxy(Ship3.SHIP2, Ship3.Ship2());
				Console.WriteLine("Ship2 get.");
				this.kcp.proxy(Map.NEXT, Map.Next());
				Console.WriteLine("NEXT.");
				Thread.Sleep(ONE_SECOND);

				this.kcp.proxy(Sortie.BATTLE, Sortie.Battle(1, 0));
				Console.WriteLine("Second battle done.");
				Thread.Sleep(TEN_SECONDS);
				this.kcp.proxy(Sortie.BATTLERESULT);
				Console.WriteLine("Second battle results get.");
				Thread.Sleep(FIVE_SECONDS);

				string port_data = this.kcp.proxy(ApiPort.PORT, ApiPort.port(this.member_id));
				this.portData = JsonConvert.DeserializeObject<KanColleAPI<Port>>(port_data).GetData();
				Console.WriteLine("Returned to port.");

				this.kcp.proxy(Hokyu.CHARGE, Hokyu.Charge(this.ship_list_string, ChargeKind.BOTH));
				Console.WriteLine("Refueled.");
				Thread.Sleep(ONE_SECOND);

				Console.WriteLine("ROUND {0} COMPLETE.", ++run_count);
				morale = getMorale(this.portData, ship_id);
				Console.WriteLine("CURRENT MORALE: " + morale + "\n");
			}
		}

		private int getMorale (Port port, int ship_id) {
			int cond = 0;
			foreach (Ship kanmusu in port.api_ship) {
				if (kanmusu.api_id == ship_id) {
					return kanmusu.api_cond;
				}
			}
			return cond;
		}

		private string getShipList (int fleetNum) {
			String result = this.kcp.proxy(ApiPort.PORT, ApiPort.port(this.member_id));
			KanColleAPI<Port> api_data = JsonConvert.DeserializeObject<KanColleAPI<Port>>(result);
			this.portData = api_data.GetData();
			try {
				return api_data.GetData().GetFleetList(fleetNum);
			} catch (Exception e) {
				Console.WriteLine(result.Substring(0, 200));
				Console.WriteLine(e.Message);
				throw new Exception(e.Message, e);
			}
		}

		private int[] getShipListArray (int fleetNum) {
			String result = this.kcp.proxy(ApiPort.PORT, ApiPort.port(this.member_id));
			KanColleAPI<Port> api_data = JsonConvert.DeserializeObject<KanColleAPI<Port>>(result);
			this.portData = api_data.GetData();
			try {
				string shipList = api_data.GetData().GetFleetList(fleetNum);
				this.ship_list_string = shipList;
				return ToIntArray(shipList, ',');
			} catch (Exception e) {
				Console.WriteLine(result.Substring(0, 200));
				Console.WriteLine(e.Message);
				throw new Exception(e.Message, e);
			}
		}

		private string getMemberId () {
			String result = this.kcp.proxy(Basic.GET);
			KanColleAPI<Basic> api_data = JsonConvert.DeserializeObject<KanColleAPI<Basic>>(result);
			try {
				return api_data.GetData().api_member_id;
			} catch (Exception e) {
				Console.WriteLine(result.Substring(0, 200));
				Console.WriteLine(e.Message);
				throw new Exception(e.Message, e);
			}
		}

		public static int[] ToIntArray (string values, char delimiter) {
			return Array.ConvertAll(values.Split(delimiter), s => int.Parse(s));
		}
	}
}