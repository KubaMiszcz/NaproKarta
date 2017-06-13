namespace NaproKarta
{
    partial class MainForm
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
			this.components = new System.ComponentModel.Container();
			this.MainMenuStrip = new System.Windows.Forms.MenuStrip();
			this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.NewCardtoolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
			this.openToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.saveToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.saveAsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
			this.toolStripRecentCards = new System.Windows.Forms.ToolStripMenuItem();
			this.toolStripRecent1 = new System.Windows.Forms.ToolStripMenuItem();
			this.toolStripRecent2 = new System.Windows.Forms.ToolStripMenuItem();
			this.toolStripRecent3 = new System.Windows.Forms.ToolStripMenuItem();
			this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
			this.printToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
			this.closeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.helpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.settingsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.toolStripAbout = new System.Windows.Forms.ToolStripMenuItem();
			this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
			this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
			this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
			this.helpProvider1 = new System.Windows.Forms.HelpProvider();
			this.tabControl1 = new System.Windows.Forms.TabControl();
			this.tabPage3 = new System.Windows.Forms.TabPage();
			this.panelChart = new System.Windows.Forms.Panel();
			this.tabPage2 = new System.Windows.Forms.TabPage();
			this.groupBox1 = new System.Windows.Forms.GroupBox();
			this.checkBox1 = new System.Windows.Forms.CheckBox();
			this.tabPage1 = new System.Windows.Forms.TabPage();
			this.numericUpDown2 = new System.Windows.Forms.NumericUpDown();
			this.numericUpDown1 = new System.Windows.Forms.NumericUpDown();
			this.label2 = new System.Windows.Forms.Label();
			this.label1 = new System.Windows.Forms.Label();
			this.domainUpDown1 = new System.Windows.Forms.DomainUpDown();
			this.observationCtrl8 = new NaproKarta.ObservationCtrl();
			this.observationCtrl7 = new NaproKarta.ObservationCtrl();
			this.observationCtrl4 = new NaproKarta.ObservationCtrl();
			this.observationCtrl5 = new NaproKarta.ObservationCtrl();
			this.observationCtrl6 = new NaproKarta.ObservationCtrl();
			this.observationCtrl3 = new NaproKarta.ObservationCtrl();
			this.observationCtrl2 = new NaproKarta.ObservationCtrl();
			this.observationCtrl1 = new NaproKarta.ObservationCtrl();
			this.MainMenuStrip.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
			this.tabControl1.SuspendLayout();
			this.tabPage3.SuspendLayout();
			this.tabPage2.SuspendLayout();
			this.groupBox1.SuspendLayout();
			this.tabPage1.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.numericUpDown2)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).BeginInit();
			this.SuspendLayout();
			// 
			// MainMenuStrip
			// 
			this.MainMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.helpToolStripMenuItem,
            this.settingsToolStripMenuItem,
            this.toolStripAbout});
			this.MainMenuStrip.Location = new System.Drawing.Point(0, 0);
			this.MainMenuStrip.Name = "MainMenuStrip";
			this.MainMenuStrip.Size = new System.Drawing.Size(871, 24);
			this.MainMenuStrip.TabIndex = 0;
			this.MainMenuStrip.Text = "menuStrip1";
			// 
			// fileToolStripMenuItem
			// 
			this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.NewCardtoolStripMenuItem1,
            this.openToolStripMenuItem,
            this.saveToolStripMenuItem,
            this.saveAsToolStripMenuItem,
            this.toolStripSeparator1,
            this.toolStripRecentCards,
            this.toolStripSeparator3,
            this.printToolStripMenuItem,
            this.toolStripSeparator2,
            this.closeToolStripMenuItem});
			this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
			this.fileToolStripMenuItem.Size = new System.Drawing.Size(38, 20);
			this.fileToolStripMenuItem.Text = "Plik";
			// 
			// NewCardtoolStripMenuItem1
			// 
			this.NewCardtoolStripMenuItem1.Image = global::NaproKarta.Properties.Resources.NewCard;
			this.NewCardtoolStripMenuItem1.Name = "NewCardtoolStripMenuItem1";
			this.NewCardtoolStripMenuItem1.Size = new System.Drawing.Size(208, 22);
			this.NewCardtoolStripMenuItem1.Text = "Nowa Karta";
			this.NewCardtoolStripMenuItem1.Click += new System.EventHandler(this.NewCardtoolStripMenuItem1_Click);
			// 
			// openToolStripMenuItem
			// 
			this.openToolStripMenuItem.Name = "openToolStripMenuItem";
			this.openToolStripMenuItem.Size = new System.Drawing.Size(208, 22);
			this.openToolStripMenuItem.Text = "Otwórz Kartę...";
			this.openToolStripMenuItem.Click += new System.EventHandler(this.otworzToolStripMenuItem_Click);
			// 
			// saveToolStripMenuItem
			// 
			this.saveToolStripMenuItem.Name = "saveToolStripMenuItem";
			this.saveToolStripMenuItem.Size = new System.Drawing.Size(208, 22);
			this.saveToolStripMenuItem.Text = "Zapisz Kartę";
			this.saveToolStripMenuItem.Click += new System.EventHandler(this.zapiszToolStripMenuItem_Click);
			// 
			// saveAsToolStripMenuItem
			// 
			this.saveAsToolStripMenuItem.Name = "saveAsToolStripMenuItem";
			this.saveAsToolStripMenuItem.Size = new System.Drawing.Size(208, 22);
			this.saveAsToolStripMenuItem.Text = "Zapisz jako nową Kartę...";
			this.saveAsToolStripMenuItem.Click += new System.EventHandler(this.zapiszJakoToolStripMenuItem_Click);
			// 
			// toolStripSeparator1
			// 
			this.toolStripSeparator1.Name = "toolStripSeparator1";
			this.toolStripSeparator1.Size = new System.Drawing.Size(205, 6);
			// 
			// toolStripRecentCards
			// 
			this.toolStripRecentCards.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripRecent1,
            this.toolStripRecent2,
            this.toolStripRecent3});
			this.toolStripRecentCards.Name = "toolStripRecentCards";
			this.toolStripRecentCards.Size = new System.Drawing.Size(208, 22);
			this.toolStripRecentCards.Text = "Ostatnio Uzywane Karty...";
			// 
			// toolStripRecent1
			// 
			this.toolStripRecent1.Name = "toolStripRecent1";
			this.toolStripRecent1.Size = new System.Drawing.Size(97, 22);
			this.toolStripRecent1.Text = "Brak";
			// 
			// toolStripRecent2
			// 
			this.toolStripRecent2.Name = "toolStripRecent2";
			this.toolStripRecent2.Size = new System.Drawing.Size(97, 22);
			this.toolStripRecent2.Text = "Brak";
			// 
			// toolStripRecent3
			// 
			this.toolStripRecent3.Name = "toolStripRecent3";
			this.toolStripRecent3.Size = new System.Drawing.Size(97, 22);
			this.toolStripRecent3.Text = "Brak";
			// 
			// toolStripSeparator3
			// 
			this.toolStripSeparator3.Name = "toolStripSeparator3";
			this.toolStripSeparator3.Size = new System.Drawing.Size(205, 6);
			// 
			// printToolStripMenuItem
			// 
			this.printToolStripMenuItem.Name = "printToolStripMenuItem";
			this.printToolStripMenuItem.Size = new System.Drawing.Size(208, 22);
			this.printToolStripMenuItem.Text = "Drukuj Kartę";
			// 
			// toolStripSeparator2
			// 
			this.toolStripSeparator2.Name = "toolStripSeparator2";
			this.toolStripSeparator2.Size = new System.Drawing.Size(205, 6);
			// 
			// closeToolStripMenuItem
			// 
			this.closeToolStripMenuItem.Name = "closeToolStripMenuItem";
			this.closeToolStripMenuItem.Size = new System.Drawing.Size(208, 22);
			this.closeToolStripMenuItem.Text = "Zamknij Program";
			this.closeToolStripMenuItem.Click += new System.EventHandler(this.closeToolStripMenuItem_Click);
			// 
			// helpToolStripMenuItem
			// 
			this.helpToolStripMenuItem.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
			this.helpToolStripMenuItem.Name = "helpToolStripMenuItem";
			this.helpToolStripMenuItem.Size = new System.Drawing.Size(44, 20);
			this.helpToolStripMenuItem.Text = "Help";
			// 
			// settingsToolStripMenuItem
			// 
			this.settingsToolStripMenuItem.Name = "settingsToolStripMenuItem";
			this.settingsToolStripMenuItem.Size = new System.Drawing.Size(76, 20);
			this.settingsToolStripMenuItem.Text = "Ustawienia";
			// 
			// toolStripAbout
			// 
			this.toolStripAbout.Name = "toolStripAbout";
			this.toolStripAbout.Size = new System.Drawing.Size(86, 20);
			this.toolStripAbout.Text = "O Programie";
			// 
			// errorProvider1
			// 
			this.errorProvider1.ContainerControl = this;
			// 
			// openFileDialog1
			// 
			this.openFileDialog1.FileName = "openFileDialog1";
			// 
			// tabControl1
			// 
			this.tabControl1.Controls.Add(this.tabPage3);
			this.tabControl1.Controls.Add(this.tabPage2);
			this.tabControl1.Controls.Add(this.tabPage1);
			this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.tabControl1.Location = new System.Drawing.Point(0, 24);
			this.tabControl1.Name = "tabControl1";
			this.tabControl1.SelectedIndex = 0;
			this.tabControl1.Size = new System.Drawing.Size(871, 515);
			this.tabControl1.TabIndex = 2;
			// 
			// tabPage3
			// 
			this.tabPage3.Controls.Add(this.panelChart);
			this.tabPage3.Location = new System.Drawing.Point(4, 22);
			this.tabPage3.Name = "tabPage3";
			this.tabPage3.Size = new System.Drawing.Size(863, 489);
			this.tabPage3.TabIndex = 2;
			this.tabPage3.Text = "Karta";
			this.tabPage3.UseVisualStyleBackColor = true;
			// 
			// panelChart
			// 
			this.panelChart.AutoScroll = true;
			this.panelChart.Dock = System.Windows.Forms.DockStyle.Fill;
			this.panelChart.Location = new System.Drawing.Point(0, 0);
			this.panelChart.Name = "panelChart";
			this.panelChart.Size = new System.Drawing.Size(863, 489);
			this.panelChart.TabIndex = 3;
			this.panelChart.Paint += new System.Windows.Forms.PaintEventHandler(this.panelChart_Paint);
			// 
			// tabPage2
			// 
			this.tabPage2.Controls.Add(this.groupBox1);
			this.tabPage2.Location = new System.Drawing.Point(4, 22);
			this.tabPage2.Name = "tabPage2";
			this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
			this.tabPage2.Size = new System.Drawing.Size(863, 489);
			this.tabPage2.TabIndex = 4;
			this.tabPage2.Text = "Ustawienia";
			this.tabPage2.UseVisualStyleBackColor = true;
			// 
			// groupBox1
			// 
			this.groupBox1.Controls.Add(this.checkBox1);
			this.groupBox1.Location = new System.Drawing.Point(8, 6);
			this.groupBox1.Name = "groupBox1";
			this.groupBox1.Size = new System.Drawing.Size(297, 100);
			this.groupBox1.TabIndex = 1;
			this.groupBox1.TabStop = false;
			this.groupBox1.Text = "groupBox1";
			// 
			// checkBox1
			// 
			this.checkBox1.AutoSize = true;
			this.checkBox1.Location = new System.Drawing.Point(7, 53);
			this.checkBox1.Name = "checkBox1";
			this.checkBox1.Size = new System.Drawing.Size(193, 17);
			this.checkBox1.TabIndex = 0;
			this.checkBox1.Text = "Automatycznie otwórz ostatnią karę";
			this.checkBox1.UseVisualStyleBackColor = true;
			// 
			// tabPage1
			// 
			this.tabPage1.Controls.Add(this.numericUpDown2);
			this.tabPage1.Controls.Add(this.numericUpDown1);
			this.tabPage1.Controls.Add(this.label2);
			this.tabPage1.Controls.Add(this.label1);
			this.tabPage1.Controls.Add(this.domainUpDown1);
			this.tabPage1.Controls.Add(this.observationCtrl8);
			this.tabPage1.Location = new System.Drawing.Point(4, 22);
			this.tabPage1.Name = "tabPage1";
			this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
			this.tabPage1.Size = new System.Drawing.Size(863, 489);
			this.tabPage1.TabIndex = 3;
			this.tabPage1.Text = "testy";
			this.tabPage1.UseVisualStyleBackColor = true;
			// 
			// numericUpDown2
			// 
			this.numericUpDown2.Location = new System.Drawing.Point(176, 54);
			this.numericUpDown2.Name = "numericUpDown2";
			this.numericUpDown2.Size = new System.Drawing.Size(120, 20);
			this.numericUpDown2.TabIndex = 8;
			this.numericUpDown2.Value = new decimal(new int[] {
            2,
            0,
            0,
            0});
			this.numericUpDown2.ValueChanged += new System.EventHandler(this.textBoxRows_TextChanged);
			// 
			// numericUpDown1
			// 
			this.numericUpDown1.Location = new System.Drawing.Point(176, 26);
			this.numericUpDown1.Name = "numericUpDown1";
			this.numericUpDown1.Size = new System.Drawing.Size(120, 20);
			this.numericUpDown1.TabIndex = 7;
			this.numericUpDown1.Value = new decimal(new int[] {
            8,
            0,
            0,
            0});
			this.numericUpDown1.ValueChanged += new System.EventHandler(this.textBoxCols_TextChanged);
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point(26, 53);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(35, 13);
			this.label2.TabIndex = 6;
			this.label2.Text = "label2";
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(26, 27);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(35, 13);
			this.label1.TabIndex = 5;
			this.label1.Text = "label1";
			// 
			// domainUpDown1
			// 
			this.domainUpDown1.Location = new System.Drawing.Point(69, 201);
			this.domainUpDown1.Name = "domainUpDown1";
			this.domainUpDown1.Size = new System.Drawing.Size(120, 20);
			this.domainUpDown1.TabIndex = 2;
			this.domainUpDown1.Text = "domainUpDown1";
			// 
			// observationCtrl8
			// 
			this.observationCtrl8.Col = 1;
			this.observationCtrl8.Location = new System.Drawing.Point(585, 77);
			this.observationCtrl8.Name = "observationCtrl8";
			this.observationCtrl8.Row = 1;
			this.observationCtrl8.Size = new System.Drawing.Size(42, 144);
			this.observationCtrl8.TabIndex = 0;
			// 
			// observationCtrl7
			// 
			this.observationCtrl7.BackColor = System.Drawing.SystemColors.Control;
			this.observationCtrl7.Col = 1;
			this.observationCtrl7.Location = new System.Drawing.Point(0, 0);
			this.observationCtrl7.Name = "observationCtrl7";
			this.observationCtrl7.Row = 1;
			this.observationCtrl7.Size = new System.Drawing.Size(42, 144);
			this.observationCtrl7.TabIndex = 0;
			// 
			// observationCtrl4
			// 
			this.observationCtrl4.BackColor = System.Drawing.SystemColors.Control;
			this.observationCtrl4.Col = 1;
			this.observationCtrl4.Location = new System.Drawing.Point(0, 0);
			this.observationCtrl4.Name = "observationCtrl4";
			this.observationCtrl4.Row = 1;
			this.observationCtrl4.Size = new System.Drawing.Size(42, 144);
			this.observationCtrl4.TabIndex = 0;
			// 
			// observationCtrl5
			// 
			this.observationCtrl5.BackColor = System.Drawing.SystemColors.Control;
			this.observationCtrl5.Col = 1;
			this.observationCtrl5.Location = new System.Drawing.Point(0, 0);
			this.observationCtrl5.Name = "observationCtrl5";
			this.observationCtrl5.Row = 1;
			this.observationCtrl5.Size = new System.Drawing.Size(42, 144);
			this.observationCtrl5.TabIndex = 0;
			// 
			// observationCtrl6
			// 
			this.observationCtrl6.BackColor = System.Drawing.SystemColors.Control;
			this.observationCtrl6.Col = 1;
			this.observationCtrl6.Location = new System.Drawing.Point(0, 0);
			this.observationCtrl6.Name = "observationCtrl6";
			this.observationCtrl6.Row = 1;
			this.observationCtrl6.Size = new System.Drawing.Size(42, 144);
			this.observationCtrl6.TabIndex = 0;
			// 
			// observationCtrl3
			// 
			this.observationCtrl3.BackColor = System.Drawing.SystemColors.Control;
			this.observationCtrl3.Col = 1;
			this.observationCtrl3.Location = new System.Drawing.Point(0, 0);
			this.observationCtrl3.Name = "observationCtrl3";
			this.observationCtrl3.Row = 1;
			this.observationCtrl3.Size = new System.Drawing.Size(42, 144);
			this.observationCtrl3.TabIndex = 0;
			// 
			// observationCtrl2
			// 
			this.observationCtrl2.BackColor = System.Drawing.SystemColors.Control;
			this.observationCtrl2.Col = 1;
			this.observationCtrl2.Location = new System.Drawing.Point(0, 0);
			this.observationCtrl2.Name = "observationCtrl2";
			this.observationCtrl2.Row = 1;
			this.observationCtrl2.Size = new System.Drawing.Size(42, 144);
			this.observationCtrl2.TabIndex = 0;
			// 
			// observationCtrl1
			// 
			this.observationCtrl1.BackColor = System.Drawing.SystemColors.Control;
			this.observationCtrl1.Col = 1;
			this.observationCtrl1.Location = new System.Drawing.Point(0, 0);
			this.observationCtrl1.Name = "observationCtrl1";
			this.observationCtrl1.Row = 1;
			this.observationCtrl1.Size = new System.Drawing.Size(42, 144);
			this.observationCtrl1.TabIndex = 0;
			// 
			// MainForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.AutoSize = true;
			this.ClientSize = new System.Drawing.Size(871, 539);
			this.Controls.Add(this.tabControl1);
			this.Controls.Add(this.MainMenuStrip);
			this.HelpButton = true;
			this.Name = "MainForm";
			this.Text = "NaproKarta";
			this.Load += new System.EventHandler(this.MainForm_Load);
			this.MainMenuStrip.ResumeLayout(false);
			this.MainMenuStrip.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
			this.tabControl1.ResumeLayout(false);
			this.tabPage3.ResumeLayout(false);
			this.tabPage2.ResumeLayout(false);
			this.groupBox1.ResumeLayout(false);
			this.groupBox1.PerformLayout();
			this.tabPage1.ResumeLayout(false);
			this.tabPage1.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.numericUpDown2)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip MainMenuStrip;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem openToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem saveToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem saveAsToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem printToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripMenuItem closeToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem helpToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem settingsToolStripMenuItem;
        private System.Windows.Forms.ErrorProvider errorProvider1;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.SaveFileDialog saveFileDialog1;
        private System.Windows.Forms.HelpProvider helpProvider1;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage3;
        private System.Windows.Forms.Panel panelChart;
        private ObservationCtrl observationCtrl1;
        private ObservationCtrl observationCtrl2;
        private ObservationCtrl observationCtrl3;
        private System.Windows.Forms.ToolStripMenuItem NewCardtoolStripMenuItem1;
        private ObservationCtrl observationCtrl4;
        private ObservationCtrl observationCtrl5;
        private ObservationCtrl observationCtrl6;
        private ObservationCtrl observationCtrl7;
		private System.Windows.Forms.TabPage tabPage2;
		private System.Windows.Forms.TabPage tabPage1;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.DomainUpDown domainUpDown1;
		private ObservationCtrl observationCtrl8;
		private System.Windows.Forms.NumericUpDown numericUpDown2;
		private System.Windows.Forms.NumericUpDown numericUpDown1;
		private System.Windows.Forms.ToolStripMenuItem toolStripRecentCards;
		private System.Windows.Forms.ToolStripMenuItem toolStripRecent1;
		private System.Windows.Forms.ToolStripMenuItem toolStripRecent2;
		private System.Windows.Forms.ToolStripMenuItem toolStripRecent3;
		private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
		private System.Windows.Forms.ToolStripMenuItem toolStripAbout;
		private System.Windows.Forms.GroupBox groupBox1;
		private System.Windows.Forms.CheckBox checkBox1;
	}
}

