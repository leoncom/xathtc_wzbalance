using System;
using System.Drawing;
using System.Drawing.Printing;
using System.Windows.Forms;
namespace wzbalance
{
	internal class DataGridViewPrinter
	{
		private DataGridView dataGridView;
		private PrintDocument printDocument;
		private PageSetupDialog pageSetupDialog;
		private PrintPreviewDialog printPreviewDialog;
		private int rowCount = 0;
		private int colCount = 0;
		private int x = 0;
		private int y = 0;
		private int i = 0;
		private int rowGap = 30;
		private int leftMargin = 10;
		private int upMargin = 10;
		private int downMargin = 10;
		private int linenum = 1;
		private Font font = new Font("Arial", 10f);
		private Font headingFont = new Font("Arial", 11f, FontStyle.Bold);
		private Font captionFont = new Font("Arial", 10f, FontStyle.Bold);
		private Font titleFont = new Font("Arial", 13f, FontStyle.Bold);
		private Brush brush = new SolidBrush(Color.Black);
		private string cellValue = string.Empty;
		private int printSelect = 0;
		private string printTitle = null;
		private string dislistcols;
		private bool autoWrap = false;
		private int append_line = 0;

        public DataGridViewPrinter(DataGridView dataGridView)
        {
            this.dataGridView = dataGridView;
            this.printDocument = new PrintDocument();
            this.printDocument.PrintPage += new PrintPageEventHandler(this.printDocument_PrintPage);
            this.headingFont = this.dataGridView.ColumnHeadersDefaultCellStyle.Font;
            this.font = this.dataGridView.DefaultCellStyle.Font;
            this.autoWrap = false;
        }
        public void setAppendLine(int lineheight)
        {
            this.append_line = lineheight * 10;
        }
        public void setAutoWrap(bool wrap)
        {
            this.autoWrap = wrap;
        }
        public void setList(string colunames)
        {
            this.dislistcols = colunames;
        }
        public void setTitle(string t, Font TitleFont)
        {
            this.printTitle = t;
            this.titleFont = TitleFont;
        }
        public void setprintselection()
        {
            this.printSelect = 1;
        }
        public void setFont(Font titleFont, Font contentFont)
        {
            this.headingFont = titleFont;
            this.font = contentFont;
        }
        private void printDocument_PrintPage(object sender, PrintPageEventArgs e)
        {
            string[] array = this.dislistcols.Split(new char[]
			{
				','
			});
            this.rowCount = this.dataGridView.Rows.Count;
            this.colCount = this.dataGridView.Columns.Count;
            this.y = this.upMargin;
            if (this.printTitle != null && this.printTitle != "")
            {
                e.Graphics.DrawString(this.printTitle, this.titleFont, this.brush, (float)(e.PageBounds.Width / 2) - e.Graphics.MeasureString(this.printTitle, this.titleFont).Width / 2f, (float)this.y);
                int num = (int)e.Graphics.MeasureString(this.printTitle, this.titleFont).Height + 10;
                this.y += num;
            }
            this.x = this.leftMargin;
            int num2 = 50;
            this.rowGap = this.getHeaderHeight(e.Graphics, this.headingFont);
            e.Graphics.FillRectangle(new SolidBrush(Color.White), this.x, this.y, num2, this.rowGap);
            e.Graphics.DrawRectangle(Pens.Black, this.x, this.y, num2, this.rowGap);
            e.Graphics.DrawString("序号", this.headingFont, this.brush, (float)this.x, (float)(this.y + 5));
            this.x += num2;
            for (int i = 0; i < array.Length; i++)
            {
                string columnName = array[i];
                if (this.dataGridView.Columns[columnName].Width > 0)
                {
                    this.cellValue = this.dataGridView.Columns[columnName].HeaderText;
                    e.Graphics.FillRectangle(new SolidBrush(Color.White), this.x, this.y, this.dataGridView.Columns[columnName].Width, this.rowGap);
                    e.Graphics.DrawRectangle(Pens.Black, this.x, this.y, this.dataGridView.Columns[columnName].Width, this.rowGap);
                    if (e.Graphics.MeasureString(this.cellValue, this.headingFont).Width > (float)this.dataGridView.Columns[columnName].Width)
                    {
                        if (!this.autoWrap)
                        {
                            this.cellValue = this.TrunString(e.Graphics, this.cellValue, this.headingFont, this.dataGridView.Columns[columnName].Width);
                        }
                        else
                        {
                            this.cellValue = this.WrapString(e.Graphics, this.cellValue, this.headingFont, this.dataGridView.Columns[columnName].Width);
                        }
                    }
                    e.Graphics.DrawString(this.cellValue, this.headingFont, this.brush, (float)(this.x + 2), (float)(this.y + 5));
                    this.x += this.dataGridView.Columns[columnName].Width;
                }
            }
            this.y += this.rowGap;
            while (this.i < this.rowCount)
            {
                this.x = this.leftMargin;
                this.rowGap = this.getLineHeight(e.Graphics, this.i, this.font) + this.append_line;
                if (this.dataGridView.Rows[this.i].Selected || this.printSelect != 1)
                {
                    e.Graphics.DrawRectangle(Pens.Black, this.x, this.y, num2, this.rowGap);
                    int num3 = this.linenum;
                    string s = num3.ToString();
                    if (this.i == this.rowCount - 1)
                    {
                        s = "合计";
                    }
                    e.Graphics.DrawString(s, this.font, this.brush, (float)(this.x + 2), (float)(this.y + 5));
                    this.x += num2;
                    for (int i = 0; i < array.Length; i++)
                    {
                        string columnName = array[i];
                        if (this.dataGridView.Columns[columnName].Width > 0)
                        {
                            Type type = this.dataGridView.Rows[this.i].Cells[columnName].Value.GetType();
                            if (type.ToString() == "System.DateTime")
                            {
                                this.cellValue = ((DateTime)this.dataGridView.Rows[this.i].Cells[columnName].Value).ToShortDateString();
                            }
                            else
                            {
                                this.cellValue = this.dataGridView.Rows[this.i].Cells[columnName].Value.ToString();
                            }
                            if (e.Graphics.MeasureString(this.cellValue, this.font).Width > (float)this.dataGridView.Columns[columnName].Width)
                            {
                                if (!this.autoWrap)
                                {
                                    this.cellValue = this.TrunString(e.Graphics, this.cellValue, this.font, this.dataGridView.Columns[columnName].Width);
                                }
                                else
                                {
                                    this.cellValue = this.WrapString(e.Graphics, this.cellValue, this.font, this.dataGridView.Columns[columnName].Width);
                                }
                            }
                            e.Graphics.DrawRectangle(Pens.Black, this.x, this.y, this.dataGridView.Columns[columnName].Width, this.rowGap);
                            e.Graphics.DrawString(this.cellValue, this.font, this.brush, (float)(this.x + 2), (float)(this.y + 5));
                            this.x += this.dataGridView.Columns[columnName].Width;
                        }
                    }
                    this.linenum++;
                    this.y += this.rowGap;
                    if (this.y >= e.PageBounds.Height - 30 - this.downMargin)
                    {
                        this.y = 0;
                        e.HasMorePages = true;
                        this.i++;
                        return;
                    }
                }
                this.i++;
            }
            this.y += this.rowGap;
            for (int j = 0; j < this.colCount; j++)
            {
                e.Graphics.DrawString(" ", this.font, this.brush, (float)this.x, (float)this.y);
            }
            this.linenum = 1;
            this.i = 0;
            e.HasMorePages = false;
        }
        private int getHeaderHeight(Graphics g, Font font)
        {
            int num = (int)((double)g.MeasureString("测试高度", font).Height + 0.5);
            int num2 = 1;
            for (int i = 0; i < this.colCount; i++)
            {
                if (this.dataGridView.Columns[i].Visible && this.dataGridView.Columns[i].Width > 0)
                {
                    string headerText = this.dataGridView.Columns[i].HeaderText;
                    int num3 = this.dataGridView.Columns[i].Width - 5;
                    int num4 = (int)g.MeasureString(headerText, font).Width;
                    int num5 = num4 / num3;
                    int num6 = num4 % num3;
                    if (num6 > 0)
                    {
                        num5++;
                    }
                    if (num5 > num2)
                    {
                        num2 = num5;
                    }
                }
            }
            return num2 * num + 10;
        }
        private int getLineHeight(Graphics g, int rownum, Font font)
        {
            int num = (int)((double)g.MeasureString("测试高度", font).Height + 0.5);
            int num2 = 1;
            for (int i = 0; i < this.colCount; i++)
            {
                if (this.dataGridView.Columns[i].Visible && this.dataGridView.Columns[i].Width > 0)
                {
                    Type type = this.dataGridView.Rows[rownum].Cells[i].Value.GetType();
                    string text;
                    if (type.ToString() == "System.DateTime")
                    {
                        text = ((DateTime)this.dataGridView.Rows[rownum].Cells[i].Value).ToShortDateString();
                    }
                    else
                    {
                        text = this.dataGridView.Rows[rownum].Cells[i].Value.ToString();
                    }
                    int num3 = this.dataGridView.Columns[i].Width - 5;
                    int num4 = (int)g.MeasureString(text, font).Width;
                    int num5 = num4 / num3;
                    int num6 = num4 % num3;
                    if (num6 > 0)
                    {
                        num5++;
                    }
                    if (num5 > num2)
                    {
                        num2 = num5;
                    }
                }
            }
            return num2 * num + 10;
        }
        public string WrapString(Graphics g, string input, Font font, int width)
        {
            int stringRows = this.GetStringRows(g, input, font, width);
            int num = (int)((double)input.Length / ((double)stringRows * 1.0) + 0.5);
            string text = "";
            for (int i = 0; i < stringRows; i++)
            {
                if (i == stringRows - 1)
                {
                    text += input.Substring(i * num);
                    break;
                }
                text = text + input.Substring(i * num, num) + "\n";
            }
            return text;
        }
        public string TrunString(Graphics g, string input, Font font, int width)
        {
            int stringRows = this.GetStringRows(g, input, font, width);
            int length = (int)((double)input.Length / ((double)stringRows * 1.0) + 0.5);
            string result;
            if (stringRows == 1)
            {
                result = input;
            }
            else
            {
                result = input.Substring(0, length) + "..";
            }
            return result;
        }
        public int GetStringRows(Graphics g, string input, Font font, int width)
        {
            width -= 5;
            int num = (int)g.MeasureString(input, font).Width;
            int num2 = num / width;
            int num3 = num % width;
            if (num3 > 0)
            {
                num2++;
            }
            return num2;
        }
        public PrintDocument GetPrintDocument()
        {
            return this.printDocument;
        }
        public void Print()
        {
            try
            {
                this.pageSetupDialog = new PageSetupDialog();
                this.pageSetupDialog.Document = this.printDocument;
                if (this.pageSetupDialog.ShowDialog() != DialogResult.Cancel)
                {
                    this.linenum = 1;
                    this.leftMargin = this.pageSetupDialog.PageSettings.Margins.Left;
                    this.upMargin = this.pageSetupDialog.PageSettings.Margins.Top;
                    this.downMargin = this.pageSetupDialog.PageSettings.Margins.Bottom;
                    this.printPreviewDialog = new PrintPreviewDialog();
                    this.printPreviewDialog.Document = this.printDocument;
                    this.printPreviewDialog.Height = 600;
                    this.printPreviewDialog.Width = 800;
                    this.printPreviewDialog.ShowDialog();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("打印错误: " + ex.Message, "Information", MessageBoxButtons.OK, MessageBoxIcon.Hand);
            }
        }
	}
}
