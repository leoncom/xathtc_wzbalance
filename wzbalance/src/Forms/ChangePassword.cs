using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace wzbalance.src.Forms
{
    public partial class ChangePassword : Form
    {
        public MainSheet mfrm;

        public ChangePassword()
        {
            this.InitializeComponent();
            base.StartPosition = FormStartPosition.CenterParent;
        }
        public void init()
        {
            this.mfrm = (MainSheet)base.Owner;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (this.oldpwd.Text == "")
            {
                MessageBox.Show("原密码不能为空", "提示", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            }
            if (this.pwd1.Text == "")
            {
                MessageBox.Show("新密码不能为空", "提示", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            }
            if (this.pwd2.Text == "")
            {
                MessageBox.Show("再输入一遍密码", "提示", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            }
            if (this.pwd1.Text != this.pwd2.Text)
            {
                MessageBox.Show("两次密码输入不一致", "提示", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            }
            string text = this.oldpwd.Text;
            string pwd = this.mfrm.getPwd();
            if (text != pwd)
            {
                MessageBox.Show("原密码输入错误", "错误", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            }
            else
            {
                string text2 = this.pwd1.Text;
                int userid = this.mfrm.getUserid();
                string sql = string.Concat(new object[]
				{
					"update users set userpwd='",
					text2,
					"' where id=",
					userid
				});
                int num = this.mfrm.dbop.updatesql(sql);
                if (num != 1)
                {
                    MessageBox.Show("密码更新失败，请稍后重试", "错误", MessageBoxButtons.OK, MessageBoxIcon.Hand);
                    LogWriter.LogEntry("error", "密码更新失败,uid=" + userid);
                }
                else
                {
                    MessageBox.Show("密码更新成功", "成功", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                    LogWriter.LogEntry("info", "密码更新,uid=" + userid);
                }
            }
        }
    }
}