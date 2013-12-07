using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DataminingProject.Algorithms;
using System.IO;

namespace DataminingProject
{
    public partial class Form1 : Form
    {
        private const int ALGORITHM_APRIORI = 0;
        private const int ALGORITHM_FPGROWTH = 1;
        private const int ALGORITHM_ECLAT = 2;
        private const int ALGORITHM_APRIORICLOSE = 3;
        
        private int _selectedAlgorithm = -1;
        private BackgroundWorker _bgWorker = new BackgroundWorker(); //the alogrithms will run on separate thread so we can update the ui asynchronously
        private System.Diagnostics.Stopwatch _stopwatch = new System.Diagnostics.Stopwatch();
        
        public Form1()
        {
            InitializeComponent();
            LoadFrequentItemsetAlgorithms();
            
            _bgWorker.WorkerReportsProgress = true;
            _bgWorker.ProgressChanged += _bgWorker_ProgressChanged;
            
        }

        void _bgWorker_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            this.textResults.AppendText(e.UserState.ToString());
            
        }

        private void LoadFrequentItemsetAlgorithms()
        {
            cboFrequentItemAlgorithms.Items.Add("Apriori");
            cboFrequentItemAlgorithms.Items.Add("FP-growth");
            cboFrequentItemAlgorithms.Items.Add("ECLAT");
            cboFrequentItemAlgorithms.Items.Add("AprioriClose");
        }

        private void cboFrequentItemAlgorithms_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (cboFrequentItemAlgorithms.SelectedIndex)
            {
                case ALGORITHM_APRIORI: //Apriori
                    _selectedAlgorithm = ALGORITHM_APRIORI;
                    break;
                case ALGORITHM_FPGROWTH: //FP-growth
                    _selectedAlgorithm = ALGORITHM_FPGROWTH;
                    break;
                case ALGORITHM_ECLAT: //ECLAT
                    _selectedAlgorithm = ALGORITHM_ECLAT;
                    break;
                case ALGORITHM_APRIORICLOSE: //Apriori Close
                    _selectedAlgorithm = ALGORITHM_APRIORICLOSE;
                    break;
            }            
        }


        private void CallApriori (double support)
        {
            int result = 0;
            
            Apriori algorithm = new Apriori(support);
            algorithm.MileStoneEvent += algorithm_MileStoneEvent;
            algorithm.InputDataFile = textDataFile.Text;
            algorithm.Process();
        }

        private void CallAprioriClose(double support)
        {
            int result = 0;

            AprioriClose algorithm = new AprioriClose(support);
            algorithm.MileStoneEvent += algorithm_MileStoneEvent;
            algorithm.InputDataFile = textDataFile.Text;
            algorithm.Process();
        }

        private void CallFPGrowth(double support)
        {
            int result = 0;

            FPGrowth algorithm = new FPGrowth(support);
            algorithm.MileStoneEvent += algorithm_MileStoneEvent;
            algorithm.InputDataFile = textDataFile.Text;
            algorithm.Process();
        }

        void algorithm_MileStoneEvent(string output)
        {
            _bgWorker.ReportProgress(0, output);
        }

        private void btnFrequentItemSet_Click(object sender, EventArgs e)
        {
            double support = double.Parse(textMinimumSupport.Text);

            if (!(textDataFile.Text.Trim() != string.Empty && System.IO.File.Exists(textDataFile.Text.Trim())))
            {
                MessageBox.Show("Please choose a valid input data file.");
                return;
            }

            if (support != -999)
            {
                _stopwatch.Reset();
                _stopwatch.Start();
                
                switch (_selectedAlgorithm)
                {
                    case ALGORITHM_APRIORI:
                        CallApriori(support);
                        break;
                    case ALGORITHM_FPGROWTH:
                        CallFPGrowth(support);
                        break;
                    case ALGORITHM_ECLAT:
                        break;
                    case ALGORITHM_APRIORICLOSE:
                        CallAprioriClose(support);
                        break;
                }
                _stopwatch.Stop();
                
                string totalTime = string.Format("{0} minutes {1} seconds {2} milliseconds", _stopwatch.Elapsed.Minutes, _stopwatch.Elapsed.Seconds, _stopwatch.Elapsed.Milliseconds);

                textResults.AppendText("\n");
                textResults.AppendText(Common.FormatOutputWithNewLine(string.Concat("Execution Time: ",totalTime)));
            }
            else
            {
                MessageBox.Show("The minimum support must be a positive integer.");
            }
        }

        private void btnBrowseDataFile_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog dlg = new OpenFileDialog())
            {
                dlg.ShowDialog();
                textDataFile.Text = dlg.FileName;
            }
        }

    

        private void btnBrowseOutputDirectory_Click(object sender, EventArgs e)
        {
            using (FolderBrowserDialog dlg = new FolderBrowserDialog())
            {
                dlg.ShowDialog();
                textOutputFile.Text = dlg.SelectedPath;
   
            }
        }
    }
}
