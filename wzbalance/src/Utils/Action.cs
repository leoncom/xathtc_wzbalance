using System;
using System.Collections.Generic;
using System.Text;

namespace wzbalance
{
    class Action
    {
        private string code;
        private string desc;
        public override string ToString()
        {
            return this.desc;
        }
        public Action(string c, string d)
        {
            this.code = c;
            this.desc = d;
        }
        public string getcode()
        {
            return this.code;
        }
    }
}
