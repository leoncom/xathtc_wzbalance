using System;
using System.Reflection;
using System.Windows.Forms;
using System.Drawing;

namespace wzbalance
{
    public partial class AboutForm : Form
    {
        public AboutForm()
        {
            this.InitializeComponent();
            this.init();
            this.richTextBox1.BackColor = Color.White;
            base.StartPosition = FormStartPosition.CenterScreen;
        }
        public void init()
        {
            string text = Assembly.GetExecutingAssembly().GetName().Version.ToString();
            this.richTextBox1.Text = string.Concat(new string[]
			{
				"西安太航特材有限公司物资平衡表\n版本号: ",
				text,
				"\nLast Updated: ",
				DateTime.Now.ToShortDateString(),
				"\nCopyright©2011 XATHTC.\nAll Rights Reserved\n\n"
			});
            this.richTextBox1.AppendText("有任何问题请发送Email至:\nxjtudaniel@gmail.com");
        }
        private void button1_Click_1(object sender, EventArgs e)
        {
            base.Dispose();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            base.Dispose();
        }
    }
}