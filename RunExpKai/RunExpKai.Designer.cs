namespace RunExpKai {
	partial class RunExpKai {
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(RunExpKai));
			this.Fleet_2_Start = new System.Windows.Forms.Button();
			this.Fleet_2_Pause = new System.Windows.Forms.Button();
			this.Fleet_3_Start = new System.Windows.Forms.Button();
			this.Fleet_3_Pause = new System.Windows.Forms.Button();
			this.Fleet_4_Start = new System.Windows.Forms.Button();
			this.Fleet_4_Pause = new System.Windows.Forms.Button();
			this.Fleet_2_DropDown = new System.Windows.Forms.ComboBox();
			this.Fleet_3_DropDown = new System.Windows.Forms.ComboBox();
			this.Fleet_4_DropDown = new System.Windows.Forms.ComboBox();
			this.flash = new AxShockwaveFlashObjects.AxShockwaveFlash();
			this.Update = new System.Windows.Forms.Button();
			this.StartAll = new System.Windows.Forms.Button();
			this.StopAll = new System.Windows.Forms.Button();
			((System.ComponentModel.ISupportInitialize)(this.flash)).BeginInit();
			this.SuspendLayout();
			// 
			// Fleet_2_Start
			// 
			this.Fleet_2_Start.Location = new System.Drawing.Point(160, 20);
			this.Fleet_2_Start.Name = "Fleet_2_Start";
			this.Fleet_2_Start.Size = new System.Drawing.Size(75, 23);
			this.Fleet_2_Start.TabIndex = 0;
			this.Fleet_2_Start.Text = "Start";
			this.Fleet_2_Start.UseVisualStyleBackColor = true;
			this.Fleet_2_Start.Click += new System.EventHandler(this.Fleet_2_Start_Click);
			// 
			// Fleet_2_Pause
			// 
			this.Fleet_2_Pause.Location = new System.Drawing.Point(250, 20);
			this.Fleet_2_Pause.Name = "Fleet_2_Pause";
			this.Fleet_2_Pause.Size = new System.Drawing.Size(75, 23);
			this.Fleet_2_Pause.TabIndex = 1;
			this.Fleet_2_Pause.Text = "Pause";
			this.Fleet_2_Pause.UseVisualStyleBackColor = true;
			this.Fleet_2_Pause.Click += new System.EventHandler(this.Fleet_2_Pause_Click);
			// 
			// Fleet_3_Start
			// 
			this.Fleet_3_Start.Location = new System.Drawing.Point(160, 58);
			this.Fleet_3_Start.Name = "Fleet_3_Start";
			this.Fleet_3_Start.Size = new System.Drawing.Size(75, 23);
			this.Fleet_3_Start.TabIndex = 2;
			this.Fleet_3_Start.Text = "Start";
			this.Fleet_3_Start.UseVisualStyleBackColor = true;
			this.Fleet_3_Start.Click += new System.EventHandler(this.Fleet_3_Start_Click);
			// 
			// Fleet_3_Pause
			// 
			this.Fleet_3_Pause.Location = new System.Drawing.Point(250, 58);
			this.Fleet_3_Pause.Name = "Fleet_3_Pause";
			this.Fleet_3_Pause.Size = new System.Drawing.Size(75, 23);
			this.Fleet_3_Pause.TabIndex = 3;
			this.Fleet_3_Pause.Text = "Pause";
			this.Fleet_3_Pause.UseVisualStyleBackColor = true;
			this.Fleet_3_Pause.Click += new System.EventHandler(this.Fleet_3_Pause_Click);
			// 
			// Fleet_4_Start
			// 
			this.Fleet_4_Start.Location = new System.Drawing.Point(160, 98);
			this.Fleet_4_Start.Name = "Fleet_4_Start";
			this.Fleet_4_Start.Size = new System.Drawing.Size(75, 23);
			this.Fleet_4_Start.TabIndex = 4;
			this.Fleet_4_Start.Text = "Start";
			this.Fleet_4_Start.UseVisualStyleBackColor = true;
			this.Fleet_4_Start.Click += new System.EventHandler(this.Fleet_4_Start_Click);
			// 
			// Fleet_4_Pause
			// 
			this.Fleet_4_Pause.Location = new System.Drawing.Point(250, 98);
			this.Fleet_4_Pause.Name = "Fleet_4_Pause";
			this.Fleet_4_Pause.Size = new System.Drawing.Size(75, 23);
			this.Fleet_4_Pause.TabIndex = 5;
			this.Fleet_4_Pause.Text = "Pause";
			this.Fleet_4_Pause.UseVisualStyleBackColor = true;
			this.Fleet_4_Pause.Click += new System.EventHandler(this.Fleet_4_Pause_Click);
			// 
			// Fleet_2_DropDown
			// 
			this.Fleet_2_DropDown.FormattingEnabled = true;
			this.Fleet_2_DropDown.Location = new System.Drawing.Point(20, 20);
			this.Fleet_2_DropDown.Name = "Fleet_2_DropDown";
			this.Fleet_2_DropDown.Size = new System.Drawing.Size(120, 21);
			this.Fleet_2_DropDown.TabIndex = 6;
			this.Fleet_2_DropDown.SelectedIndexChanged += new System.EventHandler(this.Fleet_2_DropDown_SelectedIndexChanged);
			// 
			// Fleet_3_DropDown
			// 
			this.Fleet_3_DropDown.FormattingEnabled = true;
			this.Fleet_3_DropDown.Location = new System.Drawing.Point(20, 60);
			this.Fleet_3_DropDown.Name = "Fleet_3_DropDown";
			this.Fleet_3_DropDown.Size = new System.Drawing.Size(120, 21);
			this.Fleet_3_DropDown.TabIndex = 7;
			this.Fleet_3_DropDown.SelectedIndexChanged += new System.EventHandler(this.Fleet_3_DropDown_SelectedIndexChanged);
			// 
			// Fleet_4_DropDown
			// 
			this.Fleet_4_DropDown.FormattingEnabled = true;
			this.Fleet_4_DropDown.Location = new System.Drawing.Point(20, 100);
			this.Fleet_4_DropDown.Name = "Fleet_4_DropDown";
			this.Fleet_4_DropDown.Size = new System.Drawing.Size(120, 21);
			this.Fleet_4_DropDown.TabIndex = 8;
			this.Fleet_4_DropDown.SelectedIndexChanged += new System.EventHandler(this.Fleet_4_DropDown_SelectedIndexChanged);
			// 
			// flash
			// 
			this.flash.Enabled = true;
			this.flash.Location = new System.Drawing.Point(20, 200);
			this.flash.Name = "flash";
			this.flash.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("flash.OcxState")));
			this.flash.Size = new System.Drawing.Size(305, 21);
			this.flash.TabIndex = 9;
			// 
			// Update
			// 
			this.Update.Enabled = false;
			this.Update.Location = new System.Drawing.Point(20, 140);
			this.Update.Name = "Update";
			this.Update.Size = new System.Drawing.Size(120, 23);
			this.Update.TabIndex = 10;
			this.Update.Text = "Update Fleet Data";
			this.Update.UseVisualStyleBackColor = false;
			this.Update.Click += new System.EventHandler(this.Update_Click);
			// 
			// StartAll
			// 
			this.StartAll.Location = new System.Drawing.Point(160, 140);
			this.StartAll.Name = "StartAll";
			this.StartAll.Size = new System.Drawing.Size(75, 23);
			this.StartAll.TabIndex = 11;
			this.StartAll.Text = "Start All";
			this.StartAll.UseVisualStyleBackColor = true;
			this.StartAll.Click += new System.EventHandler(this.StartAll_Click);
			// 
			// StopAll
			// 
			this.StopAll.Location = new System.Drawing.Point(250, 140);
			this.StopAll.Name = "StopAll";
			this.StopAll.Size = new System.Drawing.Size(75, 23);
			this.StopAll.TabIndex = 12;
			this.StopAll.Text = "Stop All";
			this.StopAll.UseVisualStyleBackColor = true;
			this.StopAll.Click += new System.EventHandler(this.StopAll_Click);
			// 
			// RunExpKai
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
			this.ClientSize = new System.Drawing.Size(349, 412);
			this.Controls.Add(this.StopAll);
			this.Controls.Add(this.StartAll);
			this.Controls.Add(this.Update);
			this.Controls.Add(this.flash);
			this.Controls.Add(this.Fleet_4_DropDown);
			this.Controls.Add(this.Fleet_3_DropDown);
			this.Controls.Add(this.Fleet_2_DropDown);
			this.Controls.Add(this.Fleet_4_Pause);
			this.Controls.Add(this.Fleet_4_Start);
			this.Controls.Add(this.Fleet_3_Pause);
			this.Controls.Add(this.Fleet_3_Start);
			this.Controls.Add(this.Fleet_2_Pause);
			this.Controls.Add(this.Fleet_2_Start);
			this.Name = "RunExpKai";
			this.Text = "RunExpKai";
			this.Load += new System.EventHandler(this.RunExpKai_Load);
			((System.ComponentModel.ISupportInitialize)(this.flash)).EndInit();
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.Button Fleet_2_Start;
		private System.Windows.Forms.Button Fleet_2_Pause;
		private System.Windows.Forms.Button Fleet_3_Start;
		private System.Windows.Forms.Button Fleet_3_Pause;
		private System.Windows.Forms.Button Fleet_4_Start;
		private System.Windows.Forms.Button Fleet_4_Pause;
		private System.Windows.Forms.ComboBox Fleet_2_DropDown;
		private System.Windows.Forms.ComboBox Fleet_3_DropDown;
		private System.Windows.Forms.ComboBox Fleet_4_DropDown;
		private AxShockwaveFlashObjects.AxShockwaveFlash flash;
		private System.Windows.Forms.Button Update;
		private System.Windows.Forms.Button StartAll;
		private System.Windows.Forms.Button StopAll;
	}
}

