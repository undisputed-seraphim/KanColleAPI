using System;
using System.Windows.Forms;

using KanColle;
using KanColle.Flash;

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
