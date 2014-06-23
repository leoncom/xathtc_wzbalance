using System;
namespace wzbalance
{
	public class ComboItem
	{
		private string name;
		private string text;
		private int type;
		public ComboItem(string nm, string tx, int ty)
		{
			this.name = nm;
			this.text = tx;
			this.type = ty;
		}
		public string getName()
		{
			return this.name;
		}
		public void setName(string nm)
		{
			this.name = nm;
		}
		public string getText()
		{
			return this.text;
		}
		public void setText(string tx)
		{
			this.text = tx;
		}
		public int getType()
		{
			return this.type;
		}
		public void setType(int tp)
		{
			this.type = tp;
		}
		public override string ToString()
		{
			return this.text;
		}
	}
}
