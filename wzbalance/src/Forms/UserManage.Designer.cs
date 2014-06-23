using System;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Windows.Forms;

namespace wzbalance.src.Forms
{
    partial class UserManage
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;
        private Label label1;
        private ComboBox comboBox1;
        private Label label2;
        private TextBox textBox1;
        private Label label3;
        private CheckedListBox checkedListBox1;
        private Button button1;
        private Button button2;
        private GroupBox groupBox1;
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
            this.label1 = new Label();
            this.comboBox1 = new ComboBox();
            this.label2 = new Label();
            this.textBox1 = new TextBox();
            this.label3 = new Label();
            this.checkedListBox1 = new CheckedListBox();
            this.button1 = new Button();
            this.button2 = new Button();
            this.groupBox1 = new GroupBox();
            this.button3 = new Button();
            this.groupBox1.SuspendLayout();
            base.SuspendLayout();
            this.label1.AutoSize = true;
            this.label1.Location = new Point(21, 35);
            this.label1.Name = "label1";
            this.label1.Size = new Size(53, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "选择用户";
            this.comboBox1.DropDownStyle = ComboBoxStyle.DropDownList;
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Location = new Point(91, 27);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new Size(121, 20);
            this.comboBox1.TabIndex = 1;
            this.comboBox1.SelectedIndexChanged += new EventHandler(this.comboBox1_SelectedIndexChanged);
            this.label2.AutoSize = true;
            this.label2.Location = new Point(22, 27);
            this.label2.Name = "label2";
            this.label2.Size = new Size(29, 12);
            this.label2.TabIndex = 2;
            this.label2.Text = "密码";
            this.textBox1.Location = new Point(68, 18);
            this.textBox1.Name = "textBox1";
            this.textBox1.PasswordChar = '*';
            this.textBox1.Size = new Size(110, 21);
            this.textBox1.TabIndex = 3;
            this.label3.AutoSize = true;
            this.label3.Location = new Point(22, 88);
            this.label3.Name = "label3";
            this.label3.Size = new Size(53, 12);
            this.label3.TabIndex = 4;
            this.label3.Text = "用户权限";
            this.checkedListBox1.FormattingEnabled = true;
            this.checkedListBox1.Location = new Point(24, 118);
            this.checkedListBox1.Name = "checkedListBox1";
            this.checkedListBox1.Size = new Size(154, 132);
            this.checkedListBox1.TabIndex = 5;
            this.button1.Location = new Point(103, 58);
            this.button1.Name = "button1";
            this.button1.Size = new Size(75, 23);
            this.button1.TabIndex = 6;
            this.button1.Text = "更新密码";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new EventHandler(this.button1_Click);
            this.button2.Location = new Point(103, 270);
            this.button2.Name = "button2";
            this.button2.Size = new Size(75, 23);
            this.button2.TabIndex = 6;
            this.button2.Text = "更新权限";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new EventHandler(this.button2_Click);
            this.groupBox1.Controls.Add(this.checkedListBox1);
            this.groupBox1.Controls.Add(this.button2);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.button1);
            this.groupBox1.Controls.Add(this.textBox1);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Location = new Point(23, 66);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new Size(212, 311);
            this.groupBox1.TabIndex = 7;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "用户信息";
            this.button3.Location = new Point(91, 395);
            this.button3.Name = "button3";
            this.button3.Size = new Size(75, 23);
            this.button3.TabIndex = 8;
            this.button3.Text = "删除用户";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new EventHandler(this.button3_Click);
            base.AutoScaleDimensions = new SizeF(6f, 12f);
            base.ClientSize = new Size(246, 440);
            base.Controls.Add(this.button3);
            base.Controls.Add(this.groupBox1);
            base.Controls.Add(this.comboBox1);
            base.Controls.Add(this.label1);
            base.Name = "UserManage";
            this.Text = "用户管理";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            base.ResumeLayout(false);
            base.PerformLayout();
        }

        #endregion
    }
}