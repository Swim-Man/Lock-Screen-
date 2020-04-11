/*
 * Created by SharpDevelop.
 * User: Administrator
 * Date: 2019/7/3
 * Time: 9:18
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
namespace LockScreen
{
	partial class MainForm
	{
		/// <summary>
		/// Designer variable used to keep track of non-visual components.
		/// </summary>
		private System.ComponentModel.IContainer components = null;
		private System.Windows.Forms.Label Userlabel;
		private System.Windows.Forms.TextBox UserBox;
		private System.Windows.Forms.Button button_login;
		private System.Windows.Forms.Timer timer_windowTop;
		private System.Windows.Forms.Button Login_Butoon;
		
		/// <summary>
		/// Disposes resources used by the form.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing) {
				if (components != null) {
					components.Dispose();
				}
			}
			base.Dispose(disposing);
		}
		
		/// <summary>
		/// This method is required for Windows Forms designer support.
		/// Do not change the method contents inside the source code editor. The Forms designer might
		/// not be able to load this method if it was changed manually.
		/// </summary>
		private void InitializeComponent()
		{
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.Userlabel = new System.Windows.Forms.Label();
            this.UserBox = new System.Windows.Forms.TextBox();
            this.button_login = new System.Windows.Forms.Button();
            this.timer_windowTop = new System.Windows.Forms.Timer(this.components);
            this.Login_Butoon = new System.Windows.Forms.Button();
            this.DepTextBox = new System.Windows.Forms.TextBox();
            this.ProjectTextBox = new System.Windows.Forms.TextBox();
            this.Projectlabel = new System.Windows.Forms.Label();
            this.DepLabel = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.UserNoLabel = new System.Windows.Forms.Label();
            this.UserNoBox = new System.Windows.Forms.TextBox();
            this.testbutton = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.status_label = new System.Windows.Forms.Label();
            this.Status = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // Userlabel
            // 
            this.Userlabel.Font = new System.Drawing.Font("Arial Narrow", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Userlabel.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.Userlabel.Location = new System.Drawing.Point(142, 396);
            this.Userlabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.Userlabel.Name = "Userlabel";
            this.Userlabel.Size = new System.Drawing.Size(113, 34);
            this.Userlabel.TabIndex = 0;
            this.Userlabel.Text = "User ";
            // 
            // UserBox
            // 
            this.UserBox.Font = new System.Drawing.Font("Arial Narrow", 18F);
            this.UserBox.Location = new System.Drawing.Point(280, 388);
            this.UserBox.Margin = new System.Windows.Forms.Padding(4);
            this.UserBox.Name = "UserBox";
            this.UserBox.Size = new System.Drawing.Size(346, 42);
            this.UserBox.TabIndex = 1;
            this.UserBox.Text = "123";
            // 
            // button_login
            // 
            this.button_login.Location = new System.Drawing.Point(727, 4);
            this.button_login.Margin = new System.Windows.Forms.Padding(4);
            this.button_login.Name = "button_login";
            this.button_login.Size = new System.Drawing.Size(100, 29);
            this.button_login.TabIndex = 2;
            this.button_login.Text = "解锁";
            this.button_login.UseVisualStyleBackColor = true;
            this.button_login.Click += new System.EventHandler(this.Button_loginClick);
            // 
            // timer_windowTop
            // 
            this.timer_windowTop.Enabled = true;
            this.timer_windowTop.Tick += new System.EventHandler(this.Timer_windowTopTick);
            // 
            // Login_Butoon
            // 
            this.Login_Butoon.BackColor = System.Drawing.SystemColors.Highlight;
            this.Login_Butoon.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.Login_Butoon.Cursor = System.Windows.Forms.Cursors.AppStarting;
            this.Login_Butoon.FlatAppearance.BorderColor = System.Drawing.Color.Snow;
            this.Login_Butoon.FlatAppearance.BorderSize = 2;
            this.Login_Butoon.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Login_Butoon.Font = new System.Drawing.Font("Arial", 22F, System.Drawing.FontStyle.Bold);
            this.Login_Butoon.ForeColor = System.Drawing.Color.Firebrick;
            this.Login_Butoon.Location = new System.Drawing.Point(245, 536);
            this.Login_Butoon.Margin = new System.Windows.Forms.Padding(4);
            this.Login_Butoon.Name = "Login_Butoon";
            this.Login_Butoon.Size = new System.Drawing.Size(387, 85);
            this.Login_Butoon.TabIndex = 3;
            this.Login_Butoon.Text = "Login and Logout";
            this.Login_Butoon.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.Login_Butoon.UseMnemonic = false;
            this.Login_Butoon.UseVisualStyleBackColor = false;
            this.Login_Butoon.Click += new System.EventHandler(this.Button_lockClick);
            // 
            // DepTextBox
            // 
            this.DepTextBox.Font = new System.Drawing.Font("Arial Narrow", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.DepTextBox.Location = new System.Drawing.Point(280, 258);
            this.DepTextBox.Margin = new System.Windows.Forms.Padding(4);
            this.DepTextBox.Name = "DepTextBox";
            this.DepTextBox.Size = new System.Drawing.Size(346, 42);
            this.DepTextBox.TabIndex = 2;
            this.DepTextBox.Text = "123";
            this.DepTextBox.TextChanged += new System.EventHandler(this.DepTextBox_TextChanged);
            // 
            // ProjectTextBox
            // 
            this.ProjectTextBox.Font = new System.Drawing.Font("Arial Narrow", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ProjectTextBox.Location = new System.Drawing.Point(280, 199);
            this.ProjectTextBox.Margin = new System.Windows.Forms.Padding(4);
            this.ProjectTextBox.Name = "ProjectTextBox";
            this.ProjectTextBox.Size = new System.Drawing.Size(346, 42);
            this.ProjectTextBox.TabIndex = 3;
            this.ProjectTextBox.Text = "123";
            this.ProjectTextBox.TextChanged += new System.EventHandler(this.ProjectTextBox_TextChanged);
            // 
            // Projectlabel
            // 
            this.Projectlabel.Font = new System.Drawing.Font("Arial Narrow", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Projectlabel.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.Projectlabel.Location = new System.Drawing.Point(142, 207);
            this.Projectlabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.Projectlabel.Name = "Projectlabel";
            this.Projectlabel.Size = new System.Drawing.Size(99, 34);
            this.Projectlabel.TabIndex = 5;
            this.Projectlabel.Text = "Project ";
            // 
            // DepLabel
            // 
            this.DepLabel.Font = new System.Drawing.Font("Arial Narrow", 18F);
            this.DepLabel.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.DepLabel.Location = new System.Drawing.Point(142, 268);
            this.DepLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.DepLabel.Name = "DepLabel";
            this.DepLabel.Size = new System.Drawing.Size(78, 32);
            this.DepLabel.TabIndex = 4;
            this.DepLabel.Text = "Dep.";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(245, -2);
            this.pictureBox1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(333, 126);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 8;
            this.pictureBox1.TabStop = false;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel1.Controls.Add(this.UserNoLabel);
            this.panel1.Controls.Add(this.UserNoBox);
            this.panel1.Controls.Add(this.testbutton);
            this.panel1.Controls.Add(this.label5);
            this.panel1.Controls.Add(this.status_label);
            this.panel1.Controls.Add(this.Status);
            this.panel1.Controls.Add(this.pictureBox1);
            this.panel1.Controls.Add(this.UserBox);
            this.panel1.Controls.Add(this.button_login);
            this.panel1.Controls.Add(this.DepTextBox);
            this.panel1.Controls.Add(this.Userlabel);
            this.panel1.Controls.Add(this.ProjectTextBox);
            this.panel1.Controls.Add(this.Login_Butoon);
            this.panel1.Controls.Add(this.Projectlabel);
            this.panel1.Controls.Add(this.DepLabel);
            this.panel1.Font = new System.Drawing.Font("Arial Narrow", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.panel1.ForeColor = System.Drawing.SystemColors.ButtonShadow;
            this.panel1.Location = new System.Drawing.Point(648, 270);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(835, 670);
            this.panel1.TabIndex = 9;
            this.panel1.Paint += new System.Windows.Forms.PaintEventHandler(this.panel1_Paint);
            // 
            // UserNoLabel
            // 
            this.UserNoLabel.Font = new System.Drawing.Font("Arial Narrow", 18F);
            this.UserNoLabel.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.UserNoLabel.Location = new System.Drawing.Point(142, 335);
            this.UserNoLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.UserNoLabel.Name = "UserNoLabel";
            this.UserNoLabel.Size = new System.Drawing.Size(130, 33);
            this.UserNoLabel.TabIndex = 14;
            this.UserNoLabel.Text = "User No.";
            this.UserNoLabel.Click += new System.EventHandler(this.label1_Click_1);
            // 
            // UserNoBox
            // 
            this.UserNoBox.Font = new System.Drawing.Font("Arial Narrow", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.UserNoBox.Location = new System.Drawing.Point(280, 326);
            this.UserNoBox.Margin = new System.Windows.Forms.Padding(4);
            this.UserNoBox.Name = "UserNoBox";
            this.UserNoBox.Size = new System.Drawing.Size(346, 42);
            this.UserNoBox.TabIndex = 13;
            this.UserNoBox.Text = "123";
            this.UserNoBox.TextChanged += new System.EventHandler(this.TempBox_TextChanged);
            // 
            // testbutton
            // 
            this.testbutton.Location = new System.Drawing.Point(3, 3);
            this.testbutton.Name = "testbutton";
            this.testbutton.Size = new System.Drawing.Size(115, 51);
            this.testbutton.TabIndex = 12;
            this.testbutton.Text = "button1";
            this.testbutton.UseVisualStyleBackColor = true;
            this.testbutton.Click += new System.EventHandler(this.testbutton_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Arial Narrow", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.label5.Location = new System.Drawing.Point(354, 137);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(123, 46);
            this.label5.TabIndex = 11;
            this.label5.Text = "LOGIN";
            // 
            // status_label
            // 
            this.status_label.Font = new System.Drawing.Font("Arial Narrow", 18F);
            this.status_label.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.status_label.Location = new System.Drawing.Point(147, 454);
            this.status_label.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.status_label.Name = "status_label";
            this.status_label.Size = new System.Drawing.Size(94, 47);
            this.status_label.TabIndex = 10;
            this.status_label.Text = "Status";
            // 
            // Status
            // 
            this.Status.BackColor = System.Drawing.SystemColors.ScrollBar;
            this.Status.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.Status.Font = new System.Drawing.Font("Book Antiqua", 20F, System.Drawing.FontStyle.Italic);
            this.Status.ForeColor = System.Drawing.Color.Red;
            this.Status.Location = new System.Drawing.Point(280, 453);
            this.Status.Margin = new System.Windows.Forms.Padding(4);
            this.Status.Name = "Status";
            this.Status.Size = new System.Drawing.Size(346, 41);
            this.Status.TabIndex = 9;
            this.Status.Text = "Please keyin Project";
            this.Status.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.ClientSize = new System.Drawing.Size(1556, 884);
            this.ControlBox = false;
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "MainForm";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "LockScreen";
            this.Load += new System.EventHandler(this.MainFormLoad);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

		}

        private System.Windows.Forms.TextBox DepTextBox;
        private System.Windows.Forms.Label DepLabel;
        private System.Windows.Forms.TextBox ProjectTextBox;
        private System.Windows.Forms.Label Projectlabel;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label status_label;
        private System.Windows.Forms.TextBox Status;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button testbutton;
        private System.Windows.Forms.TextBox UserNoBox;
        private System.Windows.Forms.Label UserNoLabel;
    }
}