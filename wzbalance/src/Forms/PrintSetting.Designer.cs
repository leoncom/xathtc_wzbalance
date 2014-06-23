using System;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Windows.Forms;

namespace wzbalance.src.Forms
{
    partial class PrintSetting
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;
        private Label label1;
        private TextBox textBox1;
        private Button button1;
        private GroupBox groupBox1;
        private RadioButton selfRadio;
        private RadioButton currRadio;
        private ComboBox comboBox1;
        private Button button2;
        private CheckBox autoWrap;
        private GroupBox groupBox2;
        private Label label2;
        private NumericUpDown AppendLineHeight;

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
            this.textBox1 = new TextBox();
            this.button1 = new Button();
            this.groupBox1 = new GroupBox();
            this.comboBox1 = new ComboBox();
            this.selfRadio = new RadioButton();
            this.currRadio = new RadioButton();
            this.button2 = new Button();
            this.autoWrap = new CheckBox();
            this.groupBox2 = new GroupBox();
            this.AppendLineHeight = new NumericUpDown();
            this.label2 = new Label();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((ISupportInitialize)this.AppendLineHeight).BeginInit();
            base.SuspendLayout();
            this.label1.AutoSize = true;
            this.label1.Location = new Point(12, 30);
            this.label1.Name = "label1";
            this.label1.Size = new Size(35, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "标题:";
            this.textBox1.Location = new Point(53, 21);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new Size(166, 21);
            this.textBox1.TabIndex = 1;
            this.button1.Location = new Point(237, 19);
            this.button1.Name = "button1";
            this.button1.Size = new Size(85, 23);
            this.button1.TabIndex = 2;
            this.button1.Text = "标题字体设置";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new EventHandler(this.button1_Click);
            this.groupBox1.Controls.Add(this.comboBox1);
            this.groupBox1.Controls.Add(this.selfRadio);
            this.groupBox1.Controls.Add(this.currRadio);
            this.groupBox1.Location = new Point(14, 74);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new Size(298, 112);
            this.groupBox1.TabIndex = 3;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "打印设置";
            this.comboBox1.DropDownStyle = ComboBoxStyle.DropDownList;
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Location = new Point(118, 73);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new Size(150, 20);
            this.comboBox1.TabIndex = 1;
            this.selfRadio.AutoSize = true;
            this.selfRadio.Location = new Point(16, 77);
            this.selfRadio.Name = "selfRadio";
            this.selfRadio.Size = new Size(83, 16);
            this.selfRadio.TabIndex = 0;
            this.selfRadio.TabStop = true;
            this.selfRadio.Text = "自定义样式";
            this.selfRadio.UseVisualStyleBackColor = true;
            this.selfRadio.CheckedChanged += new EventHandler(this.selfRadio_CheckedChanged);
            this.currRadio.AutoSize = true;
            this.currRadio.Location = new Point(17, 33);
            this.currRadio.Name = "currRadio";
            this.currRadio.Size = new Size(95, 16);
            this.currRadio.TabIndex = 0;
            this.currRadio.TabStop = true;
            this.currRadio.Text = "当前显示样式";
            this.currRadio.UseVisualStyleBackColor = true;
            this.button2.Location = new Point(237, 349);
            this.button2.Name = "button2";
            this.button2.Size = new Size(75, 23);
            this.button2.TabIndex = 4;
            this.button2.Text = "确认";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new EventHandler(this.button2_Click);
            this.autoWrap.AutoSize = true;
            this.autoWrap.Location = new Point(17, 30);
            this.autoWrap.Name = "autoWrap";
            this.autoWrap.Size = new Size(72, 16);
            this.autoWrap.TabIndex = 2;
            this.autoWrap.Text = "自动折行";
            this.autoWrap.UseVisualStyleBackColor = true;
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Controls.Add(this.AppendLineHeight);
            this.groupBox2.Controls.Add(this.autoWrap);
            this.groupBox2.Location = new Point(14, 202);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new Size(298, 114);
            this.groupBox2.TabIndex = 5;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "打印行高";
            this.AppendLineHeight.Location = new Point(90, 68);
            this.AppendLineHeight.Name = "AppendLineHeight";
            this.AppendLineHeight.Size = new Size(100, 21);
            this.AppendLineHeight.TabIndex = 3;
            this.label2.AutoSize = true;
            this.label2.Location = new Point(17, 77);
            this.label2.Name = "label2";
            this.label2.Size = new Size(53, 12);
            this.label2.TabIndex = 4;
            this.label2.Text = "附加行高";
            base.AutoScaleDimensions = new SizeF(6f, 12f);
            base.ClientSize = new Size(329, 384);
            base.Controls.Add(this.groupBox2);
            base.Controls.Add(this.button2);
            base.Controls.Add(this.groupBox1);
            base.Controls.Add(this.button1);
            base.Controls.Add(this.textBox1);
            base.Controls.Add(this.label1);
            base.Name = "PrintSetting";
            base.StartPosition = FormStartPosition.CenterParent;
            this.Text = "打印模板选择";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((ISupportInitialize)this.AppendLineHeight).EndInit();
            base.ResumeLayout(false);
            base.PerformLayout();
        }

        #endregion
    }
}