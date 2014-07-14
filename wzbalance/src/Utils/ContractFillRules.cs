using System;
using System.Collections.Generic;
using System.Text;
using System.Collections.Specialized;

namespace wzbalance.src.Utils
{
    public class ContractFillRules
    {
        private int id;
        private string rule_name;
        private string primary_column;
        private StringCollection check_columns;

        public ContractFillRules()
        {
            this.id = -1;
            this.check_columns = new StringCollection();
        }

        public ContractFillRules(ContractFillRules other)
        {
            this.id = other.get_id();
            this.rule_name = other.get_rule_name();
            this.primary_column = other.get_key();
            this.check_columns = other.get_columns();
        }

        public void set_id(int id)
        {
            this.id = id;
        }

        public int get_id()
        {
            return this.id;
        }

        public void set_rule_name(string rule)
        {
            this.rule_name = rule;
        }

        public string get_rule_name()
        {
            return this.rule_name;
        }

        public void set_key(string key)
        {
            this.primary_column = key;
        }

        public string get_key()
        {
            return this.primary_column;
        }

        public void add_check_column(string column)
        {
            this.check_columns.Add(column);
        }

        public StringCollection get_columns()
        {
            return this.check_columns;
        }

        public void clear_columns()
        {
            this.check_columns.Clear();
        }

        public bool find_column(string column)
        {
            return this.check_columns.IndexOf(column) >= 0;
        }

        public void set_check_column(string columns_string)
        {
            string[] column_array = columns_string.Split(',');
            this.check_columns.Clear();
            this.check_columns.AddRange(column_array);
        }

        public string get_check_column_string()
        {
            string[] column_array = new string[this.check_columns.Count];
            this.check_columns.CopyTo(column_array, 0);
            return String.Join(",", column_array);
        }

        public string generate_sql()
        {
            if (this.id == -1)
            {
                return this.generate_insert_sql();
            }
            else
            {
                return this.generate_update_sql();
            }
        }

        private string generate_insert_sql()
        {
            string sql = "insert into contract_fill_rule(`rule_name`,`primary_column`,`check_empty_columns`) " +
                        "values('" + this.rule_name + "','" + this.primary_column + "','" + this.get_check_column_string() + "')";
            return sql;    
        }

        private string generate_update_sql()
        {
            string sql = "update contract_fill_rule set rule_name='" + this.rule_name + "',primary_column='" + this.primary_column + "',"
                        + " check_empty_columns='" + this.get_check_column_string() + "' where id=" + this.id;
            return sql;
        }

        public override string ToString()
        {
            return this.rule_name;
        }
    
    }
}
