namespace wzbalance.src.Forms
{
    partial class AddContractFillRule
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

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
            this.label1 = new System.Windows.Forms.Label();
            this.rulename_textbox = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.key_comboBox = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.column_checkedListBox = new System.Windows.Forms.CheckedListBox();
            this.cancel_button = new System.Windows.Forms.Button();
            this.save_button = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(21, 25);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(53, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "规则名称";
            // 
            // rulename_textbox
            // 
            this.rulename_textbox.Location = new System.Drawing.Point(115, 16);
            this.rulename_textbox.Name = "rulename_textbox";
            this.rulename_textbox.Size = new System.Drawing.Size(110, 21);
            this.rulename_textbox.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(21, 79);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(77, 12);
            this.label2.TabIndex = 0;
            this.label2.Text = "规则触发字段";
            // 
            // key_comboBox
            // 
            this.key_comboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.key_comboBox.FormattingEnabled = true;
            this.key_comboBox.Location = new System.Drawing.Point(115, 71);
            this.key_comboBox.Name = "key_comboBox";
            this.key_comboBox.Size = new System.Drawing.Size(110, 20);
            this.key_comboBox.TabIndex = 2;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(21, 122);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(149, 12);
            this.label3.TabIndex = 0;
            this.label3.Text = "关联非空字段(录入时检查)";
            // 
            // column_checkedListBox
            // 
            this.column_checkedListBox.FormattingEnabled = true;
            this.column_checkedListBox.Location = new System.Drawing.Point(23, 147);
            this.column_checkedListBox.Name = "column_checkedListBox";
            this.column_checkedListBox.Size = new System.Drawing.Size(202, 116);
            this.column_checkedListBox.TabIndex = 3;
            // 
            // cancel_button
            // 
            this.cancel_button.Location = new System.Drawing.Point(23, 293);
            this.cancel_button.Name = "cancel_button";
            this.cancel_button.Size = new System.Drawing.Size(75, 23);
            this.cancel_button.TabIndex = 4;
            this.cancel_button.Text = "取消";
            this.cancel_button.UseVisualStyleBackColor = true;
            this.cancel_button.Click += new System.EventHandler(this.button1_Click);
            // 
            // save_button
            // 
            this.save_button.Location = new System.Drawing.Point(150, 293);
            this.save_button.Name = "save_button";
            this.save_button.Size = new System.Drawing.Size(75, 23);
            this.save_button.TabIndex = 4;
            this.save_button.Text = "保存";
            this.save_button.UseVisualStyleBackColor = true;
            this.save_button.Click += new System.EventHandler(this.save_button_Click);
            // 
            // AddContractFillRule
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(248, 339);
            this.Controls.Add(this.save_button);
            this.Controls.Add(this.cancel_button);
            this.Controls.Add(this.column_checkedListBox);
            this.Controls.Add(this.key_comboBox);
            this.Controls.Add(this.rulename_textbox);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "AddContractFillRule";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "新建合同录入规则";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox rulename_textbox;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox key_comboBox;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.CheckedListBox column_checkedListBox;
        private System.Windows.Forms.Button cancel_button;
        private System.Windows.Forms.Button save_button;
    }
}