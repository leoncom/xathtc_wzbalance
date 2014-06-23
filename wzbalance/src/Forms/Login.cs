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
    public partial class LoginForm : Form
    {
        private DataOperator dbop;
        private string user;
        private string pwd;
        private string db;

        public LoginForm()
        {
            int num = VersionCheck.needUpdate();
            if (num == 1)
            {
                if (MessageBox.Show("发现新版本,是否退出程序开始下载?", "提示", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    System.Diagnostics.Process.Start(VersionCheck.getUrl());
                    Environment.Exit(1);
                }
            }
            else
            {
                if (num == -1)
                {
                    MessageBox.Show("网络连接检测更新失败,暂不更新", "提示", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                }
            }
            this.InitializeComponent();
            base.StartPosition = FormStartPosition.CenterScreen;
            this.init();
        }
        public void init()
        {
            this.textBox1.Text = Settings.Default.ServerIP;
            this.textBox3.Text = Settings.Default.UserName;
            if (Settings.Default.Password != "")
            {
                this.textBox2.Text = Settings.Default.Password;
                this.checkBox1.Checked = true;
            }
            this.user = "root";
            this.pwd = "rocroc";
            this.db = "wzbalance";
        }
        private void AddNewTable()
        {
            string sql = "CREATE TABLE `template` ( `id` int(11) NOT NULL AUTO_INCREMENT, `name` varchar(25) NOT NULL,`title` varchar(50) DEFAULT NULL, `titlefont` varchar(25) NOT NULL,`contentfont` varchar(25) NOT NULL,`discolumns` varchar(1024) DEFAULT NULL, PRIMARY KEY (`id`)) ENGINE=InnoDB DEFAULT CHARSET=utf8;";
            this.dbop.updatesql(sql);
        }
        private void AddNewColumn(string tablename, string columnname)
        {
            string sql = string.Concat(new string[]
			{
				"ALTER table ",
				tablename,
				" add ",
				columnname,
				" varchar(256) null default ''"
			});
            this.dbop.updatesql(sql);
        }
        private bool checktableExist(string tablename)
        {
            string sql = "show tables like'" + tablename + "'";
            DataTable data = this.dbop.getData(sql);
            DataTableReader dataTableReader = data.CreateDataReader();
            bool result;
            if (dataTableReader.Read())
            {
                dataTableReader.Close();
                result = true;
            }
            else
            {
                dataTableReader.Close();
                result = false;
            }
            return result;
        }
        private bool checkcolumnExist(string tablename, string columnname)
        {
            bool result;
            if (!this.checktableExist(tablename))
            {
                result = false;
            }
            else
            {
                string sql = "desc " + tablename;
                DataTable data = this.dbop.getData(sql);
                DataTableReader dataTableReader = data.CreateDataReader();
                while (dataTableReader.Read())
                {
                    if (dataTableReader.GetString(dataTableReader.GetOrdinal("Field")) == columnname)
                    {
                        dataTableReader.Close();
                        result = true;
                        return result;
                    }
                }
                result = false;
            }
            return result;
        }
        
        public int validatepwd(string username, string pwd)
        {
            string sql = "select id,userpwd from users where username='" + username + "'";
            int result;
            try
            {
                DataTable data = this.dbop.getData(sql);
                DataTableReader dataTableReader = data.CreateDataReader();
                if (dataTableReader.Read())
                {
                    string @string = dataTableReader.GetString(1);
                    int @int = dataTableReader.GetInt32(0);
                    if (@string != pwd)
                    {
                        result = -2;
                    }
                    else
                    {
                        result = @int;
                    }
                }
                else
                {
                    result = -1;
                }
            }
            catch (Exception ex)
            {
                LogWriter.LogEntry("error", ex.Message);
                result = -3;
            }
            return result;
        }
        public int getTbdescColumnVarcharSize(string tablename, string columnname)
        {
            int num = 0;
            string sql = string.Concat(new string[]
			{
				"SELECT DATA_TYPE,CHARACTER_MAXIMUM_LENGTH from INFORMATION_SCHEMA.COLUMNS where table_name='",
				tablename,
				"' and column_name ='",
				columnname,
				"'"
			});
            int result;
            try
            {
                DataTable data = this.dbop.getData(sql);
                DataTableReader dataTableReader = data.CreateDataReader();
                if (dataTableReader.Read())
                {
                    string @string = dataTableReader.GetString(dataTableReader.GetOrdinal("DATA_TYPE"));
                    string string2 = dataTableReader.GetString(dataTableReader.GetOrdinal("CHARACTER_MAXIMUM_LENGTH"));
                    if (@string != "varchar")
                    {
                        LogWriter.LogEntry("warning", string.Concat(new string[]
						{
							"table ",
							tablename,
							" column ",
							columnname,
							" type not varchar"
						}));
                        num = -1;
                    }
                    else
                    {
                        num = int.Parse(string2);
                    }
                }
            }
            catch (Exception ex)
            {
                LogWriter.LogEntry("error", ex.Message);
                result = -3;
                return result;
            }
            result = num;
            return result;
        }
        private void checkTableNeedUpdate()
        {
            if (!this.checktableExist("template"))
            {
                this.AddNewTable();
            }
            if (!this.checkcolumnExist("balance", "zlyy"))
            {
                this.AddNewColumn("balance", "zlyy");
                string sql = "insert into tbdesc(columnname, display, type) values('zlyy','质量异议',1)";
                this.dbop.updatesql(sql);
            }
            if (!this.checkcolumnExist("balance", "luhao"))
            {
                this.AddNewColumn("balance", "luhao");
                string sql = "insert into tbdesc(columnname, display, type) values('luhao','炉号',1)";
                this.dbop.updatesql(sql);
            }
            if (!this.checktableExist("sundries"))
            {
                this.AddSundriesTable();
            }
            int tbdescColumnVarcharSize = this.getTbdescColumnVarcharSize("tbdesc", "append");
            if (tbdescColumnVarcharSize < 2048)
            {
                string sql = "alter table tbdesc modify append varchar(2048)";
                this.dbop.updatesql(sql);
            }
        }
        private void AddSundriesTable()
        {
            string sql = "CREATE TABLE `sundries` ( `id` int(11) NOT NULL AUTO_INCREMENT, `name` varchar(25) NOT NULL,`value` varchar(512) DEFAULT NULL, PRIMARY KEY (`id`)) ENGINE=InnoDB DEFAULT CHARSET=utf8;";
            this.dbop.updatesql(sql);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.button1.Enabled = false;
            this.dbop = new DataOperator(this.textBox1.Text, this.user, this.pwd, this.db);
            string text = this.dbop.conntodb();
            if (text == "ok")
            {
                Settings.Default.ServerIP = this.textBox1.Text;
                Settings.Default.Save();
                int num = this.validatepwd(this.textBox3.Text, this.textBox2.Text);
                if (num == -1)
                {
                    MessageBox.Show("用户名错误", "错误", MessageBoxButtons.OK, MessageBoxIcon.Hand);
                }
                else
                {
                    if (num == -2)
                    {
                        MessageBox.Show("密码错误", "错误", MessageBoxButtons.OK, MessageBoxIcon.Hand);
                    }
                    else
                    {
                        if (num == -3)
                        {
                            MessageBox.Show("数据库连接错误，请确认主机数据库正常启动和网络工作正常", "错误", MessageBoxButtons.OK, MessageBoxIcon.Hand);
                        }
                        else
                        {
                            this.checkTableNeedUpdate();
                            Settings.Default.UserName = this.textBox3.Text;
                            if (this.checkBox1.Checked)
                            {
                                Settings.Default.Password = this.textBox2.Text;
                            }
                            else
                            {
                                Settings.Default.Password = "";
                            }
                            Settings.Default.Save();
                            base.Hide();
                            try
                            {
                                MainSheet mainSheet = new MainSheet();
                                mainSheet.init(this.textBox1.Text, this.dbop, this.textBox3.Text, this.user, this.pwd, this.db, num);
                                mainSheet.Show();
                                mainSheet.updateColor();
                            }
                            catch (Exception ex)
                            {
                                MessageBox.Show(ex.StackTrace, ex.Message, MessageBoxButtons.OK, MessageBoxIcon.Hand);
                                base.Show();
                            }
                        }
                    }
                }
            }
            else
            {
                MessageBox.Show(text);
            }
            this.button1.Enabled = true;
        }
        private void textBox2_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyValue == 13)
            {
                this.button1_Click(sender, e);
            }
        }
        private void textBox1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyValue == 13)
            {
                this.button1_Click(sender, e);
            }
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }
    }
}