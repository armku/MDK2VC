using MDK2VC.M2V;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace MDK2VC
{
    public partial class FormMain : Form
    {
        /// <summary>
        /// 项目配置
        /// </summary>
        SysConfig cfg;
        public FormMain()
        {
            InitializeComponent();
        }

        private void FormMain_Load(object sender, EventArgs e)
        {
            cfg = SysConfig.Current;
            tBoxMDKPath.Text = cfg.MdkPath;
            tBoxVCPath.Text = cfg.VcPath;
        }
    }
}
