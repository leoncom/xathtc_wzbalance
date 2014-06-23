using Excel;
using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Runtime.Remoting.Messaging;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using wzbalance.Properties;

namespace wzbalance.src.Forms
{
    public partial class MainSheet : Form
    {
        private delegate System.Data.DataTable getDataDelegate(string sql, string sortmode);
        private List<object[]> lastRow = new List<object[]>();
        private int colindex = 0;
        private string lastSortColName = null;
        private int lastSortColMode = 0;
        private int scrollPosY = 0;
        private int scrollPosX = 0;
        private int userid = 0;
        private string curruser;
        private DateTime now = DateTime.Now;
        private string defaultsql = null;
        private LoadProgress loadfrm = null;
        private int readDBerror = 0;
        public DataOperator dbop;
        private int currpage;
        private int pagesize;
        private string nowsql;

        private string[] selectys = new string[]
		{
			"蓝色",
			"红色",
			"黄色",
			"白色"
		};
        private int[] defaultDisPos = new int[]
		{
			0,
			1,
			3,
			4,
			5,
			6,
			7,
			8,
			9,
			10,
			11,
			12,
			13,
			14,
			15,
			16,
			17,
			18,
			20,
			21,
			22,
			23,
			26,
			27,
			28,
			35,
			34,
			32,
			36,
			24,
			33,
			29,
			30,
			31,
			2,
			37,
			19,
			25
		};

        public MainSheet()
        {
            this.InitializeComponent();
            base.WindowState = FormWindowState.Maximized;
        }

        public void init(string server, DataOperator dbcop, string currusr, string user, string pwd, string db, int uid)
        {
            this.dbop = dbcop;
            this.curruser = currusr;
            this.defaultsql = string.Concat(new string[]
			{
				"select * from balance where created >= '",
				this.now.ToString("yyyy-MM-01"),
				"' and created <= '",
				this.now.ToString("yyyy-MM-dd"),
				"'  order by created desc"
			});
            this.lastSortColName = "id";
            this.lastSortColMode = 0;
            this.currpage = 0;
            this.pagesize = Settings.Default.PageSize;
            this.resumeStatus();
            this.updatelist(this.defaultsql);
            this.scrollPosX = 1;
            this.scrollPosY = 1;
            this.userid = uid;
            this.initfixcombo(this.buycontract, "buycontract");
            this.initoptioncombo(this.sellman, "sellman", 0);
            this.initoptioncombo(this.buyman, "buyman", 0);
            this.dataGridView1.RowsDefaultCellStyle.WrapMode = DataGridViewTriState.False;
            this.dataGridView1.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.DisplayedCells;
            this.dataGridView1.ColumnHeadersDefaultCellStyle.WrapMode = DataGridViewTriState.True;
            this.dataGridView1.DefaultCellStyle.Font = Settings.Default.CellFont;
            this.dataGridView1.ColumnHeadersDefaultCellStyle.Font = Settings.Default.HeaderFont;
            this.ysbs.DrawMode = DrawMode.OwnerDrawVariable;
            this.setLabeltext("buyman", this.buymanlabel);
            this.setLabeltext("sellman", this.sellmanlabel);
            this.cksj.Items.Add("已出库");
            this.cksj.Items.Add("未出库");
            this.cksj.Items.Add("已入库");
            this.cksj.Items.Add("未入库");
            this.fpzt.Items.Add("销项发票已开");
            this.fpzt.Items.Add("销项发票未开");
            this.fpzt.Items.Add("进项发票已收");
            this.fpzt.Items.Add("进项发票未收");
            this.ysbs.DataSource = this.selectys;
            this.initSearchBox();
            this.ysbs.SelectedIndex = -1;
            this.initCustomSearchCombo();
            this.dataGridView1.ShowCellToolTips = false;
            this.dataGridView1.RowsDefaultCellStyle.WrapMode = DataGridViewTriState.False;
            this.setAction();
            this.updateColor();
            this.InitEditTemplateMenu();
        }
        private void initSearchBox()
        {
            this.htdqzt.Items.Add("采购合同已到期");
            this.htdqzt.Items.Add("销售合同已到期");
        }
        public void InitEditTemplateMenu()
        {
            this.编辑模板EToolStripMenuItem.DropDownItems.Clear();
            string sql = "select id,name from template";
            System.Data.DataTable data = this.dbop.getData(sql);
            DataTableReader dataTableReader = data.CreateDataReader();
            int num = 0;
            while (dataTableReader.Read())
            {
                int id = dataTableReader.GetInt32(dataTableReader.GetOrdinal("id"));
                string @string = dataTableReader.GetString(dataTableReader.GetOrdinal("name"));
                ToolStripMenuItem toolStripMenuItem = new ToolStripMenuItem(@string, null);
                toolStripMenuItem.Click += delegate(object sender, EventArgs e)
                {
                    PrintTemplate template = new PrintTemplate();
                    template.Owner = this;
                    template.init();
                    template.setEdit(id);
                    template.ShowDialog();
                };
                this.编辑模板EToolStripMenuItem.DropDownItems.Add(toolStripMenuItem);
                num = 1;
            }
            if (num == 0)
            {
                ToolStripMenuItem toolStripMenuItem = new ToolStripMenuItem("(空)");
                toolStripMenuItem.ForeColor = Color.LightGray;
                this.编辑模板EToolStripMenuItem.DropDownItems.Add(toolStripMenuItem);
            }
            dataTableReader.Close();
        }
        public int getUserid()
        {
            return this.userid;
        }
        public string getUserName()
        {
            return this.curruser;
        }
        public string getRole()
        {
            string sql = "select * from users where id=" + this.userid;
            System.Data.DataTable data = this.dbop.getData(sql);
            DataTableReader dataTableReader = data.CreateDataReader();
            string result;
            if (dataTableReader.Read())
            {
                string @string = dataTableReader.GetString(3);
                result = @string;
            }
            else
            {
                MessageBox.Show("系统用户错误，建议您退出程序重新登录", "错误", MessageBoxButtons.OK, MessageBoxIcon.Hand);
                LogWriter.LogEntry("error", "getRole()错误,用户id为:" + this.userid);
                result = null;
            }
            return result;
        }
        public string getPwd()
        {
            string sql = "select * from users where id=" + this.userid;
            System.Data.DataTable data = this.dbop.getData(sql);
            DataTableReader dataTableReader = data.CreateDataReader();
            string result;
            if (dataTableReader.Read())
            {
                string @string = dataTableReader.GetString(2);
                result = @string;
            }
            else
            {
                MessageBox.Show("系统用户错误，建议您退出程序重新登录", "错误", MessageBoxButtons.OK, MessageBoxIcon.Hand);
                LogWriter.LogEntry("error", "getRole()错误,用户id为:" + this.userid);
                result = null;
            }
            return result;
        }
        public void setAction()
        {
            string role = this.getRole();
            string sql = "select * from actiondesc";
            System.Data.DataTable data = this.dbop.getData(sql);
            DataTableReader dataTableReader = data.CreateDataReader();
            while (dataTableReader.Read())
            {
                string @string = dataTableReader.GetString(1);
                if (role.IndexOf(@string) == -1)
                {
                    string text = @string;
                    if (text != null)
                    {
                        if (!(text == "a"))
                        {
                            if (!(text == "b"))
                            {
                                if (!(text == "c"))
                                {
                                    if (text == "d")
                                    {
                                        this.通讯录CToolStripMenuItem.Visible = false;
                                    }
                                }
                                else
                                {
                                    this.管理MToolStripMenuItem.Visible = false;
                                }
                            }
                            else
                            {
                                this.button3.Visible = false;
                                this.button4.Visible = false;
                            }
                        }
                        else
                        {
                            this.button2.Visible = false;
                        }
                    }
                }
            }
        }
        public void ScrollToBottom()
        {
            this.dataGridView1.FirstDisplayedScrollingRowIndex = this.dataGridView1.Rows.Count - 1;
        }
        public void SaveScrollPos()
        {
            this.SaveScrollPosX();
            this.SaveScrollPosY();
        }
        public void SaveScrollPosX()
        {
            this.scrollPosX = ((this.dataGridView1.FirstDisplayedScrollingColumnIndex > 0) ? this.dataGridView1.FirstDisplayedScrollingColumnIndex : 0);
        }
        public void SaveScrollPosY()
        {
            this.scrollPosY = ((this.dataGridView1.FirstDisplayedScrollingRowIndex > 0) ? this.dataGridView1.FirstDisplayedScrollingRowIndex : 0);
        }
        public void RestoreScrollPos()
        {
            try
            {
                this.RestoreScrollPosX();
                this.RestoreScrollPosY();
            }
            catch (Exception)
            {
                this.scrollPosY = 0;
            }
        }
        public void RestoreScrollPosX()
        {
            this.dataGridView1.FirstDisplayedScrollingColumnIndex = this.scrollPosX;
        }
        public void RestoreScrollPosY()
        {
            this.dataGridView1.FirstDisplayedScrollingRowIndex = this.scrollPosY;
        }
        private void setLabeltext(string columnName, System.Windows.Forms.Label label)
        {
            string sql = "select columnname,display from tbdesc where columnname='" + columnName + "'";
            System.Data.DataTable data = this.dbop.getData(sql);
            DataTableReader dataTableReader = data.CreateDataReader();
            if (dataTableReader.Read())
            {
                string @string = dataTableReader.GetString(1);
                label.Text = @string;
            }
        }
        public bool isPageFull()
        {
            return this.dataGridView1.Rows.Count - 1 == this.pagesize;
        }
        public void pageinc()
        {
            this.currpage++;
        }
        private System.Data.DataTable getDataFromDB(string sql, string sortmode)
        {
            System.Data.DataTable dataTable = this.dbop.getData(sql);
            DataView defaultView = dataTable.DefaultView;
            defaultView.Sort = this.lastSortColName + " " + sortmode;
            dataTable = defaultView.ToTable();
            double num = 0.0;
            double num2 = 0.0;
            double num3 = 0.0;
            double num4 = 0.0;
            double num5 = 0.0;
            double num6 = 0.0;
            double num7 = 0.0;
            DataTableReader dataTableReader = dataTable.CreateDataReader();
            while (dataTableReader.Read())
            {
                double num8 = 0.0;
                if (!dataTableReader.IsDBNull(dataTableReader.GetOrdinal("sellmoney")))
                {
                    num8 = dataTableReader.GetDouble(dataTableReader.GetOrdinal("sellmoney"));
                }
                double num9 = 0.0;
                if (!dataTableReader.IsDBNull(dataTableReader.GetOrdinal("buymoney")))
                {
                    num9 = dataTableReader.GetDouble(dataTableReader.GetOrdinal("buymoney"));
                }
                double num10 = 0.0;
                if (!dataTableReader.IsDBNull(dataTableReader.GetOrdinal("ckmoney")))
                {
                    num10 = dataTableReader.GetDouble(dataTableReader.GetOrdinal("ckmoney"));
                }
                double num11 = 0.0;
                if (!dataTableReader.IsDBNull(dataTableReader.GetOrdinal("planmoney")))
                {
                    num11 = dataTableReader.GetDouble(dataTableReader.GetOrdinal("planmoney"));
                }
                double num12 = 0.0;
                if (!dataTableReader.IsDBNull(dataTableReader.GetOrdinal("sellnum")))
                {
                    num12 = dataTableReader.GetDouble(dataTableReader.GetOrdinal("sellnum"));
                }
                double num13 = 0.0;
                if (!dataTableReader.IsDBNull(dataTableReader.GetOrdinal("rkl")))
                {
                    num13 = CommonTools.ParseDouble(dataTableReader.GetString(dataTableReader.GetOrdinal("rkl")));
                }
                double num14 = 0.0;
                if (!dataTableReader.IsDBNull(dataTableReader.GetOrdinal("ckl")))
                {
                    num14 = CommonTools.ParseDouble(dataTableReader.GetString(dataTableReader.GetOrdinal("ckl")));
                }
                num += num8;
                num3 += num9;
                num2 += num10;
                num4 += num11;
                num5 += num12;
                num6 += num13;
                num7 += num14;
            }
            DataRow dataRow = dataTable.NewRow();
            dataRow["sellmoney"] = num.ToString("0.00");
            dataRow["buymoney"] = num3.ToString("0.00");
            dataRow["ckmoney"] = num2.ToString("0.00");
            dataRow["planmoney"] = num4.ToString("0.00");
            dataRow["sellnum"] = num5.ToString("0.000");
            dataRow["rkl"] = num6.ToString("0.000");
            dataRow["ckl"] = num7.ToString("0.000");
            dataTable.Rows.Add(dataRow);
            return dataTable;
        }

        private delegate void setDataSource(DataGridView grid, System.Data.DataTable table);

        public void CallBack(IAsyncResult tag)
        {
            AsyncResult asyncResult = (AsyncResult)tag;
            MainSheet.getDataDelegate getDataDelegate = (MainSheet.getDataDelegate)asyncResult.AsyncDelegate;
            this.readDBerror = 0;
            try
            {
                System.Data.DataTable table = getDataDelegate.EndInvoke(tag);
                if (this.dataGridView1.InvokeRequired)
                {
                    this.dataGridView1.Invoke((MethodInvoker)delegate()
                    {
                        this.dataGridView1.DataSource = table;
                        this.dataGridView1.Hide();
                    });
                }
                else
                {
                    this.dataGridView1.DataSource = table;
                    this.dataGridView1.Hide();
                }
            }
            catch (Exception ex)
            {
                this.readDBerror = 1;
                MessageBox.Show("数据库异常," + ex.Message, "出错", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                LogWriter.LogEntry("error", "数据库select请求异常,错误: " + ex.Message + "\r\n" + ex.StackTrace);
            }
            if (this.loadfrm.InvokeRequired)
            {
                this.dataGridView1.Invoke((MethodInvoker)delegate()
                {
                    this.loadfrm.Close();
                });
            }
            else
            {
                this.loadfrm.Close();
            }
        }


        private StringCollection getDefaultCollection(string name)
        {
            string sql = "select value from sundries where name='" + name + "'";
            DataTableReader dataTableReader = this.dbop.getData(sql).CreateDataReader();
            StringCollection result;
            if (dataTableReader.Read())
            {
                string @string = dataTableReader.GetString(dataTableReader.GetOrdinal("value"));
                result = CommonTools.StringToStringCollection(@string, ',');
            }
            else
            {
                result = null;
            }
            return result;
        }
        public void UpdateGridViewDisplay()
        {
            string sql = "select * from tbdesc";
            System.Data.DataTable data = this.dbop.getData(sql);
            DataTableReader dataTableReader = data.CreateDataReader();
            StringCollection stringCollection = Settings.Default.ColumnDisplay;
            StringCollection stringCollection2 = Settings.Default.ColumnWidth;
            StringCollection stringCollection3 = Settings.Default.ColumnIndex;
            if (stringCollection.Count == 0 || stringCollection2.Count == 0 || stringCollection3.Count == 0)
            {
                StringCollection defaultCollection = this.getDefaultCollection("coll");
                if (defaultCollection != null)
                {
                    stringCollection = defaultCollection;
                }
                StringCollection defaultCollection2 = this.getDefaultCollection("cwidth");
                if (defaultCollection2 != null)
                {
                    stringCollection2 = defaultCollection2;
                }
                StringCollection defaultCollection3 = this.getDefaultCollection("cindex");
                if (defaultCollection3 != null)
                {
                    stringCollection3 = defaultCollection3;
                }
            }
            while (dataTableReader.Read())
            {
                string @string = dataTableReader.GetString(1);
                string string2 = dataTableReader.GetString(2);
                this.dataGridView1.Columns[@string].HeaderText = string2;
                int num = stringCollection.IndexOf(@string);
                if (num == -1)
                {
                    this.dataGridView1.Columns[@string].Visible = false;
                }
                else
                {
                    int num2 = int.Parse(stringCollection2[num]);
                    if (num2 != 0)
                    {
                        this.dataGridView1.Columns[@string].Width = num2;
                    }
                    if (stringCollection3 != null && stringCollection3.Count == stringCollection.Count)
                    {
                        int displayIndex = int.Parse(stringCollection3[num]);
                        this.dataGridView1.Columns[@string].DisplayIndex = displayIndex;
                    }
                }
            }
        }
        public void updatelist(string sql)
        {
            this.label3.Visible = false;
            this.dataGridView1.Hide();
            int num = 0;
            if (sql == "")
            {
                this.SaveScrollPos();
                sql = this.nowsql;
                num = 1;
            }
            else
            {
                this.nowsql = sql;
            }
            int num2 = this.pagesize * this.currpage;
            string sortmode = "asc";
            if (this.lastSortColMode == 1)
            {
                sortmode = "desc";
            }
            object obj = sql;
            sql = string.Concat(new object[]
			{
				obj,
				" limit ",
				num2,
				",",
				this.pagesize
			});
            MainSheet.getDataDelegate getDataDelegate = new MainSheet.getDataDelegate(this.getDataFromDB);
            getDataDelegate.BeginInvoke(sql, sortmode, new AsyncCallback(this.CallBack), null);
            this.loadfrm = new LoadProgress();
            this.loadfrm.ShowDialog();
            if (this.readDBerror == 0)
            {
                this.UpdateGridViewDisplay();
                if (num == 1)
                {
                    this.RestoreScrollPos();
                }
                this.dataGridView1.Show();
            }
            else
            {
                this.label3.Text = "服务器数据库异常，请确认数据库正常开启以及网络正常，稍后重试！";
                this.label3.Visible = true;
            }
            this.updateColor();
        }
        public void updateColor()
        {
            int month = DateTime.Now.Month;
            int year = DateTime.Now.Year;
            string pattern = "([0-9]+)年([0-9]+)月";
            string pattern2 = "([0-9]+)年([0-9]+)月";
            for (int i = 0; i < this.dataGridView1.Rows.Count - 1; i++)
            {
                Regex regex = new Regex(pattern);
                string input = this.dataGridView1.Rows[i].Cells["buycontract"].Value.ToString();
                string input2 = this.dataGridView1.Rows[i].Cells["selldate"].Value.ToString();
                MatchCollection matchCollection = regex.Matches(input);
                Match match = Regex.Match(input, pattern, RegexOptions.IgnoreCase);
                if (match.Success)
                {
                    string value = match.Groups[1].Value;
                    string value2 = match.Groups[2].Value;
                    int num = int.Parse(value);
                    int num2 = int.Parse(value2);
                }
                match = Regex.Match(input2, pattern2, RegexOptions.IgnoreCase);
                if (match.Success)
                {
                    string value = match.Groups[1].Value;
                    string value2 = match.Groups[2].Value;
                    int num3 = int.Parse(value);
                    int num4 = int.Parse(value2);
                }
                if (this.dataGridView1.Rows[i].Cells["cksj"].Value.ToString() != "")
                {
                    this.dataGridView1.Rows[i].DefaultCellStyle.BackColor = Color.LightBlue;
                }
                else
                {
                    if (this.dataGridView1.Rows[i].Cells["rkrq"].Value.ToString() != "" || this.dataGridView1.Rows[i].Cells["buycontract"].Value.ToString() == "已入库" || this.dataGridView1.Rows[i].Cells["kucun"].Value.ToString() == "有货")
                    {
                        this.dataGridView1.Rows[i].DefaultCellStyle.BackColor = Color.Red;
                    }
                    else
                    {
                        if (this.dataGridView1.Rows[i].Cells["buycontract"].Value.ToString() == "" || this.dataGridView1.Rows[i].Cells["buycontract"].Value.ToString() == "未订")
                        {
                            this.dataGridView1.Rows[i].DefaultCellStyle.BackColor = Color.Yellow;
                        }
                    }
                }
            }
        }
        private void MainSheet_FormClosed(object sender, FormClosedEventArgs e)
        {
            Environment.Exit(0);
        }
        private void button1_Click(object sender, EventArgs e)
        {
            SheetHeaderSetting header = new SheetHeaderSetting();
            header.Owner = this;
            header.init();
            header.Show();
        }
        public void hidecolumn(string columnname)
        {
            this.dataGridView1.Columns[columnname].Visible = false;
        }
        public void unhidecolumn(string columnname)
        {
            this.dataGridView1.Columns[columnname].Visible = true;
        }
        public DataGridViewColumnCollection getcolumns()
        {
            return this.dataGridView1.Columns;
        }
        private void 设置内容选项ToolStripMenuItem_Click(object sender, EventArgs e)
        {
        }
        public DataOperator getdbop()
        {
            return this.dbop;
        }
        private void button2_Click(object sender, EventArgs e)
        {
            AddContract newContract = new AddContract();
            newContract.Owner = this;
            newContract.init();
            newContract.Show();
        }
        private void button4_Click(object sender, EventArgs e)
        {
            int rowCount = this.dataGridView1.Rows.GetRowCount(DataGridViewElementStates.Selected);
            if (rowCount < 1)
            {
                MessageBox.Show("必须选择一行或者多行进行删除操作", "信息", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            }
            else
            {
                if (DialogResult.Yes == MessageBox.Show("确认删除选定的这些行数据?", "信息", MessageBoxButtons.YesNo, MessageBoxIcon.Question))
                {
                    for (int i = 0; i < rowCount; i++)
                    {
                        if (this.dataGridView1.SelectedRows[i].Index == this.dataGridView1.Rows.Count - 1)
                        {
                            MessageBox.Show("不能选择最后的合计行", "信息", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                            return;
                        }
                        int id = (int)this.dataGridView1.SelectedRows[i].Cells[0].Value;
                        this.removeItem(id);
                    }
                    this.SaveScrollPos();
                    this.updatelist(this.defaultsql);
                    this.RestoreScrollPos();
                    MessageBox.Show("删除成功", "信息", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                }
            }
        }
        private int removeItem(int id)
        {
            string sql = "delete from balance where id=" + id;
            return this.dbop.updatesql(sql);
        }
        private void button3_Click(object sender, EventArgs e)
        {
            int rowCount = this.dataGridView1.Rows.GetRowCount(DataGridViewElementStates.Selected);
            if (rowCount > 1)
            {
                MessageBox.Show("必须选定一行或者一行中某元素进行操作", "信息", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            }
            else
            {
                int num;
                if (rowCount == 0)
                {
                    int count = this.dataGridView1.SelectedCells.Count;
                    if (count != 1)
                    {
                        MessageBox.Show("必须选定一行或者一行中某元素进行操作", "信息", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                        return;
                    }
                    num = this.dataGridView1.SelectedCells[0].RowIndex;
                }
                else
                {
                    num = this.dataGridView1.SelectedRows[0].Index;
                    if (this.dataGridView1.SelectedRows[0].Index == this.dataGridView1.Rows.Count - 1)
                    {
                        MessageBox.Show("不能选择最后的合计行", "信息", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                        return;
                    }
                }
                int id = (int)this.dataGridView1.Rows[num].Cells[0].Value;
                AddContract newContract = new AddContract();
                newContract.Owner = this;
                newContract.init();
                newContract.setcontractid(id);
                if (newContract.editmode(num) != -1)
                {
                    newContract.Show();
                }
                else
                {
                    newContract.Dispose();
                }
            }
        }
        private void button1_MouseHover(object sender, EventArgs e)
        {
            this.toolStripStatusLabel1.Text = "设置需要显示的列";
        }
        private void button1_MouseLeave(object sender, EventArgs e)
        {
            this.resumeStatus();
        }
        private void resumeStatus()
        {
            int num = this.currpage + 1;
            this.toolStripStatusLabel1.Text = string.Concat(new object[]
			{
				"西安太航物资平衡表 操作员:",
				this.curruser,
				"          当前显示搜索结果的第",
				num,
				"页"
			});
        }
        private void dataGridView1_ColumnHeaderMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            int columnIndex = e.ColumnIndex;
            string text = Interaction.InputBox("输入新列名", "修改列名", this.dataGridView1.Columns[columnIndex].HeaderText, 500, 400);
            if (text != "")
            {
                this.dataGridView1.Columns[columnIndex].HeaderText = text;
            }
        }
        private void 新建表单ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            EditContent editContent = new EditContent();
            editContent.Owner = this;
            editContent.init();
            editContent.Show();
        }
        private void button2_MouseHover(object sender, EventArgs e)
        {
            this.toolStripStatusLabel1.Text = "添加新的项目";
        }
        private void button2_MouseLeave(object sender, EventArgs e)
        {
            this.resumeStatus();
        }
        private void button3_MouseHover(object sender, EventArgs e)
        {
            this.toolStripStatusLabel1.Text = "编辑选中的项目";
        }
        private void button3_MouseLeave(object sender, EventArgs e)
        {
            this.resumeStatus();
        }
        private void button4_MouseHover(object sender, EventArgs e)
        {
            this.toolStripStatusLabel1.Text = "删除选中的项目";
        }
        private void button4_MouseLeave(object sender, EventArgs e)
        {
            this.resumeStatus();
        }
        private void 设置表单ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int cellCount = this.dataGridView1.GetCellCount(DataGridViewElementStates.Selected);
            if (cellCount != 1)
            {
                MessageBox.Show("必须选择一格进行操作", "信息", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            }
            else
            {
                int columnIndex = this.dataGridView1.SelectedCells[0].ColumnIndex;
                string headerText = this.dataGridView1.Columns[columnIndex].HeaderText;
                string name = this.dataGridView1.Columns[columnIndex].Name;
                string text = Interaction.InputBox("输入新列名", "修改列名", headerText, 500, 400);
                if (!(text == ""))
                {
                    string sql = string.Concat(new string[]
					{
						"select * from tbdesc where display='",
						text,
						"' and columnname!='",
						name,
						"'"
					});
                    System.Data.DataTable data = this.dbop.getData(sql);
                    if (data.Rows.Count > 0)
                    {
                        MessageBox.Show("已经有其他列使用此名称，不建议重名", "警告", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    }
                    else
                    {
                        string sql2 = string.Concat(new string[]
						{
							"update tbdesc set display='",
							text,
							"' where columnname='",
							name,
							"'"
						});
                        int num = this.dbop.updatesql(sql2);
                        if (num == 1)
                        {
                            MessageBox.Show("修改成功", "信息", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                            this.dataGridView1.Columns[columnIndex].HeaderText = text;
                            if (name == "buycontract" || name == "buyman" || name == "sellman" || name == "sellcontract")
                            {
                                string key = name + "label";
                                this.setLabeltext(name, (System.Windows.Forms.Label)this.groupBox1.Controls[key]);
                            }
                            StringCollection columnDisplay = Settings.Default.ColumnDisplay;
                            int num2 = columnDisplay.IndexOf(headerText);
                            if (num2 != -1)
                            {
                                columnDisplay[num2] = text;
                                Settings.Default.Save();
                            }
                        }
                        else
                        {
                            MessageBox.Show("修改失败,请重试", "信息", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                        }
                    }
                }
            }
        }
        private void 退出ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Environment.Exit(0);
        }
        private void 导出ExcelToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.DefaultExt = "xls";
            saveFileDialog.Filter = "Excel文件|*.xls";
            saveFileDialog.ShowDialog();
            string fileName = saveFileDialog.FileName;
            if (fileName.IndexOf(":") >= 0)
            {
                ApplicationClass applicationClass = new ApplicationClass();
                applicationClass.Application.Workbooks.Add(Type.Missing);
                applicationClass.Columns.ColumnWidth = 20;
                int i = 0;
                int num = 1;
                applicationClass.Cells[1, num] = "序号";
                num++;
                while (i < this.dataGridView1.Columns.Count)
                {
                    if (this.dataGridView1.Columns[i].Visible)
                    {
                        applicationClass.Cells[1, num] = this.dataGridView1.Columns[i].HeaderText;
                        num++;
                    }
                    i++;
                }
                for (i = 0; i < this.dataGridView1.Rows.Count; i++)
                {
                    num = 1;
                    if (i == this.dataGridView1.Rows.Count - 1)
                    {
                        applicationClass.Cells[i + 2, num] = "合计";
                    }
                    else
                    {
                        applicationClass.Cells[i + 2, num] = i + 1;
                    }
                    num++;
                    DataGridViewRow dataGridViewRow = this.dataGridView1.Rows[i];
                    if (dataGridViewRow.Visible)
                    {
                        for (int j = 0; j < this.dataGridView1.Columns.Count; j++)
                        {
                            if (this.dataGridView1.Columns[j].Visible)
                            {
                                applicationClass.Cells[i + 2, num] = dataGridViewRow.Cells[j].Value;
                                num++;
                            }
                        }
                    }
                }
                applicationClass.ActiveWorkbook.SaveCopyAs(fileName);
                applicationClass.ActiveWorkbook.Saved = true;
                applicationClass.Quit();
                MessageBox.Show("已成功导出为Excel", "信息", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            }
        }
        private void 打印ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.doPrintSetting(false);
        }
        private void doPrintSetting(bool printselect)
        {
            PrintSetting printSetting = new PrintSetting();
            printSetting.Owner = this;
            printSetting.init();
            printSetting.ShowDialog();
            if (printSetting.isOK())
            {
                DataGridViewPrinter dataGridViewPrinter = new DataGridViewPrinter(this.dataGridView1);
                dataGridViewPrinter.setList(printSetting.dislists);
                dataGridViewPrinter.setFont(printSetting.headFont, printSetting.contentFont);
                dataGridViewPrinter.setList(printSetting.dislists);
                dataGridViewPrinter.setTitle(printSetting.Title, printSetting.TitleFont);
                dataGridViewPrinter.setAutoWrap(printSetting.WrapString);
                dataGridViewPrinter.setAppendLine(printSetting.AppendLine);
                if (printselect)
                {
                    dataGridViewPrinter.setprintselection();
                }
                dataGridViewPrinter.Print();
            }
        }
        private string getPrintColumnString()
        {
            return this.getDiscolumns();
        }
        public string getDiscolumns()
        {
            int[] array = new int[this.dataGridView1.Columns.Count];
            int num = 0;
            for (int i = 0; i < this.dataGridView1.Columns.Count; i++)
            {
                int displayIndex = this.dataGridView1.Columns[i].DisplayIndex;
                if (!this.dataGridView1.Columns[i].Visible)
                {
                    array[displayIndex] = -1;
                }
                else
                {
                    array[displayIndex] = i;
                    num++;
                }
            }
            string[] array2 = new string[num];
            int num2 = 0;
            for (int j = 0; j < this.dataGridView1.Columns.Count; j++)
            {
                int num3 = array[j];
                if (num3 != -1)
                {
                    if (this.dataGridView1.Columns[num3].Visible)
                    {
                        array2[num2] = this.dataGridView1.Columns[num3].Name;
                        num2++;
                    }
                }
            }
            return string.Join(",", array2);
        }
        public void initoptioncombo(ComboBox combo, string columnname, int sorttype)
        {
            DateTime dateTime = DateTime.Now.AddMonths(-3);
            string sql = string.Concat(new string[]
			{
				"select ",
				columnname,
				" from balance group by ",
				columnname,
				" order by max(id) desc"
			});
            if (sorttype == 1)
            {
                sql = string.Concat(new string[]
				{
					"select ",
					columnname,
					" from balance group by ",
					columnname,
					" order by ",
					columnname,
					" asc"
				});
            }
            System.Data.DataTable data = this.dbop.getData(sql);
            DataTableReader dataTableReader = data.CreateDataReader();
            while (dataTableReader.Read())
            {
                string text = dataTableReader.GetValue(0).ToString();
                if (text != "")
                {
                    combo.Items.Add(text);
                }
            }
        }
        public void initfixcombo(ComboBox combo, string columnname)
        {
            string sql = "select append from tbdesc where columnname='" + columnname + "'";
            System.Data.DataTable data = this.dbop.getData(sql);
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
                combo.Items.Add(array[i]);
            }
        }
        private void button5_Click(object sender, EventArgs e)
        {
            if (!this.startdate.Checked)
            {
                MessageBox.Show("开始日期不能为空", "信息", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            }
            else
            {
                string text = this.startdate.Text;
                string sql = "select * from balance where created >= '" + text + "'";
                this.updatelist(sql);
            }
        }
        private void button6_Click(object sender, EventArgs e)
        {
            if (!this.enddate.Checked)
            {
                MessageBox.Show("结束日期不能为空", "信息", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            }
            else
            {
                string text = this.enddate.Text;
                string sql = "select * from balance where created <='" + text + "'";
                this.updatelist(sql);
            }
        }
        private void button7_Click(object sender, EventArgs e)
        {
            if (this.sellman.Text == "")
            {
                if (DialogResult.Yes != MessageBox.Show("确定查找无需方单位的合同?", "信息", MessageBoxButtons.YesNo, MessageBoxIcon.Question))
                {
                    return;
                }
            }
            string text = this.sellman.Text;
            string sql = "select * from balance where sellman='" + text + "'";
            this.updatelist(sql);
        }
        private void button8_Click(object sender, EventArgs e)
        {
            if (this.buyman.Text == "")
            {
                if (DialogResult.Yes != MessageBox.Show("确定查找无供方单位的合同?", "信息", MessageBoxButtons.YesNo, MessageBoxIcon.Question))
                {
                    return;
                }
            }
            string text = this.buyman.Text;
            string sql = "select * from balance where buyman='" + text + "'";
            this.updatelist(sql);
        }
        private void button9_Click(object sender, EventArgs e)
        {
        }
        private void button10_Click(object sender, EventArgs e)
        {
            if (this.buycontract.Text == "")
            {
                MessageBox.Show("合同号不能为空", "信息", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            }
            else
            {
                string text = this.buycontract.Text;
                string sql = "select * from balance where buycontract='" + text + "'";
                this.updatelist(sql);
            }
        }
        private void button17_Click(object sender, EventArgs e)
        {
            int selectedIndex = this.cksj.SelectedIndex;
            if (selectedIndex == -1)
            {
                MessageBox.Show("出库状态不能为空", "信息", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            }
            else
            {
                string sql = "";
                if (selectedIndex == 0)
                {
                    sql = "select * from balance where cksj is not NULL";
                }
                else
                {
                    if (selectedIndex == 1)
                    {
                        sql = "select * from balance where cksj is NULL";
                    }
                    else
                    {
                        if (selectedIndex == 2)
                        {
                            sql = "select * from balance where cksj is NULL and (rkrq is not NULL or buycontract = '已入库')";
                        }
                        else
                        {
                            if (selectedIndex == 3)
                            {
                                sql = "select * from balance where cksj is NULL and (rkrq is NULL and buycontract != '已入库')";
                            }
                        }
                    }
                }
                this.updatelist(sql);
            }
        }
        private void initCustomSearchCombo()
        {
            string sql = "select * from tbdesc";
            System.Data.DataTable data = this.dbop.getData(sql);
            DataTableReader dataTableReader = data.CreateDataReader();
            while (dataTableReader.Read())
            {
                string @string = dataTableReader.GetString(1);
                string string2 = dataTableReader.GetString(2);
                int @int = dataTableReader.GetInt32(3);
                ComboItem item = new ComboItem(@string, string2, @int);
                this.customSearch.Items.Add(item);
            }
        }
        private void button11_Click(object sender, EventArgs e)
        {
            string text = this.startdate.Text;
            string text2 = this.enddate.Text;
            string text3 = this.sellman.Text;
            string text4 = this.buyman.Text;
            string text5 = this.buycontract.Text;
            int month = DateTime.Now.Month;
            string str = DateTime.Now.Year.ToString();
            string str2;
            if (month < 10)
            {
                str2 = "0" + month;
            }
            else
            {
                str2 = "" + month;
            }
            string str3 = str + "年" + str2 + "月";
            string str4 = str + "年" + str2 + "月";
            int num = 0;
            string text6 = "select * from balance ";
            if (this.startdate.Checked && text != "")
            {
                text6 = text6 + "where created >='" + text + "' ";
                num = 1;
            }
            if (this.enddate.Checked && text2 != "")
            {
                if (num == 1)
                {
                    text6 = text6 + "and created <='" + text2 + "' ";
                }
                else
                {
                    text6 = text6 + "where created <='" + text2 + "' ";
                    num = 1;
                }
            }
            if (text3 != "")
            {
                if (num == 1)
                {
                    text6 = text6 + "and sellman='" + text3 + "' ";
                }
                else
                {
                    text6 = text6 + "where sellman='" + text3 + "' ";
                    num = 1;
                }
            }
            if (text4 != "")
            {
                if (num == 1)
                {
                    text6 = text6 + "and buyman='" + text4 + "' ";
                }
                else
                {
                    text6 = text6 + "where buyman='" + text4 + "' ";
                    num = 1;
                }
            }
            if (this.htdqzt.SelectedIndex != -1)
            {
                if (this.htdqzt.SelectedIndex == 0)
                {
                    if (num == 1)
                    {
                        text6 = text6 + "and id not in(select id from balance where cksj is not NULL or (rkrq is not NULL or buycontract='已入库' or kucun = '有货') ) and (buycontract regexp '[0-9]+年[0-9]+月' and buycontract <='" + str4 + "') ";
                    }
                    else
                    {
                        text6 = text6 + "where id not in(select id from balance where cksj is not NULL or (rkrq is not NULL or buycontract='已入库' or kucun = '有货') ) and (buycontract regexp '[0-9]+年[0-9]+月' and buycontract <='" + str4 + "') ";
                        num = 1;
                    }
                }
                if (this.htdqzt.SelectedIndex == 1)
                {
                    if (num == 1)
                    {
                        text6 = text6 + "and cksj is NULL and (selldate regexp '[0-9]+年[0-9]+月' and selldate <='" + str3 + " ') ";
                    }
                    else
                    {
                        text6 = text6 + "where cksj is NULL and (selldate regexp '[0-9]+年[0-9]+月' and selldate <='" + str3 + " ') ";
                        num = 1;
                    }
                }
            }
            if (text5 != "")
            {
                if (num == 1)
                {
                    text6 = text6 + "and buycontract='" + text5 + "' ";
                }
                else
                {
                    text6 = text6 + "where buycontract='" + text5 + "' ";
                    num = 1;
                }
            }
            if (this.cksj.SelectedIndex != -1)
            {
                if (num == 1)
                {
                    if (this.cksj.SelectedIndex == 0)
                    {
                        text6 += "and cksj is not NULL ";
                    }
                    else
                    {
                        if (this.cksj.SelectedIndex == 1)
                        {
                            text6 += "and cksj is NULL ";
                        }
                        else
                        {
                            if (this.cksj.SelectedIndex == 2)
                            {
                                text6 += "and (cksj is NULL and (rkrq is not NULL or buycontract = '已入库')) ";
                            }
                            else
                            {
                                if (this.cksj.SelectedIndex == 3)
                                {
                                    text6 += "and (cksj is NULL and (rkrq is NULL and buycontract != '已入库')) ";
                                }
                            }
                        }
                    }
                }
                else
                {
                    if (this.cksj.SelectedIndex == 0)
                    {
                        text6 += "where cksj is not NULL ";
                    }
                    else
                    {
                        if (this.cksj.SelectedIndex == 1)
                        {
                            text6 += "where cksj is NULL ";
                        }
                        else
                        {
                            if (this.cksj.SelectedIndex == 2)
                            {
                                text6 += "where cksj is NULL and (rkrq is not NULL or buycontract = '已入库') ";
                            }
                            else
                            {
                                if (this.cksj.SelectedIndex == 3)
                                {
                                    text6 += "where cksj is NULL and (rkrq is NULL and buycontract != '已入库') ";
                                }
                            }
                        }
                    }
                    num = 1;
                }
            }
            if (this.ysbs.SelectedIndex != -1)
            {
                int selectedIndex = this.ysbs.SelectedIndex;
                if (num == 1)
                {
                    switch (selectedIndex)
                    {
                        case 0:
                            text6 += "and cksj is not NULL";
                            break;
                        case 1:
                            text6 += "and id not in(select id from balance where cksj is not NULL) and (rkrq is not NULL or buycontract='已入库' or kucun = '有货') ";
                            break;
                        case 2:
                            text6 += "and id not in(select id from balance where cksj is not NULL or (rkrq is not NULL or buycontract='已入库' or kucun = '有货')) and (buycontract = '' or buycontract ='未订') ";
                            break;
                        case 3:
                            text6 += "and id not in(select id from balance where cksj is not NULL or (rkrq is not NULL or buycontract='已入库' or kucun = '有货') or (buycontract = '' or buycontract ='未订')) ";
                            break;
                    }
                }
                else
                {
                    switch (selectedIndex)
                    {
                        case 0:
                            text6 += "where cksj is not NULL";
                            break;
                        case 1:
                            text6 += "where id not in(select id from balance where cksj is not NULL) and (rkrq is not NULL or buycontract='已入库' or kucun = '有货') ";
                            break;
                        case 2:
                            text6 += "where id not in(select id from balance where cksj is not NULL or (rkrq is not NULL or buycontract='已入库' or kucun = '有货')) and (buycontract = '' or buycontract ='未订') ";
                            break;
                        case 3:
                            text6 += "where id not in(select id from balance where cksj is not NULL or (rkrq is not NULL or buycontract='已入库' or kucun = '有货') or (buycontract = '' or buycontract ='未订')) ";
                            break;
                    }
                    num = 1;
                }
            }
            if (this.fpzt.SelectedIndex != -1)
            {
                int selectedIndex = this.fpzt.SelectedIndex;
                if (num == 1)
                {
                    if (selectedIndex == 0)
                    {
                        text6 += "and (cksj is not NULL and sellfapiao is not NULL) ";
                    }
                    else
                    {
                        if (selectedIndex == 1)
                        {
                            text6 += "and (cksj is not NULL and sellfapiao is NULL) ";
                        }
                        else
                        {
                            if (selectedIndex == 2)
                            {
                                text6 += "and (rkrq is not NULL and buyfapiao is not NULL) ";
                            }
                            else
                            {
                                if (selectedIndex == 3)
                                {
                                    text6 += "and (rkrq is not NULL and buyfapiao is NULL) ";
                                }
                            }
                        }
                    }
                }
                else
                {
                    if (selectedIndex == 0)
                    {
                        text6 += "where (cksj is not NULL and sellfapiao is not NULL) ";
                    }
                    else
                    {
                        if (selectedIndex == 1)
                        {
                            text6 += "where (cksj is not NULL and sellfapiao is NULL) ";
                        }
                        else
                        {
                            if (selectedIndex == 2)
                            {
                                text6 += "where (rkrq is not NULL and buyfapiao is not NULL) ";
                            }
                            else
                            {
                                if (selectedIndex == 3)
                                {
                                    text6 += "where (rkrq is not NULL and buyfapiao is NULL) ";
                                }
                            }
                        }
                    }
                    num = 1;
                }
            }
            if (this.customSearch.SelectedIndex != -1 && this.customKey.Text != "")
            {
                ComboItem comboItem = (ComboItem)this.customSearch.SelectedItem;
                string text7 = this.customKey.Text.Trim();
                int type = comboItem.getType();
                if (type == 3)
                {
                    try
                    {
                        double num2 = double.Parse(text7);
                        if (num == 1)
                        {
                            object obj = text6;
                            text6 = string.Concat(new object[]
							{
								obj,
								"and ",
								comboItem.getName(),
								"=",
								num2
							});
                        }
                        else
                        {
                            object obj = text6;
                            text6 = string.Concat(new object[]
							{
								obj,
								"where ",
								comboItem.getName(),
								"=",
								num2
							});
                            num = 1;
                        }
                    }
                    catch (Exception)
                    {
                        MessageBox.Show("自定义搜索对应该列的值只能为一个数字", "错误", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        return;
                    }
                }
                else
                {
                    if (type == 4)
                    {
                        if (num == 1)
                        {
                            string text8 = text6;
                            text6 = string.Concat(new string[]
							{
								text8,
								"and ",
								comboItem.getName(),
								" ='",
								text7,
								"' "
							});
                        }
                        else
                        {
                            string text8 = text6;
                            text6 = string.Concat(new string[]
							{
								text8,
								"where ",
								comboItem.getName(),
								" ='",
								text7,
								"' "
							});
                            num = 1;
                        }
                    }
                    else
                    {
                        if (num == 1)
                        {
                            string text8 = text6;
                            text6 = string.Concat(new string[]
							{
								text8,
								"and ",
								comboItem.getName(),
								" like '%",
								text7,
								"%' "
							});
                        }
                        else
                        {
                            string text8 = text6;
                            text6 = string.Concat(new string[]
							{
								text8,
								"where ",
								comboItem.getName(),
								" like '%",
								text7,
								"%' "
							});
                            num = 1;
                        }
                    }
                }
            }
            if (num == 0)
            {
                MessageBox.Show("必须选择至少一种过滤条件", "提示", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            }
            else
            {
                this.updatelist(text6);
            }
        }
        private void button12_Click(object sender, EventArgs e)
        {
            this.currpage = 0;
            this.SaveScrollPosX();
            this.updatelist("select * from balance order by created desc");
            this.RestoreScrollPosX();
        }
        private void 关于AToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AboutForm about = new AboutForm();
            about.ShowDialog();
        }
        private void updatepagesize(int psize)
        {
            this.pagesize = psize;
        }
        private void setPageSize(int psize)
        {
            this.pagesize = psize;
            Settings.Default.PageSize = psize;
            Settings.Default.Save();
            if (DialogResult.OK == MessageBox.Show("页面大小已更改，立即刷新数据?", "提示", MessageBoxButtons.OKCancel, MessageBoxIcon.Question))
            {
                this.updatelist(this.defaultsql);
            }
        }
        private void toolStripMenuItem2_Click(object sender, EventArgs e)
        {
            this.setPageSize(30);
        }
        private void toolStripMenuItem3_Click(object sender, EventArgs e)
        {
            this.setPageSize(50);
        }
        private void toolStripMenuItem4_Click(object sender, EventArgs e)
        {
            this.setPageSize(100);
        }
        private void toolStripMenuItem5_Click(object sender, EventArgs e)
        {
            this.setPageSize(200);
        }
        private void button13_Click(object sender, EventArgs e)
        {
            if (this.currpage == 0)
            {
                MessageBox.Show("当前页已经是第一页", "提示", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            }
            else
            {
                this.currpage--;
                this.scrollPosX = 0;
                this.updatelist("");
                this.resumeStatus();
            }
        }
        private void button14_Click(object sender, EventArgs e)
        {
            if (this.dataGridView1.Rows.Count - 1 < this.pagesize)
            {
                MessageBox.Show("当前页已经是最后一页", "提示", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            }
            else
            {
                this.currpage++;
                this.scrollPosX = 0;
                this.updatelist("");
                this.resumeStatus();
            }
        }
        private void button15_Click(object sender, EventArgs e)
        {
            if (this.groupBox1.Visible)
            {
                this.groupBox1.Visible = false;
                this.button15.Text = ">";
            }
            else
            {
                this.groupBox1.Visible = true;
                this.button15.Text = "<";
            }
        }
        private void toolStripMenuItem6_Click(object sender, EventArgs e)
        {
            this.setPageSize(15);
        }
        private void toolStripMenuItem7_Click(object sender, EventArgs e)
        {
            this.setPageSize(20);
        }
        private void dataGridView1_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            try
            {
                SolidBrush brush = new SolidBrush(this.dataGridView1.RowHeadersDefaultCellStyle.ForeColor);
                int num = e.RowIndex + 1;
                int num2 = 15;
                int num3 = 5;
                string s = num.ToString();
                if (e.RowIndex == this.dataGridView1.Rows.Count - 1)
                {
                    s = "合计";
                    num2 = 5;
                }
                e.Graphics.DrawString(s, e.InheritedRowStyle.Font, brush, (float)(e.RowBounds.Location.X + num2), (float)(e.RowBounds.Location.Y + num3));
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void 保存显示格式ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            StringCollection stringCollection = new StringCollection();
            StringCollection stringCollection2 = new StringCollection();
            StringCollection stringCollection3 = new StringCollection();
            for (int i = 0; i < this.dataGridView1.Columns.Count; i++)
            {
                if (this.dataGridView1.Columns[i].Visible)
                {
                    string name = this.dataGridView1.Columns[i].Name;
                    string value = this.dataGridView1.Columns[i].DisplayIndex.ToString();
                    stringCollection.Add(name);
                    stringCollection3.Add(value);
                    stringCollection2.Add(this.dataGridView1.Columns[i].Width.ToString());
                }
            }
            Settings.Default.ColumnDisplay = stringCollection;
            Settings.Default.ColumnWidth = stringCollection2;
            Settings.Default.ColumnIndex = stringCollection3;
            Settings.Default.HeaderFont = this.dataGridView1.ColumnHeadersDefaultCellStyle.Font;
            Settings.Default.CellFont = this.dataGridView1.DefaultCellStyle.Font;
            Settings.Default.Save();
            MessageBox.Show("显示样式保存成功", "成功", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
        }
        private void 打开帮助文档OToolStripMenuItem_Click(object sender, EventArgs e)
		{
			try
			{
				Process p = new Process();
                p.StartInfo.FileName = "物资平衡表安装使用帮助.doc";
				p.Start();
			}
			catch (Exception)
			{
				MessageBox.Show("无法找到系统帮助文件，是否已经被删除，重装程序可能会解决此问题", "错误", MessageBoxButtons.OK, MessageBoxIcon.Hand);
			}
		}
        private void dataGridView1_SortCompare(object sender, DataGridViewSortCompareEventArgs e)
        {
            try
            {
                if (e.RowIndex1 == this.dataGridView1.Rows.Count - 1)
                {
                    e.Handled = true;
                }
                if (e.RowIndex2 == this.dataGridView1.Rows.Count - 1)
                {
                    e.Handled = true;
                }
            }
            catch (Exception ex)
            {
                ex.ToString();
            }
        }
        private void dataGridView1_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            this.scrollPosY = this.dataGridView1.FirstDisplayedScrollingColumnIndex;
            if (e.RowIndex >= 0 || this.dataGridView1.Rows.Count == 0)
            {
                if (e.ColumnIndex >= 0)
                {
                    int rowIndex = e.RowIndex;
                    int columnIndex = e.ColumnIndex;
                    if (this.dataGridView1.Columns[columnIndex].Name == "sellman")
                    {
                        string str = this.dataGridView1.Rows[rowIndex].Cells[columnIndex].Value.ToString();
                        string sql = "select person1, phone1, person2, phone2, person3, phone3, address, zip from contacts where name='" + str + "'";
                        System.Data.DataTable data = this.dbop.getData(sql);
                        DataTableReader dataTableReader = data.CreateDataReader();
                        string caption;
                        if (dataTableReader.Read())
                        {
                            string @string = dataTableReader.GetString(0);
                            string string2 = dataTableReader.GetString(1);
                            string string3 = dataTableReader.GetString(2);
                            string string4 = dataTableReader.GetString(3);
                            string string5 = dataTableReader.GetString(4);
                            string string6 = dataTableReader.GetString(5);
                            string string7 = dataTableReader.GetString(6);
                            string string8 = dataTableReader.GetString(7);
                            caption = string.Concat(new string[]
							{
								"联系人: ",
								@string,
								" 电话: ",
								string2,
								"\n联系人: ",
								string3,
								" 电话: ",
								string4,
								"\n联系人: ",
								string5,
								" 电话: ",
								string6,
								"\n地址: ",
								string7,
								"\n邮编: ",
								string8
							});
                        }
                        else
                        {
                            caption = "暂无此联系单位信息,请在通讯录中添加";
                        }
                        ToolTip toolTip = new ToolTip();
                        toolTip.SetToolTip(this.dataGridView1, caption);
                    }
                    else
                    {
                        if (this.dataGridView1.Columns[columnIndex].Name == "buyman")
                        {
                            string str2 = this.dataGridView1.Rows[rowIndex].Cells[columnIndex].Value.ToString();
                            string sql = "select person1, phone1, person2, phone2, person3, phone3, address, zip from contacts where name='" + str2 + "'";
                            System.Data.DataTable data = this.dbop.getData(sql);
                            DataTableReader dataTableReader = data.CreateDataReader();
                            string caption;
                            if (dataTableReader.Read())
                            {
                                string @string = dataTableReader.GetString(0);
                                string string2 = dataTableReader.GetString(1);
                                string string3 = dataTableReader.GetString(2);
                                string string4 = dataTableReader.GetString(3);
                                string string5 = dataTableReader.GetString(4);
                                string string6 = dataTableReader.GetString(5);
                                string string7 = dataTableReader.GetString(6);
                                string string8 = dataTableReader.GetString(7);
                                caption = string.Concat(new string[]
								{
									"联系人: ",
									@string,
									" 电话: ",
									string2,
									"\n联系人: ",
									string3,
									" 电话: ",
									string4,
									"\n联系人: ",
									string5,
									" 电话: ",
									string6,
									"\n地址: ",
									string7,
									"\n邮编: ",
									string8
								});
                            }
                            else
                            {
                                caption = "暂无此联系单位信息,请在通讯录中添加";
                            }
                            ToolTip toolTip = new ToolTip();
                            toolTip.SetToolTip(this.dataGridView1, caption);
                        }
                    }
                }
            }
            else
            {
                if (this.lastRow.Count == 0)
                {
                    this.colindex = e.ColumnIndex;
                    int index = this.dataGridView1.Rows.Count - 1;
                    this.lastRow.Add(((System.Data.DataTable)this.dataGridView1.DataSource).Rows[index].ItemArray);
                    this.dataGridView1.Rows.Remove(this.dataGridView1.Rows[this.dataGridView1.Rows.Count - 1]);
                }
            }
        }
        public void SetSelectRow(int rindex)
        {
            this.dataGridView1.Rows[rindex].Selected = true;
        }
        private void dataGridView1_Sorted(object sender, EventArgs e)
        {
            if (this.lastRow.Count != 0)
            {
                if (this.colindex >= 0)
                {
                    System.Data.DataTable dataTable = (System.Data.DataTable)this.dataGridView1.DataSource;
                    DataView defaultView = dataTable.DefaultView;
                    defaultView.Sort = dataTable.Columns[this.colindex].ColumnName;
                    if (this.lastSortColName != defaultView.Sort)
                    {
                        this.lastSortColName = defaultView.Sort;
                        defaultView.Sort += " ASC";
                        this.lastSortColMode = 0;
                    }
                    else
                    {
                        if (this.lastSortColMode == 0)
                        {
                            defaultView.Sort += " DESC";
                            this.lastSortColMode = 1;
                        }
                        else
                        {
                            defaultView.Sort += " ASC";
                            this.lastSortColMode = 0;
                        }
                    }
                    dataTable = defaultView.ToTable();
                    dataTable.Rows.Add(this.lastRow[0]);
                    this.lastRow.Clear();
                    this.dataGridView1.DataSource = dataTable;
                    this.dataGridView1.FirstDisplayedScrollingColumnIndex = this.scrollPosY;
                    this.updateColor();
                }
            }
        }
        private void 测试ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (this.dataGridView1.SelectedRows.Count <= 0)
            {
                MessageBox.Show("首先请选中需要打印的行", "信息", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            else
            {
                this.doPrintSetting(true);
            }
        }
        private bool printTitle()
        {
            return DialogResult.Yes == MessageBox.Show("是否需要打印标题", "提示", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
        }
        private string getPrintTitle()
        {
            return Interaction.InputBox("输入打印标题名称", "打印标题", "在这里输入需要打印的标题", 500, 400);
        }
        private void 导出选中的行ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (this.dataGridView1.SelectedRows.Count <= 0)
            {
                MessageBox.Show("首先请选中需要导出的行", "信息", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            else
            {
                SaveFileDialog saveFileDialog = new SaveFileDialog();
                saveFileDialog.DefaultExt = "xls";
                saveFileDialog.Filter = "Excel文件|*.xls";
                saveFileDialog.ShowDialog();
                string fileName = saveFileDialog.FileName;
                if (fileName.IndexOf(":") >= 0)
                {
                    ApplicationClass applicationClass = new ApplicationClass();
                    applicationClass.Application.Workbooks.Add(Type.Missing);
                    applicationClass.Columns.ColumnWidth = 20;
                    int i = 0;
                    int num = 1;
                    applicationClass.Cells[1, num] = "序号";
                    num++;
                    while (i < this.dataGridView1.Columns.Count)
                    {
                        if (this.dataGridView1.Columns[i].Visible)
                        {
                            applicationClass.Cells[1, num] = this.dataGridView1.Columns[i].HeaderText;
                            num++;
                        }
                        i++;
                    }
                    int num2 = 1;
                    for (i = 0; i < this.dataGridView1.Rows.Count; i++)
                    {
                        num = 1;
                        if (this.dataGridView1.Rows[i].Selected)
                        {
                            if (i == this.dataGridView1.Rows.Count - 1)
                            {
                                applicationClass.Cells[num2 + 1, num] = "合计";
                            }
                            else
                            {
                                applicationClass.Cells[num2 + 1, num] = num2;
                            }
                            num++;
                            DataGridViewRow dataGridViewRow = this.dataGridView1.Rows[i];
                            if (dataGridViewRow.Visible)
                            {
                                for (int j = 0; j < this.dataGridView1.Columns.Count; j++)
                                {
                                    if (this.dataGridView1.Columns[j].Visible)
                                    {
                                        applicationClass.Cells[num2 + 1, num] = dataGridViewRow.Cells[j].Value;
                                        num++;
                                    }
                                }
                            }
                            num2++;
                        }
                    }
                    applicationClass.ActiveWorkbook.SaveCopyAs(fileName);
                    applicationClass.ActiveWorkbook.Saved = true;
                    applicationClass.Quit();
                    MessageBox.Show("已成功导出为Excel", "信息", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                }
            }
        }
        private void 更新合同金额UToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            string sql = "update balance set sellmoney=sellnum*pricewithtax";
            this.dbop.updatesql(sql);
            sql = "update balance set buymoney=rkl*buyprice";
            this.dbop.updatesql(sql);
            sql = "update balance set planmoney=sellnum*planprice";
            this.dbop.updatesql(sql);
            sql = "update balance set ckmoney=ckl*pricewithtax";
            this.dbop.updatesql(sql);
            MessageBox.Show("合同、采购、计划、出库金额已重新计算完成", "提示", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            this.updatelist("");
        }
        private void cksj_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Back)
            {
                this.cksj.SelectedIndex = -1;
            }
        }
        private void buycontract_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Back)
            {
                this.buycontract.SelectedIndex = -1;
            }
        }
        private void button16_Click(object sender, EventArgs e)
        {
            int columnHeadersHeight = this.dataGridView1.ColumnHeadersHeight;
            int height = this.dataGridView1.SelectedCells[0].Size.Height;
            string text = this.dataGridView1.SelectedCells[0].Value.ToString();
            MessageBox.Show(columnHeadersHeight.ToString() + " " + height.ToString());
        }
        private void 标题栏ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FontDialog fontDialog = new FontDialog();
            fontDialog.Font = this.dataGridView1.ColumnHeadersDefaultCellStyle.Font;
            fontDialog.ShowDialog();
            this.dataGridView1.ColumnHeadersDefaultCellStyle.Font = fontDialog.Font;
        }
        public System.Drawing.Font getTitleFont()
        {
            return this.dataGridView1.ColumnHeadersDefaultCellStyle.Font;
        }
        public System.Drawing.Font getContentFont()
        {
            return this.dataGridView1.DefaultCellStyle.Font;
        }
        private void 内容ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FontDialog fontDialog = new FontDialog();
            fontDialog.Font = this.dataGridView1.DefaultCellStyle.Font;
            fontDialog.ShowDialog();
            this.dataGridView1.DefaultCellStyle.Font = fontDialog.Font;
        }
        private void dataGridView1_RowHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            this.dataGridView1.FirstDisplayedScrollingColumnIndex = this.scrollPosX;
        }
        private void dataGridView1_RowLeave(object sender, DataGridViewCellEventArgs e)
        {
            this.scrollPosX = this.dataGridView1.FirstDisplayedScrollingColumnIndex;
        }
        private void dataGridView1_RowEnter(object sender, DataGridViewCellEventArgs e)
        {
        }
        private void 修正已出库合同CToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("确认删除所有已出库的合同中的采购状态与生成进度?", "提示", MessageBoxButtons.YesNo, MessageBoxIcon.Question) != DialogResult.No)
            {
                string sql = "update balance set buycontract='',jindu='' where cksj is not NULL";
                int num = this.dbop.updatesql(sql);
                if (num >= 0)
                {
                    MessageBox.Show("成功更新" + num + "条记录", "成功", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                }
                else
                {
                    MessageBox.Show("成功失败，请稍后重试", "失败", MessageBoxButtons.OK, MessageBoxIcon.Hand);
                }
                this.updatelist("");
            }
        }
        private void button16_Click_1(object sender, EventArgs e)
        {
            int selectedIndex = this.customSearch.SelectedIndex;
            if (selectedIndex == -1)
            {
                MessageBox.Show("必须选中需要查找的列的", "警告", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            }
            else
            {
                string text = this.customKey.Text;
                if (text == "")
                {
                    MessageBox.Show("查找的关键字不能为空", "警告", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                }
                else
                {
                    ComboItem comboItem = (ComboItem)this.customSearch.SelectedItem;
                    string sql = "select * from balance where " + comboItem.getName() + "=";
                    int type = comboItem.getType();
                    if (type == 3)
                    {
                        try
                        {
                            double num = double.Parse(text);
                            sql = string.Concat(new object[]
							{
								"select * from balance where ",
								comboItem.getName(),
								"=",
								num
							});
                        }
                        catch (Exception)
                        {
                            MessageBox.Show("该列的值只能为一个数字", "错误", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                            return;
                        }
                    }
                    else
                    {
                        if (type == 4)
                        {
                            sql = string.Concat(new string[]
							{
								"select * from balance where ",
								comboItem.getName(),
								" ='",
								text,
								"'"
							});
                        }
                        else
                        {
                            sql = string.Concat(new string[]
							{
								"select * from balance where ",
								comboItem.getName(),
								" like '%",
								text,
								"%'"
							});
                        }
                    }
                    this.updatelist(sql);
                }
            }
        }
        private void customSearch_KeyDown(object sender, KeyEventArgs e)
        {
            this.customSearch.SelectedIndex = -1;
        }
        private void 新建联系人NToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AddContact newContact = new AddContact();
            newContact.Owner = this;
            newContact.init();
            newContact.ShowDialog();
        }
        private void 管理通讯录MToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ContactsManage contactsManage = new ContactsManage();
            contactsManage.Owner = this;
            contactsManage.init();
            contactsManage.ShowDialog();
        }
        private void 自定义个数ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string text = Interaction.InputBox("输入每页显示个数", "显示个数", this.pagesize.ToString(), 500, 400);
            if (text != "")
            {
                try
                {
                    int pageSize = int.Parse(text);
                    this.setPageSize(pageSize);
                }
                catch (Exception)
                {
                    MessageBox.Show("显示个数必须为整数", "提示", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
            }
        }
        private void 统计选中行的合计金额ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            double num = 0.0;
            double num2 = 0.0;
            double num3 = 0.0;
            for (int i = 0; i < this.dataGridView1.SelectedRows.Count; i++)
            {
                try
                {
                    num += (double)this.dataGridView1.SelectedRows[i].Cells["sellmoney"].Value;
                }
                catch (Exception)
                {
                }
                try
                {
                    num2 += (double)this.dataGridView1.SelectedRows[i].Cells["buymoney"].Value;
                }
                catch (Exception)
                {
                }
                try
                {
                    num3 += (double)this.dataGridView1.SelectedRows[i].Cells["ckmoney"].Value;
                }
                catch (Exception)
                {
                }
            }
            MessageBox.Show(string.Concat(new object[]
			{
				"合同金额: ",
				num,
				"(元);计划金额: ",
				num2,
				"(元);出库金额: ",
				num3,
				"(元)"
			}), "合计金额", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
        }
        private void groupBox4_Enter(object sender, EventArgs e)
        {
            this.groupBox4.Width = 140;
            this.groupBox4.Height = 146;
        }
        private void groupBox4_Leave(object sender, EventArgs e)
        {
            this.groupBox4.Height = 15;
        }
        private void 人员管理ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AddUser newUser = new AddUser();
            newUser.Owner = this;
            newUser.init();
            newUser.ShowDialog();
        }
        private void 修改密码PToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ChangePassword modifyPwd = new ChangePassword();
            modifyPwd.Owner = this;
            modifyPwd.init();
            modifyPwd.ShowDialog();
        }
        private void 用户管理MToolStripMenuItem_Click(object sender, EventArgs e)
        {
            UserManage userManage = new UserManage();
            userManage.Owner = this;
            userManage.init();
            userManage.ShowDialog();
        }
        private void 恢复默认显示顺序ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int num = 0;
            while (num < this.dataGridView1.Columns.Count && num < this.defaultDisPos.Length)
            {
                this.dataGridView1.Columns[num].DisplayIndex = this.defaultDisPos[num];
                num++;
            }
        }
        private void button18_Click(object sender, EventArgs e)
        {
            int selectedIndex = this.fpzt.SelectedIndex;
            if (selectedIndex == -1)
            {
                MessageBox.Show("运费发票状态不能为空", "信息", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            }
            else
            {
                string sql = "";
                if (selectedIndex == 0)
                {
                    sql = "select * from balance where cksj is not NULL and sellfapiao is not NULL";
                }
                else
                {
                    if (selectedIndex == 1)
                    {
                        sql = "select * from balance where cksj is not NULL and sellfapiao is NULL";
                    }
                    else
                    {
                        if (selectedIndex == 2)
                        {
                            sql = "select * from balance where rkrq is not NULL and buyfapiao is not NULL";
                        }
                        else
                        {
                            if (selectedIndex == 3)
                            {
                                sql = "select * from balance where rkrq is not NULL and buyfapiao is NULL";
                            }
                        }
                    }
                }
                this.updatelist(sql);
            }
        }
        private void fpzt_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Back)
            {
                this.fpzt.SelectedIndex = -1;
            }
        }
        private void 采购合同添加年份YToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string sql = "select id,buycontract from balance";
            System.Data.DataTable data = this.dbop.getData(sql);
            DataTableReader dataTableReader = data.CreateDataReader();
            int num = 0;
            while (dataTableReader.Read())
            {
                int @int = dataTableReader.GetInt32(dataTableReader.GetOrdinal("id"));
                string text = dataTableReader.GetString(dataTableReader.GetOrdinal("buycontract"));
                string pattern = "([0-9]+)年([0-9]+)月";
                Regex regex = new Regex(pattern);
                MatchCollection matchCollection = regex.Matches(text);
                Match match = Regex.Match(text, pattern, RegexOptions.IgnoreCase);
                if (match.Success)
                {
                    string value = match.Groups[1].Value;
                    string value2 = match.Groups[2].Value;
                    if (value2.Length != 2)
                    {
                        int num2 = int.Parse(value2);
                        int num3 = int.Parse(value2);
                        if (num3 >= 1 && num3 < 10)
                        {
                            text = string.Concat(new object[]
							{
								value,
								"年0",
								num2,
								"月"
							});
                        }
                        else
                        {
                            text = string.Concat(new object[]
							{
								value,
								"年",
								num2,
								"月"
							});
                        }
                        string sql2 = string.Concat(new object[]
						{
							"update balance set buycontract='",
							text,
							"' where id=",
							@int
						});
                        this.dbop.updatesql(sql2);
                        num++;
                    }
                }
            }
            dataTableReader.Close();
            MessageBox.Show("成功更新" + num + "条记录采购合同日期为'xxxx年xx月'", "信息", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
        }
        private void 检测更新UToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int num = VersionCheck.needUpdate();
            if (num == 1)
            {
                if (MessageBox.Show("发现新版本,是否退出程序并下载新版本?", "提示", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    Process.Start(VersionCheck.getUrl());
                    Environment.Exit(1);
                }
            }
            else
            {
                if (num == 0)
                {
                    MessageBox.Show("当前已经是最新版本！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                }
                else
                {
                    if (num == -1)
                    {
                        MessageBox.Show("网络连接检测失败，无法更新！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                    }
                }
            }
        }
        private void ysbs_DrawItem(object sender, DrawItemEventArgs e)
        {
            Color color = default(Color);
            switch (e.Index)
            {
                case -1:
                    return;
                case 0:
                    color = Color.LightBlue;
                    break;
                case 1:
                    color = Color.Red;
                    break;
                case 2:
                    color = Color.Yellow;
                    break;
                case 3:
                    color = Color.White;
                    break;
            }
            e.DrawBackground();
            System.Drawing.Rectangle rect = new System.Drawing.Rectangle(2, e.Bounds.Top + 2, e.Bounds.Height, e.Bounds.Height - 4);
            e.Graphics.FillRectangle(new SolidBrush(color), rect);
            System.Drawing.Font font = new System.Drawing.Font(FontFamily.GenericSansSerif, 8f, FontStyle.Regular);
            e.Graphics.DrawString(" " + this.selectys[e.Index], font, Brushes.Black, new RectangleF((float)(e.Bounds.X + rect.Width), (float)(e.Bounds.Y + 1), (float)e.Bounds.Width, (float)e.Bounds.Height));
            e.DrawFocusRectangle();
        }
        private void button19_Click(object sender, EventArgs e)
        {
            int selectedIndex = this.ysbs.SelectedIndex;
            int month = DateTime.Now.Month;
            string str = DateTime.Now.Year.ToString();
            string str2;
            if (month < 10)
            {
                str2 = "0" + month;
            }
            else
            {
                str2 = "" + month;
            }
            if (selectedIndex == -1)
            {
                MessageBox.Show("必须选中某种具体颜色", "提示", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            }
            else
            {
                string text = "select * from balance where ";
                string text2 = str + "年" + str2 + "月";
                string text3 = str + "年" + str2 + "月";
                switch (selectedIndex)
                {
                    case 0:
                        text += "cksj is not NULL";
                        break;
                    case 1:
                        text += "id not in(select id from balance where cksj is not NULL) and (rkrq is not NULL or buycontract='已入库' or kucun = '有货')";
                        break;
                    case 2:
                        text += "id not in(select id from balance where cksj is not NULL or (rkrq is not NULL or buycontract='已入库' or kucun = '有货')) and (buycontract = '' or buycontract ='未订')";
                        break;
                    case 3:
                        text += "id not in(select id from balance where cksj is not NULL or (rkrq is not NULL or buycontract='已入库' or kucun = '有货') or (buycontract = '' or buycontract ='未订'))";
                        break;
                    default:
                        MessageBox.Show("必须选中某种合法颜色", "提示", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                        return;
                }
                this.updatelist(text);
            }
        }
        private void 修正交货期下拉列表ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string text = Interaction.InputBox("输入起始年份", "起始年份", DateTime.Now.Year.ToString(), 500, 400);
            if (text.Length != 4 || !CommonTools.IsNumberStr(text))
            {
                MessageBox.Show("请输出4位数字年份", "提示", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            else
            {
                string text2 = Interaction.InputBox("输入终止年份", "终止年份", DateTime.Now.Year.ToString(), 500, 400);
                if (text2.Length != 4 || !CommonTools.IsNumberStr(text2))
                {
                    MessageBox.Show("请输出4位数字年份", "提示", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
                else
                {
                    int num = int.Parse(text);
                    int num2 = int.Parse(text2);
                    string text3 = "现货,款到发货";
                    for (int i = num; i <= num2; i++)
                    {
                        for (int j = 1; j <= 12; j++)
                        {
                            string str;
                            if (j < 10)
                            {
                                str = string.Concat(new object[]
								{
									i,
									"年0",
									j,
									"月"
								});
                            }
                            else
                            {
                                str = string.Concat(new object[]
								{
									i,
									"年",
									j,
									"月"
								});
                            }
                            text3 += ",";
                            text3 += str;
                        }
                    }
                    string sql = "update tbdesc set append='" + text3 + "' where columnname='selldate'";
                    this.dbop.updatesql(sql);
                    MessageBox.Show("修正交货期下拉列表选项内容，请查看内容", "提示", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                }
            }
        }
        private void 修正交货期日期格式FToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string sql = "select id,selldate from balance";
            System.Data.DataTable data = this.dbop.getData(sql);
            DataTableReader dataTableReader = data.CreateDataReader();
            int num = 0;
            string text = DateTime.Now.Year.ToString();
            while (dataTableReader.Read())
            {
                int @int = dataTableReader.GetInt32(dataTableReader.GetOrdinal("id"));
                string text2 = dataTableReader.GetString(dataTableReader.GetOrdinal("selldate"));
                string pattern = "([0-9]+)月";
                Regex regex = new Regex(pattern);
                MatchCollection matchCollection = regex.Matches(text2);
                Match match = Regex.Match(text2, pattern, RegexOptions.IgnoreCase);
                if (match.Success)
                {
                    string value = match.Groups[1].Value;
                    int num2 = int.Parse(value);
                    if (num2 >= 1 && num2 < 10)
                    {
                        text2 = string.Concat(new object[]
						{
							text,
							"年0",
							num2,
							"月"
						});
                    }
                    else
                    {
                        text2 = string.Concat(new object[]
						{
							text,
							"年",
							num2,
							"月"
						});
                    }
                    string sql2 = string.Concat(new object[]
					{
						"update balance set selldate='",
						text2,
						"' where id=",
						@int
					});
                    this.dbop.updatesql(sql2);
                    num++;
                }
            }
            dataTableReader.Close();
            MessageBox.Show("成功更新" + num + "条记录交货期为'xxxx年xx月'", "信息", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
        }
        private void ysbs_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Back)
            {
                this.ysbs.SelectedIndex = -1;
            }
        }
        private void ysbs_MeasureItem(object sender, MeasureItemEventArgs e)
        {
            e.ItemHeight = 20;
            e.ItemWidth = 260;
        }
        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {
        }
        private void button9_Click_1(object sender, EventArgs e)
        {
            int month = DateTime.Now.Month;
            string str = DateTime.Now.Year.ToString();
            string str2;
            if (month < 10)
            {
                str2 = "0" + month;
            }
            else
            {
                str2 = "" + month;
            }
            string text = "select * from balance where ";
            string str3 = str + "年" + str2 + "月";
            text = text + "id not in(select id from balance where cksj is not NULL or (rkrq is not NULL or buycontract='已入库' or kucun = '有货') ) and (buycontract regexp '[0-9]+年[0-9]+月' and buycontract <='" + str3 + "')";
            this.updatelist(text);
        }
        private void button20_Click(object sender, EventArgs e)
        {
            int month = DateTime.Now.Month;
            string str = DateTime.Now.Year.ToString();
            string str2;
            if (month < 10)
            {
                str2 = "0" + month;
            }
            else
            {
                str2 = "" + month;
            }
            string text = "select * from balance where ";
            string str3 = str + "年" + str2 + "月";
            text = text + "cksj is NULL and (selldate regexp '[0-9]+年[0-9]+月' and selldate <='" + str3 + " ')";
            this.updatelist(text);
        }
        private void 添加新模板NToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string sql = "select count(id) as num from template";
            System.Data.DataTable data = this.dbop.getData(sql);
            DataTableReader dataTableReader = data.CreateDataReader();
            if (dataTableReader.Read())
            {
                int ordinal = dataTableReader.GetOrdinal("num");
                long @int = dataTableReader.GetInt64(ordinal);
                if (@int >= 10L)
                {
                    MessageBox.Show("已经有10个模板了，暂不支持添加更多，请选择已有模版进行编辑", "提示", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                    return;
                }
            }
            PrintTemplate template = new PrintTemplate();
            template.Owner = this;
            template.init();
            template.ShowDialog();
        }
        private void 编辑模板EToolStripMenuItem_Click(object sender, EventArgs e)
        {
        }
        private void 测试按钮ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            PrintSetting printSetting = new PrintSetting();
            printSetting.Owner = this;
            printSetting.init();
            printSetting.ShowDialog();
        }
        private void 删除模板DToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DeleteTemplate deleteTemplate = new DeleteTemplate();
            deleteTemplate.Owner = this;
            deleteTemplate.init();
            deleteTemplate.ShowDialog();
        }
        private void 查找与替换TToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FindAndModify findAndModify = new FindAndModify();
            findAndModify.Owner = this;
            findAndModify.init();
            findAndModify.ShowDialog();
        }
        public void getChineseSuggestion(ComboBox combo)
        {
            AutoCompleteStringCollection autoCompleteStringCollection = new AutoCompleteStringCollection();
            for (int i = 0; i < combo.Items.Count; i++)
            {
                string value = combo.Items[i].ToString();
                autoCompleteStringCollection.Add(value);
            }
            combo.AutoCompleteCustomSource = autoCompleteStringCollection;
        }
        private void button21_Click(object sender, EventArgs e)
        {
            if (this.htdqzt.SelectedIndex == -1)
            {
                MessageBox.Show("请选择合同到期状态", "提示", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            }
            else
            {
                if (this.htdqzt.SelectedIndex == 0)
                {
                    int month = DateTime.Now.Month;
                    string str = DateTime.Now.Year.ToString();
                    string str2;
                    if (month < 10)
                    {
                        str2 = "0" + month;
                    }
                    else
                    {
                        str2 = "" + month;
                    }
                    string text = "select * from balance where ";
                    string str3 = str + "年" + str2 + "月";
                    text = text + "id not in(select id from balance where cksj is not NULL or (rkrq is not NULL or buycontract='已入库' or kucun = '有货') ) and (buycontract regexp '[0-9]+年[0-9]+月' and buycontract <='" + str3 + "')";
                    this.updatelist(text);
                }
                if (this.htdqzt.SelectedIndex == 1)
                {
                    int month = DateTime.Now.Month;
                    string str = DateTime.Now.Year.ToString();
                    string str2;
                    if (month < 10)
                    {
                        str2 = "0" + month;
                    }
                    else
                    {
                        str2 = "" + month;
                    }
                    string text = "select * from balance where ";
                    string str4 = str + "年" + str2 + "月";
                    text = text + "cksj is NULL and (selldate regexp '[0-9]+年[0-9]+月' and selldate <='" + str4 + " ')";
                    this.updatelist(text);
                }
            }
        }
        private void 设置当前显示格式设置为默认ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            StringCollection stringCollection = new StringCollection();
            StringCollection stringCollection2 = new StringCollection();
            StringCollection stringCollection3 = new StringCollection();
            for (int i = 0; i < this.dataGridView1.Columns.Count; i++)
            {
                if (this.dataGridView1.Columns[i].Visible)
                {
                    string name = this.dataGridView1.Columns[i].Name;
                    string value = this.dataGridView1.Columns[i].DisplayIndex.ToString();
                    stringCollection.Add(name);
                    stringCollection3.Add(value);
                    stringCollection2.Add(this.dataGridView1.Columns[i].Width.ToString());
                }
            }
            if (!this.dbop.checkStringValueExist("sundries", "name", "coll"))
            {
                string sql = "insert into sundries(name, value) values('coll','" + CommonTools.StringCollectionToString(stringCollection, ",") + "')";
                this.dbop.updatesql(sql);
            }
            else
            {
                string sql = "update sundries set value='" + CommonTools.StringCollectionToString(stringCollection, ",") + "' where name='coll'";
                this.dbop.updatesql(sql);
            }
            if (!this.dbop.checkStringValueExist("sundries", "name", "cindex"))
            {
                string sql = "insert into sundries(name, value) values('cindex','" + CommonTools.StringCollectionToString(stringCollection3, ",") + "')";
                this.dbop.updatesql(sql);
            }
            else
            {
                string sql = "update sundries set value='" + CommonTools.StringCollectionToString(stringCollection3, ",") + "' where name='cindex'";
                this.dbop.updatesql(sql);
            }
            if (!this.dbop.checkStringValueExist("sundries", "name", "cwidth"))
            {
                string sql = "insert into sundries(name, value) values('cwidth','" + CommonTools.StringCollectionToString(stringCollection2, ",") + "')";
                this.dbop.updatesql(sql);
            }
            else
            {
                string sql = "update sundries set value='" + CommonTools.StringCollectionToString(stringCollection2, ",") + "' where name='cwidth'";
                this.dbop.updatesql(sql);
            }
            MessageBox.Show("设置系统默认样式保存成功", "成功", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
        }
    }
}