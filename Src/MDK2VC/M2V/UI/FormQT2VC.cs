using MDK2VC.M2V.Config;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;


namespace MDK2VC.M2V.UI
{
    public partial class FormQT2VC : Form
    {
        public FormQT2VC()
        {
            InitializeComponent();
        }

        private void mDK2VCToolStripMenuItem_Click(object sender, EventArgs e)
        {
            base.Close();
        }

        private void btnTest_Click(object sender, EventArgs e)
        {

        }
        string GetVsPath(string str)
        {
            var path = Path.GetDirectoryName(str);
            var file = Path.GetFileName(str);
            var fileonly = Path.GetFileNameWithoutExtension(str);

            return path + @"\VC2019\" + fileonly + ".sln";
        }
        private void btnSelFileName_Click(object sender, EventArgs e)
        {
            var fileDlg = new OpenFileDialog
            {
                Multiselect = true,
                Title = "请选择文件",
                Filter = "QT|*.pro"
            };
            if (fileDlg.ShowDialog() == DialogResult.OK)
            {
                comboBoxMDKPath.Text = fileDlg.FileName;
                tBoxSlnPath.Text = GetVsPath(comboBoxMDKPath.Text);
            }
            MDK2VCConfig.Current.StrQTFilePath = comboBoxMDKPath.Text;
            MDK2VCConfig.Current.StrQTVsFilePath = tBoxSlnPath.Text;
            MDK2VCConfig.Current.Save();
        }

        private void FormQT2VC_Load(object sender, EventArgs e)
        {
            comboBoxMDKPath.Text = MDK2VCConfig.Current.StrQTFilePath;
            tBoxSlnPath.Text = MDK2VCConfig.Current.StrQTVsFilePath;
        }
    }
}
