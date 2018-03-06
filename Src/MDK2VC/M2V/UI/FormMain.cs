using MDK2VC.M2V;
using MDK2VC.M2V.Xml;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Text;
using System.Windows.Forms;

namespace MDK2VC
{
    public partial class FormMain : Form
    {
        CoreManager manager = new CoreManager();
        /// <summary>
        /// 项目配置
        /// </summary>
        SysConfig cfg=new SysConfig();
        public FormMain()
        {
            InitializeComponent();
        }

        private void FormMain_Load(object sender, EventArgs e)
        {
            cfg.MdkPath= Properties.Settings.Default.LastFileName;
            if (cfg.MdkPath.Length < 5)
                cfg.MdkPath = ".uvprojx";
            tBoxMDKPath.Text = cfg.MdkPath;
            tBoxvcxproj.Text = cfg.vcxproj;
            tboxfilters.Text = cfg.filters;
            tboxsln.Text = cfg.sln;
            btnSelMDKPath.Focus();
        }

        private void btnSelMDKPath_Click(object sender, EventArgs e)
        {
            var fileDlg = new OpenFileDialog();
            fileDlg.Multiselect = true;
            fileDlg.Title = "请选择文件";
            fileDlg.Filter = "MDK|*.uvprojx;*.uvproj";
            if (fileDlg.ShowDialog() == DialogResult.OK)
            {                
                cfg.MdkPath = fileDlg.FileName;

                tBoxMDKPath.Text = cfg.MdkPath;
                tBoxvcxproj.Text = cfg.vcxproj;
                tboxfilters.Text = cfg.filters;
                tboxsln.Text = cfg.sln;

                Properties.Settings.Default.LastFileName = cfg.MdkPath;
                Properties.Settings.Default.Save();
            }
        }
        
        private void btnTrans_Click(object sender, EventArgs e)
        {
            var builder = new StringBuilder();

            if((cfg.MdkPath==null) || (!File.Exists(cfg.MdkPath)))
            {
                MessageBox.Show("请选择正确的文件");
                btnSelMDKPath.Focus();
                return;
            }
            switch (Path.GetExtension(cfg.MdkPath))
            {
                case ".uvproj":
                    manager.from = new Fromuvprojx();
                    break;
                case ".uvprojx":
                    manager.from = new Fromuvprojx();
                    break;
                default:
                    break;
            }
            
            manager.to = new ToVC2017();

            cfg.MacroDefine = manager.from.GetMacroDefine(cfg.MdkPath);
            cfg.IncludePath = manager.from.getIncludePath(cfg.MdkPath);
            cfg.Groups = manager.from.getGroups(cfg.MdkPath);
            cfg.BuilderGroupsToFilters = manager.from.getGroupsToFilters(cfg.MdkPath);
            cfg.BuilderGroupsToProj = manager.from.getGroupsToProj(cfg.MdkPath);
            cfg.BuilderGrouptoFilters = manager.from.getGrouptoFilters(cfg.MdkPath);
            cfg.projguid = Guid.NewGuid().ToString("B");
            
            builder.AppendLine(cfg.MacroDefineStr);
            builder.AppendLine(cfg.IncludePath);
            builder.Append(cfg.Groups);
            richTextBox1.Text = builder.ToString();
        }
        
        private void btnTest_Click(object sender, EventArgs e)
        {           
            btnTrans_Click(sender, e);
            manager.to.createvcxproj(cfg);
            manager.to.createfilters(cfg);
            manager.to.createsln(cfg);
            label5.Text = "转换完：" + DateTime.Now.ToString("HH:mm:ss");
        }
        /// <summary>
        /// 打开文件
        /// </summary>
        /// <param name="file"></param>
        private void OpenFile(string file)
        {
            if (File.Exists(file))
                System.Diagnostics.Process.Start(file);
            else
                MessageBox.Show("文件不存在 "+file);
        }

        private void label1_Click(object sender, EventArgs e)
        {
            this.OpenFile(cfg.MdkPath);
        }

        private void notifyIcon1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (WindowState == FormWindowState.Minimized)
            {
                //还原窗体显示    
                WindowState = FormWindowState.Normal;
                //激活窗体并给予它焦点
                this.Activate();
                //任务栏区显示图标
                this.ShowInTaskbar = true;
                //托盘区图标隐藏
                notifyIcon1.Visible = false;
            }
        }

        private void 显示ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Normal;
        }

        private void 退出ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("是否确认退出程序？", "退出", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
            {
                // 关闭所有的线程
                this.Dispose();
                this.Close();
            }
        }

        private void FormMain_SizeChanged(object sender, EventArgs e)
        {
            //判断是否选择的是最小化按钮
            if (WindowState == FormWindowState.Minimized)
            {
                //隐藏任务栏区图标
                this.ShowInTaskbar = false;
                //图标显示在托盘区
                notifyIcon1.Visible = true;
            }
        }

        private void notifyIcon1_DoubleClick(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Normal;
        }

        private void label4_Click(object sender, EventArgs e)
        {
            this.OpenFile(cfg.sln);
        }
    }
}
