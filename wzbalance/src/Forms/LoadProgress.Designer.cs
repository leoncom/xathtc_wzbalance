using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace wzbalance.src.Forms
{
    partial class LoadProgress
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;
        private ProgressBar progressBar1;

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
            this.progressBar1 = new ProgressBar();
            base.SuspendLayout();
            this.progressBar1.Location = new Point(-1, -1);
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new Size(171, 23);
            this.progressBar1.TabIndex = 0;
            base.AutoScaleDimensions = new SizeF(6f, 12f);
            base.ClientSize = new Size(168, 21);
            base.Controls.Add(this.progressBar1);
            base.MaximizeBox = false;
            base.MinimizeBox = false;
            base.Name = "LoadProgress";
            base.StartPosition = FormStartPosition.CenterParent;
            this.Text = "数据读取中";
            base.ResumeLayout(false);
        }

        #endregion
    }
}