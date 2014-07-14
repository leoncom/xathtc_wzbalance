namespace wzbalance.src.Forms
{
    partial class ContractRulesMgr
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
            this.ruleslistBox = new System.Windows.Forms.ListBox();
            this.edit_button = new System.Windows.Forms.Button();
            this.new_button = new System.Windows.Forms.Button();
            this.delete_button = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // ruleslistBox
            // 
            this.ruleslistBox.FormattingEnabled = true;
            this.ruleslistBox.ItemHeight = 12;
            this.ruleslistBox.Location = new System.Drawing.Point(23, 21);
            this.ruleslistBox.Name = "ruleslistBox";
            this.ruleslistBox.ScrollAlwaysVisible = true;
            this.ruleslistBox.Size = new System.Drawing.Size(169, 124);
            this.ruleslistBox.TabIndex = 1;
            // 
            // edit_button
            // 
            this.edit_button.Location = new System.Drawing.Point(206, 69);
            this.edit_button.Name = "edit_button";
            this.edit_button.Size = new System.Drawing.Size(75, 23);
            this.edit_button.TabIndex = 2;
            this.edit_button.Text = "编辑";
            this.edit_button.UseVisualStyleBackColor = true;
            this.edit_button.Click += new System.EventHandler(this.button1_Click);
            // 
            // new_button
            // 
            this.new_button.Location = new System.Drawing.Point(206, 21);
            this.new_button.Name = "new_button";
            this.new_button.Size = new System.Drawing.Size(75, 23);
            this.new_button.TabIndex = 2;
            this.new_button.Text = "新建";
            this.new_button.UseVisualStyleBackColor = true;
            this.new_button.Click += new System.EventHandler(this.new_button_Click);
            // 
            // delete_button
            // 
            this.delete_button.Location = new System.Drawing.Point(206, 122);
            this.delete_button.Name = "delete_button";
            this.delete_button.Size = new System.Drawing.Size(75, 23);
            this.delete_button.TabIndex = 2;
            this.delete_button.Text = "删除";
            this.delete_button.UseVisualStyleBackColor = true;
            this.delete_button.Click += new System.EventHandler(this.delete_button_Click);
            // 
            // ContractRulesMgr
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(293, 171);
            this.Controls.Add(this.new_button);
            this.Controls.Add(this.delete_button);
            this.Controls.Add(this.edit_button);
            this.Controls.Add(this.ruleslistBox);
            this.Name = "ContractRulesMgr";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "合同填写规则管理";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListBox ruleslistBox;
        private System.Windows.Forms.Button edit_button;
        private System.Windows.Forms.Button new_button;
        private System.Windows.Forms.Button delete_button;

    }
}