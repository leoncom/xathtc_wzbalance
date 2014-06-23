using System;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Windows.Forms;

namespace wzbalance.src.Forms
{
    partial class PrintTemplate
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;
        private Label label1;
        private TextBox templateName;
        private Label label2;
        private GroupBox groupBox1;
        private ListBox listBox1;
        private Button button2;
        private Button button4;
        private Button button3;
        private Button button1;
        private ListBox listBox2;
        private Button button5;
        private Button button6;
        private TextBox fontString;
        private Button button7;
        private TextBox titleFontStr;
        private Label label3;
        private Button button8;
        private Button button9;
        private Label label5;
        private Label label4;

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
            this.label1 = new Label();
            this.templateName = new TextBox();
            this.label2 = new Label();
            this.groupBox1 = new GroupBox();
            this.button2 = new Button();
            this.button4 = new Button();
            this.button3 = new Button();
            this.button1 = new Button();
            this.listBox2 = new ListBox();
            this.listBox1 = new ListBox();
            this.button5 = new Button();
            this.button6 = new Button();
            this.fontString = new TextBox();
            this.button7 = new Button();
            this.titleFontStr = new TextBox();
            this.label3 = new Label();
            this.button8 = new Button();
            this.button9 = new Button();
            this.label4 = new Label();
            this.label5 = new Label();
            this.groupBox1.SuspendLayout();
            base.SuspendLayout();
            this.label1.AutoSize = true;
            this.label1.Location = new Point(12, 27);
            this.label1.Name = "label1";
            this.label1.Size = new Size(53, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "模板名称";
            this.templateName.Location = new Point(100, 18);
            this.templateName.Name = "templateName";
            this.templateName.Size = new Size(184, 21);
            this.templateName.TabIndex = 1;
            this.label2.AutoSize = true;
            this.label2.Location = new Point(11, 113);
            this.label2.Name = "label2";
            this.label2.Size = new Size(77, 12);
            this.label2.TabIndex = 2;
            this.label2.Text = "表格内容字体";
            this.groupBox1.Controls.Add(this.button2);
            this.groupBox1.Controls.Add(this.button4);
            this.groupBox1.Controls.Add(this.button3);
            this.groupBox1.Controls.Add(this.button1);
            this.groupBox1.Controls.Add(this.listBox2);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.listBox1);
            this.groupBox1.Location = new Point(23, 152);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new Size(349, 231);
            this.groupBox1.TabIndex = 4;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "显示列选择";
            this.button2.Location = new Point(131, 165);
            this.button2.Name = "button2";
            this.button2.Size = new Size(36, 23);
            this.button2.TabIndex = 1;
            this.button2.Text = "<=";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new EventHandler(this.button2_Click);
            this.button4.Location = new Point(304, 136);
            this.button4.Name = "button4";
            this.button4.Size = new Size(22, 33);
            this.button4.TabIndex = 1;
            this.button4.Text = "↓";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new EventHandler(this.button4_Click);
            this.button3.Location = new Point(304, 88);
            this.button3.Name = "button3";
            this.button3.Size = new Size(22, 33);
            this.button3.TabIndex = 1;
            this.button3.Text = "↑";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new EventHandler(this.button3_Click);
            this.button1.Location = new Point(131, 75);
            this.button1.Name = "button1";
            this.button1.Size = new Size(36, 23);
            this.button1.TabIndex = 1;
            this.button1.Text = "=>";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new EventHandler(this.button1_Click);
            this.listBox2.FormattingEnabled = true;
            this.listBox2.ItemHeight = 12;
            this.listBox2.Location = new Point(185, 57);
            this.listBox2.Name = "listBox2";
            this.listBox2.Size = new Size(99, 160);
            this.listBox2.TabIndex = 0;
            this.listBox1.FormattingEnabled = true;
            this.listBox1.ItemHeight = 12;
            this.listBox1.Location = new Point(18, 57);
            this.listBox1.Name = "listBox1";
            this.listBox1.Size = new Size(99, 160);
            this.listBox1.TabIndex = 0;
            this.button5.Location = new Point(208, 402);
            this.button5.Name = "button5";
            this.button5.Size = new Size(75, 23);
            this.button5.TabIndex = 5;
            this.button5.Text = "取消";
            this.button5.UseVisualStyleBackColor = true;
            this.button5.Click += new EventHandler(this.button5_Click);
            this.button6.Location = new Point(297, 402);
            this.button6.Name = "button6";
            this.button6.Size = new Size(75, 23);
            this.button6.TabIndex = 5;
            this.button6.Text = "保存";
            this.button6.UseVisualStyleBackColor = true;
            this.button6.Click += new EventHandler(this.button6_Click);
            this.fontString.Location = new Point(99, 104);
            this.fontString.Name = "fontString";
            this.fontString.ReadOnly = true;
            this.fontString.Size = new Size(184, 21);
            this.fontString.TabIndex = 1;
            this.button7.Location = new Point(297, 102);
            this.button7.Name = "button7";
            this.button7.Size = new Size(75, 23);
            this.button7.TabIndex = 6;
            this.button7.Text = "设置字体";
            this.button7.UseVisualStyleBackColor = true;
            this.button7.Click += new EventHandler(this.button7_Click);
            this.titleFontStr.Location = new Point(99, 62);
            this.titleFontStr.Name = "titleFontStr";
            this.titleFontStr.ReadOnly = true;
            this.titleFontStr.Size = new Size(184, 21);
            this.titleFontStr.TabIndex = 1;
            this.label3.AutoSize = true;
            this.label3.Location = new Point(11, 71);
            this.label3.Name = "label3";
            this.label3.Size = new Size(53, 12);
            this.label3.TabIndex = 2;
            this.label3.Text = "列名字体";
            this.button8.Location = new Point(297, 60);
            this.button8.Name = "button8";
            this.button8.Size = new Size(75, 23);
            this.button8.TabIndex = 6;
            this.button8.Text = "设置字体";
            this.button8.UseVisualStyleBackColor = true;
            this.button8.Click += new EventHandler(this.button8_Click);
            this.button9.Location = new Point(23, 402);
            this.button9.Name = "button9";
            this.button9.Size = new Size(139, 23);
            this.button9.TabIndex = 7;
            this.button9.Text = "使用当前设置";
            this.button9.UseVisualStyleBackColor = true;
            this.button9.Click += new EventHandler(this.button9_Click);
            this.label4.AutoSize = true;
            this.label4.ForeColor = SystemColors.Desktop;
            this.label4.Location = new Point(16, 33);
            this.label4.Name = "label4";
            this.label4.Size = new Size(53, 12);
            this.label4.TabIndex = 2;
            this.label4.Text = "备选属性";
            this.label5.AutoSize = true;
            this.label5.ForeColor = SystemColors.Desktop;
            this.label5.Location = new Point(183, 33);
            this.label5.Name = "label5";
            this.label5.Size = new Size(53, 12);
            this.label5.TabIndex = 2;
            this.label5.Text = "打印属性";
            base.AutoScaleDimensions = new SizeF(6f, 12f);
            base.ClientSize = new Size(396, 438);
            base.Controls.Add(this.button9);
            base.Controls.Add(this.button8);
            base.Controls.Add(this.button7);
            base.Controls.Add(this.button6);
            base.Controls.Add(this.button5);
            base.Controls.Add(this.label3);
            base.Controls.Add(this.groupBox1);
            base.Controls.Add(this.titleFontStr);
            base.Controls.Add(this.label2);
            base.Controls.Add(this.fontString);
            base.Controls.Add(this.templateName);
            base.Controls.Add(this.label1);
            base.Name = "Template";
            base.StartPosition = FormStartPosition.CenterParent;
            this.Text = "打印模板";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            base.ResumeLayout(false);
            base.PerformLayout();
        }

        #endregion
    }
}