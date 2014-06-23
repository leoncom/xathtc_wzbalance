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
                MessageBox.Show("����ѡ���û�", "��ʾ", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            }
            else
            {
                string text = this.textBox1.Text;
                if (text == "")
                {
                    MessageBox.Show("���벻��Ϊ��", "��ʾ", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                }
                else
                {
                    if (MessageBox.Show("ȷ���޸�" + this.currUser.getName() + "�û�����?", "ȷ��", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
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
                            MessageBox.Show("�����޸�ʧ��,���Ժ�����", "����", MessageBoxButtons.OK, MessageBoxIcon.Hand);
                            LogWriter.LogEntry("error", string.Concat(new object[]
							{
								this.mfrm.getUserid(),
								"�޸��û�",
								this.currUser.getName(),
								"����ʧ��"
							}));
                        }
                        else
                        {
                            MessageBox.Show("�����޸ĳɹ�", "�����ɹ�", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                            LogWriter.LogEntry("info", string.Concat(new object[]
							{
								this.mfrm.getUserid(),
								"�޸��û�",
								this.currUser.getName(),
								"����"
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
                MessageBox.Show("����ѡ���û�", "��ʾ", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            }
            else
            {
                if (MessageBox.Show("ȷ���޸�" + this.currUser.getName() + "�û�Ȩ��?", "ȷ��", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    string text = "";
                    for (int i = 0; i < this.checkedListBox1.CheckedItems.Count; i++)
                    {
                        Action action = (Action)this.checkedListBox1.CheckedItems[i];
                        if (action.getcode() == "c")
                        {
                            if (DialogResult.Yes != MessageBox.Show("�����û�����,������û��޸������û���Ȩ�޺�����,ȷ��?", "��ʾ", MessageBoxButtons.YesNo, MessageBoxIcon.Question))
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
                        MessageBox.Show("Ȩ���޸�ʧ��,���Ժ�����", "����", MessageBoxButtons.OK, MessageBoxIcon.Hand);
                        LogWriter.LogEntry("error", string.Concat(new object[]
						{
							this.mfrm.getUserid(),
							"�޸��û�",
							this.currUser.getName(),
							"Ȩ��ʧ��"
						}));
                    }
                    else
                    {
                        MessageBox.Show("Ȩ���޸ĳɹ�", "�����ɹ�", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                        LogWriter.LogEntry("info", string.Concat(new object[]
						{
							this.mfrm.getUserid(),
							"�޸��û�",
							this.currUser.getName(),
							"Ȩ��"
						}));
                    }
                }
            }
        }
        private void button3_Click(object sender, EventArgs e)
        {
            if (!this.checkselected())
            {
                MessageBox.Show("����ѡ���û�", "��ʾ", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            }
            else
            {
                if (DialogResult.Yes == MessageBox.Show("ȷ��ɾ���û���", "��ʾ", MessageBoxButtons.YesNo, MessageBoxIcon.Question))
                {
                    int id = this.currUser.getId();
                    string sql = "delete from users where id=" + id;
                    int num = this.mfrm.dbop.updatesql(sql);
                    if (num != 1)
                    {
                        MessageBox.Show("�û�ɾ��ʧ��,���Ժ�����", "����", MessageBoxButtons.OK, MessageBoxIcon.Hand);
                        LogWriter.LogEntry("error", string.Concat(new object[]
						{
							this.mfrm.getUserid(),
							"ɾ���û�",
							this.currUser.getName(),
							"ʧ��"
						}));
                    }
                    else
                    {
                        MessageBox.Show("�û�ɾ���ɹ�", "�����ɹ�", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                        LogWriter.LogEntry("info", string.Concat(new object[]
						{
							this.mfrm.getUserid(),
							"ɾ���û�",
							this.currUser.getName(),
							"�ɹ�"
						}));
                        this.currUser = null;
                        this.inituser();
                    }
                }
            }
        }
    }
}