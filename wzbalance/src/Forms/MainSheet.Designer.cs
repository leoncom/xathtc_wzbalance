using Excel;
using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Runtime.Remoting.Messaging;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using wzbalance.Properties;

namespace wzbalance.src.Forms
{
    partial class MainSheet
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;
        private MenuStrip menuStrip1;
        private ToolStripMenuItem 表单ToolStripMenuItem;
        private ToolStripMenuItem 新建表单ToolStripMenuItem;
        private StatusStrip statusStrip1;
        private ToolStripStatusLabel toolStripStatusLabel1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button1;
        private ToolStripMenuItem 设置表单ToolStripMenuItem;
        private BindingSource bindingSource1;
        private System.Windows.Forms.Button button4;
        private ContextMenuStrip contextMenuStrip1;
        private ToolStripMenuItem 测试ToolStripMenuItem;
        private ToolStripMenuItem 表单ToolStripMenuItem1;
        private ToolStripMenuItem 导出ExcelToolStripMenuItem;
        private ToolStripMenuItem 打印ToolStripMenuItem;
        private ToolStripMenuItem 退出ToolStripMenuItem;
        private PrintPreviewDialog printPreviewDialog1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label buycontractlabel;
        private System.Windows.Forms.Label buymanlabel;
        private System.Windows.Forms.Label sellmanlabel;
        private System.Windows.Forms.Button button5;
        private System.Windows.Forms.Button button11;
        private ComboBox buycontract;
        private wzbalance.ComboBoxEx buyman;
        private ComboBoxEx sellman;
        private System.Windows.Forms.Button button10;
        private System.Windows.Forms.Button button8;
        private System.Windows.Forms.Button button7;
        private System.Windows.Forms.Button button6;
        private DateTimePicker startdate;
        private DateTimePicker enddate;
        private System.Windows.Forms.Button button12;
        private ToolStripMenuItem 关于BToolStripMenuItem;
        private ToolStripMenuItem 关于AToolStripMenuItem;
        private ToolStripMenuItem 每页显示个数ToolStripMenuItem;
        private ToolStripMenuItem toolStripMenuItem2;
        private ToolStripMenuItem toolStripMenuItem3;
        private ToolStripMenuItem toolStripMenuItem4;
        private ToolStripMenuItem toolStripMenuItem5;
        private System.Windows.Forms.Button button14;
        private System.Windows.Forms.Button button13;
        private System.Windows.Forms.Button button15;
        private System.Windows.Forms.GroupBox groupBox3;
        private ToolStripMenuItem toolStripMenuItem6;
        private ToolStripMenuItem toolStripMenuItem7;
        private ToolStripMenuItem 保存显示格式ToolStripMenuItem;
        private DataGridView dataGridView1;
        private System.Windows.Forms.Label cksjlabel;
        private ComboBox cksj;
        private System.Windows.Forms.Button button17;
        private ToolStripMenuItem 导出选中的行ToolStripMenuItem;
        private ToolStripMenuItem 工具TToolStripMenuItem;
        private ToolStripMenuItem 更新合同金额UToolStripMenuItem;
        private ToolStripMenuItem 设置字体ToolStripMenuItem;
        private ToolStripMenuItem 标题栏ToolStripMenuItem;
        private ToolStripMenuItem 内容ToolStripMenuItem;
        private ToolStripMenuItem 修正已出库合同CToolStripMenuItem;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.TextBox customKey;
        private ComboBox customSearch;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private ToolTip toolTip1;
        private ToolStripMenuItem 通讯录CToolStripMenuItem;
        private ToolStripMenuItem 新建联系人NToolStripMenuItem;
        private ToolStripMenuItem 管理通讯录MToolStripMenuItem;
        private ToolStripMenuItem 自定义个数ToolStripMenuItem;
        private ToolStripMenuItem 统计选中行的合计金额ToolStripMenuItem;
        private ToolStripMenuItem 管理MToolStripMenuItem;
        private ToolStripMenuItem 人员管理ToolStripMenuItem;
        private ToolStripMenuItem 用户管理MToolStripMenuItem;
        private ToolStripMenuItem 修改密码PToolStripMenuItem;
        private ToolStripMenuItem 恢复默认显示顺序ToolStripMenuItem;
        private System.Windows.Forms.Label label3;
        private ComboBox fpzt;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button button18;
        private ToolStripMenuItem 采购合同添加年份YToolStripMenuItem;
        private System.Windows.Forms.GroupBox groupBox5;
        private Panel panel1;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label9;
        private Panel panel3;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label10;
        private Panel panel5;
        private Panel panel4;
        private ToolStripMenuItem 检测更新UToolStripMenuItem;
        private ComboBox ysbs;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Button button19;
        private ToolStripMenuItem 修正交货期下拉列表ToolStripMenuItem;
        private ToolStripMenuItem 修正交货期日期格式FToolStripMenuItem;
        private ToolStripMenuItem toolStripMenuItem1;
        private ToolStripMenuItem 模板TToolStripMenuItem;
        private ToolStripMenuItem 添加新模板NToolStripMenuItem;
        private ToolStripMenuItem 编辑模板EToolStripMenuItem;
        private ToolStripMenuItem 打开帮助文档OToolStripMenuItem;
        private System.Windows.Forms.Button button16;
        private ToolStripMenuItem 删除模板DToolStripMenuItem;
        private ToolStripMenuItem 查找与替换TToolStripMenuItem;
        private ComboBox htdqzt;
        private System.Windows.Forms.Button button21;
        private System.Windows.Forms.Label label8;
        private ToolStripMenuItem 设置当前显示格式设置为默认ToolStripMenuItem;

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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.表单ToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.导出ExcelToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.打印ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.退出ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.表单ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.新建表单ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.设置表单ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.保存显示格式ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.恢复默认显示顺序ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.每页显示个数ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem6 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem7 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem2 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem3 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem4 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem5 = new System.Windows.Forms.ToolStripMenuItem();
            this.自定义个数ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.设置字体ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.标题栏ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.内容ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.设置当前显示格式设置为默认ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.通讯录CToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.新建联系人NToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.管理通讯录MToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.工具TToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.更新合同金额UToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.修正已出库合同CToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.修改密码PToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.采购合同添加年份YToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.修正交货期日期格式FToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.修正交货期下拉列表ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.查找与替换TToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.管理MToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.人员管理ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.用户管理MToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.模板TToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.添加新模板NToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.编辑模板EToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.删除模板DToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.关于BToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.打开帮助文档OToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.检测更新UToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.关于AToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.htdqzt = new System.Windows.Forms.ComboBox();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.customKey = new System.Windows.Forms.TextBox();
            this.customSearch = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.button16 = new System.Windows.Forms.Button();
            this.fpzt = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.ysbs = new System.Windows.Forms.ComboBox();
            this.label8 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.cksj = new System.Windows.Forms.ComboBox();
            this.cksjlabel = new System.Windows.Forms.Label();
            this.button11 = new System.Windows.Forms.Button();
            this.buycontract = new System.Windows.Forms.ComboBox();
            this.buyman = new wzbalance.ComboBoxEx();
            this.button18 = new System.Windows.Forms.Button();
            this.button19 = new System.Windows.Forms.Button();
            this.sellman = new wzbalance.ComboBoxEx();
            this.button21 = new System.Windows.Forms.Button();
            this.button17 = new System.Windows.Forms.Button();
            this.button10 = new System.Windows.Forms.Button();
            this.button8 = new System.Windows.Forms.Button();
            this.button7 = new System.Windows.Forms.Button();
            this.button6 = new System.Windows.Forms.Button();
            this.enddate = new System.Windows.Forms.DateTimePicker();
            this.button5 = new System.Windows.Forms.Button();
            this.startdate = new System.Windows.Forms.DateTimePicker();
            this.label2 = new System.Windows.Forms.Label();
            this.buycontractlabel = new System.Windows.Forms.Label();
            this.buymanlabel = new System.Windows.Forms.Label();
            this.sellmanlabel = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.label11 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.panel5 = new System.Windows.Forms.Panel();
            this.panel4 = new System.Windows.Forms.Panel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.label7 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.button14 = new System.Windows.Forms.Button();
            this.button13 = new System.Windows.Forms.Button();
            this.button12 = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.测试ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.导出选中的行ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.统计选中行的合计金额ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.printPreviewDialog1 = new System.Windows.Forms.PrintPreviewDialog();
            this.button15 = new System.Windows.Forms.Button();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.label3 = new System.Windows.Forms.Label();
            this.bindingSource1 = new System.Windows.Forms.BindingSource(this.components);
            this.menuStrip1.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox5.SuspendLayout();
            this.contextMenuStrip1.SuspendLayout();
            this.groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource1)).BeginInit();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.表单ToolStripMenuItem1,
            this.表单ToolStripMenuItem,
            this.通讯录CToolStripMenuItem,
            this.工具TToolStripMenuItem,
            this.管理MToolStripMenuItem,
            this.模板TToolStripMenuItem,
            this.关于BToolStripMenuItem,
            this.toolStripMenuItem1});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1098, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // 表单ToolStripMenuItem1
            // 
            this.表单ToolStripMenuItem1.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.导出ExcelToolStripMenuItem,
            this.打印ToolStripMenuItem,
            this.退出ToolStripMenuItem});
            this.表单ToolStripMenuItem1.Name = "表单ToolStripMenuItem1";
            this.表单ToolStripMenuItem1.Size = new System.Drawing.Size(59, 20);
            this.表单ToolStripMenuItem1.Text = "表单(&F)";
            // 
            // 导出ExcelToolStripMenuItem
            // 
            this.导出ExcelToolStripMenuItem.Name = "导出ExcelToolStripMenuItem";
            this.导出ExcelToolStripMenuItem.Size = new System.Drawing.Size(136, 22);
            this.导出ExcelToolStripMenuItem.Text = "导出为Excel";
            this.导出ExcelToolStripMenuItem.Click += new System.EventHandler(this.导出ExcelToolStripMenuItem_Click);
            // 
            // 打印ToolStripMenuItem
            // 
            this.打印ToolStripMenuItem.Name = "打印ToolStripMenuItem";
            this.打印ToolStripMenuItem.Size = new System.Drawing.Size(136, 22);
            this.打印ToolStripMenuItem.Text = "打印报表";
            this.打印ToolStripMenuItem.Click += new System.EventHandler(this.打印ToolStripMenuItem_Click);
            // 
            // 退出ToolStripMenuItem
            // 
            this.退出ToolStripMenuItem.Name = "退出ToolStripMenuItem";
            this.退出ToolStripMenuItem.Size = new System.Drawing.Size(136, 22);
            this.退出ToolStripMenuItem.Text = "退出";
            this.退出ToolStripMenuItem.Click += new System.EventHandler(this.退出ToolStripMenuItem_Click);
            // 
            // 表单ToolStripMenuItem
            // 
            this.表单ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.新建表单ToolStripMenuItem,
            this.设置表单ToolStripMenuItem,
            this.保存显示格式ToolStripMenuItem,
            this.恢复默认显示顺序ToolStripMenuItem,
            this.每页显示个数ToolStripMenuItem,
            this.设置字体ToolStripMenuItem,
            this.设置当前显示格式设置为默认ToolStripMenuItem});
            this.表单ToolStripMenuItem.Name = "表单ToolStripMenuItem";
            this.表单ToolStripMenuItem.Size = new System.Drawing.Size(59, 20);
            this.表单ToolStripMenuItem.Text = "设置(&S)";
            // 
            // 新建表单ToolStripMenuItem
            // 
            this.新建表单ToolStripMenuItem.Name = "新建表单ToolStripMenuItem";
            this.新建表单ToolStripMenuItem.Size = new System.Drawing.Size(178, 22);
            this.新建表单ToolStripMenuItem.Text = "编辑下拉列表";
            this.新建表单ToolStripMenuItem.Click += new System.EventHandler(this.新建表单ToolStripMenuItem_Click);
            // 
            // 设置表单ToolStripMenuItem
            // 
            this.设置表单ToolStripMenuItem.Name = "设置表单ToolStripMenuItem";
            this.设置表单ToolStripMenuItem.Size = new System.Drawing.Size(178, 22);
            this.设置表单ToolStripMenuItem.Text = "修改列名";
            this.设置表单ToolStripMenuItem.Click += new System.EventHandler(this.设置表单ToolStripMenuItem_Click);
            // 
            // 保存显示格式ToolStripMenuItem
            // 
            this.保存显示格式ToolStripMenuItem.Name = "保存显示格式ToolStripMenuItem";
            this.保存显示格式ToolStripMenuItem.Size = new System.Drawing.Size(178, 22);
            this.保存显示格式ToolStripMenuItem.Text = "保存显示格式";
            this.保存显示格式ToolStripMenuItem.Click += new System.EventHandler(this.保存显示格式ToolStripMenuItem_Click);
            // 
            // 恢复默认显示顺序ToolStripMenuItem
            // 
            this.恢复默认显示顺序ToolStripMenuItem.Name = "恢复默认显示顺序ToolStripMenuItem";
            this.恢复默认显示顺序ToolStripMenuItem.Size = new System.Drawing.Size(178, 22);
            this.恢复默认显示顺序ToolStripMenuItem.Text = "恢复默认显示顺序";
            this.恢复默认显示顺序ToolStripMenuItem.Click += new System.EventHandler(this.恢复默认显示顺序ToolStripMenuItem_Click);
            // 
            // 每页显示个数ToolStripMenuItem
            // 
            this.每页显示个数ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItem6,
            this.toolStripMenuItem7,
            this.toolStripMenuItem2,
            this.toolStripMenuItem3,
            this.toolStripMenuItem4,
            this.toolStripMenuItem5,
            this.自定义个数ToolStripMenuItem});
            this.每页显示个数ToolStripMenuItem.Name = "每页显示个数ToolStripMenuItem";
            this.每页显示个数ToolStripMenuItem.Size = new System.Drawing.Size(178, 22);
            this.每页显示个数ToolStripMenuItem.Text = "每页显示个数";
            // 
            // toolStripMenuItem6
            // 
            this.toolStripMenuItem6.Name = "toolStripMenuItem6";
            this.toolStripMenuItem6.Size = new System.Drawing.Size(130, 22);
            this.toolStripMenuItem6.Text = "15";
            this.toolStripMenuItem6.Click += new System.EventHandler(this.toolStripMenuItem6_Click);
            // 
            // toolStripMenuItem7
            // 
            this.toolStripMenuItem7.Name = "toolStripMenuItem7";
            this.toolStripMenuItem7.Size = new System.Drawing.Size(130, 22);
            this.toolStripMenuItem7.Text = "20";
            this.toolStripMenuItem7.Click += new System.EventHandler(this.toolStripMenuItem7_Click);
            // 
            // toolStripMenuItem2
            // 
            this.toolStripMenuItem2.Name = "toolStripMenuItem2";
            this.toolStripMenuItem2.Size = new System.Drawing.Size(130, 22);
            this.toolStripMenuItem2.Text = "30";
            this.toolStripMenuItem2.Click += new System.EventHandler(this.toolStripMenuItem2_Click);
            // 
            // toolStripMenuItem3
            // 
            this.toolStripMenuItem3.Name = "toolStripMenuItem3";
            this.toolStripMenuItem3.Size = new System.Drawing.Size(130, 22);
            this.toolStripMenuItem3.Text = "50";
            this.toolStripMenuItem3.Click += new System.EventHandler(this.toolStripMenuItem3_Click);
            // 
            // toolStripMenuItem4
            // 
            this.toolStripMenuItem4.Name = "toolStripMenuItem4";
            this.toolStripMenuItem4.Size = new System.Drawing.Size(130, 22);
            this.toolStripMenuItem4.Text = "100";
            this.toolStripMenuItem4.Click += new System.EventHandler(this.toolStripMenuItem4_Click);
            // 
            // toolStripMenuItem5
            // 
            this.toolStripMenuItem5.Name = "toolStripMenuItem5";
            this.toolStripMenuItem5.Size = new System.Drawing.Size(130, 22);
            this.toolStripMenuItem5.Text = "200";
            this.toolStripMenuItem5.Click += new System.EventHandler(this.toolStripMenuItem5_Click);
            // 
            // 自定义个数ToolStripMenuItem
            // 
            this.自定义个数ToolStripMenuItem.Name = "自定义个数ToolStripMenuItem";
            this.自定义个数ToolStripMenuItem.Size = new System.Drawing.Size(130, 22);
            this.自定义个数ToolStripMenuItem.Text = "自定义个数";
            this.自定义个数ToolStripMenuItem.Click += new System.EventHandler(this.自定义个数ToolStripMenuItem_Click);
            // 
            // 设置字体ToolStripMenuItem
            // 
            this.设置字体ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.标题栏ToolStripMenuItem,
            this.内容ToolStripMenuItem});
            this.设置字体ToolStripMenuItem.Name = "设置字体ToolStripMenuItem";
            this.设置字体ToolStripMenuItem.Size = new System.Drawing.Size(178, 22);
            this.设置字体ToolStripMenuItem.Text = "字体设置";
            // 
            // 标题栏ToolStripMenuItem
            // 
            this.标题栏ToolStripMenuItem.Name = "标题栏ToolStripMenuItem";
            this.标题栏ToolStripMenuItem.Size = new System.Drawing.Size(106, 22);
            this.标题栏ToolStripMenuItem.Text = "标题栏";
            this.标题栏ToolStripMenuItem.Click += new System.EventHandler(this.标题栏ToolStripMenuItem_Click);
            // 
            // 内容ToolStripMenuItem
            // 
            this.内容ToolStripMenuItem.Name = "内容ToolStripMenuItem";
            this.内容ToolStripMenuItem.Size = new System.Drawing.Size(106, 22);
            this.内容ToolStripMenuItem.Text = "内容";
            this.内容ToolStripMenuItem.Click += new System.EventHandler(this.内容ToolStripMenuItem_Click);
            // 
            // 设置当前显示格式设置为默认ToolStripMenuItem
            // 
            this.设置当前显示格式设置为默认ToolStripMenuItem.Name = "设置当前显示格式设置为默认ToolStripMenuItem";
            this.设置当前显示格式设置为默认ToolStripMenuItem.Size = new System.Drawing.Size(178, 22);
            this.设置当前显示格式设置为默认ToolStripMenuItem.Text = "设置当前列序为默认";
            this.设置当前显示格式设置为默认ToolStripMenuItem.Click += new System.EventHandler(this.设置当前显示格式设置为默认ToolStripMenuItem_Click);
            // 
            // 通讯录CToolStripMenuItem
            // 
            this.通讯录CToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.新建联系人NToolStripMenuItem,
            this.管理通讯录MToolStripMenuItem});
            this.通讯录CToolStripMenuItem.Name = "通讯录CToolStripMenuItem";
            this.通讯录CToolStripMenuItem.Size = new System.Drawing.Size(71, 20);
            this.通讯录CToolStripMenuItem.Text = "通讯录(&C)";
            // 
            // 新建联系人NToolStripMenuItem
            // 
            this.新建联系人NToolStripMenuItem.Name = "新建联系人NToolStripMenuItem";
            this.新建联系人NToolStripMenuItem.Size = new System.Drawing.Size(148, 22);
            this.新建联系人NToolStripMenuItem.Text = "新建联系人(&N)";
            this.新建联系人NToolStripMenuItem.Click += new System.EventHandler(this.新建联系人NToolStripMenuItem_Click);
            // 
            // 管理通讯录MToolStripMenuItem
            // 
            this.管理通讯录MToolStripMenuItem.Name = "管理通讯录MToolStripMenuItem";
            this.管理通讯录MToolStripMenuItem.Size = new System.Drawing.Size(148, 22);
            this.管理通讯录MToolStripMenuItem.Text = "管理通讯录(&M)";
            this.管理通讯录MToolStripMenuItem.Click += new System.EventHandler(this.管理通讯录MToolStripMenuItem_Click);
            // 
            // 工具TToolStripMenuItem
            // 
            this.工具TToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.更新合同金额UToolStripMenuItem,
            this.修正已出库合同CToolStripMenuItem,
            this.修改密码PToolStripMenuItem,
            this.采购合同添加年份YToolStripMenuItem,
            this.修正交货期日期格式FToolStripMenuItem,
            this.修正交货期下拉列表ToolStripMenuItem,
            this.查找与替换TToolStripMenuItem});
            this.工具TToolStripMenuItem.Name = "工具TToolStripMenuItem";
            this.工具TToolStripMenuItem.Size = new System.Drawing.Size(59, 20);
            this.工具TToolStripMenuItem.Text = "工具(&T)";
            // 
            // 更新合同金额UToolStripMenuItem
            // 
            this.更新合同金额UToolStripMenuItem.Name = "更新合同金额UToolStripMenuItem";
            this.更新合同金额UToolStripMenuItem.Size = new System.Drawing.Size(220, 22);
            this.更新合同金额UToolStripMenuItem.Text = "重新计算合同金额(&U)";
            this.更新合同金额UToolStripMenuItem.Click += new System.EventHandler(this.更新合同金额UToolStripMenuItem_Click_1);
            // 
            // 修正已出库合同CToolStripMenuItem
            // 
            this.修正已出库合同CToolStripMenuItem.Name = "修正已出库合同CToolStripMenuItem";
            this.修正已出库合同CToolStripMenuItem.Size = new System.Drawing.Size(220, 22);
            this.修正已出库合同CToolStripMenuItem.Text = "修正已出库合同(&C)";
            this.修正已出库合同CToolStripMenuItem.Click += new System.EventHandler(this.修正已出库合同CToolStripMenuItem_Click);
            // 
            // 修改密码PToolStripMenuItem
            // 
            this.修改密码PToolStripMenuItem.Name = "修改密码PToolStripMenuItem";
            this.修改密码PToolStripMenuItem.Size = new System.Drawing.Size(220, 22);
            this.修改密码PToolStripMenuItem.Text = "修改密码(&P)";
            this.修改密码PToolStripMenuItem.Click += new System.EventHandler(this.修改密码PToolStripMenuItem_Click);
            // 
            // 采购合同添加年份YToolStripMenuItem
            // 
            this.采购合同添加年份YToolStripMenuItem.Name = "采购合同添加年份YToolStripMenuItem";
            this.采购合同添加年份YToolStripMenuItem.Size = new System.Drawing.Size(220, 22);
            this.采购合同添加年份YToolStripMenuItem.Text = "修正采购合同月份格式(&Y)";
            this.采购合同添加年份YToolStripMenuItem.Click += new System.EventHandler(this.采购合同添加年份YToolStripMenuItem_Click);
            // 
            // 修正交货期日期格式FToolStripMenuItem
            // 
            this.修正交货期日期格式FToolStripMenuItem.Name = "修正交货期日期格式FToolStripMenuItem";
            this.修正交货期日期格式FToolStripMenuItem.Size = new System.Drawing.Size(220, 22);
            this.修正交货期日期格式FToolStripMenuItem.Text = "修正交货期日期格式(&F)";
            this.修正交货期日期格式FToolStripMenuItem.Click += new System.EventHandler(this.修正交货期日期格式FToolStripMenuItem_Click);
            // 
            // 修正交货期下拉列表ToolStripMenuItem
            // 
            this.修正交货期下拉列表ToolStripMenuItem.Name = "修正交货期下拉列表ToolStripMenuItem";
            this.修正交货期下拉列表ToolStripMenuItem.Size = new System.Drawing.Size(220, 22);
            this.修正交货期下拉列表ToolStripMenuItem.Text = "初始交货期下拉列表选项(&J)";
            this.修正交货期下拉列表ToolStripMenuItem.Click += new System.EventHandler(this.修正交货期下拉列表ToolStripMenuItem_Click);
            // 
            // 查找与替换TToolStripMenuItem
            // 
            this.查找与替换TToolStripMenuItem.Name = "查找与替换TToolStripMenuItem";
            this.查找与替换TToolStripMenuItem.Size = new System.Drawing.Size(220, 22);
            this.查找与替换TToolStripMenuItem.Text = "查找与替换(&T)";
            this.查找与替换TToolStripMenuItem.Click += new System.EventHandler(this.查找与替换TToolStripMenuItem_Click);
            // 
            // 管理MToolStripMenuItem
            // 
            this.管理MToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.人员管理ToolStripMenuItem,
            this.用户管理MToolStripMenuItem});
            this.管理MToolStripMenuItem.Name = "管理MToolStripMenuItem";
            this.管理MToolStripMenuItem.Size = new System.Drawing.Size(59, 20);
            this.管理MToolStripMenuItem.Text = "用户(&U)";
            // 
            // 人员管理ToolStripMenuItem
            // 
            this.人员管理ToolStripMenuItem.Name = "人员管理ToolStripMenuItem";
            this.人员管理ToolStripMenuItem.Size = new System.Drawing.Size(136, 22);
            this.人员管理ToolStripMenuItem.Text = "新建用户(&N)";
            this.人员管理ToolStripMenuItem.Click += new System.EventHandler(this.人员管理ToolStripMenuItem_Click);
            // 
            // 用户管理MToolStripMenuItem
            // 
            this.用户管理MToolStripMenuItem.Name = "用户管理MToolStripMenuItem";
            this.用户管理MToolStripMenuItem.Size = new System.Drawing.Size(136, 22);
            this.用户管理MToolStripMenuItem.Text = "用户管理(&M)";
            this.用户管理MToolStripMenuItem.Click += new System.EventHandler(this.用户管理MToolStripMenuItem_Click);
            // 
            // 模板TToolStripMenuItem
            // 
            this.模板TToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.添加新模板NToolStripMenuItem,
            this.编辑模板EToolStripMenuItem,
            this.删除模板DToolStripMenuItem});
            this.模板TToolStripMenuItem.Name = "模板TToolStripMenuItem";
            this.模板TToolStripMenuItem.Size = new System.Drawing.Size(59, 20);
            this.模板TToolStripMenuItem.Text = "模板(&T)";
            // 
            // 添加新模板NToolStripMenuItem
            // 
            this.添加新模板NToolStripMenuItem.Name = "添加新模板NToolStripMenuItem";
            this.添加新模板NToolStripMenuItem.Size = new System.Drawing.Size(148, 22);
            this.添加新模板NToolStripMenuItem.Text = "添加新模板(&N)";
            this.添加新模板NToolStripMenuItem.Click += new System.EventHandler(this.添加新模板NToolStripMenuItem_Click);
            // 
            // 编辑模板EToolStripMenuItem
            // 
            this.编辑模板EToolStripMenuItem.Name = "编辑模板EToolStripMenuItem";
            this.编辑模板EToolStripMenuItem.Size = new System.Drawing.Size(148, 22);
            this.编辑模板EToolStripMenuItem.Text = "编辑模板(&E)";
            this.编辑模板EToolStripMenuItem.Click += new System.EventHandler(this.编辑模板EToolStripMenuItem_Click);
            // 
            // 删除模板DToolStripMenuItem
            // 
            this.删除模板DToolStripMenuItem.Name = "删除模板DToolStripMenuItem";
            this.删除模板DToolStripMenuItem.Size = new System.Drawing.Size(148, 22);
            this.删除模板DToolStripMenuItem.Text = "删除模板(&D)";
            this.删除模板DToolStripMenuItem.Click += new System.EventHandler(this.删除模板DToolStripMenuItem_Click);
            // 
            // 关于BToolStripMenuItem
            // 
            this.关于BToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.打开帮助文档OToolStripMenuItem,
            this.检测更新UToolStripMenuItem,
            this.关于AToolStripMenuItem});
            this.关于BToolStripMenuItem.Name = "关于BToolStripMenuItem";
            this.关于BToolStripMenuItem.Size = new System.Drawing.Size(59, 20);
            this.关于BToolStripMenuItem.Text = "帮助(&H)";
            // 
            // 打开帮助文档OToolStripMenuItem
            // 
            this.打开帮助文档OToolStripMenuItem.Name = "打开帮助文档OToolStripMenuItem";
            this.打开帮助文档OToolStripMenuItem.Size = new System.Drawing.Size(160, 22);
            this.打开帮助文档OToolStripMenuItem.Text = "打开帮助文档(O)";
            this.打开帮助文档OToolStripMenuItem.Click += new System.EventHandler(this.打开帮助文档OToolStripMenuItem_Click);
            // 
            // 检测更新UToolStripMenuItem
            // 
            this.检测更新UToolStripMenuItem.Name = "检测更新UToolStripMenuItem";
            this.检测更新UToolStripMenuItem.Size = new System.Drawing.Size(160, 22);
            this.检测更新UToolStripMenuItem.Text = "检测更新(&U)";
            this.检测更新UToolStripMenuItem.Click += new System.EventHandler(this.检测更新UToolStripMenuItem_Click);
            // 
            // 关于AToolStripMenuItem
            // 
            this.关于AToolStripMenuItem.Name = "关于AToolStripMenuItem";
            this.关于AToolStripMenuItem.Size = new System.Drawing.Size(160, 22);
            this.关于AToolStripMenuItem.Text = "关于(&A)";
            this.关于AToolStripMenuItem.Click += new System.EventHandler(this.关于AToolStripMenuItem_Click);
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(12, 20);
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel1});
            this.statusStrip1.Location = new System.Drawing.Point(0, 756);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(1098, 22);
            this.statusStrip1.TabIndex = 1;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // toolStripStatusLabel1
            // 
            this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            this.toolStripStatusLabel1.Size = new System.Drawing.Size(113, 17);
            this.toolStripStatusLabel1.Text = "西安太航物资平衡表";
            // 
            // groupBox1
            // 
            this.groupBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.groupBox1.Controls.Add(this.htdqzt);
            this.groupBox1.Controls.Add(this.groupBox4);
            this.groupBox1.Controls.Add(this.fpzt);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.ysbs);
            this.groupBox1.Controls.Add(this.label8);
            this.groupBox1.Controls.Add(this.label12);
            this.groupBox1.Controls.Add(this.cksj);
            this.groupBox1.Controls.Add(this.cksjlabel);
            this.groupBox1.Controls.Add(this.button11);
            this.groupBox1.Controls.Add(this.buycontract);
            this.groupBox1.Controls.Add(this.buyman);
            this.groupBox1.Controls.Add(this.button18);
            this.groupBox1.Controls.Add(this.button19);
            this.groupBox1.Controls.Add(this.sellman);
            this.groupBox1.Controls.Add(this.button21);
            this.groupBox1.Controls.Add(this.button17);
            this.groupBox1.Controls.Add(this.button10);
            this.groupBox1.Controls.Add(this.button8);
            this.groupBox1.Controls.Add(this.button7);
            this.groupBox1.Controls.Add(this.button6);
            this.groupBox1.Controls.Add(this.enddate);
            this.groupBox1.Controls.Add(this.button5);
            this.groupBox1.Controls.Add(this.startdate);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.buycontractlabel);
            this.groupBox1.Controls.Add(this.buymanlabel);
            this.groupBox1.Controls.Add(this.sellmanlabel);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Left;
            this.groupBox1.Location = new System.Drawing.Point(0, 24);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(165, 732);
            this.groupBox1.TabIndex = 2;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "搜索";
            // 
            // htdqzt
            // 
            this.htdqzt.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.htdqzt.FormattingEnabled = true;
            this.htdqzt.Location = new System.Drawing.Point(12, 309);
            this.htdqzt.Name = "htdqzt";
            this.htdqzt.Size = new System.Drawing.Size(100, 20);
            this.htdqzt.TabIndex = 13;
            this.htdqzt.KeyDown += new System.Windows.Forms.KeyEventHandler(this.htdqzt_KeyDown);
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.customKey);
            this.groupBox4.Controls.Add(this.customSearch);
            this.groupBox4.Controls.Add(this.label5);
            this.groupBox4.Controls.Add(this.label4);
            this.groupBox4.Controls.Add(this.button16);
            this.groupBox4.Location = new System.Drawing.Point(8, 497);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(140, 146);
            this.groupBox4.TabIndex = 11;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "自定义条件";
            this.toolTip1.SetToolTip(this.groupBox4, "根据选择的列进行搜索");
            // 
            // customKey
            // 
            this.customKey.Location = new System.Drawing.Point(19, 92);
            this.customKey.Name = "customKey";
            this.customKey.Size = new System.Drawing.Size(100, 21);
            this.customKey.TabIndex = 15;
            // 
            // customSearch
            // 
            this.customSearch.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.customSearch.FormattingEnabled = true;
            this.customSearch.Location = new System.Drawing.Point(19, 46);
            this.customSearch.Name = "customSearch";
            this.customSearch.Size = new System.Drawing.Size(100, 20);
            this.customSearch.TabIndex = 14;
            this.customSearch.KeyDown += new System.Windows.Forms.KeyEventHandler(this.customSearch_KeyDown);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("宋体", 8.5F);
            this.label5.Location = new System.Drawing.Point(6, 77);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(41, 12);
            this.label5.TabIndex = 13;
            this.label5.Text = "关键字";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("宋体", 8.5F);
            this.label4.Location = new System.Drawing.Point(6, 31);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(53, 12);
            this.label4.TabIndex = 12;
            this.label4.Text = "搜索列名";
            // 
            // button16
            // 
            this.button16.BackgroundImage = global::wzbalance.Properties.Resources.search;
            this.button16.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.button16.Location = new System.Drawing.Point(113, 119);
            this.button16.Name = "button16";
            this.button16.Size = new System.Drawing.Size(21, 21);
            this.button16.TabIndex = 11;
            this.button16.UseVisualStyleBackColor = true;
            this.button16.Click += new System.EventHandler(this.button16_Click_1);
            // 
            // fpzt
            // 
            this.fpzt.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.fpzt.FormattingEnabled = true;
            this.fpzt.Location = new System.Drawing.Point(12, 467);
            this.fpzt.Name = "fpzt";
            this.fpzt.Size = new System.Drawing.Size(100, 20);
            this.fpzt.TabIndex = 8;
            this.fpzt.KeyDown += new System.Windows.Forms.KeyEventHandler(this.fpzt_KeyDown);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(10, 447);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(53, 12);
            this.label6.TabIndex = 7;
            this.label6.Text = "发票状态";
            // 
            // ysbs
            // 
            this.ysbs.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.ysbs.FormattingEnabled = true;
            this.ysbs.Location = new System.Drawing.Point(12, 415);
            this.ysbs.Name = "ysbs";
            this.ysbs.Size = new System.Drawing.Size(100, 20);
            this.ysbs.TabIndex = 8;
            this.ysbs.DrawItem += new System.Windows.Forms.DrawItemEventHandler(this.ysbs_DrawItem);
            this.ysbs.MeasureItem += new System.Windows.Forms.MeasureItemEventHandler(this.ysbs_MeasureItem);
            this.ysbs.KeyDown += new System.Windows.Forms.KeyEventHandler(this.ysbs_KeyDown);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(10, 283);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(77, 12);
            this.label8.TabIndex = 7;
            this.label8.Text = "合同到期状态";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(10, 391);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(53, 12);
            this.label12.TabIndex = 7;
            this.label12.Text = "颜色标识";
            // 
            // cksj
            // 
            this.cksj.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cksj.FormattingEnabled = true;
            this.cksj.Location = new System.Drawing.Point(12, 357);
            this.cksj.Name = "cksj";
            this.cksj.Size = new System.Drawing.Size(100, 20);
            this.cksj.TabIndex = 8;
            this.cksj.KeyDown += new System.Windows.Forms.KeyEventHandler(this.cksj_KeyDown);
            // 
            // cksjlabel
            // 
            this.cksjlabel.AutoSize = true;
            this.cksjlabel.Location = new System.Drawing.Point(10, 340);
            this.cksjlabel.Name = "cksjlabel";
            this.cksjlabel.Size = new System.Drawing.Size(65, 12);
            this.cksjlabel.TabIndex = 7;
            this.cksjlabel.Text = "出入库状态";
            // 
            // button11
            // 
            this.button11.Location = new System.Drawing.Point(37, 660);
            this.button11.Name = "button11";
            this.button11.Size = new System.Drawing.Size(75, 23);
            this.button11.TabIndex = 5;
            this.button11.Text = "搜索";
            this.button11.UseVisualStyleBackColor = true;
            this.button11.Click += new System.EventHandler(this.button11_Click);
            // 
            // buycontract
            // 
            this.buycontract.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.buycontract.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.buycontract.FormattingEnabled = true;
            this.buycontract.Location = new System.Drawing.Point(12, 249);
            this.buycontract.Name = "buycontract";
            this.buycontract.Size = new System.Drawing.Size(100, 20);
            this.buycontract.TabIndex = 4;
            this.buycontract.KeyDown += new System.Windows.Forms.KeyEventHandler(this.buycontract_KeyDown);
            // 
            // buyman
            // 
            this.buyman.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.buyman.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource;
            this.buyman.FormattingEnabled = true;
            this.buyman.Location = new System.Drawing.Point(12, 194);
            this.buyman.Name = "buyman";
            this.buyman.Size = new System.Drawing.Size(100, 20);
            this.buyman.TabIndex = 4;
            // 
            // button18
            // 
            this.button18.BackgroundImage = global::wzbalance.Properties.Resources.search;
            this.button18.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.button18.Location = new System.Drawing.Point(127, 467);
            this.button18.Name = "button18";
            this.button18.Size = new System.Drawing.Size(21, 21);
            this.button18.TabIndex = 3;
            this.button18.UseVisualStyleBackColor = true;
            this.button18.Click += new System.EventHandler(this.button18_Click);
            // 
            // button19
            // 
            this.button19.BackgroundImage = global::wzbalance.Properties.Resources.search;
            this.button19.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.button19.Location = new System.Drawing.Point(127, 414);
            this.button19.Name = "button19";
            this.button19.Size = new System.Drawing.Size(21, 21);
            this.button19.TabIndex = 3;
            this.button19.UseVisualStyleBackColor = true;
            this.button19.Click += new System.EventHandler(this.button19_Click);
            // 
            // sellman
            // 
            this.sellman.FormattingEnabled = true;
            this.sellman.Location = new System.Drawing.Point(12, 143);
            this.sellman.Name = "sellman";
            this.sellman.Size = new System.Drawing.Size(100, 20);
            this.sellman.TabIndex = 4;
            // 
            // button21
            // 
            this.button21.BackgroundImage = global::wzbalance.Properties.Resources.search;
            this.button21.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.button21.Location = new System.Drawing.Point(126, 309);
            this.button21.Name = "button21";
            this.button21.Size = new System.Drawing.Size(21, 21);
            this.button21.TabIndex = 3;
            this.button21.UseVisualStyleBackColor = true;
            this.button21.Click += new System.EventHandler(this.button21_Click);
            // 
            // button17
            // 
            this.button17.BackgroundImage = global::wzbalance.Properties.Resources.search;
            this.button17.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.button17.Location = new System.Drawing.Point(127, 356);
            this.button17.Name = "button17";
            this.button17.Size = new System.Drawing.Size(21, 21);
            this.button17.TabIndex = 3;
            this.button17.UseVisualStyleBackColor = true;
            this.button17.Click += new System.EventHandler(this.button17_Click);
            // 
            // button10
            // 
            this.button10.BackgroundImage = global::wzbalance.Properties.Resources.search;
            this.button10.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.button10.Location = new System.Drawing.Point(127, 249);
            this.button10.Name = "button10";
            this.button10.Size = new System.Drawing.Size(21, 21);
            this.button10.TabIndex = 3;
            this.button10.UseVisualStyleBackColor = true;
            this.button10.Click += new System.EventHandler(this.button10_Click);
            // 
            // button8
            // 
            this.button8.BackgroundImage = global::wzbalance.Properties.Resources.search;
            this.button8.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.button8.Location = new System.Drawing.Point(127, 194);
            this.button8.Name = "button8";
            this.button8.Size = new System.Drawing.Size(21, 21);
            this.button8.TabIndex = 3;
            this.button8.UseVisualStyleBackColor = true;
            this.button8.Click += new System.EventHandler(this.button8_Click);
            // 
            // button7
            // 
            this.button7.BackgroundImage = global::wzbalance.Properties.Resources.search;
            this.button7.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.button7.Location = new System.Drawing.Point(127, 141);
            this.button7.Name = "button7";
            this.button7.Size = new System.Drawing.Size(21, 21);
            this.button7.TabIndex = 3;
            this.button7.UseVisualStyleBackColor = true;
            this.button7.Click += new System.EventHandler(this.button7_Click);
            // 
            // button6
            // 
            this.button6.BackgroundImage = global::wzbalance.Properties.Resources.search;
            this.button6.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.button6.Location = new System.Drawing.Point(127, 91);
            this.button6.Name = "button6";
            this.button6.Size = new System.Drawing.Size(21, 21);
            this.button6.TabIndex = 3;
            this.button6.UseVisualStyleBackColor = true;
            this.button6.Click += new System.EventHandler(this.button6_Click);
            // 
            // enddate
            // 
            this.enddate.Checked = false;
            this.enddate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.enddate.Location = new System.Drawing.Point(12, 91);
            this.enddate.Name = "enddate";
            this.enddate.ShowCheckBox = true;
            this.enddate.Size = new System.Drawing.Size(100, 21);
            this.enddate.TabIndex = 2;
            // 
            // button5
            // 
            this.button5.BackgroundImage = global::wzbalance.Properties.Resources.search;
            this.button5.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.button5.Location = new System.Drawing.Point(127, 38);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(21, 21);
            this.button5.TabIndex = 3;
            this.button5.UseVisualStyleBackColor = true;
            this.button5.Click += new System.EventHandler(this.button5_Click);
            // 
            // startdate
            // 
            this.startdate.Checked = false;
            this.startdate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.startdate.Location = new System.Drawing.Point(12, 38);
            this.startdate.Name = "startdate";
            this.startdate.ShowCheckBox = true;
            this.startdate.Size = new System.Drawing.Size(100, 21);
            this.startdate.TabIndex = 2;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(10, 70);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(53, 12);
            this.label2.TabIndex = 1;
            this.label2.Text = "结束时间";
            // 
            // buycontractlabel
            // 
            this.buycontractlabel.AutoSize = true;
            this.buycontractlabel.Location = new System.Drawing.Point(10, 227);
            this.buycontractlabel.Name = "buycontractlabel";
            this.buycontractlabel.Size = new System.Drawing.Size(77, 12);
            this.buycontractlabel.TabIndex = 0;
            this.buycontractlabel.Text = "采购合同状态";
            // 
            // buymanlabel
            // 
            this.buymanlabel.AutoSize = true;
            this.buymanlabel.Location = new System.Drawing.Point(10, 173);
            this.buymanlabel.Name = "buymanlabel";
            this.buymanlabel.Size = new System.Drawing.Size(53, 12);
            this.buymanlabel.TabIndex = 0;
            this.buymanlabel.Text = "供方单位";
            // 
            // sellmanlabel
            // 
            this.sellmanlabel.AutoSize = true;
            this.sellmanlabel.Location = new System.Drawing.Point(10, 123);
            this.sellmanlabel.Name = "sellmanlabel";
            this.sellmanlabel.Size = new System.Drawing.Size(53, 12);
            this.sellmanlabel.TabIndex = 0;
            this.sellmanlabel.Text = "需方单位";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(10, 18);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(53, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "开始时间";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.groupBox5);
            this.groupBox2.Controls.Add(this.button14);
            this.groupBox2.Controls.Add(this.button13);
            this.groupBox2.Controls.Add(this.button12);
            this.groupBox2.Controls.Add(this.button4);
            this.groupBox2.Controls.Add(this.button3);
            this.groupBox2.Controls.Add(this.button2);
            this.groupBox2.Controls.Add(this.button1);
            this.groupBox2.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox2.Location = new System.Drawing.Point(186, 24);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(912, 70);
            this.groupBox2.TabIndex = 3;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "工具";
            // 
            // groupBox5
            // 
            this.groupBox5.Controls.Add(this.label11);
            this.groupBox5.Controls.Add(this.label10);
            this.groupBox5.Controls.Add(this.label9);
            this.groupBox5.Controls.Add(this.panel5);
            this.groupBox5.Controls.Add(this.panel4);
            this.groupBox5.Controls.Add(this.panel3);
            this.groupBox5.Controls.Add(this.label7);
            this.groupBox5.Controls.Add(this.panel1);
            this.groupBox5.Location = new System.Drawing.Point(288, 13);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(367, 46);
            this.groupBox5.TabIndex = 6;
            this.groupBox5.TabStop = false;
            this.groupBox5.Text = "颜色标识说明";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(272, 23);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(77, 12);
            this.label11.TabIndex = 1;
            this.label11.Text = "采购合同已订";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(33, 23);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(41, 12);
            this.label10.TabIndex = 1;
            this.label10.Text = "已出库";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(101, 23);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(41, 12);
            this.label9.TabIndex = 1;
            this.label9.Text = "待出库";
            // 
            // panel5
            // 
            this.panel5.BackColor = System.Drawing.Color.White;
            this.panel5.Location = new System.Drawing.Point(251, 22);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(15, 15);
            this.panel5.TabIndex = 0;
            // 
            // panel4
            // 
            this.panel4.BackColor = System.Drawing.Color.LightBlue;
            this.panel4.Location = new System.Drawing.Point(12, 22);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(15, 15);
            this.panel4.TabIndex = 0;
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.Red;
            this.panel3.Location = new System.Drawing.Point(80, 22);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(15, 15);
            this.panel3.TabIndex = 0;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(168, 23);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(77, 12);
            this.label7.TabIndex = 1;
            this.label7.Text = "采购合同未订";
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Yellow;
            this.panel1.Location = new System.Drawing.Point(148, 22);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(15, 15);
            this.panel1.TabIndex = 0;
            // 
            // button14
            // 
            this.button14.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.button14.Location = new System.Drawing.Point(747, 25);
            this.button14.Name = "button14";
            this.button14.Size = new System.Drawing.Size(63, 28);
            this.button14.TabIndex = 5;
            this.button14.Text = "下  页";
            this.toolTip1.SetToolTip(this.button14, "下一页记录");
            this.button14.UseVisualStyleBackColor = true;
            this.button14.Click += new System.EventHandler(this.button14_Click);
            // 
            // button13
            // 
            this.button13.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.button13.Location = new System.Drawing.Point(684, 25);
            this.button13.Name = "button13";
            this.button13.Size = new System.Drawing.Size(57, 28);
            this.button13.TabIndex = 5;
            this.button13.Text = "上  页";
            this.toolTip1.SetToolTip(this.button13, "上一页记录");
            this.button13.UseVisualStyleBackColor = true;
            this.button13.Click += new System.EventHandler(this.button13_Click);
            // 
            // button12
            // 
            this.button12.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.button12.Location = new System.Drawing.Point(816, 25);
            this.button12.Name = "button12";
            this.button12.Size = new System.Drawing.Size(90, 28);
            this.button12.TabIndex = 1;
            this.button12.Text = "显示全部记录";
            this.toolTip1.SetToolTip(this.button12, "重新显示当前页所有记录");
            this.button12.UseVisualStyleBackColor = true;
            this.button12.Click += new System.EventHandler(this.button12_Click);
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(217, 26);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(65, 28);
            this.button4.TabIndex = 0;
            this.button4.Text = "删除记录";
            this.toolTip1.SetToolTip(this.button4, "删除选中行");
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(146, 26);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(65, 28);
            this.button3.TabIndex = 0;
            this.button3.Text = "编辑记录";
            this.toolTip1.SetToolTip(this.button3, "编辑当前选中行或者当前选中表格单元所在行的记录");
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(75, 26);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(65, 28);
            this.button2.TabIndex = 0;
            this.button2.Text = "添加记录";
            this.toolTip1.SetToolTip(this.button2, "添加一条新记录");
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(4, 26);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(65, 28);
            this.button1.TabIndex = 0;
            this.button1.Text = "表头设置";
            this.toolTip1.SetToolTip(this.button1, "设置显示的列");
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.测试ToolStripMenuItem,
            this.导出选中的行ToolStripMenuItem,
            this.统计选中行的合计金额ToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(173, 70);
            // 
            // 测试ToolStripMenuItem
            // 
            this.测试ToolStripMenuItem.Name = "测试ToolStripMenuItem";
            this.测试ToolStripMenuItem.Size = new System.Drawing.Size(172, 22);
            this.测试ToolStripMenuItem.Text = "打印选中行";
            this.测试ToolStripMenuItem.Click += new System.EventHandler(this.测试ToolStripMenuItem_Click);
            // 
            // 导出选中的行ToolStripMenuItem
            // 
            this.导出选中的行ToolStripMenuItem.Name = "导出选中的行ToolStripMenuItem";
            this.导出选中的行ToolStripMenuItem.Size = new System.Drawing.Size(172, 22);
            this.导出选中的行ToolStripMenuItem.Text = "导出选中行至Excel";
            this.导出选中的行ToolStripMenuItem.Click += new System.EventHandler(this.导出选中的行ToolStripMenuItem_Click);
            // 
            // 统计选中行的合计金额ToolStripMenuItem
            // 
            this.统计选中行的合计金额ToolStripMenuItem.Name = "统计选中行的合计金额ToolStripMenuItem";
            this.统计选中行的合计金额ToolStripMenuItem.Size = new System.Drawing.Size(172, 22);
            this.统计选中行的合计金额ToolStripMenuItem.Text = "合计选中行的金额";
            this.统计选中行的合计金额ToolStripMenuItem.Click += new System.EventHandler(this.统计选中行的合计金额ToolStripMenuItem_Click);
            // 
            // printPreviewDialog1
            // 
            this.printPreviewDialog1.AutoScrollMargin = new System.Drawing.Size(0, 0);
            this.printPreviewDialog1.AutoScrollMinSize = new System.Drawing.Size(0, 0);
            this.printPreviewDialog1.ClientSize = new System.Drawing.Size(400, 300);
            this.printPreviewDialog1.Enabled = true;
            this.printPreviewDialog1.Icon = global::wzbalance.Properties.Resources.printPreviewDialog1;
            this.printPreviewDialog1.Name = "printPreviewDialog1";
            this.printPreviewDialog1.Visible = false;
            // 
            // button15
            // 
            this.button15.Dock = System.Windows.Forms.DockStyle.Fill;
            this.button15.Location = new System.Drawing.Point(3, 17);
            this.button15.Name = "button15";
            this.button15.Size = new System.Drawing.Size(15, 712);
            this.button15.TabIndex = 0;
            this.button15.Text = "<";
            this.button15.UseVisualStyleBackColor = true;
            this.button15.Click += new System.EventHandler(this.button15_Click);
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.button15);
            this.groupBox3.Dock = System.Windows.Forms.DockStyle.Left;
            this.groupBox3.Location = new System.Drawing.Point(165, 24);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(21, 732);
            this.groupBox3.TabIndex = 8;
            this.groupBox3.TabStop = false;
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToOrderColumns = true;
            this.dataGridView1.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.DisplayedCellsExceptHeaders;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridView1.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.ContextMenuStrip = this.contextMenuStrip1;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridView1.DefaultCellStyle = dataGridViewCellStyle2;
            this.dataGridView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView1.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.dataGridView1.Location = new System.Drawing.Point(186, 94);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Sunken;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle3.Format = "N0";
            dataGridViewCellStyle3.NullValue = null;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridView1.RowHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.dataGridView1.RowHeadersWidth = 45;
            this.dataGridView1.RowTemplate.Height = 23;
            this.dataGridView1.RowTemplate.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridView1.Size = new System.Drawing.Size(912, 662);
            this.dataGridView1.TabIndex = 10;
            this.dataGridView1.Sorted += new System.EventHandler(this.dataGridView1_Sorted);
            this.dataGridView1.RowPostPaint += new System.Windows.Forms.DataGridViewRowPostPaintEventHandler(this.dataGridView1_RowPostPaint);
            this.dataGridView1.CellMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dataGridView1_CellMouseClick);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label3.ForeColor = System.Drawing.Color.Red;
            this.label3.Location = new System.Drawing.Point(374, 292);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(56, 16);
            this.label3.TabIndex = 11;
            this.label3.Text = "label3";
            // 
            // MainSheet
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1098, 778);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "MainSheet";
            this.Text = "物资平衡表管理";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.MainSheet_FormClosed);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox5.ResumeLayout(false);
            this.groupBox5.PerformLayout();
            this.contextMenuStrip1.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
    }
}