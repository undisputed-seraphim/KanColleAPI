using KanColle;
using KanColle.Request.Mission;
using System;
using System.Windows.Threading;
using Newtonsoft.Json;

namespace RunExpKai {
	public class RunExp {

		private DispatcherTimer Timer;
		public int[] ShipList { get; set; }
		private KanColle.Master.Mission FleetMission;
		private bool IsRunning;
		public KanColleProxy Proxy { private get; set; }

		public RunExp() {
			this.Timer = new DispatcherTimer();
		}

		private void Expedition_Iteration(object sender, EventArgs e) {
			
		}

		public void Start() {
			this.IsRunning = true;
			this.Timer.Start();
		}

		public void Stop() {
			this.Timer.Stop();
		}

		public void NewMission(KanColle.Master.Mission Mission) {
			if (!this.Timer.IsEnabled) {
				this.Timer.Stop();
				this.IsRunning = false;
			}
			this.FleetMission = Mission;
			this.Timer = new DispatcherTimer();
			this.Timer.Interval = TimeSpan.FromMinutes(this.FleetMission.api_time);
			this.Timer.Tick += Expedition_Iteration;
		}

		private void result(int fleet_id) {
			string parameter = Mission.Result(fleet_id);
			string post_response = this.Proxy.proxy(Mission.RESULT, parameter);

			KanColleAPI<MissionResult> result = JsonConvert.DeserializeObject<KanColleAPI<MissionResult>>(post_response);

			// If mission fails, abort completely.
			if (result.GetData().GetResult().Equals(ExpeditionResult.FAIL)) {
				this.IsRunning = false;
			} else {
				int[] GetMaterials = result.GetData().PrintConsole();
			}
		}

		private void refuel() {
		}
	}
}
