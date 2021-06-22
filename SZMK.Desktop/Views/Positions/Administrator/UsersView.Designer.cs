
namespace SZMK.Desktop.Views.Positions.Administrator
{
    partial class UsersView
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(UsersView));
            this.Main_TLP = new System.Windows.Forms.TableLayoutPanel();
            this.Users_DGV = new System.Windows.Forms.DataGridView();
            this.DateCreate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SurName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.UserName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.MiddleName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Login = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Active = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.Main_TS = new System.Windows.Forms.ToolStrip();
            this.toolStripButton4 = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton3 = new System.Windows.Forms.ToolStripButton();
            this.toolStripTextBox1 = new System.Windows.Forms.ToolStripTextBox();
            this.toolStripButton1 = new System.Windows.Forms.ToolStripButton();
            this.Func_TS = new System.Windows.Forms.ToolStrip();
            this.Main_TSB = new System.Windows.Forms.ToolStripButton();
            this.MainAdd_TSB = new System.Windows.Forms.ToolStripButton();
            this.MainEdit_TSB = new System.Windows.Forms.ToolStripButton();
            this.MainDelete_TSB = new System.Windows.Forms.ToolStripButton();
            this.Hide_TSB = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton2 = new System.Windows.Forms.ToolStripButton();
            this.Main_TLP.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Users_DGV)).BeginInit();
            this.Main_TS.SuspendLayout();
            this.Func_TS.SuspendLayout();
            this.SuspendLayout();
            // 
            // Main_TLP
            // 
            this.Main_TLP.ColumnCount = 2;
            this.Main_TLP.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 150F));
            this.Main_TLP.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.Main_TLP.Controls.Add(this.Users_DGV, 1, 1);
            this.Main_TLP.Controls.Add(this.Main_TS, 1, 0);
            this.Main_TLP.Controls.Add(this.Func_TS, 0, 0);
            this.Main_TLP.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Main_TLP.Location = new System.Drawing.Point(0, 0);
            this.Main_TLP.Name = "Main_TLP";
            this.Main_TLP.RowCount = 2;
            this.Main_TLP.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.Main_TLP.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.Main_TLP.Size = new System.Drawing.Size(932, 489);
            this.Main_TLP.TabIndex = 0;
            // 
            // Users_DGV
            // 
            this.Users_DGV.AllowUserToAddRows = false;
            this.Users_DGV.AllowUserToDeleteRows = false;
            this.Users_DGV.AllowUserToResizeRows = false;
            this.Users_DGV.BackgroundColor = System.Drawing.Color.White;
            this.Users_DGV.BorderStyle = System.Windows.Forms.BorderStyle.None;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(59)))), ((int)(((byte)(65)))), ((int)(((byte)(85)))));
            dataGridViewCellStyle1.Padding = new System.Windows.Forms.Padding(2);
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(152)))), ((int)(((byte)(217)))));
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.Users_DGV.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.Users_DGV.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.Users_DGV.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.DateCreate,
            this.SurName,
            this.UserName,
            this.MiddleName,
            this.Login,
            this.Active});
            dataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle7.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle7.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            dataGridViewCellStyle7.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle7.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(152)))), ((int)(((byte)(217)))));
            dataGridViewCellStyle7.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle7.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.Users_DGV.DefaultCellStyle = dataGridViewCellStyle7;
            this.Users_DGV.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Users_DGV.Location = new System.Drawing.Point(153, 43);
            this.Users_DGV.MultiSelect = false;
            this.Users_DGV.Name = "Users_DGV";
            this.Users_DGV.ReadOnly = true;
            this.Users_DGV.RowHeadersVisible = false;
            this.Users_DGV.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.Users_DGV.Size = new System.Drawing.Size(776, 443);
            this.Users_DGV.TabIndex = 2;
            // 
            // DateCreate
            // 
            this.DateCreate.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.DateCreate.DataPropertyName = "DateCreate";
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(59)))), ((int)(((byte)(65)))), ((int)(((byte)(85)))));
            this.DateCreate.DefaultCellStyle = dataGridViewCellStyle2;
            this.DateCreate.FillWeight = 18F;
            this.DateCreate.HeaderText = "Дата создания";
            this.DateCreate.Name = "DateCreate";
            this.DateCreate.ReadOnly = true;
            // 
            // SurName
            // 
            this.SurName.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.SurName.DataPropertyName = "SurName";
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(59)))), ((int)(((byte)(65)))), ((int)(((byte)(85)))));
            this.SurName.DefaultCellStyle = dataGridViewCellStyle3;
            this.SurName.FillWeight = 20F;
            this.SurName.HeaderText = "Фамилия";
            this.SurName.Name = "SurName";
            this.SurName.ReadOnly = true;
            // 
            // UserName
            // 
            this.UserName.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.UserName.DataPropertyName = "Name";
            dataGridViewCellStyle4.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(59)))), ((int)(((byte)(65)))), ((int)(((byte)(85)))));
            this.UserName.DefaultCellStyle = dataGridViewCellStyle4;
            this.UserName.FillWeight = 20F;
            this.UserName.HeaderText = "Имя";
            this.UserName.Name = "UserName";
            this.UserName.ReadOnly = true;
            // 
            // MiddleName
            // 
            this.MiddleName.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.MiddleName.DataPropertyName = "MiddleName";
            dataGridViewCellStyle5.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle5.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            dataGridViewCellStyle5.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(59)))), ((int)(((byte)(65)))), ((int)(((byte)(85)))));
            this.MiddleName.DefaultCellStyle = dataGridViewCellStyle5;
            this.MiddleName.FillWeight = 20F;
            this.MiddleName.HeaderText = "Отчество";
            this.MiddleName.Name = "MiddleName";
            this.MiddleName.ReadOnly = true;
            // 
            // Login
            // 
            this.Login.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Login.DataPropertyName = "Login";
            dataGridViewCellStyle6.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle6.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            dataGridViewCellStyle6.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(59)))), ((int)(((byte)(65)))), ((int)(((byte)(85)))));
            this.Login.DefaultCellStyle = dataGridViewCellStyle6;
            this.Login.FillWeight = 20F;
            this.Login.HeaderText = "Логин";
            this.Login.Name = "Login";
            this.Login.ReadOnly = true;
            // 
            // Active
            // 
            this.Active.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Active.DataPropertyName = "Active";
            this.Active.FillWeight = 10F;
            this.Active.HeaderText = "Активен";
            this.Active.Name = "Active";
            this.Active.ReadOnly = true;
            // 
            // Main_TS
            // 
            this.Main_TS.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(152)))), ((int)(((byte)(217)))));
            this.Main_TS.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Main_TS.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.Main_TS.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.Main_TS.ImageScalingSize = new System.Drawing.Size(32, 32);
            this.Main_TS.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripButton4,
            this.toolStripButton3,
            this.toolStripTextBox1,
            this.toolStripButton1});
            this.Main_TS.Location = new System.Drawing.Point(150, 0);
            this.Main_TS.Name = "Main_TS";
            this.Main_TS.RenderMode = System.Windows.Forms.ToolStripRenderMode.Professional;
            this.Main_TS.Size = new System.Drawing.Size(782, 40);
            this.Main_TS.TabIndex = 3;
            this.Main_TS.Text = "Основное";
            // 
            // toolStripButton4
            // 
            this.toolStripButton4.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.toolStripButton4.Image = global::SZMK.Desktop.Properties.Resources.SearchFilter;
            this.toolStripButton4.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton4.Name = "toolStripButton4";
            this.toolStripButton4.Size = new System.Drawing.Size(181, 37);
            this.toolStripButton4.Text = "Расширенный поиск";
            // 
            // toolStripButton3
            // 
            this.toolStripButton3.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.toolStripButton3.Image = global::SZMK.Desktop.Properties.Resources.SearchClear;
            this.toolStripButton3.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton3.Name = "toolStripButton3";
            this.toolStripButton3.Size = new System.Drawing.Size(107, 37);
            this.toolStripButton3.Text = "Сбросить";
            // 
            // toolStripTextBox1
            // 
            this.toolStripTextBox1.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.toolStripTextBox1.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.toolStripTextBox1.Name = "toolStripTextBox1";
            this.toolStripTextBox1.Size = new System.Drawing.Size(150, 40);
            // 
            // toolStripButton1
            // 
            this.toolStripButton1.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.toolStripButton1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButton1.Image = global::SZMK.Desktop.Properties.Resources.Search;
            this.toolStripButton1.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton1.Name = "toolStripButton1";
            this.toolStripButton1.Size = new System.Drawing.Size(36, 37);
            this.toolStripButton1.Text = "toolStripButton1";
            // 
            // Func_TS
            // 
            this.Func_TS.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(23)))), ((int)(((byte)(43)))), ((int)(((byte)(76)))));
            this.Func_TS.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Func_TS.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.Func_TS.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.Func_TS.ImageScalingSize = new System.Drawing.Size(32, 32);
            this.Func_TS.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.Main_TSB,
            this.MainAdd_TSB,
            this.MainEdit_TSB,
            this.MainDelete_TSB,
            this.Hide_TSB});
            this.Func_TS.LayoutStyle = System.Windows.Forms.ToolStripLayoutStyle.VerticalStackWithOverflow;
            this.Func_TS.Location = new System.Drawing.Point(0, 0);
            this.Func_TS.Name = "Func_TS";
            this.Func_TS.RenderMode = System.Windows.Forms.ToolStripRenderMode.Professional;
            this.Main_TLP.SetRowSpan(this.Func_TS, 2);
            this.Func_TS.Size = new System.Drawing.Size(150, 489);
            this.Func_TS.TabIndex = 4;
            this.Func_TS.Text = "Функции";
            // 
            // Main_TSB
            // 
            this.Main_TSB.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(150)))), ((int)(((byte)(201)))));
            this.Main_TSB.Image = global::SZMK.Desktop.Properties.Resources.MainFunction;
            this.Main_TSB.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.Main_TSB.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.Main_TSB.Name = "Main_TSB";
            this.Main_TSB.Size = new System.Drawing.Size(148, 36);
            this.Main_TSB.Text = " Основное   ᐳ";
            this.Main_TSB.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.Main_TSB.ToolTipText = "Основное";
            this.Main_TSB.Click += new System.EventHandler(this.Main_TSB_Click);
            // 
            // MainAdd_TSB
            // 
            this.MainAdd_TSB.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.MainAdd_TSB.Image = global::SZMK.Desktop.Properties.Resources.AddUser1;
            this.MainAdd_TSB.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.MainAdd_TSB.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.MainAdd_TSB.Name = "MainAdd_TSB";
            this.MainAdd_TSB.Size = new System.Drawing.Size(148, 28);
            this.MainAdd_TSB.Text = "Добавить";
            this.MainAdd_TSB.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.MainAdd_TSB.Visible = false;
            this.MainAdd_TSB.Click += new System.EventHandler(this.MainAdd_TSB_Click);
            // 
            // MainEdit_TSB
            // 
            this.MainEdit_TSB.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.MainEdit_TSB.Image = global::SZMK.Desktop.Properties.Resources.EditUser1;
            this.MainEdit_TSB.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.MainEdit_TSB.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.MainEdit_TSB.Name = "MainEdit_TSB";
            this.MainEdit_TSB.Size = new System.Drawing.Size(148, 28);
            this.MainEdit_TSB.Text = "Изменить";
            this.MainEdit_TSB.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.MainEdit_TSB.Visible = false;
            this.MainEdit_TSB.Click += new System.EventHandler(this.MainEdit_TSB_Click);
            // 
            // MainDelete_TSB
            // 
            this.MainDelete_TSB.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.MainDelete_TSB.Image = global::SZMK.Desktop.Properties.Resources.DeleteUser1;
            this.MainDelete_TSB.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.MainDelete_TSB.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.MainDelete_TSB.Name = "MainDelete_TSB";
            this.MainDelete_TSB.Size = new System.Drawing.Size(148, 28);
            this.MainDelete_TSB.Text = "Удалить";
            this.MainDelete_TSB.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.MainDelete_TSB.Visible = false;
            this.MainDelete_TSB.Click += new System.EventHandler(this.MainDelete_TSB_Click);
            // 
            // Hide_TSB
            // 
            this.Hide_TSB.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.Hide_TSB.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.Hide_TSB.Image = ((System.Drawing.Image)(resources.GetObject("Hide_TSB.Image")));
            this.Hide_TSB.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.Hide_TSB.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.Hide_TSB.Name = "Hide_TSB";
            this.Hide_TSB.Size = new System.Drawing.Size(148, 36);
            this.Hide_TSB.Click += new System.EventHandler(this.Hide_TSB_Click);
            // 
            // toolStripButton2
            // 
            this.toolStripButton2.Name = "toolStripButton2";
            this.toolStripButton2.Size = new System.Drawing.Size(23, 37);
            // 
            // UsersView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(932, 489);
            this.Controls.Add(this.Main_TLP);
            this.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "UsersView";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Пользователи";
            this.Load += new System.EventHandler(this.UsersView_Load);
            this.Main_TLP.ResumeLayout(false);
            this.Main_TLP.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Users_DGV)).EndInit();
            this.Main_TS.ResumeLayout(false);
            this.Main_TS.PerformLayout();
            this.Func_TS.ResumeLayout(false);
            this.Func_TS.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel Main_TLP;
        private System.Windows.Forms.DataGridView Users_DGV;
        private System.Windows.Forms.ToolStrip Main_TS;
        private System.Windows.Forms.ToolStrip Func_TS;
        private System.Windows.Forms.ToolStripButton MainAdd_TSB;
        private System.Windows.Forms.ToolStripButton MainEdit_TSB;
        private System.Windows.Forms.ToolStripButton MainDelete_TSB;
        private System.Windows.Forms.ToolStripButton Hide_TSB;
        private System.Windows.Forms.ToolStripButton Main_TSB;
        private System.Windows.Forms.ToolStripButton toolStripButton2;
        private System.Windows.Forms.ToolStripButton toolStripButton1;
        private System.Windows.Forms.ToolStripTextBox toolStripTextBox1;
        private System.Windows.Forms.ToolStripButton toolStripButton3;
        private System.Windows.Forms.ToolStripButton toolStripButton4;
        private System.Windows.Forms.DataGridViewTextBoxColumn DateCreate;
        private System.Windows.Forms.DataGridViewTextBoxColumn SurName;
        private System.Windows.Forms.DataGridViewTextBoxColumn UserName;
        private System.Windows.Forms.DataGridViewTextBoxColumn MiddleName;
        private System.Windows.Forms.DataGridViewTextBoxColumn Login;
        private System.Windows.Forms.DataGridViewCheckBoxColumn Active;
    }
}