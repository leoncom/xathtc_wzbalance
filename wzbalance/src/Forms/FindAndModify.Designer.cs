using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace wzbalance.src.Forms
{
    partial class FindAndModify
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;
        private Label label1;
        private ComboBox comboBox1;
        private TextBox textBox1;
        private TextBox textBox2;
        private Label label2;
        private Label label3;
        private Button button1;

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
            this.comboBox1 = new ComboBox();
            this.textBox1 = new TextBox();
            this.textBox2 = new TextBox();
            this.label2 = new Label();
            this.label3 = new Label();
            this.button1 = new Button();
            base.SuspendLayout();
            this.label1.AutoSize = true;
            this.label1.Location = new Point(21, 23);
            this.label1.Name = "label1";
            this.label1.Size = new Size(29, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "属性";
            this.comboBox1.DropDownStyle = ComboBoxStyle.DropDownList;
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Location = new Point(83, 15);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new Size(121, 20);
            this.comboBox1.TabIndex = 1;
            this.textBox1.Location = new Point(83, 58);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new Size(121, 21);
            this.textBox1.TabIndex = 2;
            this.textBox2.Location = new Point(83, 104);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new Size(121, 21);
            this.textBox2.TabIndex = 2;
            this.label2.AutoSize = true;
            this.label2.Location = new Point(21, 67);
            this.label2.Name = "label2";
            this.label2.Size = new Size(53, 12);
            this.label2.TabIndex = 0;
            this.label2.Text = "查找内容";
            this.label3.AutoSize = true;
            this.label3.Location = new Point(21, 113);
            this.label3.Name = "label3";
            this.label3.Size = new Size(41, 12);
            this.label3.TabIndex = 0;
            this.label3.Text = "替换为";
            this.button1.Location = new Point(129, 152);
            this.button1.Name = "button1";
            this.button1.Size = new Size(75, 23);
            this.button1.TabIndex = 3;
            this.button1.Text = "确认";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new EventHandler(this.button1_Click);
            base.AutoScaleDimensions = new SizeF(6f, 12f);
            base.ClientSize = new Size(231, 202);
            base.Controls.Add(this.button1);
            base.Controls.Add(this.textBox2);
            base.Controls.Add(this.textBox1);
            base.Controls.Add(this.comboBox1);
            base.Controls.Add(this.label3);
            base.Controls.Add(this.label2);
            base.Controls.Add(this.label1);
            base.Name = "FindAndModify";
            this.Text = "替换";
            base.ResumeLayout(false);
            base.PerformLayout();
        }

        #endregion
    }
}