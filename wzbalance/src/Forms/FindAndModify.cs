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
                MessageBox.Show("必须选择一列", "提示", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                this.comboBox1.Focus();
            }
            else
            {
                string text = this.textBox1.Text.Trim();
                string text2 = this.textBox2.Text.Trim();
                if (text == "")
                {
                    MessageBox.Show("查找内容不能为空", "提示", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                    this.textBox1.Focus();
                }
                else
                {
                    if (text2 == "")
                    {
                        MessageBox.Show("替换内容不能为空", "提示", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
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
                            MessageBox.Show("共成功替换" + num + "处", "提示", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                            this.mfrm.updatelist("");
                        }
                        else
                        {
                            if (num == 0)
                            {
                                MessageBox.Show("未找到需要替换的项", "提示", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                            }
                            else
                            {
                                MessageBox.Show("数据库异常，请稍后重试", "提示", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
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