using AxShockwaveFlashObjects;
using KanColle;
using KanColle.Flash.External;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using System.Linq;

namespace RunExpKai {
	/// <summary>
	/// Interaction logic for MainWindow.xaml
	/// </summary>
	public partial class MainWindow : Window {

		// Members
		private ExternalInterfaceProxy flashproxy;
		bool fleet_2_isrunning, fleet_3_isrunning, fleet_4_isrunning;

		// Worker threads

		public MainWindow() {
			InitializeComponent();
			// Initialization stuff

			// Try to read from user prefs

			// Update UI elements if user data is available

			// Initialize member ship list but do nothing
			this.ShipList_Member = new Dictionary<int, KanColle.Member.Ship>();

			// Read in master ship list
			KanColle.Master.Ship[] ships = KanColleProxy.ParseArbitraryJSON<KanColle.Master.Ship[]>("shiplist.dat");
			this.ShipList_Master = new Dictionary<int, KanColle.Master.Ship>();
			foreach (KanColle.Master.Ship ship in ships) {
				this.ShipList_Master.Add(ship.ID(), ship);
			}

			// Read in master mission list
			KanColle.Master.Mission[] missions = KanColleProxy.ParseArbitraryJSON<KanColle.Master.Mission[]>("missionlist.dat");
			this.MissionList_Master = new Dictionary<int, KanColle.Master.Mission>();
			foreach (KanColle.Master.Mission mission in missions) {
				this.MissionList_Master.Add(mission.ID(), mission);
			}

			// Put in mission list into ComboBoxes
			this.Fleet_2_Select.ItemsSource = this.MissionList_Master.Values;
			this.Fleet_3_Select.ItemsSource = this.MissionList_Master.Values;
			this.Fleet_4_Select.ItemsSource = this.MissionList_Master.Values;
		}

		// Stuff here taken from WPF tutorial
		// https://msdn.microsoft.com/en-us/library/ms751761%28v=vs.110%29.aspx
		private void RunExpKai_Loaded(object sender, RoutedEventArgs e) {
			// Create the interop host control.
			System.Windows.Forms.Integration.WindowsFormsHost host = new System.Windows.Forms.Integration.WindowsFormsHost();

			// Create Shockwave Flash control.
			AxShockwaveFlash flash = new AxShockwaveFlash();

			// Assign the shockwave flash control as the host control's child.
			host.Child = flash;

			// Add the interop host control to the Grid
			// control's collection of child controls.
			this.grid_winformshost.Children.Add(host);

			string swf_path = System.IO.Directory.GetCurrentDirectory() + "\\api_port.swf";
			flash.Location = new System.Drawing.Point(0, 0);
			flash.LoadMovie(0, swf_path);
			flash.AllowScriptAccess = "always";

			this.flashproxy = new ExternalInterfaceProxy(flash);

			//string msg = this.flashproxy.Call("api_mission", null).ToString();
		}

		private void WinFormsHost_ChildChanged(object sender, System.Windows.Forms.Integration.ChildChangedEventArgs e) {
			// Do nothing. This should not have any changes.
		}

		private void api_token_box_TextChanged(object sender, TextChangedEventArgs e) {
			this.apitoken_apply.IsEnabled = true;
		}

		private void apitoken_apply_Click(object sender, RoutedEventArgs e) {
			// Update MemberID, then update Port API and Start2
			this.kcproxy = new KanColleProxy(this.api_token_box.Text);
			this.MemberID = GetMemberID();
			this.port = this.kcproxy.GetPort(this.MemberID);

			this.DisplayNameBox.Content = this.port.api_basic.api_nickname;
			this.MemberIDBox.Content = this.MemberID;

			UpdateMemberShipList();
			UpdateFleetList();
			System.Windows.Forms.MessageBox.Show(string.Join(", ", this.fleet_2_shiplist));
			this.Fleet_2_Ships.Content = this.ListShipNames(this.fleet_2_shiplist);
			this.Fleet_3_Ships.Content = this.ListShipNames(this.fleet_3_shiplist);
			this.Fleet_4_Ships.Content = this.ListShipNames(this.fleet_4_shiplist);
			// Save api token to user config file here
		}

		private void Fleet_2_Select_SelectionChanged(object sender, SelectionChangedEventArgs e) {
			this.fleet_2_mission = this.Fleet_2_Select.SelectedItem as KanColle.Master.Mission;
		}

		private void Fleet_3_Select_SelectionChanged(object sender, SelectionChangedEventArgs e) {
			this.fleet_3_mission = this.Fleet_3_Select.SelectedItem as KanColle.Master.Mission;
		}

		private void Fleet_4_Select_SelectionChanged(object sender, SelectionChangedEventArgs e) {
			this.fleet_4_mission = this.Fleet_4_Select.SelectedItem as KanColle.Master.Mission;
		}

		private void Fleet_2_Start_Click(object sender, RoutedEventArgs e) {

		}

		private void Fleet_3_Start_Click(object sender, RoutedEventArgs e) {

		}

		private void Fleet_4_Start_Click(object sender, RoutedEventArgs e) {

		}

		private void Fleet_2_Stop_Click(object sender, RoutedEventArgs e) {

		}

		private void Fleet_3_Stop_Click(object sender, RoutedEventArgs e) {

		}

		private void Fleet_4_Stop_Click(object sender, RoutedEventArgs e) {

		}
	}
}
