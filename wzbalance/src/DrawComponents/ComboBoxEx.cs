using System;
using System.Collections;
using System.Text;
using System.Windows.Forms;
namespace wzbalance
{
	public class ComboBoxEx : ComboBox
	{
		private ArrayList m_list = new ArrayList();
		private int SuggestMethod = 0;
		public void SetSuggestMethod(int method)
		{
			this.SuggestMethod = method;
		}
		protected override bool IsInputKey(Keys keyData)
		{
			if (base.DroppedDown)
			{
				base.DroppedDown = false;
			}
			return base.IsInputKey(keyData);
		}
		protected override void OnEnter(EventArgs e)
		{
			this.m_list.Clear();
			this.m_list.AddRange(base.Items);
			base.OnEnter(e);
		}
		protected override void OnLeave(EventArgs e)
		{
			base.Items.Clear();
			base.Items.AddRange(this.m_list.ToArray());
			base.OnLeave(e);
		}
		protected override void OnTextUpdate(EventArgs e)
		{
			while (base.Items.Count > 0)
			{
				base.Items.RemoveAt(0);
			}
			string text = this.Text.ToLower();
			foreach (object current in this.m_list)
			{
				if (this.SuggestMethod == 0)
				{
					string text2 = ComboBoxEx.GetChineseSpell(current.ToString()).ToLower();
					if (text2.Length >= text.Length && text2.Substring(0, text.Length).Equals(text))
					{
						base.Items.Add(current);
					}
				}
				else
				{
					if (this.SuggestMethod == 1)
					{
						string text2 = current.ToString().ToLower();
						if (text2.Contains(text))
						{
							base.Items.Add(current);
						}
					}
				}
			}
			base.DroppedDown = true;
			base.OnTextUpdate(e);
		}
		public static string GetChineseSpell(string strText)
		{
			int length = strText.Length;
			string text = "";
			for (int i = 0; i < length; i++)
			{
				string text2 = ComboBoxEx.getSpell(strText.Substring(i, 1));
				if (text2 == "*")
				{
					text2 = strText.Substring(i, 1);
				}
				text += text2;
			}
			return text;
		}
		public static string getSpell(string cnChar)
		{
			byte[] bytes = Encoding.Default.GetBytes(cnChar);
			string result;
			if (bytes.Length > 1)
			{
				int num = (int)bytes[0];
				int num2 = (int)bytes[1];
				int num3 = (num << 8) + num2;
				int[] array = new int[]
				{
					45217,
					45253,
					45761,
					46318,
					46826,
					47010,
					47297,
					47614,
					48119,
					48119,
					49062,
					49324,
					49896,
					50371,
					50614,
					50622,
					50906,
					51387,
					51446,
					52218,
					52698,
					52698,
					52698,
					52980,
					53689,
					54481
				};
				for (int i = 0; i < 26; i++)
				{
					int num4 = 55290;
					if (i != 25)
					{
						num4 = array[i + 1];
					}
					if (array[i] <= num3 && num3 < num4)
					{
						result = Encoding.Default.GetString(new byte[]
						{
							(byte)(65 + i)
						});
						return result;
					}
				}
				result = "*";
			}
			else
			{
				result = cnChar;
			}
			return result;
		}
		private void InitializeComponent()
		{
			base.SuspendLayout();
			base.ResumeLayout(false);
		}
	}
}
