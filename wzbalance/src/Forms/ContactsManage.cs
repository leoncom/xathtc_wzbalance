using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using wzbalance.Properties;

namespace wzbalance.src.Forms
{
    public partial class ContactsManage : Form
    {
        public class SearchItem
        {
            public string text;
            public string colname;
            public SearchItem(string tx, string nm)
            {
                this.text = tx;
                this.colname = nm;
            }
            public override string ToString()
            {
                return this.text;
            }
        }

        private int colindex;
        private string lastSortColName = null;
        private int lastSortColMode = 0;
        private int scrollPosY = 0;
        private int scrollPosX = 0;
        private MainSheet mfrm;
        private string nowsql;

        public ContactsManage()
        {
            InitializeComponent();
        }

        public void init()
        {
            this.mfrm = (MainSheet)base.Owner;
            string sql = "select * from contacts";
            this.initlist(sql);
            this.initSearchItem();
        }
        private void initSearchItem()
        {
            string[] array = new string[]
			{
				"name",
				"person",
				"phone",
				"address",
				"zip"
			};
            string[] array2 = new string[]
			{
				"单位名称",
				"联系人",
				"电话",
				"地址",
				"邮编"
			};
            for (int i = 0; i < array.Length; i++)
            {
                ContactsManage.SearchItem item = new ContactsManage.SearchItem(array2[i], array[i]);
                this.comboBox1.Items.Add(item);
            }
        }
        public void initlist(string sql)
        {
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
            DataTable dataTable = this.mfrm.dbop.getData(sql);
            if (this.lastSortColName != null)
            {
                string str = "asc";
                if (this.lastSortColMode == 1)
                {
                    str = "desc";
                }
                DataView defaultView = dataTable.DefaultView;
                defaultView.Sort = this.lastSortColName + " " + str;
                dataTable = defaultView.ToTable();
            }
            this.dataGridView1.DataSource = dataTable;
            this.dataGridView1.Hide();
            this.dataGridView1.Columns[0].Visible = false;
            this.dataGridView1.Columns[1].HeaderText = "单位名称";
            this.dataGridView1.Columns[2].HeaderText = "联系人一";
            this.dataGridView1.Columns[3].HeaderText = "联系电话";
            this.dataGridView1.Columns[4].HeaderText = "联系人二";
            this.dataGridView1.Columns[5].HeaderText = "联系电话";
            this.dataGridView1.Columns[6].HeaderText = "联系人三";
            this.dataGridView1.Columns[7].HeaderText = "联系电话";
            this.dataGridView1.Columns[8].HeaderText = "地址";
            this.dataGridView1.Columns[9].HeaderText = "邮编";
            if (num == 1)
            {
                this.RestoreScrollPos();
            }
            this.dataGridView1.Show();
        }
        public void SaveScrollPos()
        {
            this.scrollPosX = ((this.dataGridView1.FirstDisplayedScrollingColumnIndex > 0) ? this.dataGridView1.FirstDisplayedScrollingColumnIndex : 0);
            this.scrollPosY = ((this.dataGridView1.FirstDisplayedScrollingRowIndex > 0) ? this.dataGridView1.FirstDisplayedScrollingRowIndex : 0);
        }
        public void RestoreScrollPos()
        {
            this.dataGridView1.FirstDisplayedScrollingColumnIndex = this.scrollPosX;
            this.dataGridView1.FirstDisplayedScrollingRowIndex = this.scrollPosY;
        }
        private void dataGridView1_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            this.colindex = e.ColumnIndex;
        }
        private void dataGridView1_Sorted(object sender, EventArgs e)
        {
            DataTable dataTable = (DataTable)this.dataGridView1.DataSource;
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
            this.dataGridView1.DataSource = dataTable;
        }
        private void button1_Click(object sender, EventArgs e)
        {
            int rowCount = this.dataGridView1.Rows.GetRowCount(DataGridViewElementStates.Selected);
            if (rowCount > 1)
            {
                MessageBox.Show("必须选定一行或者一行中某元素进行操作", "信息", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            }
            else
            {
                int index;
                if (rowCount == 0)
                {
                    int count = this.dataGridView1.SelectedCells.Count;
                    if (count != 1)
                    {
                        MessageBox.Show("必须选定一行或者一行中某元素进行操作", "信息", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                        return;
                    }
                    index = this.dataGridView1.SelectedCells[0].RowIndex;
                }
                else
                {
                    index = this.dataGridView1.SelectedRows[0].Index;
                }
                int id = (int)this.dataGridView1.Rows[index].Cells[0].Value;
                AddContact newContact = new AddContact();
                newContact.Owner = base.Owner;
                newContact.init();
                newContact.editmode(id, this);
                newContact.Show();
            }
        }
        private void button2_Click(object sender, EventArgs e)
        {
            int rowCount = this.dataGridView1.Rows.GetRowCount(DataGridViewElementStates.Selected);
            if (rowCount > 1)
            {
                MessageBox.Show("必须选定一行或者一行中某元素进行操作", "信息", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            }
            else
            {
                int index;
                if (rowCount == 0)
                {
                    int count = this.dataGridView1.SelectedCells.Count;
                    if (count != 1)
                    {
                        MessageBox.Show("必须选定一行或者一行中某元素进行操作", "信息", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                        return;
                    }
                    index = this.dataGridView1.SelectedCells[0].RowIndex;
                }
                else
                {
                    index = this.dataGridView1.SelectedRows[0].Index;
                }
                if (MessageBox.Show("确定删除该行数据?", "提示", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    int num = (int)this.dataGridView1.Rows[index].Cells[0].Value;
                    this.dataGridView1.Rows.Remove(this.dataGridView1.Rows[index]);
                    string sql = "delete from contacts where id=" + num;
                    int num2 = this.mfrm.dbop.updatesql(sql);
                    MessageBox.Show("删除成功", "信息", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                }
            }
        }
        private void button6_Click(object sender, EventArgs e)
        {
            if (this.comboBox1.SelectedIndex == -1)
            {
                MessageBox.Show("必须选中一个条件", "提示", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            }
            else
            {
                if (this.textBox1.Text == "")
                {
                    MessageBox.Show("关键字不能为空", "提示", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                }
                else
                {
                    string text = this.textBox1.Text;
                    ContactsManage.SearchItem searchItem = (ContactsManage.SearchItem)this.comboBox1.SelectedItem;
                    string sql;
                    if (searchItem.colname == "person")
                    {
                        sql = string.Concat(new string[]
						{
							"select * from contacts where person1 like '%",
							text,
							"%' or person2 like '%",
							text,
							"%' or person3 like '%",
							text,
							"%'"
						});
                    }
                    else
                    {
                        if (searchItem.colname == "phone")
                        {
                            sql = string.Concat(new string[]
							{
								"select * from contacts where phone1 like '%",
								text,
								"%' or phone2 like '%",
								text,
								"%' or phone3 like '%",
								text,
								"%'"
							});
                        }
                        else
                        {
                            sql = string.Concat(new string[]
							{
								"select * from contacts where ",
								searchItem.colname,
								" like '%",
								text,
								"%'"
							});
                        }
                    }
                    this.initlist(sql);
                }
            }
        }
        private void button3_Click(object sender, EventArgs e)
        {
            string sql = "select * from contacts";
            this.initlist(sql);
        }
        private void ContactsManage_FormClosing(object sender, FormClosingEventArgs e)
        {
            Settings.Default.ContactMngLocX = base.Top;
            Settings.Default.ContactMngLocY = base.Left;
            Settings.Default.ContactMngWidth = base.Width;
            Settings.Default.Save();
        }
        private void ContactsManage_Load(object sender, EventArgs e)
        {
            base.Top = Settings.Default.ContactMngLocX;
            base.Left = Settings.Default.ContactMngLocY;
            base.Width = Settings.Default.ContactMngWidth;
        }
    }
}