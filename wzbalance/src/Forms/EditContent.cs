using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Microsoft.VisualBasic;

namespace wzbalance.src.Forms
{
    public partial class EditContent : Form
    {
        public class OptionEditItem
        {
            private string name;
            private string text;
            private string option;
            private int id;
            public OptionEditItem(int id, string nm, string tx, string op)
            {
                this.id = id;
                this.name = nm;
                this.text = tx;
                this.option = op;
            }
            public int getID()
            {
                return this.id;
            }
            public string getName()
            {
                return this.name;
            }
            public void setName(string nm)
            {
                this.name = nm;
            }
            public string getText()
            {
                return this.text;
            }
            public void setText(string tx)
            {
                this.text = tx;
            }
            public string getOption()
            {
                return this.option;
            }
            public void setOption(string op)
            {
                this.option = op;
            }
            public override string ToString()
            {
                return this.text;
            }
        }

        private MainSheet mfrm;

        public EditContent()
        {
            this.InitializeComponent();
        }
        public void init()
        {
            this.mfrm = (MainSheet)base.Owner;
            string sql = "select id, columnname, display, append from tbdesc where type = 5";
            DataTable data = this.mfrm.dbop.getData(sql);
            DataTableReader dataTableReader = data.CreateDataReader();
            while (dataTableReader.Read())
            {
                int @int = dataTableReader.GetInt32(0);
                string @string = dataTableReader.GetString(1);
                string string2 = dataTableReader.GetString(2);
                string string3 = dataTableReader.GetString(3);
                EditContent.OptionEditItem item = new EditContent.OptionEditItem(@int, @string, string2, string3);
                this.comboBox1.Items.Add(item);
            }
        }
        public void editmode(string displayname)
        {
            this.comboBox1.SelectedItem = displayname;
        }
        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.listBox1.Items.Clear();
            int selectedIndex = this.comboBox1.SelectedIndex;
            EditContent.OptionEditItem optionEditItem = (EditContent.OptionEditItem)this.comboBox1.Items[selectedIndex];
            string option = optionEditItem.getOption();
            if (option != null && option != "")
            {
                string[] array = option.Split(new char[]
				{
					','
				});
                for (int i = 0; i < array.Length; i++)
                {
                    this.listBox1.Items.Add(array[i]);
                }
            }
        }
        private void button1_Click(object sender, EventArgs e)
        {
            int selectedIndex = this.comboBox1.SelectedIndex;
            if (selectedIndex == -1)
            {
                MessageBox.Show("����ѡ��һ�����", "��ʾ", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            }
            else
            {
                EditContent.OptionEditItem opitem = (EditContent.OptionEditItem)this.comboBox1.Items[selectedIndex];
                string text = Interaction.InputBox("������ѡ��", "��ѡ��", "�����������µ�ѡ������", 500, 200);
                if (text.Length != 0)
                {
                    if (this.listBox1.Items.IndexOf(text) != -1)
                    {
                        MessageBox.Show("��ѡ���Ѿ�����", "��ʾ", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                    }
                    else
                    {
                        this.listBox1.Items.Add(text);
                        int num = this.updateContent(opitem);
                        if (num == 1)
                        {
                            MessageBox.Show("ѡ����ӳɹ�", "��ʾ", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                        }
                        else
                        {
                            MessageBox.Show("ѡ�����ʧ��", "����", MessageBoxButtons.OK, MessageBoxIcon.Hand);
                        }
                    }
                }
            }
        }
        private void button3_Click(object sender, EventArgs e)
        {
            base.Dispose();
        }

        public int updateContent(EditContent.OptionEditItem opitem)
        {
            string[] array = new string[this.listBox1.Items.Count];
            for (int i = 0; i < this.listBox1.Items.Count; i++)
            {
                array[i] = (string)this.listBox1.Items[i];
            }
            string text = string.Join(",", array);
            opitem.setOption(text);
            string sql = string.Concat(new object[]
			{
				"update tbdesc set append='",
				text,
				"' where id='",
				opitem.getID(),
				"'"
			});
            return this.mfrm.dbop.updatesql(sql);
        }
        private void button2_Click(object sender, EventArgs e)
        {
            int selectedIndex = this.comboBox1.SelectedIndex;
            if (selectedIndex == -1)
            {
                MessageBox.Show("����ѡ��һ�����", "��ʾ", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            }
            else
            {
                int selectedIndex2 = this.listBox1.SelectedIndex;
                if (selectedIndex2 == -1)
                {
                    MessageBox.Show("����ѡ��һ��ѡ��", "��ʾ", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                }
                else
                {
                    EditContent.OptionEditItem optionEditItem = (EditContent.OptionEditItem)this.comboBox1.Items[selectedIndex];
                    string text = (string)this.listBox1.Items[selectedIndex2];
                    string name = optionEditItem.getName();
                    string sql = string.Concat(new string[]
					{
						"select * from balance where ",
						name,
						"='",
						text,
						"'"
					});
                    DataTable data = this.mfrm.dbop.getData(sql);
                    if (data.Rows.Count > 0)
                    {
                        MessageBox.Show("��¼���и�ѡ����������ɾ��", "����", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    }
                    else
                    {
                        this.listBox1.Items.RemoveAt(selectedIndex2);
                        int num = this.updateContent(optionEditItem);
                        if (num == 1)
                        {
                            MessageBox.Show("ѡ��ɾ���ɹ�", "��ʾ", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                        }
                        else
                        {
                            MessageBox.Show("ѡ��ɾ��ʧ��", "����", MessageBoxButtons.OK, MessageBoxIcon.Hand);
                        }
                    }
                }
            }
        }
        private void button4_Click(object sender, EventArgs e)
        {
            int selectedIndex = this.comboBox1.SelectedIndex;
            if (selectedIndex == -1)
            {
                MessageBox.Show("����ѡ��һ�����", "��ʾ", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            }
            else
            {
                int selectedIndex2 = this.listBox1.SelectedIndex;
                if (selectedIndex2 == -1)
                {
                    MessageBox.Show("����ѡ��һ��ѡ��", "��ʾ", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                }
                else
                {
                    EditContent.OptionEditItem opitem = (EditContent.OptionEditItem)this.comboBox1.Items[selectedIndex];
                    string text = (string)this.listBox1.Items[selectedIndex2];
                    string text2 = Interaction.InputBox("������ѡ����", "�޸�ѡ��", text, 500, 200);
                    if (text2.Length != 0)
                    {
                        if (this.listBox1.Items.IndexOf(text2) != -1)
                        {
                            MessageBox.Show("��ѡ���Ѿ�����", "��ʾ", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                        }
                        else
                        {
                            this.listBox1.Items[selectedIndex2] = text2;
                            this.updateOption(opitem, text, text2);
                            int num = this.updateContent(opitem);
                            if (num == 1)
                            {
                                MessageBox.Show("ѡ���޸ĳɹ�", "��ʾ", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                            }
                            else
                            {
                                MessageBox.Show("ѡ���޸�ʧ��", "����", MessageBoxButtons.OK, MessageBoxIcon.Hand);
                            }
                        }
                    }
                }
            }
        }
        private void updateOption(EditContent.OptionEditItem opitem, string oldStr, string newStr)
        {
            string name = opitem.getName();
            string sql = string.Concat(new string[]
			{
				"update balance set ",
				name,
				"='",
				newStr,
				"' where ",
				name,
				"='",
				oldStr,
				"'"
			});
            int num = this.mfrm.dbop.updatesql(sql);
            if (num < 0)
            {
                MessageBox.Show("����ԭ��¼��ѡ�����", "����", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            else
            {
                if (num > 0)
                {
                    this.mfrm.updatelist("");
                }
            }
        }
    }
}