using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using wzbalance.Properties;
using Microsoft.VisualBasic;

namespace wzbalance.src.Forms
{
    public partial class AddContract : Form
    {
        private class Pair
        {
            public int index;
            public int subindex;
            public Pair(int a, int b)
            {
                this.index = a;
                this.subindex = b;
            }
        }
        private int selectrow;
        private string created;
        private MainSheet mfrm;
        private int updateid;

        public AddContract()
        {
            this.InitializeComponent();
            this.updateid = 0;
            base.StartPosition = FormStartPosition.Manual;
        }
        private void button1_Click(object sender, EventArgs e)
        {
            base.Close();
            base.Dispose();
        }
        public void init()
        {
            this.mfrm = (MainSheet)base.Owner;
            this.initcombox();
            this.initlabel();
            this.label1.Visible = false;
        }
        private void initlabel()
        {
            StringCollection inputOrder = Settings.Default.InputOrder;
            string sql = "select columnname,display from tbdesc";
            DataTable data = this.mfrm.dbop.getData(sql);
            DataTableReader dataTableReader = data.CreateDataReader();
            while (dataTableReader.Read())
            {
                string @string = dataTableReader.GetString(0);
                if (!(@string == "id"))
                {
                    int num = inputOrder.IndexOf(@string) + 1;
                    string text = dataTableReader.GetString(1);
                    string control_name = @string + "label";
                    AddContract.Pair pair = this.groupfindcontrol(control_name);
                    if (pair.index != -1)
                    {
                        if (num > 0)
                        {
                            object obj = text;
                            text = string.Concat(new object[]
							{
								obj,
								"(",
								num,
								")"
							});
                        }
                        base.Controls[pair.index].Controls[pair.subindex].Text = text;
                    }
                }
            }
        }
        private AddContract.Pair groupfindcontrol(string control_name)
        {
            AddContract.Pair pair = new AddContract.Pair(-1, -1);
            AddContract.Pair result;
            for (int i = 0; i < base.Controls.Count; i++)
            {
                for (int j = 0; j < base.Controls[i].Controls.Count; j++)
                {
                    if (base.Controls[i].Controls[j].Name == control_name)
                    {
                        pair.index = i;
                        pair.subindex = j;
                        result = pair;
                        return result;
                    }
                }
            }
            result = pair;
            return result;
        }
        public void setcontractid(int id)
        {
            this.updateid = id;
        }
        public int editmode(int rowindex)
        {
            this.label1.Text = "编辑前请再次确认要修改的合同内容，注意是否有他人最近修改";
            this.label1.Visible = true;
            this.selectrow = rowindex;
            this.Text = "编辑项目";
            string sql = "select * from balance where id=" + this.updateid;
            DataTable data = this.mfrm.dbop.getData(sql);
            DataTableReader dataTableReader = data.CreateDataReader();
            int result;
            if (dataTableReader.Read())
            {
                int i = 1;
                while (i < dataTableReader.FieldCount)
                {
                    if (dataTableReader.IsDBNull(i))
                    {
                        goto IL_230;
                    }
                    string name = dataTableReader.GetName(i);
                    if (name == "created")
                    {
                        this.created = dataTableReader.GetDateTime(i).ToShortDateString();
                    }
                    string dataTypeName = dataTableReader.GetDataTypeName(i);
                    AddContract.Pair pair = this.groupfindcontrol(name);
                    if (pair.index != -1)
                    {
                        if (dataTypeName == "String")
                        {
                            base.Controls[pair.index].Controls[name].Text = dataTableReader.GetString(i);
                        }
                        else
                        {
                            if (dataTypeName == "Int32")
                            {
                                base.Controls[pair.index].Controls[name].Text = dataTableReader.GetInt32(i).ToString();
                            }
                            else
                            {
                                if (dataTypeName == "Double")
                                {
                                    base.Controls[pair.index].Controls[name].Text = dataTableReader.GetDouble(i).ToString();
                                }
                                else
                                {
                                    if (dataTypeName == "DateTime")
                                    {
                                        DateTimePicker dateTimePicker = (DateTimePicker)base.Controls[pair.index].Controls[name];
                                        dateTimePicker.Checked = true;
                                        dateTimePicker.Text = dataTableReader.GetDateTime(i).ToShortDateString();
                                    }
                                }
                            }
                        }
                        goto IL_230;
                    }
                IL_2DD:
                    i++;
                    continue;
                IL_230:
                    if (dataTableReader.GetDataTypeName(i) == "DateTime" && dataTableReader.IsDBNull(i))
                    {
                        name = dataTableReader.GetName(i);
                        if (name == "created")
                        {
                            MessageBox.Show("该记录异常，无签订时间，不得修改，请联系xjtudaniel@gmail.com在后台修改", "错误", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                            result = -1;
                            return result;
                        }
                        pair = this.groupfindcontrol(name);
                        if (pair.index != -1)
                        {
                            DateTimePicker dateTimePicker = (DateTimePicker)base.Controls[pair.index].Controls[name];
                            dateTimePicker.Checked = false;
                        }
                    }
                    goto IL_2DD;
                }
            }
            result = 0;
            return result;
        }
        private void initcombox()
        {
            this.mfrm.initoptioncombo(this.jhzt, "jhzt", 0);
            this.add_fix_combox_item(this.jhzt, "jhzt");
            this.mfrm.initfixcombo(this.selldate, "selldate");
            this.mfrm.initfixcombo(this.buycontract, "buycontract");
            this.mfrm.initfixcombo(this.jindu, "jindu");
            this.mfrm.initfixcombo(this.yffp, "yffp");
            this.mfrm.initfixcombo(this.kucun, "kucun");
            this.mfrm.initoptioncombo(this.sellman, "sellman", 0);
            this.mfrm.initoptioncombo(this.pinming, "pinming", 0);
            this.mfrm.initoptioncombo(this.paihao, "paihao", 0);
            this.mfrm.initoptioncombo(this.jstj, "jstj", 0);
            this.mfrm.initoptioncombo(this.buyman, "buyman", 0);
            this.mfrm.initoptioncombo(this.location, "location", 0);
        }
        private void add_fix_combox_item(ComboBox combo, string columnname)
        {
            string sql = "select append from tbdesc where columnname='" + columnname + "'";
            DataTable data = this.mfrm.dbop.getData(sql);
            DataTableReader dataTableReader = data.CreateDataReader();
            string text = null;
            if (dataTableReader.Read())
            {
                if (dataTableReader.IsDBNull(0))
                {
                    return;
                }
                text = dataTableReader.GetString(0);
            }
            string[] array = text.Split(new char[]
			{
				','
			});
            for (int i = 0; i < array.Length; i++)
            {
                if (combo.Items.IndexOf(array[i]) == -1)
                {
                    combo.Items.Add(array[i]);
                }
            }
        }

        private string get_column_display(string column_name)
        {
            DataTable table = this.mfrm.dbop.getData("select display from tbdesc where columnname='" + column_name + "'");
            DataTableReader reader = table.CreateDataReader();
            if (reader.Read())
            {
                return reader.GetString(0);
            }
            else
            {
                return "(未知项)";
            }
        }

        private bool input_check()
        {
            // 输入规则检查，从数据库中读取规则
            DataTable fill_rule_table = this.mfrm.dbop.getData("select rule_name, primary_column, check_empty_columns from contract_fill_rule");
            DataTableReader rule_reader = fill_rule_table.CreateDataReader();

            while (rule_reader.Read())
            {
                string rule_name = rule_reader.GetString(0);
                string key = rule_reader.GetString(1);
                string check_columns = rule_reader.GetString(2);
                string[] check_column_array = check_columns.Split(',');

                AddContract.Pair key_pair = this.groupfindcontrol(key);
                if (key_pair.index == -1 || key_pair.subindex == -1)
                {
                    // this key column not found, do not check
                    continue;
                }

                if (base.Controls[key_pair.index].Controls[key_pair.subindex].Text.Trim() != "")
                {
                    // if the key column is not empty, check the column array one by one
                    for (int i = 0; i < check_column_array.Length; i++)
                    {
                        AddContract.Pair check_pair = this.groupfindcontrol(check_column_array[i]);
                        if (check_pair.index == -1 || check_pair.subindex == -1)
                        {
                            // check column not found, ignore
                            continue;
                        }

                        if (base.Controls[check_pair.index].Controls[check_pair.subindex].GetType() == typeof(DateTimePicker))
                        {
                            DateTimePicker dateTimePicker = (DateTimePicker)base.Controls[check_pair.index].Controls[check_pair.subindex];
                            if (!dateTimePicker.Checked)
                            {
                                MessageBox.Show(this.get_column_display(check_column_array[i]) + " 未填，命中规则名称(" + rule_name + ")", "提示",
                                    MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                                return false;
                            }
                        }
                        else
                        {
                            if (base.Controls[check_pair.index].Controls[check_pair.subindex].Text.Trim() == "")
                            {
                                MessageBox.Show(this.get_column_display(check_column_array[i]) + " 未填，命中规则名称(" + rule_name + ")", "提示",
                                     MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                                return false;
                            }
                        }

                    }
                }

            }
            return true;
        }
        private void button2_Click(object sender, EventArgs e)
        {
            if (this.input_check())
            {
                string text = this.thhtbh.Text;
                string text2 = this.sellcontract.Text;
                string text3 = this.sellman.Text;
                string text4 = this.pinming.Text;
                string text5 = this.paihao.Text;
                string text6 = this.guige.Text;
                string text7 = this.ckdbh.Text;
                string text8 = this.rkdbh.Text;
                string text9 = this.jstj.Text;
                string text10 = this.jhzt.Text;
                if (text10 != "")
                {
                    bool flag = false;
                    for (int i = 0; i < this.jhzt.Items.Count; i++)
                    {
                        if (this.jhzt.Items[i].ToString() == text10)
                        {
                            flag = true;
                            break;
                        }
                    }
                    if (!flag)
                    {
                        MessageBox.Show("交货状态必须是下拉列表选择中的具体值，添加新值请从菜单栏中添加", "提示", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                        return;
                    }
                }
                string text11 = this.sellnum.Text;
                if (text11 == "")
                {
                    text11 = "NULL";
                }
                else
                {
                    try
                    {
                        double.Parse(text11);
                    }
                    catch (Exception)
                    {
                        MessageBox.Show(this.sellnumlabel.Text + "必须为数字或者为空", "提示", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        return;
                    }
                }
                string text12 = this.pricewithtax.Text;
                if (text12 == "")
                {
                    text12 = "NULL";
                }
                else
                {
                    try
                    {
                        double.Parse(text12);
                    }
                    catch (Exception)
                    {
                        MessageBox.Show(this.pricewithtaxlabel.Text + "必须为数字或者为空", "提示", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        return;
                    }
                }
                string text13 = "NULL";
                if (text11 != "NULL" && text12 != "NULL")
                {
                    double num = double.Parse(text11);
                    double num2 = double.Parse(text12);
                    text13 = (num * num2).ToString();
                }
                string text14 = this.selldate.Text;
                string text15 = this.kucun.Text;
                string text16 = this.buyman.Text;
                string text17 = this.buycontract.Text;
                string text18 = this.location.Text;
                string text19 = this.jindu.Text;
                string text20 = this.rkgg.Text;
                string text21 = this.rkl.Text;
                string text22 = this.buyprice.Text;
                if (text22 == "")
                {
                    text22 = "NULL";
                }
                else
                {
                    try
                    {
                        double.Parse(text22);
                    }
                    catch (Exception)
                    {
                        MessageBox.Show(this.buypricelabel.Text + "必须为数字或者为空", "提示", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        return;
                    }
                }
                string text23 = "NULL";
                if (text21 != "" && text22 != "NULL")
                {
                    double num3 = CommonTools.ParseDouble(text21);
                    double num2 = double.Parse(text22);
                    text23 = (num3 * num2).ToString();
                }
                string text24 = this.ckl.Text;
                string text25 = "NULL";
                if (text24 != "" && text12 != "NULL")
                {
                    double num4 = CommonTools.ParseDouble(text24);
                    double num5 = double.Parse(text12);
                    text25 = (num4 * num5).ToString();
                }
                string text26 = this.planprice.Text.Trim();
                if (text26 == "")
                {
                    text26 = "NULL";
                }
                else
                {
                    try
                    {
                        double.Parse(text26);
                    }
                    catch (Exception)
                    {
                        MessageBox.Show(this.planpricelabel.Text + "必须为数字或者为空", "提示", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        return;
                    }
                }
                string text27 = "NULL";
                if (text26 != "NULL" && text11 != "NULL")
                {
                    double num = double.Parse(text11);
                    double num6 = double.Parse(text26);
                    text27 = (num * num6).ToString();
                }
                string text28 = this.cksj.Checked ? ("'" + this.cksj.Text + "'") : "NULL";
                string text29 = this.buyfapiao.Checked ? ("'" + this.buyfapiao.Text + "'") : "NULL";
                string text30 = this.sellfapiao.Checked ? ("'" + this.sellfapiao.Text + "'") : "NULL";
                string text31 = "NULL";
                string text32 = this.fxrq.Checked ? ("'" + this.fxrq.Text + "'") : "NULL";
                string text33 = this.rkrq.Checked ? ("'" + this.rkrq.Text + "'") : "NULL";
                string text34 = this.yffp.Text;
                string text35 = this.bz.Text;
                if (text28 != "NULL")
                {
                    if (text17 != "" || text19 != "")
                    {
                        if (MessageBox.Show("合同具备出库时间,是否保留采购合同及进度?", "提示", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation) == DialogResult.No)
                        {
                            text17 = "";
                            text19 = "";
                        }
                    }
                }
                string text36 = this.zlyy.Text;
                string text37 = this.luhao.Text;
                if (this.updateid == 0)
                {
                    string text38 = DateTime.Now.AddMonths(-6).ToShortDateString();
                    string sql = "";
                    if (text3 != "" && text5 != "" && text6 != "" && 
                        this.pinming.Text != "" && this.sellnum.Text != "" && this.pricewithtax.Text != "")
                    {
                        sql = string.Concat(new string[]
						{
							"select * from balance where sellman='",
							text3,
                            "' and pinming='",
                            this.pinming.Text,
							"' and paihao='",
							text5,
							"' and guige='",
							text6,
                            "' and sellnum=",
                            this.sellnum.Text,
                            " and pricewithtax=",
                            this.pricewithtax.Text,
							" and created > '",
							text38,
							"'"
						});
                        DataTable data = this.mfrm.dbop.getData(sql);
                        if (data.Rows.Count > 0)
                        {
                            if (DialogResult.Yes != MessageBox.Show("最近180天内有相同的客户、名称、牌号、规格、合同量、销价， 是否添加?", "提示", MessageBoxButtons.YesNo, MessageBoxIcon.Question))
                            {
                                return;
                            }
                        }
                    }
                    this.created = DateTime.Now.ToShortDateString();
                    sql = string.Concat(new string[]
					{
						"insert into balance(created, sellcontract, sellman, pinming, paihao, guige, jstj, jhzt, sellnum, pricewithtax, sellmoney, selldate, kucun, buyman, buycontract, location, jindu, rkgg, rkl, buyprice, buymoney, ckl,ckmoney, cksj, sellfapiao, buyfapiao, fczd, fxrq, rkrq, yffp,bz,planprice,planmoney,thhtbh,modifyuser,rkdbh,ckdbh,zlyy,luhao,tsyq,yf)values('",
						this.created,
						"','",
						text2,
						"','",
						text3,
						"','",
						text4,
						"','",
						text5,
						"','",
						text6,
						"','",
						text9,
						"','",
						text10,
						"',",
						text11,
						",",
						text12,
						",",
						text13,
						",'",
						text14,
						"','",
						text15,
						"','",
						text16,
						"','",
						text17,
						"','",
						text18,
						"','",
						text19,
						"','",
						text20,
						"','",
						text21,
						"',",
						text22,
						",",
						text23,
						",'",
						text24,
						"',",
						text25,
						",",
						text28,
						",",
						text30,
						",",
						text29,
						",",
						text31,
						",",
						text32,
						",",
						text33,
						",'",
						text34,
						"','",
						text35,
						"',",
						text26,
						",",
						text27,
						",'",
						text,
						"','",
						this.mfrm.getUserName(),
						"','",
						text8,
						"','",
						text7,
						"','",
						text36,
						"','",
						text37,
                        "','",
                        this.tsyq.Text,
                        "','",
                        this.yf.Text,
						"')"
					});
                    int num7 = this.mfrm.dbop.updatesql(sql);
                    if (num7 == 1)
                    {
                        MessageBox.Show("添加新纪录成功", "信息", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                        if (this.mfrm.isPageFull())
                        {
                            this.mfrm.pageinc();
                        }
                        this.mfrm.updatelist("");
                        base.Close();
                        base.Dispose();
                        this.mfrm.ScrollToBottom();
                    }
                    else
                    {
                        MessageBox.Show("添加记录失败", "错误", MessageBoxButtons.OK, MessageBoxIcon.Hand);
                    }
                }
                else
                {
                    string sql2 = "delete from balance where id=" + this.updateid;
                    this.mfrm.dbop.updatesql(sql2);
                    string sql = string.Concat(new object[]
					{
						"insert into balance(id, created, sellcontract, sellman, pinming, paihao, guige, jstj, jhzt, sellnum, pricewithtax, sellmoney, selldate, kucun, buyman, buycontract, location, jindu, rkgg, rkl, buyprice, buymoney,ckl,ckmoney, cksj, sellfapiao, buyfapiao, fczd, fxrq, rkrq, yffp,bz,planprice,planmoney,thhtbh,modifyuser,rkdbh,ckdbh,zlyy,luhao,tsyq,yf)values(",
						this.updateid,
						",'",
						this.created,
						"','",
						text2,
						"','",
						text3,
						"','",
						text4,
						"','",
						text5,
						"','",
						text6,
						"','",
						text9,
						"','",
						text10,
						"',",
						text11,
						",",
						text12,
						",",
						text13,
						",'",
						text14,
						"','",
						text15,
						"','",
						text16,
						"','",
						text17,
						"','",
						text18,
						"','",
						text19,
						"','",
						text20,
						"','",
						text21,
						"',",
						text22,
						",",
						text23,
						",'",
						text24,
						"',",
						text25,
						",",
						text28,
						",",
						text30,
						",",
						text29,
						",",
						text31,
						",",
						text32,
						",",
						text33,
						",'",
						text34,
						"','",
						text35,
						"',",
						text26,
						",",
						text27,
						",'",
						text,
						"','",
						this.mfrm.getUserName(),
						"','",
						text8,
						"','",
						text7,
						"','",
						text36,
						"','",
						text37,
                        "','",
                        this.tsyq.Text,
                        "','",
                        this.yf.Text,
						"')"
					});
                    int num7 = this.mfrm.dbop.updatesql(sql);
                    if (num7 == 1)
                    {
                        MessageBox.Show("编辑成功", "信息", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                        this.mfrm.updatelist("");
                        this.mfrm.SetSelectRow(this.selectrow);
                        base.Close();
                        base.Dispose();
                    }
                    else
                    {
                        MessageBox.Show("编辑记录失败", "错误", MessageBoxButtons.OK, MessageBoxIcon.Hand);
                    }
                }
            }
        }
        private void editcombobox(ComboBox combo)
        {
            int selectedIndex = combo.SelectedIndex;
            if (selectedIndex == -1)
            {
                MessageBox.Show("请先将要修改的项目选定", "信息", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            }
            else
            {
                string defaultResponse = (string)combo.Items[selectedIndex];
                string text = base.Controls[this.getcombogroup(combo)].Controls[combo.Name + "label"].Text;
                string text2 = Interaction.InputBox("输入" + text + "新选项名称", "修改选项--" + text, defaultResponse, 500, 400);
                if (!(text2 == ""))
                {
                    combo.Items[selectedIndex] = text2;
                    combo.SelectedIndex = selectedIndex;
                    this.updateComboToDB(combo);
                }
            }
        }
        private void 修改ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ComboBox activeCombobox = this.getActiveCombobox();
            if (activeCombobox != null)
            {
                this.editcombobox(activeCombobox);
            }
        }
        private ComboBox getActiveCombobox()
        {
            string a = base.ActiveControl.GetType().ToString();
            ComboBox result;
            if (a != "System.Windows.Forms.ComboBox")
            {
                MessageBox.Show("当前鼠标未选中下拉列表控件", "信息", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                result = null;
            }
            else
            {
                ComboBox comboBox = (ComboBox)base.ActiveControl;
                if (comboBox.DropDownStyle != ComboBoxStyle.DropDownList)
                {
                    MessageBox.Show("只可编辑固定选项的下拉列表", "信息", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                    result = null;
                }
                else
                {
                    result = comboBox;
                }
            }
            return result;
        }
        private void updateComboToDB(ComboBox combo)
        {
            string[] array = new string[combo.Items.Count];
            for (int i = 0; i < combo.Items.Count; i++)
            {
                array[i] = (string)combo.Items[i];
            }
            string name = combo.Name;
            string text = string.Join(",", array);
            string sql = string.Concat(new string[]
			{
				"update tbdesc set append='",
				text,
				"' where columnname='",
				name,
				"'"
			});
            this.mfrm.dbop.updatesql(sql);
        }
        private void 删除ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ComboBox activeCombobox = this.getActiveCombobox();
            if (activeCombobox != null)
            {
                this.delcombo(activeCombobox);
            }
        }
        private void delcombo(ComboBox combo)
        {
            int selectedIndex = combo.SelectedIndex;
            if (selectedIndex == -1)
            {
                MessageBox.Show("请先将要删除的项目选定在", "信息", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            }
            else
            {
                string str = (string)combo.Items[selectedIndex];
                if (DialogResult.Yes == MessageBox.Show("确认删除“" + str + "”选项？", "确认删除", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation))
                {
                    combo.Items.RemoveAt(selectedIndex);
                    combo.SelectedIndex = -1;
                    this.updateComboToDB(combo);
                }
            }
        }
        private void 添加ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ComboBox activeCombobox = this.getActiveCombobox();
            if (activeCombobox != null)
            {
                this.addcombobox(activeCombobox);
            }
        }
        private int getcombogroup(ComboBox combo)
        {
            string name = combo.Name;
            AddContract.Pair pair = this.groupfindcontrol(name);
            return pair.index;
        }
        private void addcombobox(ComboBox combo)
        {
            string text = base.Controls[this.getcombogroup(combo)].Controls[combo.Name + "label"].Text;
            string text2 = Interaction.InputBox("输入" + text + "新选项名称", "添加选项--" + text, "输入新选项", 500, 400);
            if (!(text2 == ""))
            {
                if (combo.Items.IndexOf(text2) != -1)
                {
                    MessageBox.Show("列表中已有该项目", "信息", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                    combo.SelectedItem = text2;
                }
                else
                {
                    combo.Items.Insert(0, text2);
                    combo.SelectedIndex = 0;
                    this.updateComboToDB(combo);
                }
            }
        }
        private void sellcontract_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Back)
            {
                ComboBox comboBox = (ComboBox)base.ActiveControl;
                comboBox.SelectedIndex = -1;
            }
        }
        private void NewContract_Load(object sender, EventArgs e)
        {
            base.Top = Settings.Default.NewContractLocY;
            base.Left = Settings.Default.NewContractLocX;
        }
        private void NewContract_FormClosing(object sender, FormClosingEventArgs e)
        {
            Settings.Default.NewContractLocY = base.Location.Y;
            Settings.Default.NewContractLocX = base.Location.X;
            Settings.Default.Save();
        }
        private void groupBox2_Paint(object sender, PaintEventArgs e)
        {
            e.Graphics.Clear(this.groupBox2.BackColor);
            e.Graphics.DrawString(this.groupBox2.Text, this.groupBox2.Font, Brushes.Blue, 10f, 1f);
            e.Graphics.DrawLine(Pens.Red, 1, 7, 8, 7);
            e.Graphics.DrawLine(Pens.Red, e.Graphics.MeasureString(this.groupBox2.Text, this.groupBox2.Font).Width + 8f, 7f, (float)(this.groupBox2.Width - 2), 7f);
            e.Graphics.DrawLine(Pens.Red, 1, 7, 1, this.groupBox2.Height - 2);
            e.Graphics.DrawLine(Pens.Red, 1, this.groupBox2.Height - 2, this.groupBox2.Width - 2, this.groupBox2.Height - 2);
            e.Graphics.DrawLine(Pens.Red, this.groupBox2.Width - 2, 7, this.groupBox2.Width - 2, this.groupBox2.Height - 2);
        }
        private void groupBox3_Paint(object sender, PaintEventArgs e)
        {
            e.Graphics.Clear(this.groupBox3.BackColor);
            e.Graphics.DrawString(this.groupBox3.Text, this.groupBox3.Font, Brushes.Blue, 10f, 1f);
            e.Graphics.DrawLine(Pens.Red, 1, 7, 8, 7);
            e.Graphics.DrawLine(Pens.Red, e.Graphics.MeasureString(this.groupBox3.Text, this.groupBox3.Font).Width + 8f, 7f, (float)(this.groupBox3.Width - 2), 7f);
            e.Graphics.DrawLine(Pens.Red, 1, 7, 1, this.groupBox3.Height - 2);
            e.Graphics.DrawLine(Pens.Red, 1, this.groupBox3.Height - 2, this.groupBox3.Width - 2, this.groupBox3.Height - 2);
            e.Graphics.DrawLine(Pens.Red, this.groupBox3.Width - 2, 7, this.groupBox3.Width - 2, this.groupBox3.Height - 2);
        }
        private void groupBox1_Paint(object sender, PaintEventArgs e)
        {
            e.Graphics.Clear(this.groupBox1.BackColor);
            e.Graphics.DrawString(this.groupBox1.Text, this.groupBox1.Font, Brushes.Blue, 10f, 1f);
            e.Graphics.DrawLine(Pens.Red, 1, 7, 8, 7);
            e.Graphics.DrawLine(Pens.Red, e.Graphics.MeasureString(this.groupBox1.Text, this.groupBox1.Font).Width + 8f, 7f, (float)(this.groupBox1.Width - 2), 7f);
            e.Graphics.DrawLine(Pens.Red, 1, 7, 1, this.groupBox1.Height - 2);
            e.Graphics.DrawLine(Pens.Red, 1, this.groupBox1.Height - 2, this.groupBox1.Width - 2, this.groupBox1.Height - 2);
            e.Graphics.DrawLine(Pens.Red, this.groupBox1.Width - 2, 7, this.groupBox1.Width - 2, this.groupBox1.Height - 2);
        }
        private void groupBox4_Paint(object sender, PaintEventArgs e)
        {
            e.Graphics.Clear(this.groupBox4.BackColor);
            e.Graphics.DrawString(this.groupBox4.Text, this.groupBox4.Font, Brushes.Blue, 10f, 1f);
            e.Graphics.DrawLine(Pens.Red, 1, 7, 8, 7);
            e.Graphics.DrawLine(Pens.Red, e.Graphics.MeasureString(this.groupBox4.Text, this.groupBox4.Font).Width + 8f, 7f, (float)(this.groupBox4.Width - 2), 7f);
            e.Graphics.DrawLine(Pens.Red, 1, 7, 1, this.groupBox4.Height - 2);
            e.Graphics.DrawLine(Pens.Red, 1, this.groupBox4.Height - 2, this.groupBox4.Width - 2, this.groupBox4.Height - 2);
            e.Graphics.DrawLine(Pens.Red, this.groupBox4.Width - 2, 7, this.groupBox4.Width - 2, this.groupBox4.Height - 2);
        }
        private void groupBox5_Paint(object sender, PaintEventArgs e)
        {
            e.Graphics.Clear(this.groupBox5.BackColor);
            e.Graphics.DrawString(this.groupBox5.Text, this.groupBox5.Font, Brushes.Blue, 10f, 1f);
            e.Graphics.DrawLine(Pens.Red, 1, 7, 8, 7);
            e.Graphics.DrawLine(Pens.Red, e.Graphics.MeasureString(this.groupBox5.Text, this.groupBox5.Font).Width + 8f, 7f, (float)(this.groupBox5.Width - 2), 7f);
            e.Graphics.DrawLine(Pens.Red, 1, 7, 1, this.groupBox5.Height - 2);
            e.Graphics.DrawLine(Pens.Red, 1, this.groupBox5.Height - 2, this.groupBox5.Width - 2, this.groupBox5.Height - 2);
            e.Graphics.DrawLine(Pens.Red, this.groupBox5.Width - 2, 7, this.groupBox5.Width - 2, this.groupBox5.Height - 2);
        }
        private void yffp_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Back)
            {
                ComboBox comboBox = (ComboBox)base.ActiveControl;
                comboBox.SelectedIndex = -1;
            }
        }

    }
}