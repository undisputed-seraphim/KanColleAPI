using KanColle;
using KanColle.Request.Mission;
using KanColle.Request.Hokyu;
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
		private MainWindow mw;		// The window that contains this. YES I KNOW THERE IS TIGHT COUPLING

		public RunExp(MainWindow window) {
			this.Timer = new DispatcherTimer();
			this.mw = window;
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

		private void Expedition_Iteration(object sender, EventArgs e) {
			if (IsRunning) {

			} else {
				this.Timer.Stop();
			}
		}

		public void Start() {
			this.IsRunning = true;
			this.Timer.Start();
		}

		public void Stop() {
			this.Timer.Stop();
		}

		private void result(int fleet_id) {
			string parameter = Mission.Result(fleet_id);
			string post_response = this.Proxy.proxy(Mission.RESULT, parameter);

			KanColleAPI<MissionResult> result = JsonConvert.DeserializeObject<KanColleAPI<MissionResult>>(post_response);

			// If mission fails, abort completely.
			if (result.GetData().GetResult().Equals(ExpeditionResult.FAIL)) {
				this.IsRunning = false;
				// Write status to Main Window.
				this.mw.ConsoleOutput.Text += string.Format("Expedition for {0} has FAILED! Please check your fleet!\n", this.FleetMission.api_name);
			} else {
				this.mw.fuel += result.api_data.api_get_material[0];
				this.mw.ammo += result.api_data.api_get_material[1];
				this.mw.steel += result.api_data.api_get_material[2];
				this.mw.baux += result.api_data.api_get_material[3];

				this.mw.ConsoleOutput.Text += string.Format("Expedition {0} has successfully returned!\n", this.FleetMission.api_name);
				this.mw.UpdateCollectedResourcesUI();
			}
		}

		private void refuel() {
			string parameter = Hokyu.Charge(string.Join(",",this.ShipList));
			string postResponse = this.Proxy.proxy(Hokyu.CHARGE, parameter);
		}
	}
}
