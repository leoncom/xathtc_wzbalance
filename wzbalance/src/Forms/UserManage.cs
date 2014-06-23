using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace wzbalance.src.Forms
{
    public partial class UserManage : Form
    {
        private MainSheet mfrm;
        private User currUser;

        public UserManage()
        {
            this.InitializeComponent();
            base.StartPosition = FormStartPosition.CenterParent;
        }
        public void init()
        {
            this.mfrm = (MainSheet)base.Owner;
            this.inituser();
            this.initaction();
        }
        public void inituser()
        {
            this.comboBox1.Items.Clear();
            string sql = "select id,username,userpwd,role from users";
            DataTable data = this.mfrm.dbop.getData(sql);
            DataTableReader dataTableReader = data.CreateDataReader();
            while (dataTableReader.Read())
            {
                int @int = dataTableReader.GetInt32(0);
                string @string = dataTableReader.GetString(1);
                string string2 = dataTableReader.GetString(2);
                string string3 = dataTableReader.GetString(3);
                User item = new User(@int, @string, string2, string3);
                this.comboBox1.Items.Add(item);
            }
        }
        public void initaction()
        {
            string sql = "select * from actiondesc";
            DataTable data = this.mfrm.dbop.getData(sql);
            DataTableReader dataTableReader = data.CreateDataReader();
            while (dataTableReader.Read())
            {
                string @string = dataTableReader.GetString(1);
                string string2 = dataTableReader.GetString(2);
                Action item = new Action(@string, string2);
                this.checkedListBox1.Items.Add(item);
            }
        }
        private bool checkselected()
        {
            return this.comboBox1.SelectedIndex >= 0;
        }
        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            int selectedIndex = this.comboBox1.SelectedIndex;
            if (selectedIndex >= 0)
            {
                User user = (User)this.comboBox1.Items[selectedIndex];
                this.currUser = user;
                string role = user.getRole();
                for (int i = 0; i < this.checkedListBox1.Items.Count; i++)
                {
                    Action action = (Action)this.checkedListBox1.Items[i];
                    string value = action.getcode();
                    if (role.IndexOf(value) != -1)
                    {
                        this.checkedListBox1.SetItemChecked(i, true);
                    }
                    else
                    {
                        this.checkedListBox1.SetItemChecked(i, false);
                    }
                }
            }
        }
        private void button1_Click(object sender, EventArgs e)
        {
            if (!this.checkselected())
            {
                MessageBox.Show("请先选定用户", "提示", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            }
            else
            {
                string text = this.textBox1.Text;
                if (text == "")
                {
                    MessageBox.Show("密码不能为空", "提示", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                }
                else
                {
                    if (MessageBox.Show("确认修改" + this.currUser.getName() + "用户密码?", "确认", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        int id = this.currUser.getId();
                        string sql = string.Concat(new object[]
						{
							"update users set userpwd='",
							text,
							"' where id=",
							id
						});
                        int num = this.mfrm.dbop.updatesql(sql);
                        if (num != 1)
                        {
                            MessageBox.Show("密码修改失败,请稍后重试", "错误", MessageBoxButtons.OK, MessageBoxIcon.Hand);
                            LogWriter.LogEntry("error", string.Concat(new object[]
							{
								this.mfrm.getUserid(),
								"修改用户",
								this.currUser.getName(),
								"密码失败"
							}));
                        }
                        else
                        {
                            MessageBox.Show("密码修改成功", "操作成功", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                            LogWriter.LogEntry("info", string.Concat(new object[]
							{
								this.mfrm.getUserid(),
								"修改用户",
								this.currUser.getName(),
								"密码"
							}));
                        }
                    }
                }
            }
        }
        private void button2_Click(object sender, EventArgs e)
        {
            if (!this.checkselected())
            {
                MessageBox.Show("请先选定用户", "提示", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            }
            else
            {
                if (MessageBox.Show("确认修改" + this.currUser.getName() + "用户权限?", "确认", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    string text = "";
                    for (int i = 0; i < this.checkedListBox1.CheckedItems.Count; i++)
                    {
                        Action action = (Action)this.checkedListBox1.CheckedItems[i];
                        if (action.getcode() == "c")
                        {
                            if (DialogResult.Yes != MessageBox.Show("设置用户管理,允许该用户修改其他用户的权限和密码,确认?", "提示", MessageBoxButtons.YesNo, MessageBoxIcon.Question))
                            {
                                return;
                            }
                        }
                        text += action.getcode();
                    }
                    int id = this.currUser.getId();
                    string sql = string.Concat(new object[]
					{
						"update users set role='",
						text,
						"' where id=",
						id
					});
                    int num = this.mfrm.dbop.updatesql(sql);
                    if (num != 1)
                    {
                        MessageBox.Show("权限修改失败,请稍后重试", "错误", MessageBoxButtons.OK, MessageBoxIcon.Hand);
                        LogWriter.LogEntry("error", string.Concat(new object[]
						{
							this.mfrm.getUserid(),
							"修改用户",
							this.currUser.getName(),
							"权限失败"
						}));
                    }
                    else
                    {
                        MessageBox.Show("权限修改成功", "操作成功", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                        LogWriter.LogEntry("info", string.Concat(new object[]
						{
							this.mfrm.getUserid(),
							"修改用户",
							this.currUser.getName(),
							"权限"
						}));
                    }
                }
            }
        }
        private void button3_Click(object sender, EventArgs e)
        {
            if (!this.checkselected())
            {
                MessageBox.Show("请先选定用户", "提示", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            }
            else
            {
                if (DialogResult.Yes == MessageBox.Show("确定删除用户？", "提示", MessageBoxButtons.YesNo, MessageBoxIcon.Question))
                {
                    int id = this.currUser.getId();
                    string sql = "delete from users where id=" + id;
                    int num = this.mfrm.dbop.updatesql(sql);
                    if (num != 1)
                    {
                        MessageBox.Show("用户删除失败,请稍后重试", "错误", MessageBoxButtons.OK, MessageBoxIcon.Hand);
                        LogWriter.LogEntry("error", string.Concat(new object[]
						{
							this.mfrm.getUserid(),
							"删除用户",
							this.currUser.getName(),
							"失败"
						}));
                    }
                    else
                    {
                        MessageBox.Show("用户删除成功", "操作成功", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                        LogWriter.LogEntry("info", string.Concat(new object[]
						{
							this.mfrm.getUserid(),
							"删除用户",
							this.currUser.getName(),
							"成功"
						}));
                        this.currUser = null;
                        this.inituser();
                    }
                }
            }
        }
    }
}