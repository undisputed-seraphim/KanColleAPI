using KanColle;
using KanColle.Member;
using KanColle.Request.Hokyu;
using KanColle.Request.Mission;
using Newtonsoft.Json;
using System;
using System.IO;
//using System.Linq;
using System.Text;
using System.Threading;

namespace RunExp {

	class RunExp {

		private KanColleProxy kcp;
		private int fleet_id, mission_id, interval;
		private string ship_list, member_id;
		private int run_count;
		private int[] accumulated;

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
			this.port = this.kcp.GetPort(this.member_id);
			getShipList(fleet_id);
			this.accumulated = new int[4] { 0, 0, 0, 0 };

			// Debug.
			/*
			Console.WriteLine(this.member_id);
			Console.WriteLine(this.ship_list);
			*/

			// Run once only.
			checkIfExistingMission();
		}

		public void run () {
			start();
			Console.WriteLine("This expedition has run for {0} times!", this.run_count++);
			Thread.Sleep(this.interval * 60 * 1000);
			Thread.Sleep(1000); // Sleep for one second for buffer time.
			this.port = this.kcp.GetPort(this.member_id);
			Thread.Sleep(1000); // Sleep for one second for buffer time.
			result();
			Thread.Sleep(1000); // Sleep for one second for buffer time.
			getShipList(this.fleet_id);	// Get an updated list of ships.
			charge();
			Thread.Sleep(1000); // Sleep for one second for buffer time.
		}

		private void start () {
			Console.WriteLine();
			Console.WriteLine("!!***** NEW MISSION *****!!");
			System.Diagnostics.Process proc = System.Diagnostics.Process.Start("KanColleConsole.exe");
			Thread.Sleep(400);
			proc.Kill();
			string mission_hash = File.ReadAllText("__abcde__.txt");

			string parameter = Mission.Start(this.fleet_id, this.mission_id, int.Parse(mission_hash));
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
				int[] getMaterials = result.GetData().PrintConsole();

				this.accumulated[0] += getMaterials[0];
				this.accumulated[1] += getMaterials[1];
				this.accumulated[2] += getMaterials[2];
				this.accumulated[3] += getMaterials[3];
				//this.accumulated.Zip(getMaterials, (x, y) => x + y); // Didn't work for some reason.
				Console.WriteLine("Cumulative resource acquired: {0} fuel, {1} ammo, {2} steel, {3} bauxite.", this.accumulated[0], this.accumulated[1], this.accumulated[2], this.accumulated[3]);

				// If mission fails, abort loop completely.
				if (result.GetData().GetResult().Equals(ExpeditionResult.FAIL)) {
					Console.WriteLine("Mission has FAILED! Current mission loop will be aborted.\nPlease check your fleet lineup and start again.");
					Console.WriteLine("Press any key to exit this program.");
					Console.Read();
					Environment.Exit(2);
				}

			} catch (Exception e) {
				Console.WriteLine(parameter);
				Console.WriteLine(postResponse);
				Console.WriteLine(e.Message);
				return;
			}
		}

		// Charge is an idempotent function that never fails, so it does not need to be surrounded with try/catch.
		private void charge () {
			Console.WriteLine();
			Console.WriteLine("!!***** REFUEL *****!!");
			string parameter = Hokyu.Charge(this.ship_list);
			string postResponse = this.kcp.proxy(Hokyu.CHARGE, parameter);
		}

		// This function assumes there is a recently updated copy of Port data available.
		// It does not request its own copy.
		// The old behavior was that this function would request its own copy of Port. That is no longer the case.
		private void getShipList (int fleetNum) {
			try {
				this.ship_list = this.port.GetFleetList(fleetNum);
			} catch (Exception e) {
				Console.WriteLine(e.Message);
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

		// For debugging purposes.
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
				int sleepTime = (int) ((missionEnd - DateTime.Now).TotalSeconds);
				if (sleepTime > 1) {

                    Console.WriteLine("There is already a mission running for this fleet.");
                    Console.WriteLine("It will return on " + missionEnd);

                    // Sleep, in seconds.
                    Console.WriteLine("This program will sleep for {0} minutes and {1} seconds before it resumes.", sleepTime / 60, sleepTime % 60);
                    Thread.Sleep(sleepTime * 1000);
                }

				// Wake and end mission.
				this.port = this.kcp.GetPort(this.member_id);
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