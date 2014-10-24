using AxShockwaveFlashObjects;
using System.Windows.Forms;

namespace KanColleConsole {
	partial class KanColleConsole {
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose (bool disposing) {
			if (disposing && (components != null)) {
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		#region Windows Form Designer generated code

		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent () {
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(KanColleConsole));
			this.ApiPort = new System.Windows.Forms.Button();
			this.ApiMission = new System.Windows.Forms.Button();
			this.ApiQuest = new System.Windows.Forms.Button();
			this.UserID = new System.Windows.Forms.TextBox();
			this.flash = new AxShockwaveFlashObjects.AxShockwaveFlash();
			((System.ComponentModel.ISupportInitialize)(this.flash)).BeginInit();
			this.SuspendLayout();
			// 
			// ApiPort
			// 
			this.ApiPort.Location = new System.Drawing.Point(125, 15);
			this.ApiPort.Name = "ApiPort";
			this.ApiPort.Size = new System.Drawing.Size(75, 25);
			this.ApiPort.TabIndex = 1;
			this.ApiPort.Text = "api_port";
			this.ApiPort.Click += new System.EventHandler(this.ApiPort_OnClick);
			// 
			// ApiMission
			// 
			this.ApiMission.Location = new System.Drawing.Point(225, 15);
			this.ApiMission.Name = "ApiMission";
			this.ApiMission.Size = new System.Drawing.Size(75, 25);
			this.ApiMission.TabIndex = 2;
			this.ApiMission.Text = "api_mission";
			this.ApiMission.Click += new System.EventHandler(this.ApiMission_OnClick);
			// 
			// ApiQuest
			// 
			this.ApiQuest.Location = new System.Drawing.Point(325, 15);
			this.ApiQuest.Name = "ApiQuest";
			this.ApiQuest.Size = new System.Drawing.Size(75, 25);
			this.ApiQuest.TabIndex = 3;
			this.ApiQuest.Text = "api_quest";
			this.ApiQuest.Click += new System.EventHandler(this.ApiQuest_OnClick);
			// 
			// UserID
			// 
			this.UserID.Location = new System.Drawing.Point(15, 15);
			this.UserID.MaximumSize = new System.Drawing.Size(75, 25);
			this.UserID.MaxLength = 10;
			this.UserID.MinimumSize = new System.Drawing.Size(75, 25);
			this.UserID.Name = "UserID";
			this.UserID.Size = new System.Drawing.Size(75, 20);
			this.UserID.TabIndex = 4;
			this.UserID.Text = "123456";
			// 
			// flash
			// 
			this.flash.Enabled = true;
			this.flash.Location = new System.Drawing.Point(15, 50);
			this.flash.Name = "flash";
			this.flash.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("flash.OcxState")));
			this.flash.Size = new System.Drawing.Size(400, 200);
			this.flash.TabIndex = 5;
			this.flash.Enter += new System.EventHandler(this.flash_Enter);
			// 
			// KanColleConsole
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(434, 272);
			this.Controls.Add(this.ApiPort);
			this.Controls.Add(this.ApiMission);
			this.Controls.Add(this.ApiQuest);
			this.Controls.Add(this.UserID);
			this.Controls.Add(this.flash);
			this.Name = "KanColleConsole";
			this.Text = "KanColleConsole";
			this.Load += new System.EventHandler(this.KanColleConsole_Load);
			((System.ComponentModel.ISupportInitialize)(this.flash)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private Button ApiPort, ApiMission, ApiQuest;
		private TextBox UserID;
		private AxShockwaveFlash flash;
	}
}