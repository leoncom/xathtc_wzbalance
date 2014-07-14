using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using wzbalance.src.Utils;

namespace wzbalance.src.Forms
{
    public partial class AddContractFillRule : Form
    {

        class ColumnItem
        {
            // List、Combox中标识字段类型
            int id;

            public int Id
            {
                get { return id; }
                set { id = value; }
            }
            string column_name;

            public string Column_name
            {
                get { return column_name; }
                set { column_name = value; }
            }

            string column_display;

            public string Column_display
            {
                get { return column_display; }
                set { column_display = value; }
            }


            public override string ToString()
            {
                return Column_display;
            }
        };

        private string[] exclude_column = new string[] { "id", "created" };
        private DataOperator dbop;
        private ContractFillRules current_rule;

        public AddContractFillRule(DataOperator dbop)
        {
            InitializeComponent();
            this.dbop = dbop;
            this.current_rule = new ContractFillRules();
        }

        // 初始化列表
        public void Initialize()
        {
            
            DataTable column_table = this.dbop.getData("select id,columnname,display from tbdesc");
            DataTableReader reader = column_table.CreateDataReader();
            while (reader.Read())
            {
                ColumnItem item = new ColumnItem();
                item.Id = reader.GetInt32(0);
                item.Column_name = reader.GetString(1);
                item.Column_display = reader.GetString(2);
                if (this.IsNotShowColumn(item.Column_name))
                {
                    continue;
                }

                this.column_checkedListBox.Items.Add(item);
                this.key_comboBox.Items.Add(item);
            }
        }

        private bool IsNotShowColumn(string column_name)
        {
            for (int i = 0; i < this.exclude_column.Length; i++)
            {
                if (column_name.Equals(exclude_column[i]))
                {
                    return true;
                }
            }
            return false;
        }

        // 设置已有的rule，用于编辑
        public void SetRules(ContractFillRules rule)
        {
            this.current_rule = rule;
            for (int i = 0; i < this.key_comboBox.Items.Count; i++)
            {
                ColumnItem item =  (ColumnItem)this.key_comboBox.Items[i];
                if (item.Column_name == this.current_rule.get_key())
                {
                    this.key_comboBox.SelectedIndex = i;
                    break;
                }
            }

            for (int i = 0; i < this.column_checkedListBox.Items.Count; i++)
            {
                ColumnItem item = (ColumnItem)this.key_comboBox.Items[i];
                if (this.current_rule.find_column(item.Column_name))
                {
                    this.column_checkedListBox.SetItemChecked(i, true);
                }
            }

            this.Text = "编辑合同录入规则";
            this.rulename_textbox.Text = rule.get_rule_name();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void save_button_Click(object sender, EventArgs e)
        {
            if (this.rulename_textbox.Text == "" || this.key_comboBox.SelectedIndex < 0
                || this.key_comboBox.SelectedIndex >= this.key_comboBox.Items.Count)
            {
                MessageBox.Show("规则名称或者触发的字段不能为空", "提示", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                return;
            }

            // 构造需要保存的item
            ColumnItem key_item = (ColumnItem)this.key_comboBox.SelectedItem;
            this.current_rule.set_rule_name(this.rulename_textbox.Text);
            this.current_rule.set_key(key_item.Column_name);
            this.current_rule.clear_columns();

            for (int i = 0; i < this.column_checkedListBox.CheckedItems.Count; i++)
            {
                ColumnItem column_item = (ColumnItem)this.column_checkedListBox.CheckedItems[i];
                this.current_rule.add_check_column(column_item.Column_name);
            }

            // 生成sql，保存
            string sql = this.current_rule.generate_sql();
            this.dbop.updatesql(sql);

            MessageBox.Show("规则保存成功", "提示", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);

            this.Dispose();
        }
    }
}