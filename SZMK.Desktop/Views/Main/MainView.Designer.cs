namespace SZMK.Desktop.Views.Main
{
    partial class MainView
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainView));
            this.Main_TS = new System.Windows.Forms.ToolStrip();
            this.Profile_TSB = new System.Windows.Forms.ToolStripDropDownButton();
            this.Settings_TSB = new System.Windows.Forms.ToolStripMenuItem();
            this.Update_TSB = new System.Windows.Forms.ToolStripMenuItem();
            this.About_TSB = new System.Windows.Forms.ToolStripMenuItem();
            this.Logout_TSB = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripButton1 = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton3 = new System.Windows.Forms.ToolStripButton();
            this.toolStripTextBox1 = new System.Windows.Forms.ToolStripTextBox();
            this.toolStripButton2 = new System.Windows.Forms.ToolStripButton();
            this.Main_TLP = new System.Windows.Forms.TableLayoutPanel();
            this.Func_TS = new System.Windows.Forms.ToolStrip();
            this.Administrator_TSB = new System.Windows.Forms.ToolStripButton();
            this.AdministratorUsers_TSB = new System.Windows.Forms.ToolStripButton();
            this.Hide_TSB = new System.Windows.Forms.ToolStripButton();
            this.Main_TS.SuspendLayout();
            this.Main_TLP.SuspendLayout();
            this.Func_TS.SuspendLayout();
            this.SuspendLayout();
            // 
            // Main_TS
            // 
            this.Main_TS.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(152)))), ((int)(((byte)(217)))));
            this.Main_TS.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.Main_TS.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Main_TS.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.Main_TS.GripMargin = new System.Windows.Forms.Padding(0);
            this.Main_TS.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.Main_TS.ImageScalingSize = new System.Drawing.Size(32, 32);
            this.Main_TS.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.Profile_TSB,
            this.toolStripButton1,
            this.toolStripButton3,
            this.toolStripTextBox1,
            this.toolStripButton2});
            this.Main_TS.Location = new System.Drawing.Point(200, 0);
            this.Main_TS.Name = "Main_TS";
            this.Main_TS.Padding = new System.Windows.Forms.Padding(0);
            this.Main_TS.RenderMode = System.Windows.Forms.ToolStripRenderMode.Professional;
            this.Main_TS.Size = new System.Drawing.Size(984, 40);
            this.Main_TS.TabIndex = 0;
            this.Main_TS.Text = "Основное";
            // 
            // Profile_TSB
            // 
            this.Profile_TSB.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.Profile_TSB.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(152)))), ((int)(((byte)(217)))));
            this.Profile_TSB.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.Settings_TSB,
            this.Update_TSB,
            this.About_TSB,
            this.Logout_TSB});
            this.Profile_TSB.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.Profile_TSB.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.Profile_TSB.Image = ((System.Drawing.Image)(resources.GetObject("Profile_TSB.Image")));
            this.Profile_TSB.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.Profile_TSB.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.Profile_TSB.Name = "Profile_TSB";
            this.Profile_TSB.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.Profile_TSB.Size = new System.Drawing.Size(146, 37);
            this.Profile_TSB.Text = "Пользователь";
            this.Profile_TSB.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.Profile_TSB.DropDownClosed += new System.EventHandler(this.Profile_TSB_DropDownClosed);
            this.Profile_TSB.DropDownOpened += new System.EventHandler(this.Profile_TSB_DropDownOpened);
            // 
            // Settings_TSB
            // 
            this.Settings_TSB.BackColor = System.Drawing.Color.White;
            this.Settings_TSB.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.Settings_TSB.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.Settings_TSB.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(79)))), ((int)(((byte)(77)))), ((int)(((byte)(89)))));
            this.Settings_TSB.Name = "Settings_TSB";
            this.Settings_TSB.Size = new System.Drawing.Size(163, 22);
            this.Settings_TSB.Text = "Настройки";
            this.Settings_TSB.Click += new System.EventHandler(this.Settings_TSB_Click);
            // 
            // Update_TSB
            // 
            this.Update_TSB.BackColor = System.Drawing.Color.White;
            this.Update_TSB.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.Update_TSB.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.Update_TSB.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(79)))), ((int)(((byte)(77)))), ((int)(((byte)(89)))));
            this.Update_TSB.Name = "Update_TSB";
            this.Update_TSB.Size = new System.Drawing.Size(163, 22);
            this.Update_TSB.Text = "Обновить";
            this.Update_TSB.Click += new System.EventHandler(this.Update_TSB_Click);
            // 
            // About_TSB
            // 
            this.About_TSB.BackColor = System.Drawing.Color.White;
            this.About_TSB.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.About_TSB.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.About_TSB.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(79)))), ((int)(((byte)(77)))), ((int)(((byte)(89)))));
            this.About_TSB.Name = "About_TSB";
            this.About_TSB.Size = new System.Drawing.Size(163, 22);
            this.About_TSB.Text = "О программе";
            this.About_TSB.Click += new System.EventHandler(this.About_TSB_Click);
            // 
            // Logout_TSB
            // 
            this.Logout_TSB.BackColor = System.Drawing.Color.White;
            this.Logout_TSB.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.Logout_TSB.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.Logout_TSB.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(79)))), ((int)(((byte)(77)))), ((int)(((byte)(89)))));
            this.Logout_TSB.Name = "Logout_TSB";
            this.Logout_TSB.Size = new System.Drawing.Size(163, 22);
            this.Logout_TSB.Text = "Выход";
            this.Logout_TSB.Click += new System.EventHandler(this.Logout_TSMI_Click);
            // 
            // toolStripButton1
            // 
            this.toolStripButton1.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.toolStripButton1.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.toolStripButton1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.toolStripButton1.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton1.Image")));
            this.toolStripButton1.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton1.Name = "toolStripButton1";
            this.toolStripButton1.Size = new System.Drawing.Size(181, 37);
            this.toolStripButton1.Text = "Расширенный поиск";
            // 
            // toolStripButton3
            // 
            this.toolStripButton3.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.toolStripButton3.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.toolStripButton3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.toolStripButton3.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton3.Image")));
            this.toolStripButton3.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton3.Name = "toolStripButton3";
            this.toolStripButton3.Size = new System.Drawing.Size(107, 37);
            this.toolStripButton3.Text = "Сбросить";
            // 
            // toolStripTextBox1
            // 
            this.toolStripTextBox1.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.toolStripTextBox1.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.toolStripTextBox1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(79)))), ((int)(((byte)(77)))), ((int)(((byte)(89)))));
            this.toolStripTextBox1.Name = "toolStripTextBox1";
            this.toolStripTextBox1.Size = new System.Drawing.Size(175, 40);
            // 
            // toolStripButton2
            // 
            this.toolStripButton2.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.toolStripButton2.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButton2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.toolStripButton2.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton2.Image")));
            this.toolStripButton2.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton2.Name = "toolStripButton2";
            this.toolStripButton2.Size = new System.Drawing.Size(36, 37);
            this.toolStripButton2.ToolTipText = "Поиск";
            // 
            // Main_TLP
            // 
            this.Main_TLP.ColumnCount = 2;
            this.Main_TLP.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 200F));
            this.Main_TLP.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.Main_TLP.Controls.Add(this.Func_TS, 0, 0);
            this.Main_TLP.Controls.Add(this.Main_TS, 1, 0);
            this.Main_TLP.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Main_TLP.Location = new System.Drawing.Point(0, 0);
            this.Main_TLP.Margin = new System.Windows.Forms.Padding(0);
            this.Main_TLP.Name = "Main_TLP";
            this.Main_TLP.RowCount = 2;
            this.Main_TLP.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.Main_TLP.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.Main_TLP.Size = new System.Drawing.Size(1184, 611);
            this.Main_TLP.TabIndex = 27;
            // 
            // Func_TS
            // 
            this.Func_TS.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(23)))), ((int)(((byte)(43)))), ((int)(((byte)(76)))));
            this.Func_TS.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.Func_TS.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Func_TS.GripMargin = new System.Windows.Forms.Padding(0);
            this.Func_TS.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.Func_TS.ImageScalingSize = new System.Drawing.Size(32, 32);
            this.Func_TS.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.Administrator_TSB,
            this.AdministratorUsers_TSB,
            this.Hide_TSB});
            this.Func_TS.LayoutStyle = System.Windows.Forms.ToolStripLayoutStyle.VerticalStackWithOverflow;
            this.Func_TS.Location = new System.Drawing.Point(0, 0);
            this.Func_TS.Name = "Func_TS";
            this.Func_TS.Padding = new System.Windows.Forms.Padding(0);
            this.Func_TS.RenderMode = System.Windows.Forms.ToolStripRenderMode.Professional;
            this.Main_TLP.SetRowSpan(this.Func_TS, 2);
            this.Func_TS.Size = new System.Drawing.Size(200, 611);
            this.Func_TS.TabIndex = 3;
            this.Func_TS.Text = "Функции";
            // 
            // Administrator_TSB
            // 
            this.Administrator_TSB.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.Administrator_TSB.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(150)))), ((int)(((byte)(201)))));
            this.Administrator_TSB.Image = ((System.Drawing.Image)(resources.GetObject("Administrator_TSB.Image")));
            this.Administrator_TSB.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.Administrator_TSB.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.Administrator_TSB.Name = "Administrator_TSB";
            this.Administrator_TSB.Size = new System.Drawing.Size(199, 36);
            this.Administrator_TSB.Text = "  Администратор      ᐳ";
            this.Administrator_TSB.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.Administrator_TSB.ToolTipText = "Администратор";
            this.Administrator_TSB.Click += new System.EventHandler(this.Administrator_TSB_Click);
            // 
            // AdministratorUsers_TSB
            // 
            this.AdministratorUsers_TSB.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.AdministratorUsers_TSB.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.AdministratorUsers_TSB.Image = ((System.Drawing.Image)(resources.GetObject("AdministratorUsers_TSB.Image")));
            this.AdministratorUsers_TSB.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.AdministratorUsers_TSB.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.AdministratorUsers_TSB.Name = "AdministratorUsers_TSB";
            this.AdministratorUsers_TSB.Size = new System.Drawing.Size(199, 28);
            this.AdministratorUsers_TSB.Text = "  Пользователи";
            this.AdministratorUsers_TSB.ToolTipText = "Пользователи";
            this.AdministratorUsers_TSB.Visible = false;
            this.AdministratorUsers_TSB.Click += new System.EventHandler(this.AdministratorUsers_TSB_Click);
            // 
            // Hide_TSB
            // 
            this.Hide_TSB.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.Hide_TSB.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.Hide_TSB.Image = ((System.Drawing.Image)(resources.GetObject("Hide_TSB.Image")));
            this.Hide_TSB.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.Hide_TSB.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.Hide_TSB.Name = "Hide_TSB";
            this.Hide_TSB.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.Hide_TSB.Size = new System.Drawing.Size(199, 36);
            this.Hide_TSB.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.Hide_TSB.Click += new System.EventHandler(this.Hide_TSB_Click);
            // 
            // MainView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1184, 611);
            this.Controls.Add(this.Main_TLP);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MinimumSize = new System.Drawing.Size(1200, 650);
            this.Name = "MainView";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "СЗМК: ЭДО";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainView_FormClosing);
            this.Load += new System.EventHandler(this.MainView_Load);
            this.Main_TS.ResumeLayout(false);
            this.Main_TS.PerformLayout();
            this.Main_TLP.ResumeLayout(false);
            this.Main_TLP.PerformLayout();
            this.Func_TS.ResumeLayout(false);
            this.Func_TS.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ToolStrip Main_TS;
        private System.Windows.Forms.ToolStripDropDownButton Profile_TSB;
        private System.Windows.Forms.ToolStripMenuItem Settings_TSB;
        private System.Windows.Forms.ToolStripMenuItem Update_TSB;
        private System.Windows.Forms.ToolStripMenuItem About_TSB;
        private System.Windows.Forms.ToolStripMenuItem Logout_TSB;
        private System.Windows.Forms.TableLayoutPanel Main_TLP;
        private System.Windows.Forms.ToolStrip Func_TS;
        private System.Windows.Forms.ToolStripButton Administrator_TSB;
        private System.Windows.Forms.ToolStripButton AdministratorUsers_TSB;
        private System.Windows.Forms.ToolStripButton Hide_TSB;
        private System.Windows.Forms.ToolStripButton toolStripButton1;
        private System.Windows.Forms.ToolStripTextBox toolStripTextBox1;
        private System.Windows.Forms.ToolStripButton toolStripButton2;
        private System.Windows.Forms.ToolStripButton toolStripButton3;
    }
}