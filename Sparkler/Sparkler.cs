using KanColle;
using KanColle.Master;
using KanColle.Member;
using Newtonsoft.Json;
using System;
using System.IO;
using System.Text;

namespace Sparkler {

	class Sparkler {

		private KanColleProxy kcp;
		private int fleet_id, run_times;
		private string member_id, ship_list;

		static void Main (string[] args) {
			Console.OutputEncoding = Encoding.Unicode;

			StreamReader reader = new StreamReader("api_token.txt");
			string full_api_token = reader.ReadLine();
			reader.Close();

			//int fleet_id = Convert.ToInt32(args[0]),
			//	run_times = Convert.ToInt32(args[1]);

			Sparkler sparkler = new Sparkler(full_api_token/*, fleet_id, run_times*/);

		}

		public Sparkler (string full_api_token/*, int fleet_id, int run_times*/) {
			this.kcp = new KanColleProxy(full_api_token);
			//this.fleet_id = fleet_id;
			//this.run_times = run_times;

			StreamReader reader = new StreamReader("DATA/dat.txt", Encoding.Unicode);
			string readin = reader.ReadLine();
			reader.Close();

			KanColleAPI<Start2> api_data = JsonConvert.DeserializeObject<KanColleAPI<Start2>>(readin);

			foreach (MapArea map in api_data.GetData().api_mst_maparea) {
				StreamWriter stream = new StreamWriter("DATA/MAPAREA.txt", true, Encoding.UTF8);
				stream.WriteLine(map);
				stream.Flush();
				stream.Close();
			}

			foreach (MapInfo map in api_data.GetData().api_mst_mapinfo) {
				StreamWriter stream = new StreamWriter("DATA/MAPINFO.txt", true, Encoding.UTF8);
				stream.WriteLine(map);
				stream.Flush();
				stream.Close();
			}

		}

		private string getShipList (int fleetNum) {
			String result = this.kcp.proxy(ApiPort.PORT, ApiPort.port(this.member_id));
			KanColleAPI<Port> api_data = JsonConvert.DeserializeObject<KanColleAPI<Port>>(result);
			try {
				return api_data.GetData().GetFleetList(fleetNum);
			} catch (Exception e) {
				Console.WriteLine(result);
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
				Console.WriteLine(result);
				Console.WriteLine(e.Message);
				throw new Exception(e.Message, e);
			}
		}
	}
}