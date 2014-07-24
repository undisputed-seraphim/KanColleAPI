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

		// Port is an object that is frequently updated.
		private Port port;

		static void Main (string[] args) {
			Console.OutputEncoding = Encoding.Unicode;

			StreamReader reader = new StreamReader("api_token.txt");
			string full_api_token = reader.ReadLine();
			reader.Close();

			int fleet_id = Convert.ToInt32(args[0]),
				mission_id = Convert.ToInt32(args[1]),
				interval = Convert.ToInt32(args[2]);

			RunExp runexp = new RunExp(full_api_token, fleet_id, mission_id, interval);

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
			checkIfExistingMission();
			start();
			Console.WriteLine("This expedition has run for {0} times!", this.run_count++);
			Thread.Sleep(this.interval * 60 * 1000);
			Thread.Sleep(1000); // Sleep for one second for buffer time.
			getPort();
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

		private String getPort () {
			String result = this.kcp.proxy(ApiPort.PORT, ApiPort.port(this.member_id));
			this.port = JsonConvert.DeserializeObject<KanColleAPI<Port>>(result).GetData();
			return result;
		}

		private string getShipList (int fleetNum) {
			String result = getPort();
			try {
				return this.port.GetFleetList(fleetNum);
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

		/*
		 * Checks if there is already a mission running, and stalls the program until that mission ends.
		 * When it reawakens, it will end the mission before resuming normal operation.
		 */
		private void checkIfExistingMission () {
			long missionTime = this.port.api_deck_port[this.fleet_id - 1].api_mission[2] / 1000;

			if (missionTime != 0) {
				DateTime missionEnd = timeUnixEpochToDotNet(missionTime);
				Console.WriteLine("There is already a mission running for this fleet.");
				Console.WriteLine("It will return in " + missionEnd);
				Console.WriteLine("This program will sleep until that time before it resumes.");

				// Sleep, in seconds.
				int sleepTime = (int) ((missionEnd - DateTime.Now).TotalSeconds);
				Thread.Sleep(sleepTime);

				// Wake and end mission.
				getPort();
				Thread.Sleep(1000);
				result();
				Thread.Sleep(1000);
				charge();
			}
		}

		private static DateTime timeUnixEpochToDotNet (long unixTime) {
			return new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc).AddSeconds(unixTime).ToLocalTime();
		}
	}
}