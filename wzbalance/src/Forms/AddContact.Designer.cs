using System;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Windows.Forms;

namespace wzbalance.src.Forms
{
    partial class AddContact
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;
        private GroupBox groupBox1;
        private Label label1;
        private Button button1;
        private TextBox phone1;
        private Label label3;
        private TextBox person1;
        private Label label2;
        private ComboBox comboBox1;
        private TextBox zipcode;
        private Label label9;
        private TextBox phone3;
        private Label label7;
        private TextBox phone2;
        private TextBox address;
        private Label label5;
        private TextBox person3;
        private Label label8;
        private TextBox person2;
        private Label label6;
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
            this.groupBox1 = new GroupBox();
            this.button1 = new Button();
            this.label1 = new Label();
            this.comboBox1 = new ComboBox();
            this.label2 = new Label();
            this.person1 = new TextBox();
            this.label3 = new Label();
            this.phone1 = new TextBox();
            this.label4 = new Label();
            this.person2 = new TextBox();
            this.label5 = new Label();
            this.phone2 = new TextBox();
            this.label6 = new Label();
            this.person3 = new TextBox();
            this.label7 = new Label();
            this.phone3 = new TextBox();
            this.label8 = new Label();
            this.address = new TextBox();
            this.label9 = new Label();
            this.zipcode = new TextBox();
            this.groupBox1.SuspendLayout();
            base.SuspendLayout();
            this.groupBox1.Controls.Add(this.zipcode);
            this.groupBox1.Controls.Add(this.label9);
            this.groupBox1.Controls.Add(this.phone3);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.phone2);
            this.groupBox1.Controls.Add(this.address);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.person3);
            this.groupBox1.Controls.Add(this.phone1);
            this.groupBox1.Controls.Add(this.label8);
            this.groupBox1.Controls.Add(this.person2);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.person1);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.comboBox1);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new Point(25, 37);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new Size(457, 398);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "输入信息";
            this.button1.Location = new Point(394, 473);
            this.button1.Name = "button1";
            this.button1.Size = new Size(75, 23);
            this.button1.TabIndex = 10;
            this.button1.Text = "添加";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new EventHandler(this.button1_Click);
            this.label1.AutoSize = true;
            this.label1.Location = new Point(22, 33);
            this.label1.Name = "label1";
            this.label1.Size = new Size(53, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "单位名称";
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Location = new Point(97, 24);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new Size(112, 20);
            this.comboBox1.TabIndex = 1;
            this.label2.AutoSize = true;
            this.label2.Location = new Point(22, 70);
            this.label2.Name = "label2";
            this.label2.Size = new Size(41, 12);
            this.label2.TabIndex = 2;
            this.label2.Text = "联系人";
            this.person1.Location = new Point(97, 61);
            this.person1.Name = "person1";
            this.person1.Size = new Size(112, 21);
            this.person1.TabIndex = 2;
            this.label3.AutoSize = true;
            this.label3.Location = new Point(260, 70);
            this.label3.Name = "label3";
            this.label3.Size = new Size(29, 12);
            this.label3.TabIndex = 2;
            this.label3.Text = "电话";
            this.phone1.Location = new Point(309, 61);
            this.phone1.Name = "phone1";
            this.phone1.Size = new Size(112, 21);
            this.phone1.TabIndex = 3;
            this.label4.AutoSize = true;
            this.label4.Location = new Point(22, 113);
            this.label4.Name = "label4";
            this.label4.Size = new Size(41, 12);
            this.label4.TabIndex = 2;
            this.label4.Text = "联系人";
            this.person2.Location = new Point(97, 104);
            this.person2.Name = "person2";
            this.person2.Size = new Size(112, 21);
            this.person2.TabIndex = 4;
            this.label5.AutoSize = true;
            this.label5.Location = new Point(260, 113);
            this.label5.Name = "label5";
            this.label5.Size = new Size(29, 12);
            this.label5.TabIndex = 2;
            this.label5.Text = "电话";
            this.phone2.Location = new Point(309, 104);
            this.phone2.Name = "phone2";
            this.phone2.Size = new Size(112, 21);
            this.phone2.TabIndex = 5;
            this.label6.AutoSize = true;
            this.label6.Location = new Point(22, 155);
            this.label6.Name = "label6";
            this.label6.Size = new Size(41, 12);
            this.label6.TabIndex = 2;
            this.label6.Text = "联系人";
            this.person3.Location = new Point(97, 146);
            this.person3.Name = "person3";
            this.person3.Size = new Size(112, 21);
            this.person3.TabIndex = 6;
            this.label7.AutoSize = true;
            this.label7.Location = new Point(260, 155);
            this.label7.Name = "label7";
            this.label7.Size = new Size(29, 12);
            this.label7.TabIndex = 2;
            this.label7.Text = "电话";
            this.phone3.Location = new Point(309, 146);
            this.phone3.Name = "phone3";
            this.phone3.Size = new Size(112, 21);
            this.phone3.TabIndex = 7;
            this.label8.AutoSize = true;
            this.label8.Location = new Point(22, 197);
            this.label8.Name = "label8";
            this.label8.Size = new Size(29, 12);
            this.label8.TabIndex = 2;
            this.label8.Text = "地址";
            this.address.Location = new Point(97, 188);
            this.address.Name = "address";
            this.address.Size = new Size(324, 21);
            this.address.TabIndex = 8;
            this.label9.AutoSize = true;
            this.label9.Location = new Point(22, 241);
            this.label9.Name = "label9";
            this.label9.Size = new Size(53, 12);
            this.label9.TabIndex = 2;
            this.label9.Text = "邮政编码";
            this.zipcode.Location = new Point(97, 232);
            this.zipcode.Name = "zipcode";
            this.zipcode.Size = new Size(112, 21);
            this.zipcode.TabIndex = 9;
            base.AutoScaleDimensions = new SizeF(6f, 12f);
            base.ClientSize = new Size(511, 508);
            base.Controls.Add(this.button1);
            base.Controls.Add(this.groupBox1);
            base.Name = "NewContact";
            this.Text = "添加联系人";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            base.ResumeLayout(false);
        }

        #endregion
    }
}