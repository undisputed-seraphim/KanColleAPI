using KanColle;
using KanColle.Member;
using KanColle.Request.Hokyu;
using KanColle.Request.Mission;
using Newtonsoft.Json;
using System;
using System.IO;
using System.Text;
using System.Threading;

namespace RunExp {

	class RunExp {

		private KanColleProxy kcp;
		private int fleet_id, mission_id, interval;
		private string ship_list, member_id;
		private int run_count;

		static void Main (string[] args) {
			Console.OutputEncoding = Encoding.Unicode;

			StreamReader reader = new StreamReader("api_token.txt");
			string full_api_token = reader.ReadLine();
			reader.Close();

			int fleet_id = Convert.ToInt32(args[0]),
				mission_id = Convert.ToInt32(args[1]),
				interval = Convert.ToInt32(args[2]);

			RunExp runexp = new RunExp(full_api_token, fleet_id, mission_id, interval);

			string built_date = "21 June 2014, 18:49";
			Console.WriteLine("RUNEXP is a Kancolle expedition bot.\nThis version was built on {0}\n", built_date);

			while (true) {
				try {
					runexp.run();
				} catch (Exception e) {
					Console.WriteLine(e.Message);
					break;
				}
			}
			Console.Read();
			Console.WriteLine("Exiting...");
		}

		public RunExp (string full_api_token, int fleet_id, int mission_id, int interval) {
			this.kcp = new KanColleProxy(full_api_token);
			this.fleet_id = fleet_id;
			this.mission_id = mission_id;
			this.interval = interval;
			this.run_count = 0;

			this.member_id = getMemberId();
			this.ship_list = getShipList(fleet_id);

			// Debug.
			/*
			Console.WriteLine(this.member_id);
			Console.WriteLine(this.ship_list);
			*/
		}

		public void run () {
			start();
			Console.WriteLine("This expedition has run for {0} times!", this.run_count++);
			Thread.Sleep(this.interval * 60 * 1000);
			Thread.Sleep(1000); // Sleep for one second for buffer time.
			this.kcp.proxy(ApiPort.PORT, ApiPort.port(this.member_id));
			Thread.Sleep(1000); // Sleep for one second for buffer time.
			result();
			Thread.Sleep(1000); // Sleep for one second for buffer time.
			charge();
			Thread.Sleep(1000); // Sleep for one second for buffer time.
		}

		private void start () {
			Console.WriteLine();
			Console.WriteLine("!!***** NEW MISSION *****!!");
			string parameter = Mission.Start(this.fleet_id, this.mission_id);
			string postResponse = this.kcp.proxy(Mission.START, parameter);

			// Debug
			// Console.WriteLine(postResponse);

			try {
				KanColleAPI<MissionStart> start = JsonConvert.DeserializeObject<KanColleAPI<MissionStart>>(postResponse);
				start.GetData().PrintConsole();
			} catch (Exception e) {
				Console.WriteLine(parameter);
				Console.WriteLine(postResponse);
				Console.WriteLine(e.Message);
				return;
			}
		}

		private void result () {
			Console.WriteLine();
			Console.WriteLine("!!***** MISSION RESULTS *****!!");
			string parameter = Mission.Result(this.fleet_id);
			string postResponse = this.kcp.proxy(Mission.RESULT, parameter);

			// Debug
			// Console.WriteLine(postResponse);
			try {
				KanColleAPI<MissionResult> result = JsonConvert.DeserializeObject<KanColleAPI<MissionResult>>(postResponse);
				result.GetData().PrintConsole();
			} catch (Exception e) {
				Console.WriteLine(parameter);
				Console.WriteLine(postResponse);
				Console.WriteLine(e.Message);
				return;
			}
		}

		private void charge () {
			Console.WriteLine();
			Console.WriteLine("!!***** REFUEL *****!!");
			string parameter = Hokyu.Charge(this.ship_list);
			string postResponse = this.kcp.proxy(Hokyu.CHARGE, parameter);

			// Debug
			// Console.WriteLine(postResponse);
		}

		private string getShipList (int fleetNum) {
			String result = this.kcp.proxy(ApiPort.PORT, ApiPort.port(this.member_id));
			try {
				KanColleAPI<Port> api_data = JsonConvert.DeserializeObject<KanColleAPI<Port>>(result);
				return api_data.GetData().GetFleetList(fleetNum);
			} catch (Exception e) {

				Console.WriteLine(result);
				Console.WriteLine(e.Message);
				throw new Exception(e.Message, e);
			}
		}

		private string getMemberId () {
			String result = this.kcp.proxy(Basic.GET);
			try {
				KanColleAPI<Basic> api_data = JsonConvert.DeserializeObject<KanColleAPI<Basic>>(result);
				return api_data.GetData().api_member_id;
			} catch (Exception e) {
				Console.WriteLine(result);
				Console.WriteLine(e.Message);
				throw new Exception(e.Message, e);
			}
		}

		private static void writeToFile (string input, string path) {
			StreamWriter stream = new StreamWriter(path, false, Encoding.UTF8);
			stream.Write(input);
			stream.Flush();
			stream.Close();
		}
	}
}