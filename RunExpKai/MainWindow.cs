using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Forms;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

using Newtonsoft.Json;
using AxShockwaveFlashObjects;

using KanColle;
using KanColle.Request.Mission;

namespace RunExpKai {
	partial class MainWindow {

		private KanColle.Member.Port port;
		private KanColleProxy kcproxy;
		private KanColle.Master.Start2 start2;
		private string MemberID;

		private void update() {
		}

		private void run() {

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

		private void GetMissionList() {
			
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
