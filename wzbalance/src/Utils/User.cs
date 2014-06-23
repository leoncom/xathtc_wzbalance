using System;
using System.Collections.Generic;
using System.Text;

namespace wzbalance
{
    class User
    {
        private string name;
        private string pwd;
        private string role;
        private int id;
        public User(int id, string nm, string pw, string rl)
        {
            this.id = id;
            this.name = nm;
            this.pwd = pw;
            this.role = rl;
        }
        public override string ToString()
        {
            return this.name;
        }
        public int getId()
        {
            return this.id;
        }
        public string getName()
        {
            return this.name;
        }
        public string getPwd()
        {
            return this.pwd;
        }
        public string getRole()
        {
            return this.role;
        }
    }
}
