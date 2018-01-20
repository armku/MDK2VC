using MDK2VC.M2V;
using MDK2VC.M2V.Xml;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
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
        XMLHelper helper = new XMLHelper();
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
        }

        private void btnSelMDKPath_Click(object sender, EventArgs e)
        {
            var fileDlg = new OpenFileDialog();
            fileDlg.Multiselect = true;
            fileDlg.Title = "请选择文件";
            fileDlg.Filter = "MDK|*.uvprojx";
            if (fileDlg.ShowDialog() == DialogResult.OK)
            {
                tBoxMDKPath.Text = fileDlg.FileName;
                cfg.MdkPath = fileDlg.FileName;
                var fp = cfg.MdkPath.Substring(0,cfg.MdkPath.Length-7);
                cfg.vcxproj = fp + "vcxproj";
                cfg.filters = fp + "filters";
                cfg.sln = fp + "sln";

                tBoxvcxproj.Text = cfg.vcxproj;
                tboxfilters.Text = cfg.filters;
                tboxsln.Text = cfg.sln;                
            }
        }
        
        private void btnTrans_Click(object sender, EventArgs e)
        {
            var builder = new StringBuilder();
            helper.getDefine(builder,cfg.MdkPath);
            builder.AppendLine(helper.getIncludePath(cfg.MdkPath));
            helper.getGroups(builder,cfg.MdkPath);
            richTextBox1.Text = builder.ToString();
        }
        
        private void btnTest_Click(object sender, EventArgs e)
        {
            helper.createvcxproj(cfg.vcxproj,cfg.MdkPath);
            helper.createfilters(cfg.filters,cfg.MdkPath);
            helper.createsln(cfg.sln);
        }        
    }
}
