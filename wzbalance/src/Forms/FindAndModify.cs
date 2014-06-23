using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace wzbalance.src.Forms
{
    public partial class FindAndModify : Form
    {
        private MainSheet mfrm;
        public FindAndModify()
        {
            this.InitializeComponent();
            base.StartPosition = FormStartPosition.CenterScreen;
        }
        public void init()
        {
            this.mfrm = (MainSheet)base.Owner;
            this.initHeaders();
        }
        public void initHeaders()
        {
            DataGridViewColumnCollection dataGridViewColumnCollection = this.mfrm.getcolumns();
            for (int i = 0; i < dataGridViewColumnCollection.Count; i++)
            {
                string name = dataGridViewColumnCollection[i].Name;
                string headerText = dataGridViewColumnCollection[i].HeaderText;
                HeaderDes item = new HeaderDes(name, headerText);
                this.comboBox1.Items.Add(item);
            }
        }
        private void button1_Click(object sender, EventArgs e)
        {
            if (this.comboBox1.SelectedIndex == -1)
            {
                MessageBox.Show("����ѡ��һ��", "��ʾ", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                this.comboBox1.Focus();
            }
            else
            {
                string text = this.textBox1.Text.Trim();
                string text2 = this.textBox2.Text.Trim();
                if (text == "")
                {
                    MessageBox.Show("�������ݲ���Ϊ��", "��ʾ", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                    this.textBox1.Focus();
                }
                else
                {
                    if (text2 == "")
                    {
                        MessageBox.Show("�滻���ݲ���Ϊ��", "��ʾ", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                        this.textBox2.Focus();
                    }
                    else
                    {
                        HeaderDes headerDes = (HeaderDes)this.comboBox1.SelectedItem;
                        string text3 = string.Concat(new string[]
						{
							"update balance set ",
							headerDes.getcolumn(),
							"='",
							text2,
							"' where ",
							headerDes.getcolumn(),
							"='",
							text,
							"'"
						});
                        int num = this.mfrm.dbop.updatesql(text3);
                        if (num > 0)
                        {
                            MessageBox.Show("���ɹ��滻" + num + "��", "��ʾ", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                            this.mfrm.updatelist("");
                        }
                        else
                        {
                            if (num == 0)
                            {
                                MessageBox.Show("δ�ҵ���Ҫ�滻����", "��ʾ", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                            }
                            else
                            {
                                MessageBox.Show("���ݿ��쳣�����Ժ�����", "��ʾ", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                                LogWriter.LogEntry("error", string.Concat(new object[]
								{
									"update sql return ",
									num,
									", msg:[sql] ",
									text3
								}));
                            }
                        }
                        base.Close();
                    }
                }
            }
        }
    }
}