using System;
using System.Windows.Forms;

namespace KanColleConsole {
	class KanColleConsoleApp {

		[STAThread]
		static void Main () {
			Application.EnableVisualStyles();
			Application.SetCompatibleTextRenderingDefault(false);
			Application.Run(new KanColleConsole());
		}
	}
}
