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
                MessageBox.Show("ԭ���벻��Ϊ��", "��ʾ", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            }
            if (this.pwd1.Text == "")
            {
                MessageBox.Show("�����벻��Ϊ��", "��ʾ", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            }
            if (this.pwd2.Text == "")
            {
                MessageBox.Show("������һ������", "��ʾ", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            }
            if (this.pwd1.Text != this.pwd2.Text)
            {
                MessageBox.Show("�����������벻һ��", "��ʾ", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            }
            string text = this.oldpwd.Text;
            string pwd = this.mfrm.getPwd();
            if (text != pwd)
            {
                MessageBox.Show("ԭ�����������", "����", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
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
                    MessageBox.Show("�������ʧ�ܣ����Ժ�����", "����", MessageBoxButtons.OK, MessageBoxIcon.Hand);
                    LogWriter.LogEntry("error", "�������ʧ��,uid=" + userid);
                }
                else
                {
                    MessageBox.Show("������³ɹ�", "�ɹ�", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                    LogWriter.LogEntry("info", "�������,uid=" + userid);
                }
            }
        }
    }
}