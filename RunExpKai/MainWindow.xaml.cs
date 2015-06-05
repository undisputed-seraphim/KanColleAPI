using System.Windows;
using System.Windows.Controls;
using System.Linq;

using AxShockwaveFlashObjects;
using KanColle;
using KanColle.Flash.External;

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

			// Put in mission list into ComboBoxes
			KanColle.Master.Mission[] missions = KanColleProxy.ParseArbitraryJSON<KanColle.Master.Mission[]>("missionlist.dat");
			this.Fleet_2_Select.ItemsSource = missions;
			this.Fleet_3_Select.ItemsSource = missions;
			this.Fleet_4_Select.ItemsSource = missions;
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
			this.start2 = this.kcproxy.GetStart2();

			this.DisplayNameBox.Content = this.port.api_basic.api_nickname;
			this.MemberIDBox.Content = this.MemberID;

			// Save api token to user config file here
		}

		private void Fleet_2_Select_SelectionChanged(object sender, SelectionChangedEventArgs e) {

		}

		private void Fleet_3_Select_SelectionChanged(object sender, SelectionChangedEventArgs e) {

		}

		private void Fleet_4_Select_SelectionChanged(object sender, SelectionChangedEventArgs e) {

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
