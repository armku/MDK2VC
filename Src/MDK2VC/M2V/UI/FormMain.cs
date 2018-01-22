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
            fileDlg.Filter = "MDK|*.uvprojx";
            if (fileDlg.ShowDialog() == DialogResult.OK)
            {                
                cfg.MdkPath = fileDlg.FileName;

                tBoxMDKPath.Text = cfg.MdkPath;
                tBoxvcxproj.Text = cfg.vcxproj;
                tboxfilters.Text = cfg.filters;
                tboxsln.Text = cfg.sln;                
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

            cfg.MacroDefine = FromMDK5.GetMacroDefine(cfg.MdkPath);
            cfg.IncludePath = FromMDK5.getIncludePath(cfg.MdkPath);
            builder.AppendLine(cfg.MacroDefine);


            builder.AppendLine(cfg.IncludePath);
            FromMDK5.getGroups(builder,cfg.MdkPath);
            richTextBox1.Text = builder.ToString();
        }
        
        private void btnTest_Click(object sender, EventArgs e)
        {
            if ((cfg.MdkPath == null) || (!File.Exists(cfg.MdkPath)))
            {
                MessageBox.Show("请选择正确的文件");
                btnSelMDKPath.Focus();
                return;
            }
            cfg.MacroDefine = FromMDK5.GetMacroDefine(cfg.MdkPath);
            cfg.IncludePath = FromMDK5.getIncludePath(cfg.MdkPath);
            cfg.projguid = Guid.NewGuid().ToString("B");
            ToVC2017.createvcxproj(cfg);
            ToVC2017.createfilters(cfg);
            ToVC2017.createsln(cfg);
            label5.Text = "转换完：" + DateTime.Now.ToString("HH:mm:ss");
        }
    }
}
