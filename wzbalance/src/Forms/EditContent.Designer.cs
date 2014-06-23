using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace wzbalance.src.Forms
{
    partial class EditContent
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;
        private ComboBox comboBox1;
        private Label label1;
        private Label label2;
        private ListBox listBox1;
        private Button button1;
        private Button button2;
        private Button button3;
        private Button button4;

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
            this.comboBox1 = new ComboBox();
            this.label1 = new Label();
            this.label2 = new Label();
            this.listBox1 = new ListBox();
            this.button1 = new Button();
            this.button2 = new Button();
            this.button3 = new Button();
            this.button4 = new Button();
            base.SuspendLayout();
            this.comboBox1.DropDownStyle = ComboBoxStyle.DropDownList;
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Location = new Point(35, 49);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new Size(188, 20);
            this.comboBox1.TabIndex = 0;
            this.comboBox1.SelectedIndexChanged += new EventHandler(this.comboBox1_SelectedIndexChanged);
            this.label1.AutoSize = true;
            this.label1.Location = new Point(33, 20);
            this.label1.Name = "label1";
            this.label1.Size = new Size(53, 12);
            this.label1.TabIndex = 1;
            this.label1.Text = "表单项目";
            this.label2.AutoSize = true;
            this.label2.Location = new Point(33, 86);
            this.label2.Name = "label2";
            this.label2.Size = new Size(53, 12);
            this.label2.TabIndex = 2;
            this.label2.Text = "选项内容";
            this.listBox1.FormattingEnabled = true;
            this.listBox1.ItemHeight = 12;
            this.listBox1.Location = new Point(35, 111);
            this.listBox1.Name = "listBox1";
            this.listBox1.Size = new Size(188, 88);
            this.listBox1.TabIndex = 3;
            this.button1.Location = new Point(35, 215);
            this.button1.Name = "button1";
            this.button1.Size = new Size(51, 23);
            this.button1.TabIndex = 4;
            this.button1.Text = "添加";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new EventHandler(this.button1_Click);
            this.button2.Location = new Point(172, 215);
            this.button2.Name = "button2";
            this.button2.Size = new Size(51, 23);
            this.button2.TabIndex = 4;
            this.button2.Text = "删除";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new EventHandler(this.button2_Click);
            this.button3.Location = new Point(148, 262);
            this.button3.Name = "button3";
            this.button3.Size = new Size(75, 23);
            this.button3.TabIndex = 5;
            this.button3.Text = "确定";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new EventHandler(this.button3_Click);
            this.button4.Location = new Point(103, 215);
            this.button4.Name = "button4";
            this.button4.Size = new Size(51, 23);
            this.button4.TabIndex = 6;
            this.button4.Text = "修改";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new EventHandler(this.button4_Click);
            base.AutoScaleDimensions = new SizeF(6f, 12f);
            base.ClientSize = new Size(265, 313);
            base.Controls.Add(this.button4);
            base.Controls.Add(this.button3);
            base.Controls.Add(this.button2);
            base.Controls.Add(this.button1);
            base.Controls.Add(this.listBox1);
            base.Controls.Add(this.label2);
            base.Controls.Add(this.label1);
            base.Controls.Add(this.comboBox1);
            base.Name = "EditContent";
            this.Text = "编辑表单属性";
            base.ResumeLayout(false);
            base.PerformLayout();
        }

        #endregion
    }
}