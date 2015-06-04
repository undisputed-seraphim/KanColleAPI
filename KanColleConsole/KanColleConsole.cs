﻿using KanColle.Flash.External;
using System;
using System.Windows.Forms;
using System.IO;
using System.Threading;

namespace KanColleConsole {
	public partial class KanColleConsole : Form {
		const int WM_APP = 0x8000;
		const int WM_API_PORT = WM_APP + 1;

		private ExternalInterfaceProxy proxy;

		public KanColleConsole() {
			InitializeComponent();

			// Read in the swf file.
			string swfPath = System.IO.Directory.GetCurrentDirectory() + "\\api_port.swf";
			this.flash.LoadMovie(0, swfPath);

			// Set up the proxy for the flash file.
			this.proxy = new ExternalInterfaceProxy(this.flash);
		}

		#region Button OnClicks
		private void ApiPort_OnClick(object sender, EventArgs e) {
			object obj = this.proxy.Call("api_port", this.UserID.Text);
			MessageBox.Show(obj.ToString());
		}

		private void ApiMission_OnClick(object sender, EventArgs e) {
			object obj = this.proxy.Call("api_mission", null);
			MessageBox.Show(obj.ToString());
		}

		private void ApiQuest_OnClick(object sender, EventArgs e) {
			object obj = this.proxy.Call("api_quest", null);
			MessageBox.Show(obj.ToString());
		}
		#endregion
		/*
		protected override void WndProc (ref Message m) {
			if (m.Msg == WM_API_PORT) {
				Console.WriteLine("ENtry Success!");
				string param = m.WParam.ToInt32().ToString();
				object obj = proxy.Call("api_port", param);
				System.IO.File.WriteAllText("api_port", obj.ToString());
				return;
			}
			base.WndProc(ref m);
		}*/

		private void KanColleConsole_Load(object sender, EventArgs e) {
			this.Visible = false;
			bool notSuccessful = true;

			while (notSuccessful) {
				try {
					System.IO.File.WriteAllText("Handle", this.Handle.ToInt64().ToString());
					System.IO.File.WriteAllText("__abcde__.txt", this.proxy.Call("api_mission", null).ToString());
					notSuccessful = false;
				} catch (IOException error) {
					// Sleep, then continue trying.
					Console.WriteLine(error.ToString());
					Thread.Sleep(250);
				}
			}
		}

		private void flash_Enter(object sender, EventArgs e) {

		}
	}
}
