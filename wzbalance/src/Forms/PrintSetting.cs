using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace wzbalance.src.Forms
{
    public partial class PrintSetting : Form
    {
        public Font TitleFont;
        public string Title;
        public MainSheet mfrm;
        public Font headFont;
        public Font contentFont;
        public string dislists;
        private int OK;
        public bool WrapString;
        public int AppendLine;

        public PrintSetting()
        {
            this.InitializeComponent();
        }
        public void init()
        {
            this.comboBox1.Enabled = false;
            this.mfrm = (MainSheet)base.Owner;
            this.initPrintTemplate();
            this.TitleFont = null;
            this.dislists = "";
            this.OK = 0;
            this.currRadio.Checked = true;
            this.WrapString = false;
            this.AppendLine = 0;
        }
        public void initPrintTemplate()
        {
            string sql = "select * from template";
            DataTable data = this.mfrm.dbop.getData(sql);
            DataTableReader dataTableReader = data.CreateDataReader();
            while (dataTableReader.Read())
            {
                int @int = dataTableReader.GetInt32(dataTableReader.GetOrdinal("id"));
                string @string = dataTableReader.GetString(dataTableReader.GetOrdinal("name"));
                string string2 = dataTableReader.GetString(dataTableReader.GetOrdinal("titlefont"));
                string string3 = dataTableReader.GetString(dataTableReader.GetOrdinal("contentFont"));
                string string4 = dataTableReader.GetString(dataTableReader.GetOrdinal("discolumns"));
                PrintTemplateClass item = new PrintTemplateClass(@int, @string, string2, string3, string4);
                this.comboBox1.Items.Add(item);
            }
            if (this.comboBox1.Items.Count > 0)
            {
                this.comboBox1.SelectedIndex = 0;
            }
        }
        private void button2_Click(object sender, EventArgs e)
        {
            if (this.textBox1.Text.Trim() == "")
            {
                if (DialogResult.Yes != MessageBox.Show("未设置标题，确认不打印标题？", "提示", MessageBoxButtons.YesNo, MessageBoxIcon.Question))
                {
                    return;
                }
            }
            else
            {
                if (this.TitleFont == null)
                {
                    MessageBox.Show("请设置标题的字体", "提示", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                    return;
                }
            }
            this.Title = this.textBox1.Text.Trim();
            if (this.currRadio.Checked)
            {
                this.headFont = this.mfrm.getTitleFont();
                this.contentFont = this.mfrm.getContentFont();
                this.dislists = this.mfrm.getDiscolumns();
            }
            else
            {
                if (this.selfRadio.Checked)
                {
                    int selectedIndex = this.comboBox1.SelectedIndex;
                    if (selectedIndex == -1)
                    {
                        MessageBox.Show("请选择需要使用的模板", "提示", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                        return;
                    }
                    PrintTemplateClass printTemplateClass = (PrintTemplateClass)this.comboBox1.Items[selectedIndex];
                    this.headFont = printTemplateClass.headerFont;
                    this.contentFont = printTemplateClass.contentFont;
                    this.dislists = printTemplateClass.dislist;
                }
            }
            if (this.autoWrap.Checked)
            {
                this.WrapString = true;
            }
            this.AppendLine = (int)this.AppendLineHeight.Value;
            this.OK = 1;
            base.Close();
        }
        public bool isOK()
        {
            return this.OK == 1;
        }
        private void button1_Click(object sender, EventArgs e)
        {
            FontDialog fontDialog = new FontDialog();
            fontDialog.Font = this.TitleFont;
            fontDialog.ShowDialog();
            this.TitleFont = fontDialog.Font;
        }
        private void selfRadio_CheckedChanged(object sender, EventArgs e)
        {
            if (this.selfRadio.Checked)
            {
                this.comboBox1.Enabled = true;
            }
            else
            {
                this.comboBox1.Enabled = false;
            }
        }
    }
}