using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace wzbalance.src.Forms
{
    public partial class AddUser : Form
    {
        private MainSheet mfrm;

        public AddUser()
        {
            this.InitializeComponent();
            base.StartPosition = FormStartPosition.CenterParent;
        }
        public void init()
        {
            this.mfrm = (MainSheet)base.Owner;
            this.getactions();
        }
        public void getactions()
        {
            string sql = "select * from actiondesc";
            DataTable data = this.mfrm.dbop.getData(sql);
            DataTableReader dataTableReader = data.CreateDataReader();
            while (dataTableReader.Read())
            {
                string @string = dataTableReader.GetString(2);
                string string2 = dataTableReader.GetString(1);
                Action item = new Action(string2, @string);
                this.rolecheckbox.Items.Add(item);
            }
        }
        private void button2_Click(object sender, EventArgs e)
        {
            if (this.username.Text == "")
            {
                MessageBox.Show("用户名不能为空", "提示", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            }
            if (this.pwd1.Text == "")
            {
                MessageBox.Show("密码不能为空", "提示", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            }
            if (this.pwd2.Text == "")
            {
                MessageBox.Show("再输入一遍密码", "提示", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            }
            if (this.pwd1.Text != this.pwd2.Text)
            {
                MessageBox.Show("两次密码输入不一致", "提示", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            }
            string text = this.username.Text;
            string text2 = this.pwd2.Text;
            string text3 = "";
            for (int i = 0; i < this.rolecheckbox.CheckedItems.Count; i++)
            {
                Action action = (Action)this.rolecheckbox.CheckedItems[i];
                if (action.getcode() == "c")
                {
                    if (DialogResult.Yes != MessageBox.Show("设置用户管理,允许该用户修改其他用户的权限和密码,确认?", "提示", MessageBoxButtons.YesNo, MessageBoxIcon.Question))
                    {
                        return;
                    }
                }
                text3 += action.getcode();
            }
            string sql = "select * from users where username='" + text + "'";
            DataTable data = this.mfrm.dbop.getData(sql);
            if (data.Rows.Count != 0)
            {
                MessageBox.Show("该用户名已经存在，不得重复添加", "错误", MessageBoxButtons.OK, MessageBoxIcon.Hand);
                return;
            }
            sql = string.Concat(new string[]
			{
				"insert into users(username,userpwd,role) values('",
				text,
				"','",
				text2,
				"','",
				text3,
				"')"
			});
            int num = this.mfrm.dbop.updatesql(sql);
            if (num != 1)
            {
                MessageBox.Show("添加用户失败，具体消息请查看日志", "错误", MessageBoxButtons.OK, MessageBoxIcon.Hand);
                LogWriter.LogEntry("error", "添加用户失败，sql返回值" + num);
                return;
            }
            MessageBox.Show("添加用户成功", "成功", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            base.Close();
        }
    }
}