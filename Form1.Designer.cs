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
            btnSearch = new Button();
            lstSearchResults = new ListBox();
            lstEpisodes = new ListBox();
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
            button1 = new Button();
            toolStripProgressBar1 = new ToolStripProgressBar();
            grpDetails.SuspendLayout();
            statusStrip1.SuspendLayout();
            SuspendLayout();
            // 
            // txtSearch
            // 
            txtSearch.Location = new Point(12, 12);
            txtSearch.Name = "txtSearch";
            txtSearch.Size = new Size(250, 23);
            txtSearch.TabIndex = 0;
            // 
            // btnSearch
            // 
            btnSearch.Location = new Point(268, 12);
            btnSearch.Name = "btnSearch";
            btnSearch.Size = new Size(75, 23);
            btnSearch.TabIndex = 1;
            btnSearch.Text = "Search";
            btnSearch.UseVisualStyleBackColor = true;
            btnSearch.Click += btnSearch_Click;
            // 
            // lstSearchResults
            // 
            lstSearchResults.FormattingEnabled = true;
            lstSearchResults.Location = new Point(12, 41);
            lstSearchResults.Name = "lstSearchResults";
            lstSearchResults.Size = new Size(331, 94);
            lstSearchResults.Sorted = true;
            lstSearchResults.TabIndex = 2;
            lstSearchResults.SelectedIndexChanged += lstSearchResults_SelectedIndexChanged;
            // 
            // lstEpisodes
            // 
            lstEpisodes.FormattingEnabled = true;
            lstEpisodes.Location = new Point(12, 141);
            lstEpisodes.Name = "lstEpisodes";
            lstEpisodes.SelectionMode = SelectionMode.MultiExtended;
            lstEpisodes.Size = new Size(331, 94);
            lstEpisodes.TabIndex = 3;
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
            grpDetails.Location = new Point(349, 12);
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
            statusStrip1.Location = new Point(0, 244);
            statusStrip1.Name = "statusStrip1";
            statusStrip1.Size = new Size(692, 22);
            statusStrip1.TabIndex = 5;
            statusStrip1.Text = "statusStrip1";
            // 
            // toolStripStatusLabel1
            // 
            toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            toolStripStatusLabel1.Size = new Size(118, 17);
            toolStripStatusLabel1.Text = "toolStripStatusLabel1";
            // 
            // button1
            // 
            button1.Location = new Point(605, 212);
            button1.Name = "button1";
            button1.Size = new Size(75, 23);
            button1.TabIndex = 6;
            button1.Text = "Download";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // toolStripProgressBar1
            // 
            toolStripProgressBar1.Alignment = ToolStripItemAlignment.Right;
            toolStripProgressBar1.Name = "toolStripProgressBar1";
            toolStripProgressBar1.Size = new Size(100, 16);
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(692, 266);
            Controls.Add(button1);
            Controls.Add(statusStrip1);
            Controls.Add(grpDetails);
            Controls.Add(btnSearch);
            Controls.Add(txtSearch);
            Controls.Add(lstEpisodes);
            Controls.Add(lstSearchResults);
            Name = "Form1";
            Text = "Form1";
            grpDetails.ResumeLayout(false);
            grpDetails.PerformLayout();
            statusStrip1.ResumeLayout(false);
            statusStrip1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox txtSearch;
        private Button btnSearch;
        private ListBox lstSearchResults;
        private ListBox lstEpisodes;
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
        private Button button1;
        private ToolStripProgressBar toolStripProgressBar1;
    }
}
