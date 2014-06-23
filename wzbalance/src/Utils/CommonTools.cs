using System;
using System.Collections.Specialized;
using System.Drawing;
using System.Text;
namespace wzbalance
{
	internal class CommonTools
	{
		public static bool IsNumberStr(string input)
		{
			bool result;
			for (int i = 0; i < input.Length; i++)
			{
				if (!char.IsDigit(input[i]))
				{
					result = false;
					return result;
				}
			}
			result = true;
			return result;
		}
		public static int ParseInt(string input)
		{
			int result;
			if (input == null || input == "")
			{
				result = 0;
			}
			else
			{
				int num = 1;
				int num2 = 0;
				int length = input.Length;
				if (input[0] == '-')
				{
					num = -1;
					num2++;
				}
				int num3 = 0;
				while (num2 < length && char.IsNumber(input[num2]))
				{
					num3 = num3 * 10 + (int)(input[num2] - '0');
					num2++;
				}
				result = num3 * num;
			}
			return result;
		}
		public static bool isEmptyStr(string input)
		{
			return input == null || input.Trim() == "";
		}
		public static string StringCollectionToString(StringCollection sc, string delim)
		{
			string[] array = new string[sc.Count];
			for (int i = 0; i < sc.Count; i++)
			{
				array[i] = sc[i];
			}
			return string.Join(delim, array);
		}
		public static StringCollection StringToStringCollection(string input, char delim)
		{
			string[] value = input.Split(new char[]
			{
				delim
			});
			StringCollection stringCollection = new StringCollection();
			stringCollection.AddRange(value);
			return stringCollection;
		}
		public static double ParseDouble(string input)
		{
			double result;
			if (input == null || input.Length == 0)
			{
				result = 0.0;
			}
			else
			{
				int num = 1;
				int num2 = 0;
				int length = input.Length;
				if (input[0] == '-')
				{
					num = -1;
					num2++;
				}
				double num3 = 0.0;
				double num4 = 1.0;
				while (num2 < length && char.IsNumber(input[num2]))
				{
					num3 = 10.0 * num3 + (double)(input[num2] - '0');
					num2++;
				}
				if (num2 < length && input[num2] == '.')
				{
					num2++;
					while (num2 < length && char.IsNumber(input[num2]))
					{
						num3 = 10.0 * num3 + (double)(input[num2] - '0');
						num4 *= 10.0;
						num2++;
					}
				}
				result = (double)num * num3 / num4;
			}
			return result;
		}
		public static string FontOutputStr(Font font)
		{
            string text = "";
            object obj = text;
            text = string.Concat(new object[]
			{
				obj,
				font.Name,
				",",
				font.Size
			});
            if ((font.Style & FontStyle.Bold) != FontStyle.Regular)
            {
                text += ",粗体";
            }
            if ((font.Style & FontStyle.Italic) != FontStyle.Regular)
            {
                text += ",斜体";
            }
            if ((font.Style & FontStyle.Strikeout) != FontStyle.Regular)
            {
                text += ",删除线";
            }
            if ((font.Style & FontStyle.Underline) != FontStyle.Regular)
            {
                text += ",下划线";
            }
            return text;
		}
		public static string FontSqlStr(Font font)
		{
			int num = 0;
			if ((font.Style & FontStyle.Bold) != FontStyle.Regular)
			{
				num |= 2;
			}
			if ((font.Style & FontStyle.Italic) != FontStyle.Regular)
			{
				num |= 4;
			}
			if ((font.Style & FontStyle.Strikeout) != FontStyle.Regular)
			{
				num |= 8;
			}
			if ((font.Style & FontStyle.Underline) != FontStyle.Regular)
			{
				num |= 16;
			}
			return string.Concat(new object[]
			{
				font.Name,
				",",
				font.Size,
				",",
				num
			});
		}
		public static Font StrToFont(string fontstr)
		{
			Font result;
			if (fontstr == null || fontstr == "")
			{
				result = null;
			}
			else
			{
				string[] array = fontstr.Split(new char[]
				{
					','
				});
				if (array.Length != 3)
				{
					result = null;
				}
				else
				{
					string familyName = array[0];
					float emSize = 0f;
					int num = 0;
					try
					{
						emSize = float.Parse(array[1]);
						num = int.Parse(array[2]);
					}
					catch (Exception ex)
					{
						LogWriter.LogEntry("warning", "font size convert failed, + " + ex.Message + ex.StackTrace);
						result = null;
						return result;
					}
					FontStyle fontStyle = FontStyle.Regular;
					if ((num & 2) != 0)
					{
						fontStyle |= FontStyle.Bold;
					}
					if ((num & 4) != 0)
					{
						fontStyle |= FontStyle.Italic;
					}
					if ((num & 8) != 0)
					{
						fontStyle |= FontStyle.Strikeout;
					}
					if ((num & 16) != 0)
					{
						fontStyle |= FontStyle.Underline;
					}
					result = new Font(familyName, emSize, fontStyle);
				}
			}
			return result;
		}
		public static string GetChineseSpell(string strText)
		{
			int length = strText.Length;
			string text = "";
			for (int i = 0; i < length; i++)
			{
				text += CommonTools.getSpell(strText.Substring(i, 1));
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
		public static string ChineseCap(string ChineseStr)
		{
			string text = "";
			byte[] array = new byte[2];
			string str = "";
			for (int i = 0; i <= ChineseStr.Length - 1; i++)
			{
				string s = ChineseStr.Substring(i, 1).ToString();
				array = Encoding.Default.GetBytes(s);
				if (array.Length != 2)
				{
					text = ChineseStr;
					break;
				}
				int num = (int)array[0];
				int num2 = (int)array[1];
				long num3 = (long)(num * 256 + num2);
				if (num3 >= 45217L && num3 <= 45252L)
				{
					str = "A";
				}
				else
				{
					if (num3 >= 45253L && num3 <= 45760L)
					{
						str = "B";
					}
					else
					{
						if (num3 >= 45761L && num3 <= 46317L)
						{
							str = "C";
						}
						else
						{
							if (num3 >= 46318L && num3 <= 46825L)
							{
								str = "D";
							}
							else
							{
								if (num3 >= 46826L && num3 <= 47009L)
								{
									str = "E";
								}
								else
								{
									if (num3 >= 47010L && num3 <= 47296L)
									{
										str = "F";
									}
									else
									{
										if (num3 >= 47297L && num3 <= 47613L)
										{
											str = "G";
										}
										else
										{
											if (num3 >= 47614L && num3 <= 48118L)
											{
												str = "H";
											}
											else
											{
												if (num3 >= 48119L && num3 <= 49061L)
												{
													str = "J";
												}
												else
												{
													if (num3 >= 49062L && num3 <= 49323L)
													{
														str = "K";
													}
													else
													{
														if (num3 >= 49324L && num3 <= 49895L)
														{
															str = "L";
														}
														else
														{
															if (num3 >= 49896L && num3 <= 50370L)
															{
																str = "M";
															}
															else
															{
																if (num3 >= 50371L && num3 <= 50613L)
																{
																	str = "N";
																}
																else
																{
																	if (num3 >= 50614L && num3 <= 50621L)
																	{
																		str = "O";
																	}
																	else
																	{
																		if (num3 >= 50622L && num3 <= 50905L)
																		{
																			str = "P";
																		}
																		else
																		{
																			if (num3 >= 50906L && num3 <= 51386L)
																			{
																				str = "Q";
																			}
																			else
																			{
																				if (num3 >= 51387L && num3 <= 51445L)
																				{
																					str = "R";
																				}
																				else
																				{
																					if (num3 >= 51446L && num3 <= 52217L)
																					{
																						str = "S";
																					}
																					else
																					{
																						if (num3 >= 52218L && num3 <= 52697L)
																						{
																							str = "T";
																						}
																						else
																						{
																							if (num3 >= 52698L && num3 <= 52979L)
																							{
																								str = "W";
																							}
																							else
																							{
																								if (num3 >= 52980L && num3 <= 53640L)
																								{
																									str = "X";
																								}
																								else
																								{
																									if (num3 >= 53689L && num3 <= 54480L)
																									{
																										str = "Y";
																									}
																									else
																									{
																										if (num3 >= 54481L && num3 <= 55289L)
																										{
																											str = "Z";
																										}
																									}
																								}
																							}
																						}
																					}
																				}
																			}
																		}
																	}
																}
															}
														}
													}
												}
											}
										}
									}
								}
							}
						}
					}
				}
				text += str;
			}
			return text;
		}
	}
}
