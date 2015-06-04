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
	}
}
