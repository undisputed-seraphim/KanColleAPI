using KanColle;
using KanColle.Flash.External;
using KanColle.Member;
using KanColle.Request.Mission;
using KanColle.Request.Hokyu;
using Newtonsoft.Json;
using System;
using System.IO;
using System.Text;
using System.Windows.Forms;
using System.Threading;
using System.ComponentModel;

namespace RunExpKai {
	public partial class RunExpKai :Form {

		private static string API_TOKEN_DIR = "api_token.txt";
		private static string API_PORT_DIR = "api_port.swf";

		private KanColleProxy kcp;
		private ExternalInterfaceProxy eip;
		private bool debug;
		private int member_id;
		private Port port;
		private int[][] fleet_lists;
		private int[][] accumulated;
		private KanColle.Master.Mission[] mission_list;

		public RunExpKai () {
			InitializeComponent();

			// Debug flag. Set to true only for debug builds.
			this.debug = false;

			// Read in api token, read in api_port, initialize the interfaces.
			Console.OutputEncoding = Encoding.Unicode;
			StreamReader reader = new StreamReader(API_TOKEN_DIR);
			string full_api_token = reader.ReadLine();
			reader.Close();

			this.flash.LoadMovie(0, API_PORT_DIR);
			this.eip = new ExternalInterfaceProxy(this.flash);
			this.kcp = new KanColleProxy(full_api_token);

			// Run once on program startup to fetch initial data.
			this.member_id = int.Parse(this.kcp.GetBasic().api_member_id);
			this.port = this.kcp.GetPort(this.member_id.ToString());
			this.mission_list = this.kcp.GetStart2().api_mst_mission;

			this.fleet_lists = new int[4][];
			this.fleet_lists[0] = null;
			this.fleet_lists[1] = this.port.api_deck_port[1].api_ship;
			this.fleet_lists[2] = this.port.api_deck_port[2].api_ship;
			this.fleet_lists[3] = this.port.api_deck_port[3].api_ship;
			this.accumulated = new int[4][];
		}

		#region Flash interface

		private long GetApiPort_Flash () {
			object obj = this.eip.Call("api_port", this.member_id.ToString());
			return long.Parse(obj.ToString());
		}

		private int GetMission_Flash () {
			object obj = this.eip.Call("api_mission", null);
			return int.Parse(obj.ToString());
		}

		private int GetQuest_Flash () {
			object obj = this.eip.Call("api_quest", null);
			return int.Parse(obj.ToString());
		}

		#endregion

		#region Main Logic

		private void start (int fleet_id, int mission_id) {
			string param = KanColle.Request.Mission.Mission.Start(fleet_id, mission_id, GetMission_Flash());
			string response = this.kcp.proxy(KanColle.Request.Mission.Mission.START, param);

			try {
				KanColleAPI<MissionStart> start = JsonConvert.DeserializeObject<KanColleAPI<MissionStart>>(response);
				start.GetData().PrintConsole();
			} catch (Exception e) {
				Console.WriteLine(param);
				Console.WriteLine(response);
				Console.WriteLine(e.Message);
				return;
			}
		}

		private void charge (int fleet_id) {
			string parameter = Hokyu.Charge(IntArrayToString(this.fleet_lists[fleet_id]));
			string postResponse = this.kcp.proxy(Hokyu.CHARGE, parameter);
		}

		private void result (int fleet_id) {
			string parameter = KanColle.Request.Mission.Mission.Result(fleet_id);
			string postResponse = this.kcp.proxy(KanColle.Request.Mission.Mission.RESULT, parameter);

			try {
				KanColleAPI<MissionResult> result = JsonConvert.DeserializeObject<KanColleAPI<MissionResult>>(postResponse);

				// If mission fails, abort loop completely.
				if (result.GetData().GetResult().Equals(ExpeditionResult.FAIL)) {
					Console.WriteLine("Mission has FAILED! Current mission loop will be aborted.\nPlease check your fleet lineup and start again.");
					Console.WriteLine("Press any key to exit this program."); // Not really supposde to exit...
					Console.Read();
					Environment.Exit(2);
				}

				this.accumulated[fleet_id][0] += result.GetData().api_get_material[0];
				this.accumulated[fleet_id][1] += result.GetData().api_get_material[1];
				this.accumulated[fleet_id][2] += result.GetData().api_get_material[2];
				this.accumulated[fleet_id][3] += result.GetData().api_get_material[3];
			} catch (Exception e) {
				Console.WriteLine(parameter);
				Console.WriteLine(postResponse);
				Console.WriteLine(e.Message);
				return;
			}
		}

		#endregion

		#region Interface Logic

		private void RunExpKai_Load (object sender, EventArgs e) {

		}

		private void Fleet_2_Start_Click (object sender, EventArgs e) {
			if (Fleet_2_Worker.IsBusy == false) {
				//TODO: Do stuff
				int expedition_id = Fleet_2_DropDown.SelectedItem;
			}
		}

		private void Fleet_2_Pause_Click (object sender, EventArgs e) {
			if (Fleet_2_Worker.WorkerSupportsCancellation) {
				//TODO: Pause or cancel.
				Fleet_2_Worker.CancelAsync();
			}
		}

		private void Fleet_3_Start_Click (object sender, EventArgs e) {
			if (Fleet_3_Worker.IsBusy == false) {
				// TODO: Do stuff
			}
		}

		private void Fleet_3_Pause_Click (object sender, EventArgs e) {
			if (Fleet_3_Worker.WorkerSupportsCancellation == true) {
				//TODO: Pause or cancel.
				Fleet_3_Worker.CancelAsync();
			}
		}

		private void Fleet_4_Start_Click (object sender, EventArgs e) {
			if (Fleet_4_Worker.IsBusy == false) {
				//TODO: Do stuff
			}
		}

		private void Fleet_4_Pause_Click (object sender, EventArgs e) {
			if (Fleet_4_Worker.WorkerSupportsCancellation == true) {
				//TODO: Pause or cancel.
				Fleet_4_Worker.CancelAsync();
			}
		}

		private void Fleet_2_DropDown_SelectedIndexChanged (object sender, EventArgs e) {

		}

		private void Fleet_3_DropDown_SelectedIndexChanged (object sender, EventArgs e) {

		}

		private void Fleet_4_DropDown_SelectedIndexChanged (object sender, EventArgs e) {

		}

		private void StartAll_Click (object sender, EventArgs e) {
			Fleet_2_Start_Click(sender, e);
			Fleet_3_Start_Click(sender, e);
			Fleet_4_Start_Click(sender, e);
		}

		private void StopAll_Click (object sender, EventArgs e) {
			Fleet_2_Pause_Click(sender, e);
			Fleet_3_Pause_Click(sender, e);
			Fleet_4_Pause_Click(sender, e);
		}

		private void Update_Click (object sender, EventArgs e) {
			this.kcp.GetPort(this.member_id.ToString());
		}

		#endregion

		#region Background Workers

		private void Fleet_2_Expedition_Executor (object sender, DoWorkEventArgs e) {
			BackgroundWorker worker = sender as BackgroundWorker;

			while (true) {
				if (worker.CancellationPending == true) {
					e.Cancel = true;
					break;
				} else {

				}
			}
		}

		#endregion

		#region Misc. functions

		private string IntArrayToString(int[] array, bool SkipEmptyPositions = true) {
			if (SkipEmptyPositions) {
				return string.Join(",", array).Replace(",-1", "");
			} else {
				return string.Join(",", array);
			}
		}

		private static DateTime timeUnixEpochToDotNet (long unixTime) {
			return new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc).AddSeconds(unixTime).ToLocalTime();
		}

		private void CheckIfRunningMission (int fleet_id) {
			long missionTime = this.port.api_deck_port[fleet_id - 1].api_mission[2] / 1000;

			if (missionTime != 0) {
				DateTime missionEnd = timeUnixEpochToDotNet(missionTime);
				int sleepTime = (int) ((missionEnd - DateTime.Now).TotalSeconds);
				if (sleepTime > 1) {
					/*
					 * There is already a running mission, it will end on missionEnd.
					 */

					// Sleep for that many seconds in a separate thread.
					Thread.Sleep(sleepTime * 1000);
				}
				// Wake and end mission.
				this.port = this.kcp.GetPort(this.member_id.ToString());
				Thread.Sleep(1000);
				result(fleet_id);
				Thread.Sleep(1000);
				charge(fleet_id);
			} // else do nothing and continue as per normal.
		}

		#endregion
	}
}
