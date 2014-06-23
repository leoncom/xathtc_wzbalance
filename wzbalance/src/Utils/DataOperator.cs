using MySql.Data.MySqlClient;
using System;
using System.Data;

namespace wzbalance
{
    public class DataOperator
    {
        private MySqlConnection conn;
        private string mysqlconnstr;

        public DataOperator(string server, string user, string pwd, string db)
        {
            this.conn = new MySqlConnection();
            this.mysqlconnstr = "CharSet = utf8; server = " + server + "; uid = " +
                user + "; pwd = " + pwd + "; database = " + db;
            this.conn.ConnectionString = this.mysqlconnstr;
        }

        public string conntodb()
        {
            string result;
            try {
                this.conn.Open();
                result = "ok";
            }
            catch (MySqlException ex)
            {
                int number = ex.Number;
                if (number != 1042)
                {
                    if (number != 1045)
                    {
                        if (number != 1049)
                        {
                            result = ex.Number + ":" + ex.Message;
                        }
                        else
                        {
                            result = "数据库不存在，或数据库名错误";
                        }
                    }
                    else
                    {
                        result = "无效的用户名/密码,请重试！";
                    }
                }
                else
                {
                    result = "不能连接到数据库服务器，请确认数据库已启动并配置正确，或者网络畅通！";
                }
            }
            return result;
        }

        public MySqlConnection getconn()
        {
            return this.conn;
        }
        public DataTable getData(string sql)
        {
            MySqlDataAdapter mySqlDataAdapter = new MySqlDataAdapter(sql, this.conn);
            DataTable dataTable = new DataTable();
            mySqlDataAdapter.Fill(dataTable);
            return dataTable;
        }

        public int updatesql(string sql)
        {
            MySqlCommand mySqlCommand = this.conn.CreateCommand();
            mySqlCommand.CommandText = sql;
            return mySqlCommand.ExecuteNonQuery();
        }

        public void closeconn()
        {
            this.conn.Clone();
        }

        public bool checkTableExist(string tablename)
        {
            string sql = "show tables like '" + tablename + "'";
            DataTable data = this.getData(sql);
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
        public bool checkcolumnExist(string tablename, string columnname)
        {
            bool result;
            if (!this.checkTableExist(tablename))
            {
                result = false;
            }
            else
            {
                string sql = "desc " + tablename;
                DataTable data = this.getData(sql);
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

        public bool checkStringValueExist(string tablename, string columname, string value)
        {
            bool result;
            if (!this.checkcolumnExist(tablename, columname))
            {
                result = false;
            }
            else
            {
                string sql = string.Concat(new string[]
				{
					"select * from ",
					tablename,
					" where ",
					columname,
					"='",
					value,
					"'"
				});
                DataTable data = this.getData(sql);
                DataTableReader dataTableReader = data.CreateDataReader();
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
            }
            return result;
        }
    }
}
