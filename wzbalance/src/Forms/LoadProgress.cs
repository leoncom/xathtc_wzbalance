using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Threading;

namespace wzbalance.src.Forms
{
    public partial class LoadProgress : Form
    {
        private delegate void setProgressValue(int val);

        public LoadProgress()
        {
            this.InitializeComponent();
            this.progressBar1.Maximum = 5;
            base.ControlBox = false;
            Thread thread = new Thread(new ThreadStart(this.runProcess));
            thread.Start();
        }

        private void setValue(int val)
        {
            if (this.progressBar1.InvokeRequired)
            {
                this.progressBar1.Invoke((MethodInvoker)delegate()
                {
                    this.progressBar1.Value = val % this.progressBar1.Maximum;
                });
            }
            else
            {
                this.progressBar1.Value = val % this.progressBar1.Maximum;
            }
        }

        private void runProcess()
        {
            int num = 1;
            while (true)
            {
                LoadProgress.setProgressValue setProgressValue = new LoadProgress.setProgressValue(this.setValue);
                setProgressValue(num);
                num++;
                Thread.Sleep(500);
            }
        }
    }
}