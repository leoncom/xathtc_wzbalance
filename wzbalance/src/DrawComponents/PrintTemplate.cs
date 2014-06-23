using System;
using System.Drawing;
namespace wzbalance
{
	internal class PrintTemplate
	{
		public string Title;
		public string DisplayLists;
		public string FontName;
		public float FontSize;
		public bool isRegular;
		public bool isBold;
		public bool isItalic;
		public bool isStrikeout;
		public bool isUnderline;
		private bool isValid = true;
		public PrintTemplate(string fontstr, string title, string displaylist)
		{
			this.Title = title;
			this.DisplayLists = displaylist;
			this.isRegular = false;
			this.isBold = false;
			this.isItalic = false;
			this.isStrikeout = false;
			this.isUnderline = false;
			this.FontSize = 0f;
			this.FontName = "";
			this.isValid = this.init(fontstr);
		}
		private bool init(string fontstr)
		{
			string[] array = fontstr.Split(new char[]
			{
				','
			});
			bool result;
			if (array.Length != 3)
			{
				LogWriter.LogEntry("warning", "Error Font String Format: " + fontstr);
				result = false;
			}
			else
			{
				for (int i = 0; i < 3; i++)
				{
					if (CommonTools.isEmptyStr(array[i]))
					{
						LogWriter.LogEntry("warning", "Error Font String Format: " + fontstr);
						result = false;
						return result;
					}
				}
				this.FontName = array[0];
				int num = 0;
				try
				{
					this.FontSize = float.Parse(array[1]);
					num = int.Parse(array[2]);
				}
				catch (Exception ex)
				{
					string message = string.Concat(new string[]
					{
						"Error Font String Format: ",
						fontstr,
						"\n",
						ex.Message,
						"\n",
						ex.StackTrace
					});
					LogWriter.LogEntry("warning", message);
					result = false;
					return result;
				}
				if (this.FontSize <= 0f || num <= 0)
				{
					LogWriter.LogEntry("warning", "Error Font String Format: " + fontstr);
					result = false;
				}
				else
				{
					this.isRegular = ((num & 1) != 0);
					this.isBold = ((num & 2) != 0);
					this.isItalic = ((num & 4) != 0);
					this.isStrikeout = ((num & 8) != 0);
					this.isUnderline = ((num & 16) != 0);
					result = true;
				}
			}
			return result;
		}
		public Font getFont()
		{
			Font result;
			if (!this.isValid)
			{
				result = null;
			}
			else
			{
				FontStyle fontStyle = FontStyle.Regular;
				if (this.isBold)
				{
					fontStyle |= FontStyle.Bold;
				}
				if (this.isItalic)
				{
					fontStyle |= FontStyle.Italic;
				}
				if (this.isStrikeout)
				{
					fontStyle |= FontStyle.Strikeout;
				}
				if (this.isUnderline)
				{
					fontStyle |= FontStyle.Underline;
				}
				Font font = new Font(this.FontName, this.FontSize, fontStyle);
				result = font;
			}
			return result;
		}
	}
}
