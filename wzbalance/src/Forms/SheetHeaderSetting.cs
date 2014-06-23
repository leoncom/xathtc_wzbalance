using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace wzbalance.src.Forms
{
    public partial class SheetHeaderSetting : Form
    {
        private MainSheet mfrm;

        public SheetHeaderSetting()
        {
            this.InitializeComponent();
            base.StartPosition = FormStartPosition.CenterScreen;
        }
        public void init()
        {
            this.mfrm = (MainSheet)base.Owner;
            DataGridViewColumnCollection dataGridViewColumnCollection = this.mfrm.getcolumns();
            for (int i = 0; i < dataGridViewColumnCollection.Count; i++)
            {
                string name = dataGridViewColumnCollection[i].Name;
                string headerText = dataGridViewColumnCollection[i].HeaderText;
                HeaderDes item = new HeaderDes(name, headerText);
                bool visible = dataGridViewColumnCollection[i].Visible;
                this.checkedListBox1.Items.Add(item, visible);
            }
        }
        private void checkedListBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            int selectedIndex = this.checkedListBox1.SelectedIndex;
            if (this.checkedListBox1.GetItemChecked(selectedIndex))
            {
                HeaderDes headerDes = (HeaderDes)this.checkedListBox1.Items[selectedIndex];
                this.mfrm.unhidecolumn(headerDes.getcolumn());
            }
            else
            {
                HeaderDes headerDes = (HeaderDes)this.checkedListBox1.Items[selectedIndex];
                this.mfrm.hidecolumn(headerDes.getcolumn());
            }
        }
        private void button1_Click(object sender, EventArgs e)
        {
            base.Dispose();
        }
        private void button2_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < this.checkedListBox1.Items.Count; i++)
            {
                this.checkedListBox1.SetItemChecked(i, true);
            }
        }
        private void button3_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < this.checkedListBox1.Items.Count; i++)
            {
                this.checkedListBox1.SetItemChecked(i, false);
            }
        }
    }
}