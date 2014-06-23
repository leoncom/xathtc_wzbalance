using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace wzbalance.src.Forms
{
    public partial class PrintTemplate : Form
    {
        private Font curr_font;
        private Font curr_titlefont;
        private string curr_title;
        private string curr_dislists;
        private MainSheet mfrm;
        private int id;

        public PrintTemplate()
        {
            this.InitializeComponent();
        }
        public void init()
        {
            this.mfrm = (MainSheet)base.Owner;
            this.listBox1.Items.Clear();
            this.listBox2.Items.Clear();
            this.initFullList();
            this.id = 0;
            this.templateName.Focus();
        }
        public void initFullList()
        {
            DataGridViewColumnCollection dataGridViewColumnCollection = this.mfrm.getcolumns();
            for (int i = 0; i < dataGridViewColumnCollection.Count; i++)
            {
                string name = dataGridViewColumnCollection[i].Name;
                string headerText = dataGridViewColumnCollection[i].HeaderText;
                HeaderDes item = new HeaderDes(name, headerText);
                this.listBox1.Items.Add(item);
            }
        }
        public void initVisiableList()
        {
            DataGridViewColumnCollection dataGridViewColumnCollection = this.mfrm.getcolumns();
            int[] array = new int[dataGridViewColumnCollection.Count];
            for (int i = 0; i < dataGridViewColumnCollection.Count; i++)
            {
                int displayIndex = dataGridViewColumnCollection[i].DisplayIndex;
                array[displayIndex] = i;
            }
            for (int i = 0; i < dataGridViewColumnCollection.Count; i++)
            {
                int index = array[i];
                if (dataGridViewColumnCollection[index].Visible)
                {
                    string name = dataGridViewColumnCollection[index].Name;
                    int index2 = this.FindHeaderRes(this.listBox1, name);
                    this.swapHeaderItems(this.listBox1, this.listBox2, index2);
                }
            }
        }
        public bool setEdit(int eid)
        {
            this.id = eid;
            bool result;
            if (this.id != 0)
            {
                string sql = "select * from template where id=" + this.id;
                DataTable data = this.mfrm.dbop.getData(sql);
                DataTableReader dataTableReader = data.CreateDataReader();
                if (!dataTableReader.Read())
                {
                    dataTableReader.Close();
                    result = false;
                    return result;
                }
                this.curr_title = dataTableReader.GetString(dataTableReader.GetOrdinal("name"));
                this.curr_dislists = dataTableReader.GetString(dataTableReader.GetOrdinal("discolumns"));
                this.curr_titlefont = CommonTools.StrToFont(dataTableReader.GetString(dataTableReader.GetOrdinal("titlefont")));
                this.curr_font = CommonTools.StrToFont(dataTableReader.GetString(dataTableReader.GetOrdinal("contentfont")));
                this.templateName.Text = this.curr_title;
                this.fontString.Text = CommonTools.FontOutputStr(this.curr_font);
                this.titleFontStr.Text = CommonTools.FontOutputStr(this.curr_titlefont);
                if (this.initList())
                {
                    result = true;
                    return result;
                }
            }
            result = false;
            return result;
        }
        public bool initList()
        {
            string[] array = this.curr_dislists.Split(new char[]
			{
				','
			});
            for (int i = 0; i < array.Length; i++)
            {
                string text = array[i];
                int num = this.FindHeaderRes(this.listBox1, text);
                if (num != -1)
                {
                    this.swapHeaderItems(this.listBox1, this.listBox2, num);
                }
                else
                {
                    LogWriter.LogEntry("warning", "初始化模板列表错误，unknown colname:" + text);
                }
            }
            return true;
        }
        public int FindHeaderRes(ListBox list, string colname)
        {
            int result;
            for (int i = 0; i < list.Items.Count; i++)
            {
                HeaderDes headerDes = (HeaderDes)list.Items[i];
                if (headerDes.getcolumn() == colname)
                {
                    result = i;
                    return result;
                }
            }
            result = -1;
            return result;
        }
        private void button6_Click(object sender, EventArgs e)
        {
            if (this.IsTitleEmpty())
            {
                MessageBox.Show("模板名为空", "提示", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                this.templateName.Focus();
            }
            else
            {
                if (this.isTitleFontEmpty())
                {
                    MessageBox.Show("当前标题字体设置为空", "提示", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                }
                else
                {
                    if (this.isFontEmpty())
                    {
                        MessageBox.Show("当前内容字体设置为空", "提示", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                    }
                    else
                    {
                        if (this.getRightItemNum() <= 0)
                        {
                            MessageBox.Show("右侧列表模板需要显示的列为空", "提示", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                        }
                        else
                        {
                            string sql = this.generateSql();
                            int num = this.mfrm.dbop.updatesql(sql);
                            if (num <= 0)
                            {
                                MessageBox.Show("模板保存失败，请稍后重试", "提示", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                            }
                            else
                            {
                                MessageBox.Show("模板保存成功", "提示", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                                if (this.id == 0)
                                {
                                    this.mfrm.InitEditTemplateMenu();
                                }
                                base.Close();
                            }
                        }
                    }
                }
            }
        }
        private bool isFontEmpty()
        {
            return this.fontString.Text.Trim() == "";
        }
        private bool isTitleFontEmpty()
        {
            return this.titleFontStr.Text.Trim() == "";
        }
        private bool IsTitleEmpty()
        {
            return this.templateName.Text.Trim() == "";
        }
        private int getRightItemNum()
        {
            return this.listBox2.Items.Count;
        }
        private string generateSql()
        {
            string text = this.templateName.Text.Trim();
            string text2 = CommonTools.FontSqlStr(this.curr_font);
            string text3 = CommonTools.FontSqlStr(this.curr_titlefont);
            string displayListStr = this.getDisplayListStr();
            string result;
            if (this.id == 0)
            {
                result = string.Concat(new string[]
				{
					"insert into template(name,title,titlefont,contentfont,discolumns) values('",
					text,
					"','','",
					text3,
					"','",
					text2,
					"','",
					displayListStr,
					"')"
				});
            }
            else
            {
                result = string.Concat(new object[]
				{
					"update template set name='",
					text,
					"',title='',titlefont='",
					text3,
					"',contentfont='",
					text2,
					"',discolumns='",
					displayListStr,
					"' where id=",
					this.id
				});
            }
            return result;
        }
        private string getDisplayListStr()
        {
            string[] array = new string[this.listBox2.Items.Count];
            for (int i = 0; i < this.listBox2.Items.Count; i++)
            {
                HeaderDes headerDes = (HeaderDes)this.listBox2.Items[i];
                array[i] = headerDes.getcolumn();
            }
            return string.Join(",", array);
        }
        private void button7_Click(object sender, EventArgs e)
        {
            FontDialog fontDialog = new FontDialog();
            fontDialog.Font = this.curr_font;
            fontDialog.ShowDialog();
            this.curr_font = fontDialog.Font;
            this.SetFontValue(this.curr_font);
        }
        private void SetFontValue(Font font)
        {
            this.fontString.Text = CommonTools.FontOutputStr(font);
        }
        private void button1_Click(object sender, EventArgs e)
        {
            if (this.listBox1.SelectedIndex < 0)
            {
                MessageBox.Show("必须选中左侧具体的一列", "提示", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            }
            else
            {
                this.swapHeaderItems(this.listBox1, this.listBox2, this.listBox1.SelectedIndex);
            }
        }
        private void button2_Click(object sender, EventArgs e)
        {
            if (this.listBox2.SelectedIndex < 0)
            {
                MessageBox.Show("必须选中右侧具体的一列", "提示", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            }
            else
            {
                this.swapHeaderItems(this.listBox2, this.listBox1, this.listBox2.SelectedIndex);
            }
        }
        private void swapHeaderItems(ListBox source, ListBox dest, int index)
        {
            if (source != null && dest != null && index >= 0 && source.Items.Count != 0)
            {
                HeaderDes item = (HeaderDes)source.Items[index];
                dest.Items.Add(item);
                source.Items.RemoveAt(index);
                if (index >= source.Items.Count)
                {
                    index = source.Items.Count - 1;
                }
                source.SelectedIndex = index;
            }
        }
        private void button3_Click(object sender, EventArgs e)
        {
            this.MoveTo(true);
        }
        private void MoveTo(bool is_up)
        {
            if (this.listBox2.SelectedIndex < 0)
            {
                MessageBox.Show("必须选中右侧具体的一列", "提示", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            }
            else
            {
                int num = this.listBox2.SelectedIndex;
                HeaderDes item = (HeaderDes)this.listBox2.Items[num];
                this.listBox2.Items.RemoveAt(num);
                if (is_up)
                {
                    num--;
                    if (num < 0)
                    {
                        num = 0;
                    }
                }
                else
                {
                    num++;
                    if (num > this.listBox2.Items.Count)
                    {
                        num = this.listBox2.Items.Count;
                    }
                }
                this.listBox2.Items.Insert(num, item);
                this.listBox2.SelectedIndex = num;
            }
        }
        private void button4_Click(object sender, EventArgs e)
        {
            this.MoveTo(false);
        }
        private void button8_Click(object sender, EventArgs e)
        {
            FontDialog fontDialog = new FontDialog();
            fontDialog.Font = this.curr_font;
            fontDialog.ShowDialog();
            this.curr_titlefont = fontDialog.Font;
            this.titleFontStr.Text = CommonTools.FontOutputStr(this.curr_titlefont);
        }
        private void button9_Click(object sender, EventArgs e)
        {
            this.curr_titlefont = this.mfrm.getTitleFont();
            this.curr_font = this.mfrm.getContentFont();
            this.titleFontStr.Text = CommonTools.FontOutputStr(this.curr_titlefont);
            this.fontString.Text = CommonTools.FontOutputStr(this.curr_font);
            this.initFromSheet();
        }
        private void resetList()
        {
            this.listBox1.Items.Clear();
            this.listBox2.Items.Clear();
            this.initFullList();
        }
        private void initFromSheet()
        {
            this.resetList();
            this.initVisiableList();
        }
        private void button5_Click(object sender, EventArgs e)
        {
            base.Close();
            base.Dispose();
        }
    }
}