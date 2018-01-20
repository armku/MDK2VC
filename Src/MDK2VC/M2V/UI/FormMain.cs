using MDK2VC.M2V;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Xml;
using System.Xml.Linq;

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
            tBoxVCPathdsp.Text = cfg.vcdsp;
            tboxdsw.Text = cfg.vcdsw;
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
                cfg.Save();
            }
        }

        private void btnSelectVCPath_Click(object sender, EventArgs e)
        {
            var fileDlg = new SaveFileDialog();
            fileDlg.Title = "请选择文件";
            fileDlg.Filter = "VC项目|*.dsp";
            if (fileDlg.ShowDialog() == DialogResult.OK)
            {
                tBoxVCPathdsp.Text = fileDlg.FileName;
                cfg.vcdsp = fileDlg.FileName;
                cfg.Save();
            }
        }

        private void btnTrans_Click(object sender, EventArgs e)
        {
            var builder = new StringBuilder();
            getDefine(builder);
            getIncludePath(builder);
            getGroups(builder);
            richTextBox1.Text = builder.ToString();
        }
        void getIncludePath(StringBuilder builder)
        {
            var doc = XElement.Load(cfg.MdkPath);
            var Targets = doc.Element("Targets");
            var Target = Targets.Element("Target");
            var TargetOption = Target.Element("TargetOption");
            var TargetArmAds = TargetOption.Element("TargetArmAds");
            var Cads = TargetArmAds.Element("Cads");
            var VariousControls = Cads.Element("VariousControls");
            var IncludePath = VariousControls.Element("IncludePath");
                                   
            builder.AppendLine(IncludePath.Value);
           
        }
        void getDefine(StringBuilder builder)
        {
            var doc = XElement.Load(cfg.MdkPath);
            var Targets = doc.Element("Targets");
            var Target = Targets.Element("Target");
            var TargetOption = Target.Element("TargetOption");
            var TargetArmAds = TargetOption.Element("TargetArmAds");
            var Cads = TargetArmAds.Element("Cads");
            var VariousControls = Cads.Element("VariousControls");
            var Define = VariousControls.Element("Define");
                        
            builder.AppendLine(Define.Value);
        }
        void getGroups(StringBuilder builder)
        {
            var doc = XElement.Load(cfg.MdkPath);
            var Targets = doc.Element("Targets");
            var Target = Targets.Element("Target");
            var Groups = Target.Element("Groups");

            var Group = Groups.Elements("Group");
            foreach(var grou in Group)
            {                
                var aa = grou.Element("GroupName");
                builder.AppendLine(aa.Value);
                var Files = grou.Elements("Files");
                foreach (var File in Files)
                {
                    var file = File.Elements("File");
                    foreach (var ff in file)
                    {
                        var FilePath = ff.Element("FilePath");
                        if (FilePath != null)
                            builder.AppendLine(FilePath.Value);
                    }
                }
            }
        }
        void createdsw(string filename,string name)
        {
            var builder = new StringBuilder();
            builder.AppendLine("Microsoft Developer Studio Workspace File, Format Version 6.00");
            builder.AppendLine("# WARNING: DO NOT EDIT OR DELETE THIS WORKSPACE FILE!");
            builder.AppendLine("");
            builder.AppendLine("###############################################################################");
            builder.AppendLine("");
            builder.Append(@"Project: ").Append(@"""demo""=").Append(name).AppendLine(@" - Package Owner=<4>");
            builder.AppendLine("");
            builder.AppendLine(@"Package=<5>");
            builder.AppendLine("{{{");
            builder.AppendLine("}}}");
            builder.AppendLine("");
            builder.AppendLine(@"Package=<4>");
            builder.AppendLine("{{{");
            builder.AppendLine("}}}");
            builder.AppendLine("");
            builder.AppendLine("###############################################################################");
            builder.AppendLine("");
            builder.AppendLine("Global:");
            builder.AppendLine("");
            builder.AppendLine(@"Package=<5>");
            builder.AppendLine("{{{");
            builder.AppendLine("}}}");
            builder.AppendLine("");
            builder.AppendLine(@"Package=<3>");
            builder.AppendLine("{{{");
            builder.AppendLine("}}}");
            builder.AppendLine("");
            builder.AppendLine("###############################################################################");
            builder.AppendLine("");

            var fs = new FileStream(filename, FileMode.Create);
            byte[] data = new UTF8Encoding().GetBytes(builder.ToString());
            fs.Write(data);
            fs.Flush();
            fs.Close();
        }

        private void btnTest_Click(object sender, EventArgs e)
        {
           createdsw(cfg.vcdsw, @".\demo.dsp");





            var builderdef = new StringBuilder();
            getDefine(builderdef);

            

            var builderinclude = new StringBuilder();
            getIncludePath(builderinclude);

            var xDoc = new XDocument();
            var Project = new XElement("Project",new XAttribute("DefaultTargets", "Build"));
            var ItemGroup = new XElement("ItemGroup",new XAttribute("Label", "ProjectConfigurations"));

            var PropertyGroup = new XElement("PropertyGroup", new XAttribute("Label", "Globals"));
            //var ProjectGuid = new XElement("ProjectGuid",new XAttribute("", @"{DB72F4F2-0882-46C5-83D8-39933DDC3412}"));

            Project.Add(PropertyGroup);

            var ItemDefinitionGroup = new XElement("ItemDefinitionGroup",new XAttribute("Condition", @"'$(Configuration)|$(Platform)'=='Release|x64'"));
            var ClCompile = new XElement("ClCompile");
            var AdditionalIncludeDirectories = new XElement("AdditionalIncludeDirectories", builderinclude.ToString());
            var PreprocessorDefinitions = new XElement("PreprocessorDefinitions", builderdef.ToString()+@";%(PreprocessorDefinitions)");


            ClCompile.Add(AdditionalIncludeDirectories);
            ClCompile.Add(PreprocessorDefinitions);

            ItemDefinitionGroup.Add(ClCompile);

            var ItemGroupfiles = new XElement("ItemGroup");
            for(int i=0;i<10;i++)
            {
                var f1 = new XElement("ClCompile" , new XAttribute("Include", @"..\..\STDOS\App\AT.cpp"));   
                
                ItemGroupfiles.Add(f1);
            }



            Project.Add(ItemGroup);
            Project.Add(ItemDefinitionGroup);
            Project.Add(ItemGroupfiles);


            xDoc.Add(Project);


            xDoc.Save(cfg.vcdsp);
        }

        private void btnOpenDsw_Click(object sender, EventArgs e)
        {
            var fileDlg = new SaveFileDialog();
            fileDlg.Title = "请选择文件";
            fileDlg.Filter = "VC项目|*.dsw";
            if (fileDlg.ShowDialog() == DialogResult.OK)
            {
                tboxdsw .Text = fileDlg.FileName;
                cfg.vcdsw = fileDlg.FileName;
                cfg.Save();
            }
        }
    }
}
