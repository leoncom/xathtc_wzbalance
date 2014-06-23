using System;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using wzbalance.Properties;

namespace wzbalance.src.Forms
{
    partial class ContactsManage
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;
        private Panel panel1;
        private DataGridView dataGridView1;
        private Button button2;
        private Button button1;
        private GroupBox groupBox1;
        private ComboBox comboBox1;
        private TextBox textBox1;
        private Button button6;
        private ToolTip toolTip1;
        private BindingSource bindingSource1;
        private Button button3;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.panel1 = new Panel();
			this.groupBox1 = new GroupBox();
			this.button6 = new Button();
			this.textBox1 = new TextBox();
			this.comboBox1 = new ComboBox();
			this.button2 = new Button();
			this.button1 = new Button();
			this.dataGridView1 = new DataGridView();
			this.toolTip1 = new ToolTip(this.components);
			this.bindingSource1 = new BindingSource(this.components);
			this.button3 = new Button();
			this.panel1.SuspendLayout();
			this.groupBox1.SuspendLayout();
			((ISupportInitialize)this.dataGridView1).BeginInit();
			((ISupportInitialize)this.bindingSource1).BeginInit();
			base.SuspendLayout();
			this.panel1.Controls.Add(this.groupBox1);
			this.panel1.Controls.Add(this.button3);
			this.panel1.Controls.Add(this.button2);
			this.panel1.Controls.Add(this.button1);
			this.panel1.Dock = DockStyle.Top;
			this.panel1.Location = new Point(0, 0);
			this.panel1.Name = "panel1";
			this.panel1.Size = new Size(680, 59);
			this.panel1.TabIndex = 0;
			this.groupBox1.Anchor = (AnchorStyles.Top | AnchorStyles.Right);
			this.groupBox1.Controls.Add(this.button6);
			this.groupBox1.Controls.Add(this.textBox1);
			this.groupBox1.Controls.Add(this.comboBox1);
			this.groupBox1.Location = new Point(393, 3);
			this.groupBox1.Name = "groupBox1";
			this.groupBox1.Size = new Size(275, 50);
			this.groupBox1.TabIndex = 1;
			this.groupBox1.TabStop = false;
			this.groupBox1.Text = "搜索";
			this.button6.BackgroundImage = Resources.search;
			this.button6.BackgroundImageLayout = ImageLayout.Center;
			this.button6.Location = new Point(236, 20);
			this.button6.Name = "button6";
			this.button6.Size = new Size(21, 21);
			this.button6.TabIndex = 4;
			this.toolTip1.SetToolTip(this.button6, "搜索");
			this.button6.UseVisualStyleBackColor = true;
			this.button6.Click += new EventHandler(this.button6_Click);
			this.textBox1.Location = new Point(121, 21);
			this.textBox1.Name = "textBox1";
			this.textBox1.Size = new Size(100, 21);
			this.textBox1.TabIndex = 1;
			this.toolTip1.SetToolTip(this.textBox1, "输入查询关键字");
			this.comboBox1.DropDownStyle = ComboBoxStyle.DropDownList;
			this.comboBox1.FormattingEnabled = true;
			this.comboBox1.Location = new Point(16, 21);
			this.comboBox1.Name = "comboBox1";
			this.comboBox1.Size = new Size(88, 20);
			this.comboBox1.TabIndex = 0;
			this.toolTip1.SetToolTip(this.comboBox1, "选择搜索的内容");
			this.button2.Location = new Point(116, 12);
			this.button2.Name = "button2";
			this.button2.Size = new Size(71, 35);
			this.button2.TabIndex = 0;
			this.button2.Text = "删除信息";
			this.toolTip1.SetToolTip(this.button2, "删除当前行记录");
			this.button2.UseVisualStyleBackColor = true;
			this.button2.Click += new EventHandler(this.button2_Click);
			this.button1.Location = new Point(22, 12);
			this.button1.Name = "button1";
			this.button1.Size = new Size(71, 35);
			this.button1.TabIndex = 0;
			this.button1.Text = "修改信息";
			this.toolTip1.SetToolTip(this.button1, "修改当前行记录");
			this.button1.UseVisualStyleBackColor = true;
			this.button1.Click += new EventHandler(this.button1_Click);
			this.dataGridView1.AllowUserToAddRows = false;
			this.dataGridView1.AllowUserToDeleteRows = false;
			this.dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.dataGridView1.Dock = DockStyle.Fill;
			this.dataGridView1.EditMode = DataGridViewEditMode.EditProgrammatically;
			this.dataGridView1.Location = new Point(0, 59);
			this.dataGridView1.Name = "dataGridView1";
			this.dataGridView1.RowTemplate.Height = 23;
			this.dataGridView1.Size = new Size(680, 448);
			this.dataGridView1.TabIndex = 1;
			this.dataGridView1.CellMouseClick += new DataGridViewCellMouseEventHandler(this.dataGridView1_CellMouseClick);
			this.dataGridView1.Sorted += new EventHandler(this.dataGridView1_Sorted);
			this.button3.Location = new Point(210, 12);
			this.button3.Name = "button3";
			this.button3.Size = new Size(71, 35);
			this.button3.TabIndex = 0;
			this.button3.Text = "显示全部";
			this.toolTip1.SetToolTip(this.button3, "显示全部的联系单位");
			this.button3.UseVisualStyleBackColor = true;
			this.button3.Click += new EventHandler(this.button3_Click);
			base.AutoScaleDimensions = new SizeF(6f, 12f);
			base.ClientSize = new Size(680, 507);
			base.Controls.Add(this.dataGridView1);
			base.Controls.Add(this.panel1);
			base.Name = "ContactsManage";
			this.Text = "管理联系人";
			base.Load += new EventHandler(this.ContactsManage_Load);
			base.FormClosing += new FormClosingEventHandler(this.ContactsManage_FormClosing);
			this.panel1.ResumeLayout(false);
			this.groupBox1.ResumeLayout(false);
			this.groupBox1.PerformLayout();
			((ISupportInitialize)this.dataGridView1).EndInit();
			((ISupportInitialize)this.bindingSource1).EndInit();
			base.ResumeLayout(false);
		}

        #endregion
    }
}