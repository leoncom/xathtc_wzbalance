using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace wzbalance.src.Forms
{
    partial class ChangePassword
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;
        private TextBox pwd2;
        private Label label3;
        private TextBox pwd1;
        private Label label2;
        private TextBox oldpwd;
        private Label label1;
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
            this.pwd2 = new TextBox();
            this.label3 = new Label();
            this.pwd1 = new TextBox();
            this.label2 = new Label();
            this.oldpwd = new TextBox();
            this.label1 = new Label();
            this.button1 = new Button();
            base.SuspendLayout();
            this.pwd2.Location = new Point(96, 111);
            this.pwd2.Name = "pwd2";
            this.pwd2.PasswordChar = '*';
            this.pwd2.Size = new Size(100, 21);
            this.pwd2.TabIndex = 3;
            this.label3.AutoSize = true;
            this.label3.Location = new Point(23, 120);
            this.label3.Name = "label3";
            this.label3.Size = new Size(65, 12);
            this.label3.TabIndex = 5;
            this.label3.Text = "再输入一遍";
            this.pwd1.Location = new Point(96, 66);
            this.pwd1.Name = "pwd1";
            this.pwd1.PasswordChar = '*';
            this.pwd1.Size = new Size(100, 21);
            this.pwd1.TabIndex = 2;
            this.label2.AutoSize = true;
            this.label2.Location = new Point(23, 75);
            this.label2.Name = "label2";
            this.label2.Size = new Size(41, 12);
            this.label2.TabIndex = 4;
            this.label2.Text = "新密码";
            this.oldpwd.Location = new Point(96, 20);
            this.oldpwd.Name = "oldpwd";
            this.oldpwd.PasswordChar = '*';
            this.oldpwd.Size = new Size(100, 21);
            this.oldpwd.TabIndex = 1;
            this.label1.AutoSize = true;
            this.label1.Location = new Point(23, 29);
            this.label1.Name = "label1";
            this.label1.Size = new Size(41, 12);
            this.label1.TabIndex = 6;
            this.label1.Text = "原密码";
            this.button1.Location = new Point(121, 167);
            this.button1.Name = "button1";
            this.button1.Size = new Size(75, 23);
            this.button1.TabIndex = 7;
            this.button1.Text = "确定";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new EventHandler(this.button1_Click);
            base.AutoScaleDimensions = new SizeF(6f, 12f);
            base.ClientSize = new Size(233, 216);
            base.Controls.Add(this.button1);
            base.Controls.Add(this.pwd2);
            base.Controls.Add(this.label3);
            base.Controls.Add(this.pwd1);
            base.Controls.Add(this.label2);
            base.Controls.Add(this.oldpwd);
            base.Controls.Add(this.label1);
            base.Name = "ChangePassword";
            this.Text = "修改密码";
            base.ResumeLayout(false);
            base.PerformLayout();
        }

        #endregion
    }
}