using System;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Windows.Forms;

namespace wzbalance.src.Forms
{
    partial class AddUser
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;
        private Label label1;
        private TextBox username;
        private Label label2;
        private TextBox pwd1;
        private CheckedListBox rolecheckbox;
        private Button button2;
        private Label label3;
        private TextBox pwd2;

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
            this.username = new TextBox();
            this.label2 = new Label();
            this.pwd1 = new TextBox();
            this.rolecheckbox = new CheckedListBox();
            this.button2 = new Button();
            this.label3 = new Label();
            this.pwd2 = new TextBox();
            base.SuspendLayout();
            this.label1.AutoSize = true;
            this.label1.Location = new Point(27, 28);
            this.label1.Name = "label1";
            this.label1.Size = new Size(41, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "用户名";
            this.username.Location = new Point(100, 19);
            this.username.Name = "username";
            this.username.Size = new Size(100, 21);
            this.username.TabIndex = 1;
            this.label2.AutoSize = true;
            this.label2.Location = new Point(27, 74);
            this.label2.Name = "label2";
            this.label2.Size = new Size(29, 12);
            this.label2.TabIndex = 0;
            this.label2.Text = "密码";
            this.pwd1.Location = new Point(100, 65);
            this.pwd1.Name = "pwd1";
            this.pwd1.PasswordChar = '*';
            this.pwd1.Size = new Size(100, 21);
            this.pwd1.TabIndex = 2;
            this.rolecheckbox.FormattingEnabled = true;
            this.rolecheckbox.Location = new Point(29, 169);
            this.rolecheckbox.Name = "rolecheckbox";
            this.rolecheckbox.Size = new Size(171, 148);
            this.rolecheckbox.TabIndex = 4;
            this.button2.Location = new Point(133, 338);
            this.button2.Name = "button2";
            this.button2.Size = new Size(67, 23);
            this.button2.TabIndex = 5;
            this.button2.Text = "确认";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new EventHandler(this.button2_Click);
            this.label3.AutoSize = true;
            this.label3.Location = new Point(27, 119);
            this.label3.Name = "label3";
            this.label3.Size = new Size(65, 12);
            this.label3.TabIndex = 0;
            this.label3.Text = "再输入一遍";
            this.pwd2.Location = new Point(100, 110);
            this.pwd2.Name = "pwd2";
            this.pwd2.PasswordChar = '*';
            this.pwd2.Size = new Size(100, 21);
            this.pwd2.TabIndex = 3;
            base.ClientSize = new Size(232, 388);
            base.Controls.Add(this.button2);
            base.Controls.Add(this.rolecheckbox);
            base.Controls.Add(this.pwd2);
            base.Controls.Add(this.label3);
            base.Controls.Add(this.pwd1);
            base.Controls.Add(this.label2);
            base.Controls.Add(this.username);
            base.Controls.Add(this.label1);
            base.Name = "NewUser";
            this.Text = "新建用户";
            base.ResumeLayout(false);
            base.PerformLayout();
        }

        #endregion
    }
}