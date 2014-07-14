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
    public partial class ContractRulesMgr : Form
    {
        public DataOperator dbop;
        public ContractRulesMgr(DataOperator op)
        {
            this.dbop = op;
            InitializeComponent();
        }

        public void Initialize()
        {
            this.ruleslistBox.Items.Clear();
            DataTable rule_table = this.dbop.getData("select id, rule_name, primary_column, check_empty_columns from contract_fill_rule");
            DataTableReader rule_reader = rule_table.CreateDataReader();
            while (rule_reader.Read())
            {
                int id = rule_reader.GetInt32(0);
                string rule_name = rule_reader.GetString(1);
                string key_column = rule_reader.GetString(2);
                string check_columns = rule_reader.GetString(3);
                ContractFillRules rule = new ContractFillRules();
                rule.set_id(id);
                rule.set_rule_name(rule_name);
                rule.set_key(key_column);
                rule.set_check_column(check_columns);
                this.ruleslistBox.Items.Add(rule);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (this.ruleslistBox.SelectedIndex < 0)
            {
                MessageBox.Show("必须选择一个规则进行编辑", "提示", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                return;
            }

            ContractFillRules rule = (ContractFillRules)this.ruleslistBox.SelectedItem;
            AddContractFillRule add_rule_form = new AddContractFillRule(this.dbop);
            add_rule_form.Initialize();
            add_rule_form.SetRules(rule);
            add_rule_form.ShowDialog();
            this.Initialize();
        }

        private void delete_button_Click(object sender, EventArgs e)
        {
            if (this.ruleslistBox.SelectedIndex < 0)
            {
                MessageBox.Show("必须选择一个规则进行删除", "提示", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                return;
            }

            ContractFillRules rule = (ContractFillRules)this.ruleslistBox.SelectedItem;
            string confirm_text = "确定删除规则\"" + rule.get_rule_name() +"\"?";
            if (MessageBox.Show(confirm_text, "确认", MessageBoxButtons.YesNo, MessageBoxIcon.Question) != DialogResult.Yes)
            {
                return;
            }
            string sql = "delete from contract_fill_rule where id=" + rule.get_id();
            this.dbop.updatesql(sql);
            this.Initialize();

            MessageBox.Show("规则已删除", "通知", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void new_button_Click(object sender, EventArgs e)
        {
            AddContractFillRule add_rule_form = new AddContractFillRule(this.dbop);
            add_rule_form.Initialize();
            add_rule_form.ShowDialog();
            this.Initialize();
        }
    }
}