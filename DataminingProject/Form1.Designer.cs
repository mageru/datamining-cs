namespace DataminingProject
{
    partial class Form1
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnFrequentItemSet = new System.Windows.Forms.Button();
            this.textMinimumSupport = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.cboFrequentItemAlgorithms = new System.Windows.Forms.ComboBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.btnBrowseDataFile = new System.Windows.Forms.Button();
            this.textDataFile = new System.Windows.Forms.TextBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.cboClusteringAlgorithms = new System.Windows.Forms.ComboBox();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.textResults = new System.Windows.Forms.TextBox();
            this.statusStrip = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripProgressBar1 = new System.Windows.Forms.ToolStripProgressBar();
            this.groupBox6 = new System.Windows.Forms.GroupBox();
            this.btnBrowseOutputDirectory = new System.Windows.Forms.Button();
            this.textOutputFile = new System.Windows.Forms.TextBox();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.groupBox5.SuspendLayout();
            this.statusStrip.SuspendLayout();
            this.groupBox6.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnFrequentItemSet);
            this.groupBox1.Controls.Add(this.textMinimumSupport);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.cboFrequentItemAlgorithms);
            this.groupBox1.Location = new System.Drawing.Point(12, 27);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(387, 157);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Frequent Itemset Mining Algorithms";
            // 
            // btnFrequentItemSet
            // 
            this.btnFrequentItemSet.Location = new System.Drawing.Point(9, 99);
            this.btnFrequentItemSet.Name = "btnFrequentItemSet";
            this.btnFrequentItemSet.Size = new System.Drawing.Size(372, 52);
            this.btnFrequentItemSet.TabIndex = 3;
            this.btnFrequentItemSet.Text = "GO";
            this.btnFrequentItemSet.UseVisualStyleBackColor = true;
            this.btnFrequentItemSet.Click += new System.EventHandler(this.btnFrequentItemSet_Click);
            // 
            // textMinimumSupport
            // 
            this.textMinimumSupport.Location = new System.Drawing.Point(129, 60);
            this.textMinimumSupport.Name = "textMinimumSupport";
            this.textMinimumSupport.Size = new System.Drawing.Size(79, 22);
            this.textMinimumSupport.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 63);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(117, 17);
            this.label1.TabIndex = 1;
            this.label1.Text = "Minimum Support";
            // 
            // cboFrequentItemAlgorithms
            // 
            this.cboFrequentItemAlgorithms.FormattingEnabled = true;
            this.cboFrequentItemAlgorithms.Location = new System.Drawing.Point(6, 24);
            this.cboFrequentItemAlgorithms.Name = "cboFrequentItemAlgorithms";
            this.cboFrequentItemAlgorithms.Size = new System.Drawing.Size(375, 24);
            this.cboFrequentItemAlgorithms.TabIndex = 0;
            this.cboFrequentItemAlgorithms.SelectedIndexChanged += new System.EventHandler(this.cboFrequentItemAlgorithms_SelectedIndexChanged);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.btnBrowseDataFile);
            this.groupBox2.Controls.Add(this.textDataFile);
            this.groupBox2.Location = new System.Drawing.Point(443, 27);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(699, 60);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Data File";
            // 
            // btnBrowseDataFile
            // 
            this.btnBrowseDataFile.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnBrowseDataFile.Location = new System.Drawing.Point(626, 18);
            this.btnBrowseDataFile.Name = "btnBrowseDataFile";
            this.btnBrowseDataFile.Size = new System.Drawing.Size(67, 23);
            this.btnBrowseDataFile.TabIndex = 1;
            this.btnBrowseDataFile.Text = "...";
            this.btnBrowseDataFile.UseVisualStyleBackColor = true;
            this.btnBrowseDataFile.Click += new System.EventHandler(this.btnBrowseDataFile_Click);
            // 
            // textDataFile
            // 
            this.textDataFile.Location = new System.Drawing.Point(12, 19);
            this.textDataFile.Name = "textDataFile";
            this.textDataFile.Size = new System.Drawing.Size(608, 22);
            this.textDataFile.TabIndex = 0;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.cboClusteringAlgorithms);
            this.groupBox3.Location = new System.Drawing.Point(12, 255);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(387, 58);
            this.groupBox3.TabIndex = 2;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Clustering Algorithms";
            // 
            // cboClusteringAlgorithms
            // 
            this.cboClusteringAlgorithms.FormattingEnabled = true;
            this.cboClusteringAlgorithms.Location = new System.Drawing.Point(6, 23);
            this.cboClusteringAlgorithms.Name = "cboClusteringAlgorithms";
            this.cboClusteringAlgorithms.Size = new System.Drawing.Size(375, 24);
            this.cboClusteringAlgorithms.TabIndex = 1;
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.comboBox1);
            this.groupBox4.Location = new System.Drawing.Point(12, 336);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(387, 58);
            this.groupBox4.TabIndex = 3;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Classification Algorithms";
            // 
            // comboBox1
            // 
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Location = new System.Drawing.Point(6, 23);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(375, 24);
            this.comboBox1.TabIndex = 1;
            // 
            // groupBox5
            // 
            this.groupBox5.Controls.Add(this.textResults);
            this.groupBox5.Location = new System.Drawing.Point(446, 178);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(696, 557);
            this.groupBox5.TabIndex = 4;
            this.groupBox5.TabStop = false;
            this.groupBox5.Text = "Results";
            // 
            // textResults
            // 
            this.textResults.Dock = System.Windows.Forms.DockStyle.Fill;
            this.textResults.Location = new System.Drawing.Point(3, 18);
            this.textResults.Multiline = true;
            this.textResults.Name = "textResults";
            this.textResults.Size = new System.Drawing.Size(690, 536);
            this.textResults.TabIndex = 0;
            // 
            // statusStrip
            // 
            this.statusStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel1,
            this.toolStripProgressBar1});
            this.statusStrip.Location = new System.Drawing.Point(0, 756);
            this.statusStrip.Name = "statusStrip";
            this.statusStrip.Size = new System.Drawing.Size(1154, 25);
            this.statusStrip.TabIndex = 5;
            this.statusStrip.Text = "statusStrip1";
            // 
            // toolStripStatusLabel1
            // 
            this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            this.toolStripStatusLabel1.Size = new System.Drawing.Size(151, 20);
            this.toolStripStatusLabel1.Text = "toolStripStatusLabel1";
            // 
            // toolStripProgressBar1
            // 
            this.toolStripProgressBar1.Name = "toolStripProgressBar1";
            this.toolStripProgressBar1.Size = new System.Drawing.Size(100, 19);
            // 
            // groupBox6
            // 
            this.groupBox6.Controls.Add(this.btnBrowseOutputDirectory);
            this.groupBox6.Controls.Add(this.textOutputFile);
            this.groupBox6.Location = new System.Drawing.Point(443, 97);
            this.groupBox6.Name = "groupBox6";
            this.groupBox6.Size = new System.Drawing.Size(699, 60);
            this.groupBox6.TabIndex = 6;
            this.groupBox6.TabStop = false;
            this.groupBox6.Text = "Output File";
            // 
            // btnBrowseOutputDirectory
            // 
            this.btnBrowseOutputDirectory.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnBrowseOutputDirectory.Location = new System.Drawing.Point(626, 18);
            this.btnBrowseOutputDirectory.Name = "btnBrowseOutputDirectory";
            this.btnBrowseOutputDirectory.Size = new System.Drawing.Size(67, 23);
            this.btnBrowseOutputDirectory.TabIndex = 1;
            this.btnBrowseOutputDirectory.Text = "...";
            this.btnBrowseOutputDirectory.UseVisualStyleBackColor = true;
            this.btnBrowseOutputDirectory.Click += new System.EventHandler(this.btnBrowseOutputDirectory_Click);
            // 
            // textOutputFile
            // 
            this.textOutputFile.Location = new System.Drawing.Point(12, 19);
            this.textOutputFile.Name = "textOutputFile";
            this.textOutputFile.Size = new System.Drawing.Size(608, 22);
            this.textOutputFile.TabIndex = 0;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1154, 781);
            this.Controls.Add(this.groupBox6);
            this.Controls.Add(this.statusStrip);
            this.Controls.Add(this.groupBox5);
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox4.ResumeLayout(false);
            this.groupBox5.ResumeLayout(false);
            this.groupBox5.PerformLayout();
            this.statusStrip.ResumeLayout(false);
            this.statusStrip.PerformLayout();
            this.groupBox6.ResumeLayout(false);
            this.groupBox6.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.ComboBox cboFrequentItemAlgorithms;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.ComboBox cboClusteringAlgorithms;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.GroupBox groupBox5;
        private System.Windows.Forms.StatusStrip statusStrip;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;
        private System.Windows.Forms.ToolStripProgressBar toolStripProgressBar1;
        private System.Windows.Forms.TextBox textResults;
        private System.Windows.Forms.Button btnBrowseDataFile;
        private System.Windows.Forms.TextBox textDataFile;
        private System.Windows.Forms.Button btnFrequentItemSet;
        private System.Windows.Forms.TextBox textMinimumSupport;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox6;
        private System.Windows.Forms.Button btnBrowseOutputDirectory;
        private System.Windows.Forms.TextBox textOutputFile;
    }
}

