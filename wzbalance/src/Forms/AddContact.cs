using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace wzbalance.src.Forms
{
    public partial class AddContact : Form
    {
        private MainSheet mfrm;
        private int updateid;
        private ContactsManage mcm;

        public AddContact()
        {
            this.InitializeComponent();
        }
        public void init()
        {
            this.mfrm = (MainSheet)base.Owner;
            this.initContactName("sellman");
            this.initContactName("buyman");
            this.updateid = 0;
        }
        public void editmode(int id, ContactsManage cm)
        {
            this.mcm = cm;
            string sql = "select * from contacts where id=" + id;
            DataTable data = this.mfrm.dbop.getData(sql);
            DataTableReader dataTableReader = data.CreateDataReader();
            if (dataTableReader.Read())
            {
                this.updateid = id;
                string @string = dataTableReader.GetString(1);
                string string2 = dataTableReader.GetString(2);
                string string3 = dataTableReader.GetString(3);
                string string4 = dataTableReader.GetString(4);
                string string5 = dataTableReader.GetString(5);
                string string6 = dataTableReader.GetString(6);
                string string7 = dataTableReader.GetString(7);
                string string8 = dataTableReader.GetString(8);
                string string9 = dataTableReader.GetString(9);
                this.comboBox1.Text = @string;
                this.person1.Text = string2;
                this.phone1.Text = string3;
                this.person2.Text = string4;
                this.phone2.Text = string5;
                this.person3.Text = string6;
                this.phone3.Text = string7;
                this.address.Text = string8;
                this.zipcode.Text = string9;
            }
        }
        public void initContactName(string columnname)
        {
            string sql = string.Concat(new string[]
			{
				"select ",
				columnname,
				", count(",
				columnname,
				") as cnt from balance where ",
				columnname,
				" not in (select name from contacts) group by ",
				columnname,
				" order by cnt desc"
			});
            DataTable data = this.mfrm.dbop.getData(sql);
            DataTableReader dataTableReader = data.CreateDataReader();
            while (dataTableReader.Read())
            {
                string text = dataTableReader.GetValue(0).ToString();
                if (text != "")
                {
                    this.comboBox1.Items.Add(text);
                }
            }
        }
        private void button1_Click(object sender, EventArgs e)
        {
            string text = this.comboBox1.Text;
            if (this.Text == "")
            {
                MessageBox.Show("必须输入联系单位名称", "提示", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            }
            else
            {
                string text2 = this.person1.Text;
                string text3 = this.person2.Text;
                string text4 = this.person3.Text;
                string text5 = this.phone1.Text;
                string text6 = this.phone2.Text;
                string text7 = this.phone3.Text;
                string text8 = this.address.Text;
                string text9 = this.zipcode.Text;
                string sql;
                if (this.updateid == 0)
                {
                    sql = string.Concat(new string[]
					{
						"insert into contacts(name,person1,phone1,person2,phone2,person3,phone3,address,zip) values('",
						text,
						"','",
						text2,
						"','",
						text5,
						"','",
						text3,
						"','",
						text6,
						"','",
						text4,
						"','",
						text7,
						"','",
						text8,
						"','",
						text9,
						"')"
					});
                }
                else
                {
                    sql = string.Concat(new object[]
					{
						"update contacts set name='",
						text,
						"',person1='",
						text2,
						"',phone1='",
						text5,
						"',person2='",
						text3,
						"',phone2='",
						text6,
						"',person3='",
						text4,
						"',phone3='",
						text7,
						"',address='",
						text8,
						"',zip='",
						text9,
						"' where id=",
						this.updateid
					});
                }
                int num = this.mfrm.dbop.updatesql(sql);
                if (num >= 0)
                {
                    if (this.updateid == 0)
                    {
                        MessageBox.Show("联系人添加成功", "提示", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                    }
                    else
                    {
                        MessageBox.Show("联系人修改成功", "提示", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                        this.mcm.initlist("");
                    }
                }
                else
                {
                    MessageBox.Show("联系人添加失败，请重试", "提示", MessageBoxButtons.OK, MessageBoxIcon.Hand);
                }
                base.Dispose();
            }
        }
    }
}