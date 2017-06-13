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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.MainMenuStrip = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.NewCardtoolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.openToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveAsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.printToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.closeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.helpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.settingsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            this.helpProvider1 = new System.Windows.Forms.HelpProvider();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.button5 = new System.Windows.Forms.Button();
            this.ChartPanel = new System.Windows.Forms.Panel();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.observationCtrl7 = new NaproKarta.ObservationCtrl();
            this.flowLayoutPanel2 = new System.Windows.Forms.FlowLayoutPanel();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.observationCtrl4 = new NaproKarta.ObservationCtrl();
            this.observationCtrl5 = new NaproKarta.ObservationCtrl();
            this.observationCtrl6 = new NaproKarta.ObservationCtrl();
            this.button1 = new System.Windows.Forms.Button();
            this.observationCtrl3 = new NaproKarta.ObservationCtrl();
            this.observationCtrl2 = new NaproKarta.ObservationCtrl();
            this.observationCtrl1 = new NaproKarta.ObservationCtrl();
            this.button2 = new System.Windows.Forms.Button();
            this.MainMenuStrip.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            this.tabControl1.SuspendLayout();
            this.tabPage3.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // MainMenuStrip
            // 
            this.MainMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.helpToolStripMenuItem,
            this.settingsToolStripMenuItem});
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
            this.NewCardtoolStripMenuItem1.Size = new System.Drawing.Size(203, 22);
            this.NewCardtoolStripMenuItem1.Text = "Nowa Karta";
            this.NewCardtoolStripMenuItem1.Click += new System.EventHandler(this.NewCardtoolStripMenuItem1_Click);
            // 
            // openToolStripMenuItem
            // 
            this.openToolStripMenuItem.Name = "openToolStripMenuItem";
            this.openToolStripMenuItem.Size = new System.Drawing.Size(203, 22);
            this.openToolStripMenuItem.Text = "Otwórz Kartę...";
            this.openToolStripMenuItem.Click += new System.EventHandler(this.otworzToolStripMenuItem_Click);
            // 
            // saveToolStripMenuItem
            // 
            this.saveToolStripMenuItem.Name = "saveToolStripMenuItem";
            this.saveToolStripMenuItem.Size = new System.Drawing.Size(203, 22);
            this.saveToolStripMenuItem.Text = "Zapisz Kartę";
            this.saveToolStripMenuItem.Click += new System.EventHandler(this.zapiszToolStripMenuItem_Click);
            // 
            // saveAsToolStripMenuItem
            // 
            this.saveAsToolStripMenuItem.Name = "saveAsToolStripMenuItem";
            this.saveAsToolStripMenuItem.Size = new System.Drawing.Size(203, 22);
            this.saveAsToolStripMenuItem.Text = "Zapisz jako nową Kartę...";
            this.saveAsToolStripMenuItem.Click += new System.EventHandler(this.zapiszJakoToolStripMenuItem_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(200, 6);
            // 
            // printToolStripMenuItem
            // 
            this.printToolStripMenuItem.Name = "printToolStripMenuItem";
            this.printToolStripMenuItem.Size = new System.Drawing.Size(203, 22);
            this.printToolStripMenuItem.Text = "Drukuj Kartę";
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(200, 6);
            // 
            // closeToolStripMenuItem
            // 
            this.closeToolStripMenuItem.Name = "closeToolStripMenuItem";
            this.closeToolStripMenuItem.Size = new System.Drawing.Size(203, 22);
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
            // groupBox1
            // 
            this.groupBox1.Location = new System.Drawing.Point(149, 134);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(200, 100);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "groupBox1";
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
            this.tabPage3.Controls.Add(this.button5);
            this.tabPage3.Controls.Add(this.ChartPanel);
            this.tabPage3.Location = new System.Drawing.Point(4, 22);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Size = new System.Drawing.Size(863, 489);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "Karta";
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // button5
            // 
            this.button5.Location = new System.Drawing.Point(697, 458);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(75, 23);
            this.button5.TabIndex = 5;
            this.button5.Text = "button5";
            this.button5.UseVisualStyleBackColor = true;
            this.button5.Visible = false;
            this.button5.Click += new System.EventHandler(this.button5_Click);
            // 
            // ChartPanel
            // 
            this.ChartPanel.AutoScroll = true;
            this.ChartPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ChartPanel.Location = new System.Drawing.Point(0, 0);
            this.ChartPanel.Name = "ChartPanel";
            this.ChartPanel.Size = new System.Drawing.Size(863, 489);
            this.ChartPanel.TabIndex = 3;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.button2);
            this.tabPage1.Controls.Add(this.observationCtrl7);
            this.tabPage1.Controls.Add(this.flowLayoutPanel2);
            this.tabPage1.Controls.Add(this.tableLayoutPanel1);
            this.tabPage1.Controls.Add(this.button1);
            this.tabPage1.Controls.Add(this.groupBox1);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(863, 489);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Ustawienia";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // observationCtrl7
            // 
            this.observationCtrl7.Cyferki = null;
            this.observationCtrl7.CyferkiCD = null;
            this.observationCtrl7.Date = new System.DateTime(((long)(0)));
            this.observationCtrl7.IleRazy = null;
            this.observationCtrl7.IsNew = false;
            this.observationCtrl7.Literki = null;
            this.observationCtrl7.Location = new System.Drawing.Point(282, 18);
            this.observationCtrl7.MarkerImage = null;
            this.observationCtrl7.MarkerImageDescriptionTag = null;
            this.observationCtrl7.Name = "observationCtrl7";
            this.observationCtrl7.NoteMarks = ((System.Collections.Generic.List<string>)(resources.GetObject("observationCtrl7.NoteMarks")));
            this.observationCtrl7.NotesContent = ((System.Collections.Generic.List<string>)(resources.GetObject("observationCtrl7.NotesContent")));
            this.observationCtrl7.Size = new System.Drawing.Size(42, 144);
            this.observationCtrl7.TabIndex = 4;
            this.observationCtrl7.Uwagi = ((System.Collections.Generic.List<string>)(resources.GetObject("observationCtrl7.Uwagi")));
            // 
            // flowLayoutPanel2
            // 
            this.flowLayoutPanel2.Location = new System.Drawing.Point(23, 304);
            this.flowLayoutPanel2.Name = "flowLayoutPanel2";
            this.flowLayoutPanel2.Size = new System.Drawing.Size(200, 100);
            this.flowLayoutPanel2.TabIndex = 0;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 5;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 42F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 42F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 42F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 42F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 237F));
            this.tableLayoutPanel1.Controls.Add(this.observationCtrl4, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.observationCtrl5, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.observationCtrl6, 2, 0);
            this.tableLayoutPanel1.Location = new System.Drawing.Point(406, 74);
            this.tableLayoutPanel1.Margin = new System.Windows.Forms.Padding(0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 4;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 144F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 144F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 144F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 144F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(405, 385);
            this.tableLayoutPanel1.TabIndex = 3;
            // 
            // observationCtrl4
            // 
            this.observationCtrl4.Cyferki = null;
            this.observationCtrl4.CyferkiCD = null;
            this.observationCtrl4.Date = new System.DateTime(((long)(0)));
            this.observationCtrl4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.observationCtrl4.IleRazy = null;
            this.observationCtrl4.IsNew = false;
            this.observationCtrl4.Literki = null;
            this.observationCtrl4.Location = new System.Drawing.Point(3, 3);
            this.observationCtrl4.MarkerImage = null;
            this.observationCtrl4.MarkerImageDescriptionTag = null;
            this.observationCtrl4.Name = "observationCtrl4";
            this.observationCtrl4.NoteMarks = ((System.Collections.Generic.List<string>)(resources.GetObject("observationCtrl4.NoteMarks")));
            this.observationCtrl4.NotesContent = ((System.Collections.Generic.List<string>)(resources.GetObject("observationCtrl4.NotesContent")));
            this.observationCtrl4.Size = new System.Drawing.Size(36, 138);
            this.observationCtrl4.TabIndex = 0;
            this.observationCtrl4.Uwagi = ((System.Collections.Generic.List<string>)(resources.GetObject("observationCtrl4.Uwagi")));
            // 
            // observationCtrl5
            // 
            this.observationCtrl5.Cyferki = null;
            this.observationCtrl5.CyferkiCD = null;
            this.observationCtrl5.Date = new System.DateTime(((long)(0)));
            this.observationCtrl5.Dock = System.Windows.Forms.DockStyle.Fill;
            this.observationCtrl5.IleRazy = null;
            this.observationCtrl5.IsNew = false;
            this.observationCtrl5.Literki = null;
            this.observationCtrl5.Location = new System.Drawing.Point(45, 3);
            this.observationCtrl5.MarkerImage = null;
            this.observationCtrl5.MarkerImageDescriptionTag = null;
            this.observationCtrl5.Name = "observationCtrl5";
            this.observationCtrl5.NoteMarks = ((System.Collections.Generic.List<string>)(resources.GetObject("observationCtrl5.NoteMarks")));
            this.observationCtrl5.NotesContent = ((System.Collections.Generic.List<string>)(resources.GetObject("observationCtrl5.NotesContent")));
            this.observationCtrl5.Size = new System.Drawing.Size(36, 138);
            this.observationCtrl5.TabIndex = 1;
            this.observationCtrl5.Uwagi = ((System.Collections.Generic.List<string>)(resources.GetObject("observationCtrl5.Uwagi")));
            // 
            // observationCtrl6
            // 
            this.observationCtrl6.Cyferki = null;
            this.observationCtrl6.CyferkiCD = null;
            this.observationCtrl6.Date = new System.DateTime(((long)(0)));
            this.observationCtrl6.Dock = System.Windows.Forms.DockStyle.Fill;
            this.observationCtrl6.IleRazy = null;
            this.observationCtrl6.IsNew = false;
            this.observationCtrl6.Literki = null;
            this.observationCtrl6.Location = new System.Drawing.Point(87, 3);
            this.observationCtrl6.MarkerImage = null;
            this.observationCtrl6.MarkerImageDescriptionTag = null;
            this.observationCtrl6.Name = "observationCtrl6";
            this.observationCtrl6.NoteMarks = ((System.Collections.Generic.List<string>)(resources.GetObject("observationCtrl6.NoteMarks")));
            this.observationCtrl6.NotesContent = ((System.Collections.Generic.List<string>)(resources.GetObject("observationCtrl6.NotesContent")));
            this.observationCtrl6.Size = new System.Drawing.Size(36, 138);
            this.observationCtrl6.TabIndex = 2;
            this.observationCtrl6.Uwagi = ((System.Collections.Generic.List<string>)(resources.GetObject("observationCtrl6.Uwagi")));
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(23, 153);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(161, 23);
            this.button1.TabIndex = 2;
            this.button1.Text = "Nowa Karta";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // observationCtrl3
            // 
            this.observationCtrl3.Cyferki = null;
            this.observationCtrl3.CyferkiCD = null;
            this.observationCtrl3.Date = new System.DateTime(((long)(0)));
            this.observationCtrl3.IleRazy = null;
            this.observationCtrl3.IsNew = false;
            this.observationCtrl3.Literki = null;
            this.observationCtrl3.Location = new System.Drawing.Point(0, 0);
            this.observationCtrl3.MarkerImage = null;
            this.observationCtrl3.MarkerImageDescriptionTag = "";
            this.observationCtrl3.Name = "observationCtrl3";
            this.observationCtrl3.NoteMarks = ((System.Collections.Generic.List<string>)(resources.GetObject("observationCtrl3.NoteMarks")));
            this.observationCtrl3.NotesContent = ((System.Collections.Generic.List<string>)(resources.GetObject("observationCtrl3.NotesContent")));
            this.observationCtrl3.Size = new System.Drawing.Size(42, 144);
            this.observationCtrl3.TabIndex = 0;
            this.observationCtrl3.Uwagi = ((System.Collections.Generic.List<string>)(resources.GetObject("observationCtrl3.Uwagi")));
            // 
            // observationCtrl2
            // 
            this.observationCtrl2.Cyferki = null;
            this.observationCtrl2.CyferkiCD = null;
            this.observationCtrl2.Date = new System.DateTime(((long)(0)));
            this.observationCtrl2.IleRazy = null;
            this.observationCtrl2.IsNew = false;
            this.observationCtrl2.Literki = null;
            this.observationCtrl2.Location = new System.Drawing.Point(0, 0);
            this.observationCtrl2.MarkerImage = null;
            this.observationCtrl2.MarkerImageDescriptionTag = "";
            this.observationCtrl2.Name = "observationCtrl2";
            this.observationCtrl2.NoteMarks = ((System.Collections.Generic.List<string>)(resources.GetObject("observationCtrl2.NoteMarks")));
            this.observationCtrl2.NotesContent = ((System.Collections.Generic.List<string>)(resources.GetObject("observationCtrl2.NotesContent")));
            this.observationCtrl2.Size = new System.Drawing.Size(42, 144);
            this.observationCtrl2.TabIndex = 0;
            this.observationCtrl2.Uwagi = ((System.Collections.Generic.List<string>)(resources.GetObject("observationCtrl2.Uwagi")));
            // 
            // observationCtrl1
            // 
            this.observationCtrl1.Cyferki = null;
            this.observationCtrl1.CyferkiCD = null;
            this.observationCtrl1.Date = new System.DateTime(((long)(0)));
            this.observationCtrl1.IleRazy = null;
            this.observationCtrl1.IsNew = false;
            this.observationCtrl1.Literki = null;
            this.observationCtrl1.Location = new System.Drawing.Point(0, 0);
            this.observationCtrl1.MarkerImage = null;
            this.observationCtrl1.MarkerImageDescriptionTag = "";
            this.observationCtrl1.Name = "observationCtrl1";
            this.observationCtrl1.NoteMarks = ((System.Collections.Generic.List<string>)(resources.GetObject("observationCtrl1.NoteMarks")));
            this.observationCtrl1.NotesContent = ((System.Collections.Generic.List<string>)(resources.GetObject("observationCtrl1.NotesContent")));
            this.observationCtrl1.Size = new System.Drawing.Size(42, 144);
            this.observationCtrl1.TabIndex = 0;
            this.observationCtrl1.Uwagi = ((System.Collections.Generic.List<string>)(resources.GetObject("observationCtrl1.Uwagi")));
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(6, 6);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(217, 23);
            this.button2.TabIndex = 5;
            this.button2.Text = "Zapisz ustawienia do pliku";
            this.button2.UseVisualStyleBackColor = true;
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
            this.tabPage1.ResumeLayout(false);
            this.tableLayoutPanel1.ResumeLayout(false);
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
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.ErrorProvider errorProvider1;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.SaveFileDialog saveFileDialog1;
        private System.Windows.Forms.HelpProvider helpProvider1;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TabPage tabPage3;
        private System.Windows.Forms.Panel ChartPanel;
        private System.Windows.Forms.Button button5;
        private ObservationCtrl observationCtrl1;
        private ObservationCtrl observationCtrl2;
        private ObservationCtrl observationCtrl3;
        private System.Windows.Forms.ToolStripMenuItem NewCardtoolStripMenuItem1;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel2;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private ObservationCtrl observationCtrl4;
        private ObservationCtrl observationCtrl5;
        private ObservationCtrl observationCtrl6;
        private ObservationCtrl observationCtrl7;
        private System.Windows.Forms.Button button2;
    }
}

