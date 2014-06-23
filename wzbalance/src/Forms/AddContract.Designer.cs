using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace wzbalance.src.Forms
{
    partial class AddContract
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;
        private Button button1;
        private Button button2;
        private ContextMenuStrip contextMenuStrip1;
        private ToolStripMenuItem 修改ToolStripMenuItem;
        private ToolStripMenuItem 删除ToolStripMenuItem;
        private ToolStripMenuItem 添加ToolStripMenuItem;
        private Label label1;
        private Label thhtbhlabel;
        private Label pinminglabel;
        private Label sellfapiaolabel;
        private Label paihaolabel;
        private Label guigelabel;
        private Label rkrqlabel;
        private Label jstjlabel;
        private Label sellnumlabel;
        private Label selldatelabel;
        private Label rkgglabel;
        private Label locationlabel;
        private Label buypricelabel;
        private Label sellmanlabel;
        private Label jhztlabel;
        private Label buymanlabel;
        private Label pricewithtaxlabel;
        private Label kucunlabel;
        private Label rkllabel;
        private Label jindulabel;
        private Label cksjlabel;
        private Label sellcontractlabel;
        private Label buycontractlabel;
        private Label buyfapiaolabel;
        private Label fxrqlabel;
        private Label yffplabel;
        private DateTimePicker cksj;
        private DateTimePicker sellfapiao;
        private DateTimePicker buyfapiao;
        private ComboBox kucun;
        private DateTimePicker fxrq;
        private DateTimePicker rkrq;
        private ComboBox buycontract;
        private ComboBox jindu;
        private ComboBox yffp;
        private ComboBoxEx sellman;
        private ComboBoxEx pinming;
        private ComboBoxEx buyman;
        private ComboBoxEx location;
        private ComboBoxEx jhzt;
        private ComboBox paihao;
        private ComboBox jstj;
        private ComboBox selldate;
        private TextBox sellnum;
        private TextBox guige;
        private TextBox pricewithtax;
        private TextBox rkgg;
        private TextBox rkl;
        private TextBox buyprice;
        private TextBox ckl;
        private TextBox sellcontract;
        private Label bzlabel;
        private TextBox bz;
        private Label ckllabel;
        private GroupBox groupBox1;
        private TextBox planprice;
        private Label planpricelabel;
        private GroupBox groupBox2;
        private GroupBox groupBox3;
        private GroupBox groupBox4;
        private GroupBox groupBox5;
        private TextBox thhtbh;
        private Label rkdbhlabel;
        private TextBox rkdbh;
        private Label ckdbhlabel;
        private TextBox ckdbh;
        private Label zlyylabel;
        private TextBox zlyy;
        private ComboBox luhao;
        private Label luhaolabel;

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
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.添加ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.修改ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.删除ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.thhtbhlabel = new System.Windows.Forms.Label();
            this.pinminglabel = new System.Windows.Forms.Label();
            this.sellfapiaolabel = new System.Windows.Forms.Label();
            this.paihaolabel = new System.Windows.Forms.Label();
            this.guigelabel = new System.Windows.Forms.Label();
            this.rkrqlabel = new System.Windows.Forms.Label();
            this.jstjlabel = new System.Windows.Forms.Label();
            this.sellnumlabel = new System.Windows.Forms.Label();
            this.selldatelabel = new System.Windows.Forms.Label();
            this.rkgglabel = new System.Windows.Forms.Label();
            this.locationlabel = new System.Windows.Forms.Label();
            this.buypricelabel = new System.Windows.Forms.Label();
            this.sellmanlabel = new System.Windows.Forms.Label();
            this.jhztlabel = new System.Windows.Forms.Label();
            this.buymanlabel = new System.Windows.Forms.Label();
            this.pricewithtaxlabel = new System.Windows.Forms.Label();
            this.kucunlabel = new System.Windows.Forms.Label();
            this.rkllabel = new System.Windows.Forms.Label();
            this.jindulabel = new System.Windows.Forms.Label();
            this.cksjlabel = new System.Windows.Forms.Label();
            this.sellcontractlabel = new System.Windows.Forms.Label();
            this.buycontractlabel = new System.Windows.Forms.Label();
            this.buyfapiaolabel = new System.Windows.Forms.Label();
            this.fxrqlabel = new System.Windows.Forms.Label();
            this.yffplabel = new System.Windows.Forms.Label();
            this.cksj = new System.Windows.Forms.DateTimePicker();
            this.sellfapiao = new System.Windows.Forms.DateTimePicker();
            this.buyfapiao = new System.Windows.Forms.DateTimePicker();
            this.kucun = new System.Windows.Forms.ComboBox();
            this.fxrq = new System.Windows.Forms.DateTimePicker();
            this.rkrq = new System.Windows.Forms.DateTimePicker();
            this.buycontract = new System.Windows.Forms.ComboBox();
            this.jindu = new System.Windows.Forms.ComboBox();
            this.yffp = new System.Windows.Forms.ComboBox();
            this.paihao = new System.Windows.Forms.ComboBox();
            this.jstj = new System.Windows.Forms.ComboBox();
            this.selldate = new System.Windows.Forms.ComboBox();
            this.sellnum = new System.Windows.Forms.TextBox();
            this.guige = new System.Windows.Forms.TextBox();
            this.pricewithtax = new System.Windows.Forms.TextBox();
            this.rkgg = new System.Windows.Forms.TextBox();
            this.rkl = new System.Windows.Forms.TextBox();
            this.buyprice = new System.Windows.Forms.TextBox();
            this.ckl = new System.Windows.Forms.TextBox();
            this.sellcontract = new System.Windows.Forms.TextBox();
            this.bzlabel = new System.Windows.Forms.Label();
            this.bz = new System.Windows.Forms.TextBox();
            this.ckllabel = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.rkdbhlabel = new System.Windows.Forms.Label();
            this.rkdbh = new System.Windows.Forms.TextBox();
            this.location = new wzbalance.ComboBoxEx();
            this.buyman = new wzbalance.ComboBoxEx();
            this.planprice = new System.Windows.Forms.TextBox();
            this.planpricelabel = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.thhtbh = new System.Windows.Forms.TextBox();
            this.sellman = new wzbalance.ComboBoxEx();
            this.pinming = new wzbalance.ComboBoxEx();
            this.jhzt = new wzbalance.ComboBoxEx();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.ckdbhlabel = new System.Windows.Forms.Label();
            this.ckdbh = new System.Windows.Forms.TextBox();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.zlyy = new System.Windows.Forms.TextBox();
            this.zlyylabel = new System.Windows.Forms.Label();
            this.luhao = new System.Windows.Forms.ComboBox();
            this.luhaolabel = new System.Windows.Forms.Label();
            this.contextMenuStrip1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.groupBox5.SuspendLayout();
            this.SuspendLayout();
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.添加ToolStripMenuItem,
            this.修改ToolStripMenuItem,
            this.删除ToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(191, 70);
            // 
            // 添加ToolStripMenuItem
            // 
            this.添加ToolStripMenuItem.Name = "添加ToolStripMenuItem";
            this.添加ToolStripMenuItem.Size = new System.Drawing.Size(190, 22);
            this.添加ToolStripMenuItem.Text = "添加";
            // 
            // 修改ToolStripMenuItem
            // 
            this.修改ToolStripMenuItem.Enabled = false;
            this.修改ToolStripMenuItem.Name = "修改ToolStripMenuItem";
            this.修改ToolStripMenuItem.Size = new System.Drawing.Size(190, 22);
            this.修改ToolStripMenuItem.Text = "修改(请从设置中修改)";
            // 
            // 删除ToolStripMenuItem
            // 
            this.删除ToolStripMenuItem.Enabled = false;
            this.删除ToolStripMenuItem.Name = "删除ToolStripMenuItem";
            this.删除ToolStripMenuItem.Size = new System.Drawing.Size(190, 22);
            this.删除ToolStripMenuItem.Text = "删除(请从设置中修改)";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(660, 654);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 6;
            this.button1.Text = "取消";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(759, 654);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 23);
            this.button2.TabIndex = 7;
            this.button2.Text = "确定";
            this.button2.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.ForeColor = System.Drawing.Color.Red;
            this.label1.Location = new System.Drawing.Point(281, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(41, 12);
            this.label1.TabIndex = 3;
            this.label1.Text = "label1";
            // 
            // thhtbhlabel
            // 
            this.thhtbhlabel.AutoSize = true;
            this.thhtbhlabel.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.thhtbhlabel.Location = new System.Drawing.Point(21, 31);
            this.thhtbhlabel.Name = "thhtbhlabel";
            this.thhtbhlabel.Size = new System.Drawing.Size(91, 14);
            this.thhtbhlabel.TabIndex = 0;
            this.thhtbhlabel.Text = "太航合同编号";
            // 
            // pinminglabel
            // 
            this.pinminglabel.AutoSize = true;
            this.pinminglabel.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.pinminglabel.Location = new System.Drawing.Point(21, 70);
            this.pinminglabel.Name = "pinminglabel";
            this.pinminglabel.Size = new System.Drawing.Size(35, 14);
            this.pinminglabel.TabIndex = 0;
            this.pinminglabel.Text = "品名";
            // 
            // sellfapiaolabel
            // 
            this.sellfapiaolabel.AutoSize = true;
            this.sellfapiaolabel.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.sellfapiaolabel.Location = new System.Drawing.Point(19, 69);
            this.sellfapiaolabel.Name = "sellfapiaolabel";
            this.sellfapiaolabel.Size = new System.Drawing.Size(91, 14);
            this.sellfapiaolabel.TabIndex = 0;
            this.sellfapiaolabel.Text = "销项发票日期";
            // 
            // paihaolabel
            // 
            this.paihaolabel.AutoSize = true;
            this.paihaolabel.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.paihaolabel.Location = new System.Drawing.Point(282, 70);
            this.paihaolabel.Name = "paihaolabel";
            this.paihaolabel.Size = new System.Drawing.Size(35, 14);
            this.paihaolabel.TabIndex = 0;
            this.paihaolabel.Text = "牌号";
            // 
            // guigelabel
            // 
            this.guigelabel.AutoSize = true;
            this.guigelabel.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.guigelabel.Location = new System.Drawing.Point(534, 70);
            this.guigelabel.Name = "guigelabel";
            this.guigelabel.Size = new System.Drawing.Size(35, 14);
            this.guigelabel.TabIndex = 0;
            this.guigelabel.Text = "规格";
            // 
            // rkrqlabel
            // 
            this.rkrqlabel.AutoSize = true;
            this.rkrqlabel.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.rkrqlabel.Location = new System.Drawing.Point(536, 100);
            this.rkrqlabel.Name = "rkrqlabel";
            this.rkrqlabel.Size = new System.Drawing.Size(63, 14);
            this.rkrqlabel.TabIndex = 0;
            this.rkrqlabel.Text = "入库日期";
            // 
            // jstjlabel
            // 
            this.jstjlabel.AutoSize = true;
            this.jstjlabel.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.jstjlabel.Location = new System.Drawing.Point(533, 107);
            this.jstjlabel.Name = "jstjlabel";
            this.jstjlabel.Size = new System.Drawing.Size(63, 14);
            this.jstjlabel.TabIndex = 0;
            this.jstjlabel.Text = "技术条件";
            // 
            // sellnumlabel
            // 
            this.sellnumlabel.AutoSize = true;
            this.sellnumlabel.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.sellnumlabel.Location = new System.Drawing.Point(21, 108);
            this.sellnumlabel.Name = "sellnumlabel";
            this.sellnumlabel.Size = new System.Drawing.Size(35, 14);
            this.sellnumlabel.TabIndex = 0;
            this.sellnumlabel.Text = "数量";
            // 
            // selldatelabel
            // 
            this.selldatelabel.AutoSize = true;
            this.selldatelabel.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.selldatelabel.Location = new System.Drawing.Point(282, 143);
            this.selldatelabel.Name = "selldatelabel";
            this.selldatelabel.Size = new System.Drawing.Size(49, 14);
            this.selldatelabel.TabIndex = 0;
            this.selldatelabel.Text = "交货期";
            // 
            // rkgglabel
            // 
            this.rkgglabel.AutoSize = true;
            this.rkgglabel.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.rkgglabel.Location = new System.Drawing.Point(536, 61);
            this.rkgglabel.Name = "rkgglabel";
            this.rkgglabel.Size = new System.Drawing.Size(63, 14);
            this.rkgglabel.TabIndex = 0;
            this.rkgglabel.Text = "入库规格";
            // 
            // locationlabel
            // 
            this.locationlabel.AutoSize = true;
            this.locationlabel.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.locationlabel.Location = new System.Drawing.Point(22, 61);
            this.locationlabel.Name = "locationlabel";
            this.locationlabel.Size = new System.Drawing.Size(35, 14);
            this.locationlabel.TabIndex = 0;
            this.locationlabel.Text = "产地";
            // 
            // buypricelabel
            // 
            this.buypricelabel.AutoSize = true;
            this.buypricelabel.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.buypricelabel.Location = new System.Drawing.Point(275, 101);
            this.buypricelabel.Name = "buypricelabel";
            this.buypricelabel.Size = new System.Drawing.Size(35, 14);
            this.buypricelabel.TabIndex = 0;
            this.buypricelabel.Text = "进价";
            // 
            // sellmanlabel
            // 
            this.sellmanlabel.AutoSize = true;
            this.sellmanlabel.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.sellmanlabel.Location = new System.Drawing.Point(533, 31);
            this.sellmanlabel.Name = "sellmanlabel";
            this.sellmanlabel.Size = new System.Drawing.Size(63, 14);
            this.sellmanlabel.TabIndex = 0;
            this.sellmanlabel.Text = "需方单位";
            // 
            // jhztlabel
            // 
            this.jhztlabel.AutoSize = true;
            this.jhztlabel.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.jhztlabel.Location = new System.Drawing.Point(21, 148);
            this.jhztlabel.Name = "jhztlabel";
            this.jhztlabel.Size = new System.Drawing.Size(63, 14);
            this.jhztlabel.TabIndex = 0;
            this.jhztlabel.Text = "交货状态";
            // 
            // buymanlabel
            // 
            this.buymanlabel.AutoSize = true;
            this.buymanlabel.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.buymanlabel.Location = new System.Drawing.Point(275, 26);
            this.buymanlabel.Name = "buymanlabel";
            this.buymanlabel.Size = new System.Drawing.Size(63, 14);
            this.buymanlabel.TabIndex = 0;
            this.buymanlabel.Text = "供方单位";
            // 
            // pricewithtaxlabel
            // 
            this.pricewithtaxlabel.AutoSize = true;
            this.pricewithtaxlabel.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.pricewithtaxlabel.Location = new System.Drawing.Point(280, 108);
            this.pricewithtaxlabel.Name = "pricewithtaxlabel";
            this.pricewithtaxlabel.Size = new System.Drawing.Size(49, 14);
            this.pricewithtaxlabel.TabIndex = 0;
            this.pricewithtaxlabel.Text = "含税价";
            // 
            // kucunlabel
            // 
            this.kucunlabel.AutoSize = true;
            this.kucunlabel.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.kucunlabel.Location = new System.Drawing.Point(22, 26);
            this.kucunlabel.Name = "kucunlabel";
            this.kucunlabel.Size = new System.Drawing.Size(49, 14);
            this.kucunlabel.TabIndex = 0;
            this.kucunlabel.Text = "库存量";
            // 
            // rkllabel
            // 
            this.rkllabel.AutoSize = true;
            this.rkllabel.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.rkllabel.Location = new System.Drawing.Point(22, 101);
            this.rkllabel.Name = "rkllabel";
            this.rkllabel.Size = new System.Drawing.Size(49, 14);
            this.rkllabel.TabIndex = 0;
            this.rkllabel.Text = "入库量";
            // 
            // jindulabel
            // 
            this.jindulabel.AutoSize = true;
            this.jindulabel.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.jindulabel.Location = new System.Drawing.Point(275, 61);
            this.jindulabel.Name = "jindulabel";
            this.jindulabel.Size = new System.Drawing.Size(63, 14);
            this.jindulabel.TabIndex = 0;
            this.jindulabel.Text = "进度情况";
            // 
            // cksjlabel
            // 
            this.cksjlabel.AutoSize = true;
            this.cksjlabel.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.cksjlabel.Location = new System.Drawing.Point(536, 26);
            this.cksjlabel.Name = "cksjlabel";
            this.cksjlabel.Size = new System.Drawing.Size(63, 14);
            this.cksjlabel.TabIndex = 0;
            this.cksjlabel.Text = "出库时间";
            // 
            // sellcontractlabel
            // 
            this.sellcontractlabel.AutoSize = true;
            this.sellcontractlabel.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.sellcontractlabel.Location = new System.Drawing.Point(282, 31);
            this.sellcontractlabel.Name = "sellcontractlabel";
            this.sellcontractlabel.Size = new System.Drawing.Size(63, 14);
            this.sellcontractlabel.TabIndex = 0;
            this.sellcontractlabel.Text = "销项合同";
            // 
            // buycontractlabel
            // 
            this.buycontractlabel.AutoSize = true;
            this.buycontractlabel.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.buycontractlabel.Location = new System.Drawing.Point(536, 26);
            this.buycontractlabel.Name = "buycontractlabel";
            this.buycontractlabel.Size = new System.Drawing.Size(63, 14);
            this.buycontractlabel.TabIndex = 0;
            this.buycontractlabel.Text = "进项合同";
            // 
            // buyfapiaolabel
            // 
            this.buyfapiaolabel.AutoSize = true;
            this.buyfapiaolabel.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.buyfapiaolabel.Location = new System.Drawing.Point(279, 64);
            this.buyfapiaolabel.Name = "buyfapiaolabel";
            this.buyfapiaolabel.Size = new System.Drawing.Size(91, 14);
            this.buyfapiaolabel.TabIndex = 0;
            this.buyfapiaolabel.Text = "进项发票日期";
            // 
            // fxrqlabel
            // 
            this.fxrqlabel.AutoSize = true;
            this.fxrqlabel.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.fxrqlabel.Location = new System.Drawing.Point(534, 26);
            this.fxrqlabel.Name = "fxrqlabel";
            this.fxrqlabel.Size = new System.Drawing.Size(63, 14);
            this.fxrqlabel.TabIndex = 0;
            this.fxrqlabel.Text = "发信日期";
            // 
            // yffplabel
            // 
            this.yffplabel.AutoSize = true;
            this.yffplabel.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.yffplabel.Location = new System.Drawing.Point(277, 27);
            this.yffplabel.Name = "yffplabel";
            this.yffplabel.Size = new System.Drawing.Size(63, 14);
            this.yffplabel.TabIndex = 0;
            this.yffplabel.Text = "运费发票";
            // 
            // cksj
            // 
            this.cksj.Checked = false;
            this.cksj.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.cksj.Location = new System.Drawing.Point(632, 20);
            this.cksj.Name = "cksj";
            this.cksj.ShowCheckBox = true;
            this.cksj.Size = new System.Drawing.Size(121, 21);
            this.cksj.TabIndex = 25;
            // 
            // sellfapiao
            // 
            this.sellfapiao.Checked = false;
            this.sellfapiao.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.sellfapiao.Location = new System.Drawing.Point(131, 62);
            this.sellfapiao.Name = "sellfapiao";
            this.sellfapiao.ShowCheckBox = true;
            this.sellfapiao.Size = new System.Drawing.Size(121, 21);
            this.sellfapiao.TabIndex = 29;
            // 
            // buyfapiao
            // 
            this.buyfapiao.Checked = false;
            this.buyfapiao.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.buyfapiao.Location = new System.Drawing.Point(376, 57);
            this.buyfapiao.Name = "buyfapiao";
            this.buyfapiao.ShowCheckBox = true;
            this.buyfapiao.Size = new System.Drawing.Size(121, 21);
            this.buyfapiao.TabIndex = 30;
            // 
            // kucun
            // 
            this.kucun.ContextMenuStrip = this.contextMenuStrip1;
            this.kucun.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.kucun.FormattingEnabled = true;
            this.kucun.Location = new System.Drawing.Point(133, 20);
            this.kucun.Name = "kucun";
            this.kucun.Size = new System.Drawing.Size(121, 20);
            this.kucun.TabIndex = 12;
            // 
            // fxrq
            // 
            this.fxrq.Checked = false;
            this.fxrq.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.fxrq.Location = new System.Drawing.Point(630, 20);
            this.fxrq.Name = "fxrq";
            this.fxrq.ShowCheckBox = true;
            this.fxrq.Size = new System.Drawing.Size(121, 21);
            this.fxrq.TabIndex = 28;
            // 
            // rkrq
            // 
            this.rkrq.Checked = false;
            this.rkrq.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.rkrq.Location = new System.Drawing.Point(632, 93);
            this.rkrq.Name = "rkrq";
            this.rkrq.ShowCheckBox = true;
            this.rkrq.Size = new System.Drawing.Size(121, 21);
            this.rkrq.TabIndex = 22;
            // 
            // buycontract
            // 
            this.buycontract.ContextMenuStrip = this.contextMenuStrip1;
            this.buycontract.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.buycontract.FormattingEnabled = true;
            this.buycontract.Location = new System.Drawing.Point(632, 20);
            this.buycontract.Name = "buycontract";
            this.buycontract.Size = new System.Drawing.Size(121, 20);
            this.buycontract.TabIndex = 16;
            // 
            // jindu
            // 
            this.jindu.ContextMenuStrip = this.contextMenuStrip1;
            this.jindu.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.jindu.FormattingEnabled = true;
            this.jindu.Location = new System.Drawing.Point(374, 55);
            this.jindu.Name = "jindu";
            this.jindu.Size = new System.Drawing.Size(121, 20);
            this.jindu.TabIndex = 18;
            // 
            // yffp
            // 
            this.yffp.ContextMenuStrip = this.contextMenuStrip1;
            this.yffp.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.yffp.FormattingEnabled = true;
            this.yffp.Location = new System.Drawing.Point(376, 21);
            this.yffp.Name = "yffp";
            this.yffp.Size = new System.Drawing.Size(121, 20);
            this.yffp.TabIndex = 27;
            // 
            // paihao
            // 
            this.paihao.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.paihao.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.paihao.FormattingEnabled = true;
            this.paihao.Location = new System.Drawing.Point(378, 64);
            this.paihao.Name = "paihao";
            this.paihao.Size = new System.Drawing.Size(121, 20);
            this.paihao.TabIndex = 5;
            // 
            // jstj
            // 
            this.jstj.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.jstj.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.jstj.FormattingEnabled = true;
            this.jstj.Location = new System.Drawing.Point(632, 100);
            this.jstj.Name = "jstj";
            this.jstj.Size = new System.Drawing.Size(121, 20);
            this.jstj.TabIndex = 9;
            // 
            // selldate
            // 
            this.selldate.ContextMenuStrip = this.contextMenuStrip1;
            this.selldate.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.selldate.FormattingEnabled = true;
            this.selldate.Location = new System.Drawing.Point(378, 142);
            this.selldate.MaxDropDownItems = 11;
            this.selldate.Name = "selldate";
            this.selldate.Size = new System.Drawing.Size(121, 20);
            this.selldate.TabIndex = 11;
            // 
            // sellnum
            // 
            this.sellnum.Location = new System.Drawing.Point(133, 102);
            this.sellnum.Name = "sellnum";
            this.sellnum.Size = new System.Drawing.Size(121, 21);
            this.sellnum.TabIndex = 7;
            // 
            // guige
            // 
            this.guige.Location = new System.Drawing.Point(632, 63);
            this.guige.Name = "guige";
            this.guige.Size = new System.Drawing.Size(121, 21);
            this.guige.TabIndex = 6;
            // 
            // pricewithtax
            // 
            this.pricewithtax.Location = new System.Drawing.Point(379, 101);
            this.pricewithtax.Name = "pricewithtax";
            this.pricewithtax.Size = new System.Drawing.Size(121, 21);
            this.pricewithtax.TabIndex = 8;
            // 
            // rkgg
            // 
            this.rkgg.Location = new System.Drawing.Point(632, 54);
            this.rkgg.Name = "rkgg";
            this.rkgg.Size = new System.Drawing.Size(121, 21);
            this.rkgg.TabIndex = 19;
            // 
            // rkl
            // 
            this.rkl.Location = new System.Drawing.Point(133, 94);
            this.rkl.Name = "rkl";
            this.rkl.Size = new System.Drawing.Size(121, 21);
            this.rkl.TabIndex = 20;
            // 
            // buyprice
            // 
            this.buyprice.Location = new System.Drawing.Point(373, 94);
            this.buyprice.Name = "buyprice";
            this.buyprice.Size = new System.Drawing.Size(121, 21);
            this.buyprice.TabIndex = 21;
            // 
            // ckl
            // 
            this.ckl.Location = new System.Drawing.Point(375, 21);
            this.ckl.Name = "ckl";
            this.ckl.Size = new System.Drawing.Size(121, 21);
            this.ckl.TabIndex = 24;
            // 
            // sellcontract
            // 
            this.sellcontract.Location = new System.Drawing.Point(378, 24);
            this.sellcontract.Name = "sellcontract";
            this.sellcontract.Size = new System.Drawing.Size(121, 21);
            this.sellcontract.TabIndex = 2;
            // 
            // bzlabel
            // 
            this.bzlabel.AutoSize = true;
            this.bzlabel.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.bzlabel.Location = new System.Drawing.Point(21, 109);
            this.bzlabel.Name = "bzlabel";
            this.bzlabel.Size = new System.Drawing.Size(35, 14);
            this.bzlabel.TabIndex = 27;
            this.bzlabel.Text = "备注";
            // 
            // bz
            // 
            this.bz.Location = new System.Drawing.Point(131, 102);
            this.bz.Name = "bz";
            this.bz.Size = new System.Drawing.Size(121, 21);
            this.bz.TabIndex = 31;
            // 
            // ckllabel
            // 
            this.ckllabel.AutoSize = true;
            this.ckllabel.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.ckllabel.Location = new System.Drawing.Point(277, 27);
            this.ckllabel.Name = "ckllabel";
            this.ckllabel.Size = new System.Drawing.Size(49, 14);
            this.ckllabel.TabIndex = 29;
            this.ckllabel.Text = "出库量";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.buyprice);
            this.groupBox1.Controls.Add(this.rkdbhlabel);
            this.groupBox1.Controls.Add(this.rkl);
            this.groupBox1.Controls.Add(this.rkgg);
            this.groupBox1.Controls.Add(this.rkdbh);
            this.groupBox1.Controls.Add(this.rkrqlabel);
            this.groupBox1.Controls.Add(this.location);
            this.groupBox1.Controls.Add(this.buyman);
            this.groupBox1.Controls.Add(this.jindu);
            this.groupBox1.Controls.Add(this.buycontract);
            this.groupBox1.Controls.Add(this.buycontractlabel);
            this.groupBox1.Controls.Add(this.jindulabel);
            this.groupBox1.Controls.Add(this.rkllabel);
            this.groupBox1.Controls.Add(this.buymanlabel);
            this.groupBox1.Controls.Add(this.rkrq);
            this.groupBox1.Controls.Add(this.buypricelabel);
            this.groupBox1.Controls.Add(this.locationlabel);
            this.groupBox1.Controls.Add(this.rkgglabel);
            this.groupBox1.Location = new System.Drawing.Point(28, 288);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(807, 130);
            this.groupBox1.TabIndex = 3;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "采购入库";
            // 
            // rkdbhlabel
            // 
            this.rkdbhlabel.AutoSize = true;
            this.rkdbhlabel.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.rkdbhlabel.Location = new System.Drawing.Point(22, 26);
            this.rkdbhlabel.Name = "rkdbhlabel";
            this.rkdbhlabel.Size = new System.Drawing.Size(77, 14);
            this.rkdbhlabel.TabIndex = 0;
            this.rkdbhlabel.Text = "入库单编号";
            // 
            // rkdbh
            // 
            this.rkdbh.Location = new System.Drawing.Point(133, 20);
            this.rkdbh.Name = "rkdbh";
            this.rkdbh.Size = new System.Drawing.Size(121, 21);
            this.rkdbh.TabIndex = 14;
            // 
            // location
            // 
            this.location.FormattingEnabled = true;
            this.location.Location = new System.Drawing.Point(133, 55);
            this.location.Name = "location";
            this.location.Size = new System.Drawing.Size(121, 20);
            this.location.TabIndex = 17;
            // 
            // buyman
            // 
            this.buyman.FormattingEnabled = true;
            this.buyman.Location = new System.Drawing.Point(374, 20);
            this.buyman.Name = "buyman";
            this.buyman.Size = new System.Drawing.Size(121, 20);
            this.buyman.TabIndex = 15;
            // 
            // planprice
            // 
            this.planprice.Location = new System.Drawing.Point(378, 20);
            this.planprice.Name = "planprice";
            this.planprice.Size = new System.Drawing.Size(121, 21);
            this.planprice.TabIndex = 13;
            // 
            // planpricelabel
            // 
            this.planpricelabel.AutoSize = true;
            this.planpricelabel.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.planpricelabel.Location = new System.Drawing.Point(280, 21);
            this.planpricelabel.Name = "planpricelabel";
            this.planpricelabel.Size = new System.Drawing.Size(63, 14);
            this.planpricelabel.TabIndex = 0;
            this.planpricelabel.Text = "计划价格";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.paihao);
            this.groupBox2.Controls.Add(this.thhtbhlabel);
            this.groupBox2.Controls.Add(this.pinminglabel);
            this.groupBox2.Controls.Add(this.thhtbh);
            this.groupBox2.Controls.Add(this.sellcontract);
            this.groupBox2.Controls.Add(this.paihaolabel);
            this.groupBox2.Controls.Add(this.guigelabel);
            this.groupBox2.Controls.Add(this.sellmanlabel);
            this.groupBox2.Controls.Add(this.sellcontractlabel);
            this.groupBox2.Controls.Add(this.pricewithtax);
            this.groupBox2.Controls.Add(this.sellnum);
            this.groupBox2.Controls.Add(this.sellman);
            this.groupBox2.Controls.Add(this.selldate);
            this.groupBox2.Controls.Add(this.jstj);
            this.groupBox2.Controls.Add(this.pinming);
            this.groupBox2.Controls.Add(this.jhzt);
            this.groupBox2.Controls.Add(this.guige);
            this.groupBox2.Controls.Add(this.jstjlabel);
            this.groupBox2.Controls.Add(this.sellnumlabel);
            this.groupBox2.Controls.Add(this.selldatelabel);
            this.groupBox2.Controls.Add(this.jhztlabel);
            this.groupBox2.Controls.Add(this.pricewithtaxlabel);
            this.groupBox2.Location = new System.Drawing.Point(28, 24);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(807, 177);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "合同录入";
            // 
            // thhtbh
            // 
            this.thhtbh.Location = new System.Drawing.Point(133, 24);
            this.thhtbh.Name = "thhtbh";
            this.thhtbh.Size = new System.Drawing.Size(121, 21);
            this.thhtbh.TabIndex = 1;
            // 
            // sellman
            // 
            this.sellman.FormattingEnabled = true;
            this.sellman.Location = new System.Drawing.Point(632, 25);
            this.sellman.Name = "sellman";
            this.sellman.Size = new System.Drawing.Size(121, 20);
            this.sellman.TabIndex = 3;
            // 
            // pinming
            // 
            this.pinming.FormattingEnabled = true;
            this.pinming.Location = new System.Drawing.Point(133, 64);
            this.pinming.Name = "pinming";
            this.pinming.Size = new System.Drawing.Size(121, 20);
            this.pinming.TabIndex = 4;
            // 
            // jhzt
            // 
            this.jhzt.ContextMenuStrip = this.contextMenuStrip1;
            this.jhzt.FormattingEnabled = true;
            this.jhzt.Location = new System.Drawing.Point(133, 142);
            this.jhzt.Name = "jhzt";
            this.jhzt.Size = new System.Drawing.Size(121, 20);
            this.jhzt.TabIndex = 10;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.kucun);
            this.groupBox3.Controls.Add(this.kucunlabel);
            this.groupBox3.Controls.Add(this.planprice);
            this.groupBox3.Controls.Add(this.planpricelabel);
            this.groupBox3.Location = new System.Drawing.Point(28, 219);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(807, 53);
            this.groupBox3.TabIndex = 2;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "库存及计划价";
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.ckllabel);
            this.groupBox4.Controls.Add(this.ckdbhlabel);
            this.groupBox4.Controls.Add(this.ckl);
            this.groupBox4.Controls.Add(this.cksj);
            this.groupBox4.Controls.Add(this.cksjlabel);
            this.groupBox4.Controls.Add(this.ckdbh);
            this.groupBox4.Location = new System.Drawing.Point(28, 433);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(807, 55);
            this.groupBox4.TabIndex = 4;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "销售出库";
            // 
            // ckdbhlabel
            // 
            this.ckdbhlabel.AutoSize = true;
            this.ckdbhlabel.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.ckdbhlabel.Location = new System.Drawing.Point(21, 27);
            this.ckdbhlabel.Name = "ckdbhlabel";
            this.ckdbhlabel.Size = new System.Drawing.Size(77, 14);
            this.ckdbhlabel.TabIndex = 0;
            this.ckdbhlabel.Text = "出库单编号";
            // 
            // ckdbh
            // 
            this.ckdbh.Location = new System.Drawing.Point(133, 26);
            this.ckdbh.Name = "ckdbh";
            this.ckdbh.Size = new System.Drawing.Size(121, 21);
            this.ckdbh.TabIndex = 23;
            // 
            // groupBox5
            // 
            this.groupBox5.Controls.Add(this.bz);
            this.groupBox5.Controls.Add(this.yffp);
            this.groupBox5.Controls.Add(this.zlyy);
            this.groupBox5.Controls.Add(this.buyfapiao);
            this.groupBox5.Controls.Add(this.buyfapiaolabel);
            this.groupBox5.Controls.Add(this.sellfapiaolabel);
            this.groupBox5.Controls.Add(this.bzlabel);
            this.groupBox5.Controls.Add(this.sellfapiao);
            this.groupBox5.Controls.Add(this.zlyylabel);
            this.groupBox5.Controls.Add(this.fxrqlabel);
            this.groupBox5.Controls.Add(this.fxrq);
            this.groupBox5.Controls.Add(this.luhao);
            this.groupBox5.Controls.Add(this.yffplabel);
            this.groupBox5.Controls.Add(this.luhaolabel);
            this.groupBox5.Location = new System.Drawing.Point(30, 494);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(804, 147);
            this.groupBox5.TabIndex = 5;
            this.groupBox5.TabStop = false;
            this.groupBox5.Text = "票据及备注";
            // 
            // zlyy
            // 
            this.zlyy.Location = new System.Drawing.Point(377, 102);
            this.zlyy.Name = "zlyy";
            this.zlyy.Size = new System.Drawing.Size(379, 21);
            this.zlyy.TabIndex = 32;
            // 
            // zlyylabel
            // 
            this.zlyylabel.AutoSize = true;
            this.zlyylabel.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.zlyylabel.Location = new System.Drawing.Point(280, 109);
            this.zlyylabel.Name = "zlyylabel";
            this.zlyylabel.Size = new System.Drawing.Size(63, 14);
            this.zlyylabel.TabIndex = 0;
            this.zlyylabel.Text = "质量异议";
            // 
            // luhao
            // 
            this.luhao.DropDownStyle = System.Windows.Forms.ComboBoxStyle.Simple;
            this.luhao.FormattingEnabled = true;
            this.luhao.Location = new System.Drawing.Point(131, 20);
            this.luhao.Name = "luhao";
            this.luhao.Size = new System.Drawing.Size(121, 150);
            this.luhao.TabIndex = 26;
            // 
            // luhaolabel
            // 
            this.luhaolabel.AutoSize = true;
            this.luhaolabel.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.luhaolabel.Location = new System.Drawing.Point(19, 27);
            this.luhaolabel.Name = "luhaolabel";
            this.luhaolabel.Size = new System.Drawing.Size(35, 14);
            this.luhaolabel.TabIndex = 0;
            this.luhaolabel.Text = "炉号";
            // 
            // AddContractForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(852, 751);
            this.Controls.Add(this.groupBox5);
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.button2);
            this.Location = new System.Drawing.Point(450, 50);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "AddContractForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "添加新项目";
            this.contextMenuStrip1.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.groupBox5.ResumeLayout(false);
            this.groupBox5.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
    }
}