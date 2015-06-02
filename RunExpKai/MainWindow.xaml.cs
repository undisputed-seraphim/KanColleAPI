using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

using Newtonsoft.Json;

using KanColle;
using KanColle.Request.Mission;


namespace RunExpKai {
	/// <summary>
	/// Interaction logic for MainWindow.xaml
	/// </summary>
	public partial class MainWindow : Window {
		public MainWindow() {
			InitializeComponent();
		}

		// Members
		KanColleProxy kcproxy;
		bool fleet_2_isrunning, fleet_3_isrunning, fleet_4_isrunning;

		// Worker threads

		private void Fleet_2_Select_SelectionChanged( object sender, SelectionChangedEventArgs e ) {

		}

		private void Fleet_3_Select_SelectionChanged( object sender, SelectionChangedEventArgs e ) {

		}

		private void Fleet_4_Select_SelectionChanged( object sender, SelectionChangedEventArgs e ) {

		}

		private void Fleet_2_Start_Click( object sender, RoutedEventArgs e ) {

		}

		private void Fleet_3_Start_Click( object sender, RoutedEventArgs e ) {

		}

		private void Fleet_4_Start_Click( object sender, RoutedEventArgs e ) {

		}

		private void Fleet_2_Stop_Click( object sender, RoutedEventArgs e ) {

		}

		private void Fleet_3_Stop_Click( object sender, RoutedEventArgs e ) {

		}

		private void Fleet_4_Stop_Click( object sender, RoutedEventArgs e ) {

		}


		private void run() {

		}

		private void result(int fleet_id) {
			string parameter = Mission.Result( fleet_id );
			string post_response = this.kcproxy.proxy( Mission.RESULT, parameter );

			KanColleAPI<MissionResult> result = JsonConvert.DeserializeObject<KanColleAPI<MissionResult>>( post_response );

			// If mission fails, abort completely.
			if (result.GetData().GetResult().Equals( ExpeditionResult.FAIL )) {
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
