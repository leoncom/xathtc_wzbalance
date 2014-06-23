using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace wzbalance.src.Forms
{
    public partial class DeleteTemplate : Form
    {
        private MainSheet mfrm;

        public DeleteTemplate()
        {
            this.InitializeComponent();
            base.StartPosition = FormStartPosition.CenterParent;
        }
        public void init()
        {
            this.mfrm = (MainSheet)base.Owner;
            this.initSelect();
        }
        public void initSelect()
        {
            string sql = "select id,name from template";
            DataTable data = this.mfrm.dbop.getData(sql);
            DataTableReader dataTableReader = data.CreateDataReader();
            while (dataTableReader.Read())
            {
                int @int = dataTableReader.GetInt32(dataTableReader.GetOrdinal("id"));
                string @string = dataTableReader.GetString(dataTableReader.GetOrdinal("name"));
                PrintTemplateClass item = new PrintTemplateClass(@int, @string, null, null, null);
                this.comboBox1.Items.Add(item);
            }
            if (this.comboBox1.Items.Count != 0)
            {
                this.comboBox1.SelectedIndex = 0;
            }
        }
        private void button1_Click(object sender, EventArgs e)
        {
            int selectedIndex = this.comboBox1.SelectedIndex;
            if (selectedIndex < 0 || selectedIndex >= this.comboBox1.Items.Count)
            {
                MessageBox.Show("请选定要删除的列", "提示", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            }
            else
            {
                if (DialogResult.Yes == MessageBox.Show("确定删除该模板?", "提示", MessageBoxButtons.YesNo, MessageBoxIcon.Asterisk))
                {
                    PrintTemplateClass printTemplateClass = (PrintTemplateClass)this.comboBox1.Items[selectedIndex];
                    string sql = "delete from template where id=" + printTemplateClass.id;
                    if (this.mfrm.dbop.updatesql(sql) != 1)
                    {
                        MessageBox.Show("删除失败,稍后退出重试", "提示", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    }
                    else
                    {
                        MessageBox.Show("删除模板成功", "提示", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        this.mfrm.InitEditTemplateMenu();
                        this.comboBox1.Items.RemoveAt(selectedIndex);
                        base.Close();
                    }
                }
            }
        }
    }
}