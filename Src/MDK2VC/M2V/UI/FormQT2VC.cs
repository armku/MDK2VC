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
        public Config_T cfg = new Config_T();
        public FormQT2VC()
        {
            InitializeComponent();
        }

        private void mDK2VCToolStripMenuItem_Click(object sender, EventArgs e)
        {
            base.Close();
        }
        void tosln()
        {
            var builder = new StringBuilder();

            builder.AppendLine("Microsoft Visual Studio Solution File, Format Version 12.00");
            builder.AppendLine("# Visual Studio Version 16");
            builder.AppendLine("VisualStudioVersion = 16.0.29201.188");
            builder.AppendLine("MinimumVisualStudioVersion = 10.0.40219.1");

            builder.Append("Project(\"{8BC9CEB8-8B4A-11D0-8D11-00A0C91BC942}\") = \"");
            builder.Append(cfg.FileNameWithoutExtension);
            builder.Append("\",\"");
            builder.Append(cfg.FileNameWithoutExtension);
            //builder.AppendLine(".vcxproj\", \"{0CEFE3F1-D04E-4470-8EBF-0A193EAD57AD}\"");
            builder.Append(".vcxproj\", \"");
            builder.Append(cfg.Projguidvc);
            builder.AppendLine("\"");

            builder.AppendLine("EndProject");
            builder.AppendLine("Global");
            builder.AppendLine("	GlobalSection(SolutionConfigurationPlatforms) = preSolution");
            //builder.AppendLine("		Debug|x64 = Debug|x64");
            builder.Append("		");
            builder.Append(cfg.FileNameWithoutExtension);
            builder.Append("|x86 = ");
            builder.Append(cfg.FileNameWithoutExtension);
            builder.AppendLine("|x86");

            builder.AppendLine("	EndGlobalSection");
            builder.AppendLine("	GlobalSection(ProjectConfigurationPlatforms) = postSolution");
            //builder.AppendLine("		{0CEFE3F1-D04E-4470-8EBF-0A193EAD57AD}.Debug|x64.ActiveCfg = Debug|x64");
            builder.Append("		");
            builder.Append(cfg.Projguidvc);
            //builder.AppendLine(".Debug|x64.ActiveCfg = Debug|x64");
            builder.Append(".");
            builder.Append(cfg.FileNameWithoutExtension);
            builder.Append("|x86.ActiveCfg = ");
            builder.Append(cfg.FileNameWithoutExtension);
            builder.AppendLine("|Win32");

            //builder.AppendLine("		{0CEFE3F1-D04E-4470-8EBF-0A193EAD57AD}.Debug|x64.Build.0 = Debug|x64");
            builder.Append("		");
            builder.Append(cfg.Projguidvc);
            //builder.AppendLine(".Debug|x64.Build.0 = Debug|x64");
            builder.Append(".");
            builder.Append(cfg.FileNameWithoutExtension);
            builder.Append("|x86.Build.0 = ");
            builder.Append(cfg.FileNameWithoutExtension);
            builder.AppendLine("|Win32");

            builder.AppendLine("	EndGlobalSection");
            builder.AppendLine("	GlobalSection(SolutionProperties) = preSolution");
            builder.AppendLine("		HideSolutionNode = FALSE");
            builder.AppendLine("	EndGlobalSection");
            builder.AppendLine("	GlobalSection(ExtensibilityGlobals) = postSolution");
            builder.AppendLine("		SolutionGuid = {133C6D99-11F2-4EE7-A3DA-7F3CF3AB45A5}");
            builder.AppendLine("	EndGlobalSection");
            builder.AppendLine("EndGlobal");

            var fs = new FileStream(cfg.Sln, FileMode.Create);
            byte[] data = new UTF8Encoding().GetBytes(builder.ToString());
            fs.Write(data);
            fs.Flush();
            fs.Close();
        }
        private void btnTest_Click(object sender, EventArgs e)
        {
            cfg.Sln = MDK2VCConfig.Current.StrQTVsFilePath;
            cfg.Projguidvc = Guid.NewGuid().ToString("B"); 
            cfg.FileNameWithoutExtension= Path.GetFileNameWithoutExtension(MDK2VCConfig.Current.StrQTVsFilePath);

            if(!Directory.Exists(Path.GetDirectoryName(cfg.Sln)))
            {
                Directory.CreateDirectory(Path.GetDirectoryName(cfg.Sln));
            }

            tosln();

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
    public class Config_T
    {
        public string FileNameWithoutExtension;
        public string Projguidvc;
        public string Sln;
    }
}
