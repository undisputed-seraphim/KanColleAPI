using KanColle;
using System;
using System.Collections.Generic;

namespace RunExpKai {
	partial class MainWindow {

		private readonly IDictionary<int, KanColle.Master.Ship> ShipList_Master;
		private readonly IDictionary<int, KanColle.Master.Mission> MissionList_Master;
		private IDictionary<int, KanColle.Member.Ship> ShipList_Member;

		private KanColle.Member.Port Port;
		private KanColleProxy KCProxy;
		private string MemberID;

		private RunExp Fleet2, Fleet3, Fleet4;

		public int fuel { get; set; }
		public int ammo { get; set; }
		public int steel { get; set; }
		public int baux { get; set; }

		private void UpdateMemberShipList() {
			KanColle.Member.Ship[] Ships = this.Port.api_ship;
			foreach (KanColle.Member.Ship Ship in Ships) {
				if (!this.ShipList_Member.ContainsKey(Ship.api_id))
					this.ShipList_Member.Add(Ship.api_id, Ship);
			}
		}

		private void UpdateFleetList() {
			if (this.Port == null) {
				this.Port = this.KCProxy.GetPort(this.MemberID);
				UpdateMemberShipList();
			}
			this.Fleet2.ShipList = this.Port.api_deck_port[1].api_ship;
			this.Fleet3.ShipList = this.Port.api_deck_port[2].api_ship;
			this.Fleet4.ShipList = this.Port.api_deck_port[3].api_ship;
		}

		private void FleetUpdatePorts() {
			this.Fleet2.Proxy = this.KCProxy;
			this.Fleet3.Proxy = this.KCProxy;
			this.Fleet4.Proxy = this.KCProxy;
		}

		private string GetMemberID() {
			try {
				return this.KCProxy.GetBasic().api_member_id;
			} catch (Exception e) {
				Console.WriteLine(e.Message);
				throw new Exception(e.Message, e);
			}
		}

		private string ListShipNames(int[] shiplist) {
			var ret = new System.Text.StringBuilder();
			foreach (int i in shiplist) {
				if (i == -1)
					continue;
				string ShipName = this.ShipList_Master[this.ShipList_Member[i].api_ship_id].api_name;
				ret.AppendFormat("{0} ", ShipName);
			}
			return ret.ToString();
		}

		// @param fleet_id is a natural number.
		private void CheckIfExistingMission(int fleet_id) {
			long missionTime = this.Port.api_deck_port[fleet_id - 1].api_mission[2] / 1000;

			if (missionTime != 0) {
				DateTime missionEnd = timeUnixEpochToDotNet(missionTime);
			}
		}

		private static DateTime timeUnixEpochToDotNet(long unixTime) {
			return new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc).AddSeconds(unixTime).ToLocalTime();
		}
	}
}
