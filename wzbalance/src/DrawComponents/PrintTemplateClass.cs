using System;
using System.Drawing;
namespace wzbalance
{
	internal class PrintTemplateClass
	{
		public Font headerFont;
		public Font contentFont;
		public string name;
		public string dislist;
		public int id;
		public PrintTemplateClass(int id, string nm, string headerstr, string contentstr, string list)
		{
			this.id = id;
			this.name = nm;
			if (headerstr != null && headerstr != "")
			{
				this.headerFont = CommonTools.StrToFont(headerstr);
			}
			if (contentstr != null && contentstr != "")
			{
				this.contentFont = CommonTools.StrToFont(contentstr);
			}
			this.dislist = list;
		}
		public override string ToString()
		{
			return this.name;
		}
	}
}
