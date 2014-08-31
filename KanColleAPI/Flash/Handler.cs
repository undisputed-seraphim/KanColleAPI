using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.InteropServices;
using System.IO;

namespace KanColle.Flash {
	public class Handler {
		System.Diagnostics.Process proc;

		const int WM_APP = 0x8000;
		const int WM_API_PORT = WM_APP + 1;

		[DllImport("User32.dll", EntryPoint = "SendMessage")]
		public static extern Int32 SendMessage (Int32 hWnd, Int32 Msg, Int32 wParam, Int32 lParam);

		public void StartUp () {
			this.proc = System.Diagnostics.Process.Start("KanColleConsole.exe");
		}

		public void Exit () {
			try {
				this.proc.Kill();
			} catch { }
		}

		public string GetApiPort (string memberID) {
			string handler = File.ReadAllText("Handle");
			SendMessage(int.Parse(handler), WM_API_PORT, int.Parse(memberID), 0);
			return File.ReadAllText("api_port");
		}
	}
}
