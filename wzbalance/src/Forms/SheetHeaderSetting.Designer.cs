using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace wzbalance.src.Forms
{
    partial class SheetHeaderSetting
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;
        private CheckedListBox checkedListBox1;
        private Button button1;
        private Label label1;

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
            this.checkedListBox1 = new CheckedListBox();
            this.button1 = new Button();
            this.label1 = new Label();
            base.SuspendLayout();
            this.checkedListBox1.FormattingEnabled = true;
            this.checkedListBox1.Location = new Point(33, 31);
            this.checkedListBox1.Name = "checkedListBox1";
            this.checkedListBox1.Size = new Size(175, 180);
            this.checkedListBox1.TabIndex = 0;
            this.checkedListBox1.SelectedIndexChanged += new EventHandler(this.checkedListBox1_SelectedIndexChanged);
            this.button1.Location = new Point(133, 266);
            this.button1.Name = "button1";
            this.button1.Size = new Size(75, 23);
            this.button1.TabIndex = 1;
            this.button1.Text = "关闭";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new EventHandler(this.button1_Click);
            this.label1.AutoSize = true;
            this.label1.ForeColor = Color.DarkGreen;
            this.label1.Location = new Point(40, 230);
            this.label1.Name = "label1";
            this.label1.Size = new Size(137, 12);
            this.label1.TabIndex = 2;
            this.label1.Text = "在需要显示的列名前打勾";
            base.AutoScaleDimensions = new SizeF(6f, 12f);
            base.ClientSize = new Size(244, 301);
            base.Controls.Add(this.label1);
            base.Controls.Add(this.button1);
            base.Controls.Add(this.checkedListBox1);
            base.Name = "Header";
            this.Text = "表头设置";
            base.ResumeLayout(false);
            base.PerformLayout();
        }

        #endregion
    }
}