using System;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Windows.Forms;

namespace wzbalance.src.Forms
{
    partial class DeleteTemplate
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;
        private ComboBox comboBox1;
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
            this.comboBox1 = new ComboBox();
            this.button1 = new Button();
            base.SuspendLayout();
            this.comboBox1.DropDownStyle = ComboBoxStyle.DropDownList;
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Location = new Point(23, 25);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new Size(121, 20);
            this.comboBox1.TabIndex = 0;
            this.button1.Location = new Point(172, 25);
            this.button1.Name = "button1";
            this.button1.Size = new Size(64, 23);
            this.button1.TabIndex = 1;
            this.button1.Text = "删除";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new EventHandler(this.button1_Click);
            base.AutoScaleDimensions = new SizeF(6f, 12f);
            base.ClientSize = new Size(253, 67);
            base.Controls.Add(this.button1);
            base.Controls.Add(this.comboBox1);
            base.Name = "DeleteTemplate";
            this.Text = "删除模板";
            base.ResumeLayout(false);
        }

        #endregion

    }
}