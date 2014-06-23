using System;
namespace wzbalance
{
	internal class HeaderDes
	{
		private string column;
		private string desription;
		public HeaderDes(string c, string d)
		{
			this.column = c;
			this.desription = d;
		}
		public override string ToString()
		{
			return this.desription;
		}
		public string getcolumn()
		{
			return this.column;
		}
	}
}
