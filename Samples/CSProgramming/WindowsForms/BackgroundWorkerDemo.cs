using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Windows.Forms;

namespace WindowsForms
{
    partial class BackgroundWorkerDemo : Form
    {
        public BackgroundWorkerDemo()
        {
            InitializeComponent();
        }

        public static void Main()
        {
            Application.Run(new BackgroundWorkerDemo());
        }

        private void button1_Click(object sender, EventArgs e) {
            this.button1.Enabled = false;
            this.button2.Enabled = true;
            this.backgroundWorker1.RunWorkerAsync();
        }

        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e) {
            // This method will run on a thread other than the UI thread.
            // Be sure not to manipulate any Windows Forms controls created
            // on the UI thread from this method.
            e.Result = this.Calculate(sender as BackgroundWorker, e);
        }

        private long Calculate(BackgroundWorker instance, DoWorkEventArgs e)
        {
            for (int i = 0; i < 100; i++)
            {
                if (instance.CancellationPending)
                {
                    e.Cancel = true;
                    break;
                }
                else
                {
                    System.Threading.Thread.Sleep(100);
                    instance.ReportProgress(i);
                }
            }
            return 0L;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.backgroundWorker1.CancelAsync();
            this.button2.Enabled = false;
        }

        private void backgroundWorker1_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            //Data marshalled back to UI thread so it is safe to update the progress bar here
            this.progressBar1.Value = e.ProgressPercentage;
        }

        private void backgroundWorker1_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            this.button1.Enabled = true;
            this.progressBar1.Value = 0;
            this.label1.Text = "BackgroundWorker Completed!";
        }
    }
}