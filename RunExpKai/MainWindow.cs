using KanColle;
using KanColle.Request.Mission;
using Newtonsoft.Json;
using System;
using System.Windows.Threading;
using System.Collections.Generic;

namespace RunExpKai {
	partial class MainWindow {

		private readonly IDictionary<int, KanColle.Master.Ship> ShipList_Master;
		private readonly IDictionary<int, KanColle.Master.Mission> MissionList_Master;

		private IDictionary<int, KanColle.Member.Ship> ShipList_Member;

		private KanColle.Member.Port port;
		private KanColle.Master.Start2 start2;
		private KanColleProxy kcproxy;
		private string MemberID;

		private KanColle.Master.Mission fleet_2_mission, fleet_3_mission, fleet_4_mission;
		private int[] fleet_2_shiplist, fleet_3_shiplist, fleet_4_shiplist;
		private KanColle.Member.Ship[] f2shiplist;

		private void update() {
		}

		private void run() {
			DispatcherTimer timer = new DispatcherTimer();
		}


		private void result(int fleet_id) {
			string parameter = Mission.Result(fleet_id);
			string post_response = this.kcproxy.proxy(Mission.RESULT, parameter);

			KanColleAPI<MissionResult> result = JsonConvert.DeserializeObject<KanColleAPI<MissionResult>>(post_response);

			// If mission fails, abort completely.
			if (result.GetData().GetResult().Equals(ExpeditionResult.FAIL)) {
				if (fleet_id == 2) { this.fleet_2_isrunning = false; }
				if (fleet_id == 3) { this.fleet_3_isrunning = false; }
				if (fleet_id == 4) { this.fleet_4_isrunning = false; }
			} else {
				int[] GetMaterials = result.GetData().PrintConsole();

			}
		}

		private void refuel() {
		}

		private void UpdateMemberShipList() {
			KanColle.Member.Ship[] Ships = this.port.api_ship;
			foreach (KanColle.Member.Ship Ship in Ships) {
				if (!this.ShipList_Member.ContainsKey(Ship.ID()))
					this.ShipList_Member.Add(Ship.ID(), Ship);
			}
		}

		private void UpdateFleetList() {
			if (this.port == null) {
				this.port = this.kcproxy.GetPort(this.MemberID);
				UpdateMemberShipList();
			}
			this.fleet_2_shiplist = this.port.api_deck_port[1].api_ship;
			this.fleet_3_shiplist = this.port.api_deck_port[2].api_ship;
			this.fleet_4_shiplist = this.port.api_deck_port[3].api_ship;
		}

		private string GetMemberID() {
			string result = this.kcproxy.proxy(KanColle.Member.Basic.GET);
			try {
				KanColleAPI<KanColle.Member.Basic> api_data = JsonConvert.DeserializeObject<KanColleAPI<KanColle.Member.Basic>>(result);
				return api_data.GetData().api_member_id;
			} catch (Exception e) {
				Console.WriteLine(result);
				Console.WriteLine(e.Message);
				throw new Exception(e.Message, e);
			}
		}

		private string ListShipNames(int[] shiplist) {
			var ret = new System.Text.StringBuilder();

			foreach (int i in shiplist) {
				if (i == -1)
					continue;
				string ShipName = this.ShipList_Master[this.ShipList_Member[i].api_ship_id].Name();
				ret.AppendFormat("{0} ", ShipName);
			}

			return ret.ToString();
		}

		// @param fleet_id is a natural number.
		private void CheckIfExistingMission(int fleet_id) {
			long missionTime = this.port.api_deck_port[fleet_id - 1].api_mission[2] / 1000;

			if (missionTime != 0) {
				DateTime missionEnd = timeUnixEpochToDotNet(missionTime);
			}

		}

		private static DateTime timeUnixEpochToDotNet(long unixTime) {
			return new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc).AddSeconds(unixTime).ToLocalTime();
		}
	}
}
