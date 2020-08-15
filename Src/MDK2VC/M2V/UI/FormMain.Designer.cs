namespace MDK2VC
{
    partial class FormMain
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
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormMain));
            this.btnTrans = new System.Windows.Forms.Button();
            this.btnTest = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.notifyIcon1 = new System.Windows.Forms.NotifyIcon(this.components);
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.显示ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.退出ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabel2 = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabel3 = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabel4 = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabel5 = new System.Windows.Forms.ToolStripStatusLabel();
            this.treeView1 = new System.Windows.Forms.TreeView();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnSelFileName = new System.Windows.Forms.Button();
            this.comboBoxMDKPath = new System.Windows.Forms.ComboBox();
            this.labelOpenProj = new System.Windows.Forms.Label();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.TargetStatus = new System.Windows.Forms.TextBox();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.comboBoxTarget = new System.Windows.Forms.ComboBox();
            this.elementHost = new System.Windows.Forms.Integration.ElementHost();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.buttonLoadManulTarget = new System.Windows.Forms.Button();
            this.checkBoxManulSetTarget = new System.Windows.Forms.CheckBox();
            this.labelOpenVC = new System.Windows.Forms.Label();
            this.tBoxSlnPath = new System.Windows.Forms.TextBox();
            this.elementHost1 = new System.Windows.Forms.Integration.ElementHost();
            this.comboBoxOutTarget = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.文件ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.退出ToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.工具ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.清理路径ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.帮助ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.使用说明ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.contextMenuStrip1.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.groupBox5.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnTrans
            // 
            this.btnTrans.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnTrans.Location = new System.Drawing.Point(11, 582);
            this.btnTrans.Name = "btnTrans";
            this.btnTrans.Size = new System.Drawing.Size(75, 23);
            this.btnTrans.TabIndex = 4;
            this.btnTrans.Text = "测试读取";
            this.btnTrans.UseVisualStyleBackColor = true;
            this.btnTrans.Click += new System.EventHandler(this.BtnTrans_Click);
            // 
            // btnTest
            // 
            this.btnTest.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnTest.Location = new System.Drawing.Point(136, 582);
            this.btnTest.Name = "btnTest";
            this.btnTest.Size = new System.Drawing.Size(75, 23);
            this.btnTest.TabIndex = 9;
            this.btnTest.Text = "转换";
            this.btnTest.UseVisualStyleBackColor = true;
            this.btnTest.Click += new System.EventHandler(this.BtnTest_Click);
            // 
            // label5
            // 
            this.label5.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(261, 587);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(41, 12);
            this.label5.TabIndex = 15;
            this.label5.Text = "未转换";
            // 
            // notifyIcon1
            // 
            this.notifyIcon1.ContextMenuStrip = this.contextMenuStrip1;
            this.notifyIcon1.Icon = ((System.Drawing.Icon)(resources.GetObject("notifyIcon1.Icon")));
            this.notifyIcon1.Text = "MDK2VC";
            this.notifyIcon1.Visible = true;
            this.notifyIcon1.DoubleClick += new System.EventHandler(this.NotifyIcon1_DoubleClick);
            this.notifyIcon1.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.NotifyIcon1_MouseDoubleClick);
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.显示ToolStripMenuItem,
            this.退出ToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(101, 48);
            // 
            // 显示ToolStripMenuItem
            // 
            this.显示ToolStripMenuItem.Name = "显示ToolStripMenuItem";
            this.显示ToolStripMenuItem.Size = new System.Drawing.Size(100, 22);
            this.显示ToolStripMenuItem.Text = "显示";
            this.显示ToolStripMenuItem.Click += new System.EventHandler(this.显示ToolStripMenuItem_Click);
            // 
            // 退出ToolStripMenuItem
            // 
            this.退出ToolStripMenuItem.Name = "退出ToolStripMenuItem";
            this.退出ToolStripMenuItem.Size = new System.Drawing.Size(100, 22);
            this.退出ToolStripMenuItem.Text = "退出";
            this.退出ToolStripMenuItem.Click += new System.EventHandler(this.退出ToolStripMenuItem_Click);
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel1,
            this.toolStripStatusLabel2,
            this.toolStripStatusLabel3,
            this.toolStripStatusLabel4,
            this.toolStripStatusLabel5});
            this.statusStrip1.Location = new System.Drawing.Point(0, 611);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(784, 22);
            this.statusStrip1.TabIndex = 17;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // toolStripStatusLabel1
            // 
            this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            this.toolStripStatusLabel1.Size = new System.Drawing.Size(176, 17);
            this.toolStripStatusLabel1.Text = "双击\"MDK项目\"打开MDK工程 ";
            // 
            // toolStripStatusLabel2
            // 
            this.toolStripStatusLabel2.Name = "toolStripStatusLabel2";
            this.toolStripStatusLabel2.Size = new System.Drawing.Size(11, 17);
            this.toolStripStatusLabel2.Text = "|";
            // 
            // toolStripStatusLabel3
            // 
            this.toolStripStatusLabel3.Name = "toolStripStatusLabel3";
            this.toolStripStatusLabel3.Size = new System.Drawing.Size(146, 17);
            this.toolStripStatusLabel3.Text = "双击\"VC工程\"打开VC工程";
            // 
            // toolStripStatusLabel4
            // 
            this.toolStripStatusLabel4.Name = "toolStripStatusLabel4";
            this.toolStripStatusLabel4.Size = new System.Drawing.Size(11, 17);
            this.toolStripStatusLabel4.Text = "|";
            // 
            // toolStripStatusLabel5
            // 
            this.toolStripStatusLabel5.Name = "toolStripStatusLabel5";
            this.toolStripStatusLabel5.Size = new System.Drawing.Size(116, 17);
            this.toolStripStatusLabel5.Text = "最小化后到系统托盘";
            // 
            // treeView1
            // 
            this.treeView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.treeView1.Location = new System.Drawing.Point(3, 19);
            this.treeView1.Name = "treeView1";
            this.treeView1.Size = new System.Drawing.Size(761, 227);
            this.treeView1.TabIndex = 18;
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Controls.Add(this.btnSelFileName);
            this.groupBox1.Controls.Add(this.comboBoxMDKPath);
            this.groupBox1.Controls.Add(this.labelOpenProj);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(760, 54);
            this.groupBox1.TabIndex = 19;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Project File Path";
            // 
            // btnSelFileName
            // 
            this.btnSelFileName.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.btnSelFileName.Location = new System.Drawing.Point(699, 18);
            this.btnSelFileName.Name = "btnSelFileName";
            this.btnSelFileName.Size = new System.Drawing.Size(51, 23);
            this.btnSelFileName.TabIndex = 5;
            this.btnSelFileName.Text = "...";
            this.btnSelFileName.UseVisualStyleBackColor = true;
            this.btnSelFileName.Click += new System.EventHandler(this.BtnSelFileName_Click);
            // 
            // comboBoxMDKPath
            // 
            this.comboBoxMDKPath.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.comboBoxMDKPath.FormattingEnabled = true;
            this.comboBoxMDKPath.Location = new System.Drawing.Point(44, 19);
            this.comboBoxMDKPath.Name = "comboBoxMDKPath";
            this.comboBoxMDKPath.Size = new System.Drawing.Size(648, 20);
            this.comboBoxMDKPath.TabIndex = 4;
            this.comboBoxMDKPath.SelectedIndexChanged += new System.EventHandler(this.comboBoxMDKPath_SelectedIndexChanged);
            // 
            // labelOpenProj
            // 
            this.labelOpenProj.AutoSize = true;
            this.labelOpenProj.Location = new System.Drawing.Point(9, 23);
            this.labelOpenProj.Name = "labelOpenProj";
            this.labelOpenProj.Size = new System.Drawing.Size(29, 12);
            this.labelOpenProj.TabIndex = 3;
            this.labelOpenProj.Text = "Open";
            this.labelOpenProj.Click += new System.EventHandler(this.LabelOpenProj_Click);
            // 
            // groupBox4
            // 
            this.groupBox4.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox4.Controls.Add(this.TargetStatus);
            this.groupBox4.Font = new System.Drawing.Font("Consolas", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox4.Location = new System.Drawing.Point(4, 230);
            this.groupBox4.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Padding = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.groupBox4.Size = new System.Drawing.Size(766, 90);
            this.groupBox4.TabIndex = 21;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Target Info";
            // 
            // TargetStatus
            // 
            this.TargetStatus.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.TargetStatus.BackColor = System.Drawing.SystemColors.Window;
            this.TargetStatus.Font = new System.Drawing.Font("Consolas", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TargetStatus.Location = new System.Drawing.Point(6, 16);
            this.TargetStatus.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.TargetStatus.Multiline = true;
            this.TargetStatus.Name = "TargetStatus";
            this.TargetStatus.ReadOnly = true;
            this.TargetStatus.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.TargetStatus.Size = new System.Drawing.Size(754, 66);
            this.TargetStatus.TabIndex = 0;
            // 
            // groupBox5
            // 
            this.groupBox5.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox5.Controls.Add(this.treeView1);
            this.groupBox5.Font = new System.Drawing.Font("Consolas", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox5.Location = new System.Drawing.Point(5, 328);
            this.groupBox5.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Padding = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.groupBox5.Size = new System.Drawing.Size(767, 250);
            this.groupBox5.TabIndex = 22;
            this.groupBox5.TabStop = false;
            this.groupBox5.Text = "Source Groups";
            // 
            // groupBox3
            // 
            this.groupBox3.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox3.Controls.Add(this.comboBoxTarget);
            this.groupBox3.Controls.Add(this.elementHost);
            this.groupBox3.Font = new System.Drawing.Font("Consolas", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox3.Location = new System.Drawing.Point(8, 166);
            this.groupBox3.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Padding = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.groupBox3.Size = new System.Drawing.Size(760, 56);
            this.groupBox3.TabIndex = 23;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Target Groups";
            // 
            // comboBoxTarget
            // 
            this.comboBoxTarget.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.comboBoxTarget.FormattingEnabled = true;
            this.comboBoxTarget.Location = new System.Drawing.Point(12, 22);
            this.comboBoxTarget.Name = "comboBoxTarget";
            this.comboBoxTarget.Size = new System.Drawing.Size(735, 22);
            this.comboBoxTarget.TabIndex = 14;
            // 
            // elementHost
            // 
            this.elementHost.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.elementHost.Location = new System.Drawing.Point(6, 16);
            this.elementHost.Name = "elementHost";
            this.elementHost.Size = new System.Drawing.Size(748, 33);
            this.elementHost.TabIndex = 11;
            this.elementHost.Text = "elementHost1";
            this.elementHost.Child = null;
            // 
            // groupBox2
            // 
            this.groupBox2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox2.Controls.Add(this.buttonLoadManulTarget);
            this.groupBox2.Controls.Add(this.checkBoxManulSetTarget);
            this.groupBox2.Controls.Add(this.labelOpenVC);
            this.groupBox2.Controls.Add(this.tBoxSlnPath);
            this.groupBox2.Controls.Add(this.elementHost1);
            this.groupBox2.Font = new System.Drawing.Font("Consolas", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox2.Location = new System.Drawing.Point(10, 73);
            this.groupBox2.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Padding = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.groupBox2.Size = new System.Drawing.Size(760, 85);
            this.groupBox2.TabIndex = 24;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Target";
            // 
            // buttonLoadManulTarget
            // 
            this.buttonLoadManulTarget.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.buttonLoadManulTarget.Location = new System.Drawing.Point(700, 22);
            this.buttonLoadManulTarget.Name = "buttonLoadManulTarget";
            this.buttonLoadManulTarget.Size = new System.Drawing.Size(51, 23);
            this.buttonLoadManulTarget.TabIndex = 15;
            this.buttonLoadManulTarget.Text = "...";
            this.buttonLoadManulTarget.UseVisualStyleBackColor = true;
            this.buttonLoadManulTarget.Visible = false;
            // 
            // checkBoxManulSetTarget
            // 
            this.checkBoxManulSetTarget.AutoSize = true;
            this.checkBoxManulSetTarget.Location = new System.Drawing.Point(13, 50);
            this.checkBoxManulSetTarget.Name = "checkBoxManulSetTarget";
            this.checkBoxManulSetTarget.Size = new System.Drawing.Size(166, 18);
            this.checkBoxManulSetTarget.TabIndex = 14;
            this.checkBoxManulSetTarget.Text = "手动设置输出工程路径";
            this.checkBoxManulSetTarget.UseVisualStyleBackColor = true;
            this.checkBoxManulSetTarget.CheckedChanged += new System.EventHandler(this.checkBoxManulSetTarget_CheckedChanged);
            // 
            // labelOpenVC
            // 
            this.labelOpenVC.AutoSize = true;
            this.labelOpenVC.Location = new System.Drawing.Point(10, 25);
            this.labelOpenVC.Name = "labelOpenVC";
            this.labelOpenVC.Size = new System.Drawing.Size(35, 14);
            this.labelOpenVC.TabIndex = 13;
            this.labelOpenVC.Text = "Open";
            this.labelOpenVC.Click += new System.EventHandler(this.LabelOpenVC_Click);
            // 
            // tBoxSlnPath
            // 
            this.tBoxSlnPath.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tBoxSlnPath.Location = new System.Drawing.Point(45, 22);
            this.tBoxSlnPath.Name = "tBoxSlnPath";
            this.tBoxSlnPath.ReadOnly = true;
            this.tBoxSlnPath.Size = new System.Drawing.Size(649, 22);
            this.tBoxSlnPath.TabIndex = 12;
            // 
            // elementHost1
            // 
            this.elementHost1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.elementHost1.Location = new System.Drawing.Point(6, 16);
            this.elementHost1.Name = "elementHost1";
            this.elementHost1.Size = new System.Drawing.Size(748, 62);
            this.elementHost1.TabIndex = 11;
            this.elementHost1.Text = "elementHost1";
            this.elementHost1.Child = null;
            // 
            // comboBoxOutTarget
            // 
            this.comboBoxOutTarget.FormattingEnabled = true;
            this.comboBoxOutTarget.Items.AddRange(new object[] {
            "VC2019",
            "VC2017"});
            this.comboBoxOutTarget.Location = new System.Drawing.Point(552, 512);
            this.comboBoxOutTarget.Name = "comboBoxOutTarget";
            this.comboBoxOutTarget.Size = new System.Drawing.Size(121, 20);
            this.comboBoxOutTarget.TabIndex = 25;
            this.comboBoxOutTarget.Text = "VC2019";
            this.comboBoxOutTarget.SelectedIndexChanged += new System.EventHandler(this.comboBoxOutTarget_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(484, 515);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(53, 12);
            this.label1.TabIndex = 26;
            this.label1.Text = "输出目标";
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.文件ToolStripMenuItem,
            this.工具ToolStripMenuItem,
            this.帮助ToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(784, 25);
            this.menuStrip1.TabIndex = 27;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // 文件ToolStripMenuItem
            // 
            this.文件ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.退出ToolStripMenuItem1});
            this.文件ToolStripMenuItem.Name = "文件ToolStripMenuItem";
            this.文件ToolStripMenuItem.Size = new System.Drawing.Size(44, 21);
            this.文件ToolStripMenuItem.Text = "文件";
            // 
            // 退出ToolStripMenuItem1
            // 
            this.退出ToolStripMenuItem1.Name = "退出ToolStripMenuItem1";
            this.退出ToolStripMenuItem1.Size = new System.Drawing.Size(100, 22);
            this.退出ToolStripMenuItem1.Text = "退出";
            // 
            // 工具ToolStripMenuItem
            // 
            this.工具ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.清理路径ToolStripMenuItem});
            this.工具ToolStripMenuItem.Name = "工具ToolStripMenuItem";
            this.工具ToolStripMenuItem.Size = new System.Drawing.Size(44, 21);
            this.工具ToolStripMenuItem.Text = "工具";
            // 
            // 清理路径ToolStripMenuItem
            // 
            this.清理路径ToolStripMenuItem.Name = "清理路径ToolStripMenuItem";
            this.清理路径ToolStripMenuItem.Size = new System.Drawing.Size(124, 22);
            this.清理路径ToolStripMenuItem.Text = "清理路径";
            this.清理路径ToolStripMenuItem.Click += new System.EventHandler(this.清理路径ToolStripMenuItem_Click);
            // 
            // 帮助ToolStripMenuItem
            // 
            this.帮助ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.使用说明ToolStripMenuItem});
            this.帮助ToolStripMenuItem.Name = "帮助ToolStripMenuItem";
            this.帮助ToolStripMenuItem.Size = new System.Drawing.Size(44, 21);
            this.帮助ToolStripMenuItem.Text = "帮助";
            // 
            // 使用说明ToolStripMenuItem
            // 
            this.使用说明ToolStripMenuItem.Name = "使用说明ToolStripMenuItem";
            this.使用说明ToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.使用说明ToolStripMenuItem.Text = "使用说明";
            this.使用说明ToolStripMenuItem.Click += new System.EventHandler(this.使用说明ToolStripMenuItem_Click);
            // 
            // FormMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(784, 633);
            this.Controls.Add(this.menuStrip1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.comboBoxOutTarget);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox5);
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.btnTest);
            this.Controls.Add(this.btnTrans);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FormMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "MDK5 2 VC2019 VC2017";
            this.Load += new System.EventHandler(this.FormMain_Load);
            this.SizeChanged += new System.EventHandler(this.FormMain_SizeChanged);
            this.contextMenuStrip1.ResumeLayout(false);
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.groupBox5.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button btnTrans;
        private System.Windows.Forms.Button btnTest;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.NotifyIcon notifyIcon1;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem 显示ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 退出ToolStripMenuItem;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel2;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel3;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel4;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel5;
        private System.Windows.Forms.TreeView treeView1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.TextBox TargetStatus;
        private System.Windows.Forms.GroupBox groupBox5;
        private System.Windows.Forms.GroupBox groupBox3;
        public System.Windows.Forms.Integration.ElementHost elementHost;
        private System.Windows.Forms.Label labelOpenProj;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label labelOpenVC;
        public System.Windows.Forms.Integration.ElementHost elementHost1;
        private System.Windows.Forms.ComboBox comboBoxTarget;
        private System.Windows.Forms.TextBox tBoxSlnPath;
        private System.Windows.Forms.ComboBox comboBoxMDKPath;
        private System.Windows.Forms.Button btnSelFileName;
        private System.Windows.Forms.ComboBox comboBoxOutTarget;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.CheckBox checkBoxManulSetTarget;
        private System.Windows.Forms.Button buttonLoadManulTarget;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem 文件ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 工具ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 清理路径ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 退出ToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem 帮助ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 使用说明ToolStripMenuItem;
    }
}

