namespace AnimeDL
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            txtSearch = new TextBox();
            BtnSearch = new Button();
            LsbSearchResults = new ListBox();
            LsbEpisodes = new ListBox();
            grpDetails = new GroupBox();
            lblDubs = new Label();
            lblSubs = new Label();
            lblName = new Label();
            lblId = new Label();
            label5 = new Label();
            label4 = new Label();
            label3 = new Label();
            label2 = new Label();
            label1 = new Label();
            statusStrip1 = new StatusStrip();
            toolStripStatusLabel1 = new ToolStripStatusLabel();
            toolStripProgressBar1 = new ToolStripProgressBar();
            BtnDownload = new Button();
            tabControl1 = new TabControl();
            tabPage1 = new TabPage();
            cmbLanguage = new ComboBox();
            tabPage2 = new TabPage();
            groupBox3 = new GroupBox();
            cmbDefaultLanguage = new ComboBox();
            label7 = new Label();
            groupBox2 = new GroupBox();
            txtFFmpegPath = new TextBox();
            groupBox1 = new GroupBox();
            label6 = new Label();
            txtAniwatchPort = new TextBox();
            txtAniwatchAddress = new TextBox();
            cmbAniwatchProtocol = new ComboBox();
            grpDetails.SuspendLayout();
            statusStrip1.SuspendLayout();
            tabControl1.SuspendLayout();
            tabPage1.SuspendLayout();
            tabPage2.SuspendLayout();
            groupBox3.SuspendLayout();
            groupBox2.SuspendLayout();
            groupBox1.SuspendLayout();
            SuspendLayout();
            // 
            // txtSearch
            // 
            txtSearch.Location = new Point(6, 6);
            txtSearch.Name = "txtSearch";
            txtSearch.Size = new Size(250, 23);
            txtSearch.TabIndex = 0;
            // 
            // BtnSearch
            // 
            BtnSearch.Location = new Point(262, 6);
            BtnSearch.Name = "BtnSearch";
            BtnSearch.Size = new Size(75, 23);
            BtnSearch.TabIndex = 1;
            BtnSearch.Text = "Search";
            BtnSearch.UseVisualStyleBackColor = true;
            BtnSearch.Click += BtnSearch_Click;
            // 
            // LsbSearchResults
            // 
            LsbSearchResults.FormattingEnabled = true;
            LsbSearchResults.Location = new Point(6, 35);
            LsbSearchResults.Name = "LsbSearchResults";
            LsbSearchResults.Size = new Size(331, 94);
            LsbSearchResults.Sorted = true;
            LsbSearchResults.TabIndex = 2;
            LsbSearchResults.SelectedIndexChanged += LsbSearchResults_SelectedIndexChanged;
            // 
            // LsbEpisodes
            // 
            LsbEpisodes.FormattingEnabled = true;
            LsbEpisodes.Location = new Point(6, 135);
            LsbEpisodes.Name = "LsbEpisodes";
            LsbEpisodes.SelectionMode = SelectionMode.MultiExtended;
            LsbEpisodes.Size = new Size(331, 94);
            LsbEpisodes.TabIndex = 3;
            // 
            // grpDetails
            // 
            grpDetails.Controls.Add(lblDubs);
            grpDetails.Controls.Add(lblSubs);
            grpDetails.Controls.Add(lblName);
            grpDetails.Controls.Add(lblId);
            grpDetails.Controls.Add(label5);
            grpDetails.Controls.Add(label4);
            grpDetails.Controls.Add(label3);
            grpDetails.Controls.Add(label2);
            grpDetails.Controls.Add(label1);
            grpDetails.Location = new Point(343, 6);
            grpDetails.Name = "grpDetails";
            grpDetails.Size = new Size(331, 123);
            grpDetails.TabIndex = 4;
            grpDetails.TabStop = false;
            grpDetails.Text = "Details";
            // 
            // lblDubs
            // 
            lblDubs.AutoSize = true;
            lblDubs.Location = new Point(68, 79);
            lblDubs.Name = "lblDubs";
            lblDubs.Size = new Size(38, 15);
            lblDubs.TabIndex = 8;
            lblDubs.Text = "label6";
            // 
            // lblSubs
            // 
            lblSubs.AutoSize = true;
            lblSubs.Location = new Point(68, 64);
            lblSubs.Name = "lblSubs";
            lblSubs.Size = new Size(38, 15);
            lblSubs.TabIndex = 7;
            lblSubs.Text = "label6";
            // 
            // lblName
            // 
            lblName.AutoSize = true;
            lblName.Location = new Point(54, 34);
            lblName.Name = "lblName";
            lblName.Size = new Size(38, 15);
            lblName.TabIndex = 6;
            lblName.Text = "label6";
            // 
            // lblId
            // 
            lblId.AutoSize = true;
            lblId.Location = new Point(33, 19);
            lblId.Name = "lblId";
            lblId.Size = new Size(38, 15);
            lblId.TabIndex = 5;
            lblId.Text = "label6";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(30, 79);
            label5.Name = "label5";
            label5.Size = new Size(32, 15);
            label5.TabIndex = 4;
            label5.Text = "Dub:";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(32, 64);
            label4.Name = "label4";
            label4.Size = new Size(30, 15);
            label4.TabIndex = 3;
            label4.Text = "Sub:";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(6, 49);
            label3.Name = "label3";
            label3.Size = new Size(56, 15);
            label3.TabIndex = 2;
            label3.Text = "Episodes:";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(6, 34);
            label2.Name = "label2";
            label2.Size = new Size(42, 15);
            label2.TabIndex = 1;
            label2.Text = "Name:";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(6, 19);
            label1.Name = "label1";
            label1.Size = new Size(21, 15);
            label1.TabIndex = 0;
            label1.Text = "ID:";
            // 
            // statusStrip1
            // 
            statusStrip1.Items.AddRange(new ToolStripItem[] { toolStripStatusLabel1, toolStripProgressBar1 });
            statusStrip1.LayoutStyle = ToolStripLayoutStyle.HorizontalStackWithOverflow;
            statusStrip1.Location = new Point(0, 287);
            statusStrip1.Name = "statusStrip1";
            statusStrip1.Size = new Size(715, 22);
            statusStrip1.TabIndex = 5;
            statusStrip1.Text = "statusStrip1";
            // 
            // toolStripStatusLabel1
            // 
            toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            toolStripStatusLabel1.Size = new Size(118, 17);
            toolStripStatusLabel1.Text = "toolStripStatusLabel1";
            // 
            // toolStripProgressBar1
            // 
            toolStripProgressBar1.Alignment = ToolStripItemAlignment.Right;
            toolStripProgressBar1.Name = "toolStripProgressBar1";
            toolStripProgressBar1.Size = new Size(100, 16);
            // 
            // BtnDownload
            // 
            BtnDownload.Location = new Point(599, 206);
            BtnDownload.Name = "BtnDownload";
            BtnDownload.Size = new Size(75, 23);
            BtnDownload.TabIndex = 6;
            BtnDownload.Text = "Download";
            BtnDownload.UseVisualStyleBackColor = true;
            BtnDownload.Click += BtnDownload_Click;
            // 
            // tabControl1
            // 
            tabControl1.Controls.Add(tabPage1);
            tabControl1.Controls.Add(tabPage2);
            tabControl1.Location = new Point(12, 12);
            tabControl1.Name = "tabControl1";
            tabControl1.SelectedIndex = 0;
            tabControl1.Size = new Size(692, 267);
            tabControl1.TabIndex = 7;
            // 
            // tabPage1
            // 
            tabPage1.Controls.Add(cmbLanguage);
            tabPage1.Controls.Add(txtSearch);
            tabPage1.Controls.Add(BtnDownload);
            tabPage1.Controls.Add(LsbSearchResults);
            tabPage1.Controls.Add(LsbEpisodes);
            tabPage1.Controls.Add(grpDetails);
            tabPage1.Controls.Add(BtnSearch);
            tabPage1.Location = new Point(4, 24);
            tabPage1.Name = "tabPage1";
            tabPage1.Padding = new Padding(3);
            tabPage1.Size = new Size(684, 239);
            tabPage1.TabIndex = 0;
            tabPage1.Text = "Main";
            tabPage1.UseVisualStyleBackColor = true;
            // 
            // cmbLanguage
            // 
            cmbLanguage.FormattingEnabled = true;
            cmbLanguage.Items.AddRange(new object[] { "Sub", "Dub" });
            cmbLanguage.Location = new Point(472, 206);
            cmbLanguage.Name = "cmbLanguage";
            cmbLanguage.Size = new Size(121, 23);
            cmbLanguage.TabIndex = 7;
            // 
            // tabPage2
            // 
            tabPage2.Controls.Add(groupBox3);
            tabPage2.Controls.Add(groupBox2);
            tabPage2.Controls.Add(groupBox1);
            tabPage2.Location = new Point(4, 24);
            tabPage2.Name = "tabPage2";
            tabPage2.Padding = new Padding(3);
            tabPage2.Size = new Size(684, 239);
            tabPage2.TabIndex = 1;
            tabPage2.Text = "Settings";
            tabPage2.UseVisualStyleBackColor = true;
            // 
            // groupBox3
            // 
            groupBox3.Controls.Add(cmbDefaultLanguage);
            groupBox3.Controls.Add(label7);
            groupBox3.Location = new Point(6, 138);
            groupBox3.Name = "groupBox3";
            groupBox3.Size = new Size(672, 95);
            groupBox3.TabIndex = 3;
            groupBox3.TabStop = false;
            groupBox3.Text = "General";
            // 
            // cmbDefaultLanguage
            // 
            cmbDefaultLanguage.FormattingEnabled = true;
            cmbDefaultLanguage.Items.AddRange(new object[] { "Sub", "Dub" });
            cmbDefaultLanguage.Location = new Point(115, 22);
            cmbDefaultLanguage.Name = "cmbDefaultLanguage";
            cmbDefaultLanguage.Size = new Size(61, 23);
            cmbDefaultLanguage.TabIndex = 1;
            cmbDefaultLanguage.SelectedIndexChanged += SettingsFieldChanged;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new Point(6, 25);
            label7.Name = "label7";
            label7.Size = new Size(103, 15);
            label7.TabIndex = 0;
            label7.Text = "Default Language:";
            // 
            // groupBox2
            // 
            groupBox2.Controls.Add(txtFFmpegPath);
            groupBox2.Location = new Point(6, 72);
            groupBox2.Name = "groupBox2";
            groupBox2.Size = new Size(672, 60);
            groupBox2.TabIndex = 2;
            groupBox2.TabStop = false;
            groupBox2.Text = "FFmpeg";
            // 
            // txtFFmpegPath
            // 
            txtFFmpegPath.Location = new Point(6, 22);
            txtFFmpegPath.Name = "txtFFmpegPath";
            txtFFmpegPath.Size = new Size(660, 23);
            txtFFmpegPath.TabIndex = 0;
            txtFFmpegPath.TextChanged += SettingsFieldChanged;
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(label6);
            groupBox1.Controls.Add(txtAniwatchPort);
            groupBox1.Controls.Add(txtAniwatchAddress);
            groupBox1.Controls.Add(cmbAniwatchProtocol);
            groupBox1.Location = new Point(6, 6);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(340, 60);
            groupBox1.TabIndex = 1;
            groupBox1.TabStop = false;
            groupBox1.Text = "aniwatch-api";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(265, 25);
            label6.Name = "label6";
            label6.Size = new Size(10, 15);
            label6.TabIndex = 3;
            label6.Text = ":";
            // 
            // txtAniwatchPort
            // 
            txtAniwatchPort.Location = new Point(281, 22);
            txtAniwatchPort.Name = "txtAniwatchPort";
            txtAniwatchPort.Size = new Size(53, 23);
            txtAniwatchPort.TabIndex = 2;
            txtAniwatchPort.TextChanged += SettingsFieldChanged;
            // 
            // txtAniwatchAddress
            // 
            txtAniwatchAddress.Location = new Point(76, 22);
            txtAniwatchAddress.Name = "txtAniwatchAddress";
            txtAniwatchAddress.Size = new Size(183, 23);
            txtAniwatchAddress.TabIndex = 1;
            txtAniwatchAddress.TextChanged += SettingsFieldChanged;
            // 
            // cmbAniwatchProtocol
            // 
            cmbAniwatchProtocol.FormattingEnabled = true;
            cmbAniwatchProtocol.Items.AddRange(new object[] { "http://", "https://" });
            cmbAniwatchProtocol.Location = new Point(6, 22);
            cmbAniwatchProtocol.Name = "cmbAniwatchProtocol";
            cmbAniwatchProtocol.Size = new Size(64, 23);
            cmbAniwatchProtocol.TabIndex = 0;
            cmbAniwatchProtocol.SelectedIndexChanged += SettingsFieldChanged;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(715, 309);
            Controls.Add(tabControl1);
            Controls.Add(statusStrip1);
            Name = "Form1";
            Text = "AnimeDL";
            grpDetails.ResumeLayout(false);
            grpDetails.PerformLayout();
            statusStrip1.ResumeLayout(false);
            statusStrip1.PerformLayout();
            tabControl1.ResumeLayout(false);
            tabPage1.ResumeLayout(false);
            tabPage1.PerformLayout();
            tabPage2.ResumeLayout(false);
            groupBox3.ResumeLayout(false);
            groupBox3.PerformLayout();
            groupBox2.ResumeLayout(false);
            groupBox2.PerformLayout();
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox txtSearch;
        private Button BtnSearch;
        private ListBox LsbSearchResults;
        private ListBox LsbEpisodes;
        private GroupBox grpDetails;
        private Label lblDubs;
        private Label lblSubs;
        private Label lblName;
        private Label lblId;
        private Label label5;
        private Label label4;
        private Label label3;
        private Label label2;
        private Label label1;
        private StatusStrip statusStrip1;
        private ToolStripStatusLabel toolStripStatusLabel1;
        private Button BtnDownload;
        private ToolStripProgressBar toolStripProgressBar1;
        private TabControl tabControl1;
        private TabPage tabPage1;
        private TabPage tabPage2;
        private GroupBox groupBox1;
        private Label label6;
        private TextBox txtAniwatchPort;
        private TextBox txtAniwatchAddress;
        private ComboBox cmbAniwatchProtocol;
        private GroupBox groupBox2;
        private TextBox txtFFmpegPath;
        private ComboBox cmbLanguage;
        private GroupBox groupBox3;
        private Label label7;
        private ComboBox cmbDefaultLanguage;
    }
}
