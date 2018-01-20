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
            tBoxvcxproj.Text = cfg.vcxproj;
            tboxfilters.Text = cfg.filters;
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
            fileDlg.Filter = "VC项目|*.vcxproj";
            if (fileDlg.ShowDialog() == DialogResult.OK)
            {
                tBoxvcxproj.Text = fileDlg.FileName;
                cfg.vcxproj = fileDlg.FileName;
                cfg.filters = cfg.vcxproj + ".filters";
                tboxfilters.Text = cfg.filters;
                cfg.Save();
            }
        }

        private void btnTrans_Click(object sender, EventArgs e)
        {
            var builder = new StringBuilder();
            getDefine(builder);
            builder.AppendLine(getIncludePath());
            getGroups(builder);
            richTextBox1.Text = builder.ToString();
        }
        string getIncludePath()
        {
            var doc = XElement.Load(cfg.MdkPath);
            var Targets = doc.Element("Targets");
            var Target = Targets.Element("Target");
            var TargetOption = Target.Element("TargetOption");
            var TargetArmAds = TargetOption.Element("TargetArmAds");
            var Cads = TargetArmAds.Element("Cads");
            var VariousControls = Cads.Element("VariousControls");
            var IncludePath = VariousControls.Element("IncludePath");

            return IncludePath.Value;

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
        void getDefineToVc(StringBuilder builder)
        {
            var doc = XElement.Load(cfg.MdkPath);
            var Targets = doc.Element("Targets");
            var Target = Targets.Element("Target");
            var TargetOption = Target.Element("TargetOption");
            var TargetArmAds = TargetOption.Element("TargetArmAds");
            var Cads = TargetArmAds.Element("Cads");
            var VariousControls = Cads.Element("VariousControls");
            var Define = VariousControls.Element("Define");

            builder.Append("      <PreprocessorDefinitions>");

            var strs = Define.Value.ToString().Split(new char[] { ','});
            foreach(var str in strs)
            {
                builder.Append(str).Append(";");
            }            
            builder.AppendLine("%(PreprocessorDefinitions)</PreprocessorDefinitions>");
        }
        void getGroups(StringBuilder builder)
        {
            var doc = XElement.Load(cfg.MdkPath);
            var Targets = doc.Element("Targets");
            var Target = Targets.Element("Target");
            var Groups = Target.Element("Groups");

            var Group = Groups.Elements("Group");
            foreach (var grou in Group)
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
        void getGroupsToFilters(StringBuilder builder)
        {
            var doc = XElement.Load(cfg.MdkPath);
            var Targets = doc.Element("Targets");
            var Target = Targets.Element("Target");
            var Groups = Target.Element("Groups");

            var Group = Groups.Elements("Group");
            foreach (var grou in Group)
            {
                var aa = grou.Element("GroupName");                
                var Files = grou.Elements("Files");
                foreach (var File in Files)
                {
                    var file = File.Elements("File");
                    foreach (var ff in file)
                    {
                        var FilePath = ff.Element("FilePath");
                        builder.Append("    <ClCompile Include=\"");
                        if (FilePath != null)
                            builder.Append(FilePath.Value);
                        builder.AppendLine("\">");
                        builder.Append("      <Filter>").Append(aa.Value).AppendLine("</Filter>");
                        builder.AppendLine("    </ClCompile>");
                    }
                }
            }
        }
        void getGroupsToProj(StringBuilder builder)
        {
            var doc = XElement.Load(cfg.MdkPath);
            var Targets = doc.Element("Targets");
            var Target = Targets.Element("Target");
            var Groups = Target.Element("Groups");

            var Group = Groups.Elements("Group");
            foreach (var grou in Group)
            {
                var aa = grou.Element("GroupName");
                var Files = grou.Elements("Files");
                foreach (var File in Files)
                {
                    var file = File.Elements("File");
                    foreach (var ff in file)
                    {
                        var FilePath = ff.Element("FilePath");
                        builder.Append("    <ClCompile Include=\"");
                        if (FilePath != null)
                            builder.Append(FilePath.Value);
                        builder.AppendLine("\" /> ");
                    }
                }
            }
        }
        void getGrouptoFilters(StringBuilder builder)
        {
            var doc = XElement.Load(cfg.MdkPath);
            var Targets = doc.Element("Targets");
            var Target = Targets.Element("Target");
            var Groups = Target.Element("Groups");

            var Group = Groups.Elements("Group");
            foreach (var grou in Group)
            {
                var aa = grou.Element("GroupName");
                builder.Append("    <Filter Include=\"").Append(aa.Value).AppendLine("\">");
                builder.AppendLine("      <UniqueIdentifier>{926455ce-06fe-4d2e-a713-9c90bcdea046}</UniqueIdentifier>");
                builder.AppendLine("    </Filter>");
            }
        }

        void createvcxproj(string filename, string name)
        {
            var builder = new StringBuilder();
            builder.AppendLine("<?xml version=\"1.0\" encoding=\"utf-8\"?>");
            builder.AppendLine("<Project DefaultTargets=\"Build\" ToolsVersion=\"15.0\" xmlns=\"http://schemas.microsoft.com/developer/msbuild/2003\">");
            builder.AppendLine("  <ItemGroup Label=\"ProjectConfigurations\">");
            builder.AppendLine("    <ProjectConfiguration Include=\"Debug | Win32\">");
            builder.AppendLine("      <Configuration>Debug</Configuration>");
            builder.AppendLine("      <Platform>Win32</Platform>");
            builder.AppendLine("    </ProjectConfiguration>");
            builder.AppendLine("    <ProjectConfiguration Include=\"Release | Win32\">");
            builder.AppendLine("      <Configuration>Release</Configuration>");
            builder.AppendLine("      <Platform>Win32</Platform>");
            builder.AppendLine("    </ProjectConfiguration>");
            builder.AppendLine("    <ProjectConfiguration Include=\"Debug | x64\">");
            builder.AppendLine("      <Configuration>Debug</Configuration>");
            builder.AppendLine("      <Platform>x64</Platform>");
            builder.AppendLine("    </ProjectConfiguration>");
            builder.AppendLine("    <ProjectConfiguration Include=\"Release | x64\">");
            builder.AppendLine("      <Configuration>Release</Configuration>");
            builder.AppendLine("      <Platform>x64</Platform>");
            builder.AppendLine("    </ProjectConfiguration>");
            builder.AppendLine("  </ItemGroup>");
            builder.AppendLine("  <PropertyGroup Label=\"Globals\">");
            builder.AppendLine("    <VCProjectVersion>15.0</VCProjectVersion>");
            builder.AppendLine("    <ProjectGuid>{DB72F4F2-0882-46C5-83D8-39933DDC3412}</ProjectGuid>");
            builder.AppendLine("    <RootNamespace>STM32F1</RootNamespace>");
            builder.AppendLine("    <WindowsTargetPlatformVersion>10.0.16299.0</WindowsTargetPlatformVersion>");
            builder.AppendLine("  </PropertyGroup>");
            builder.AppendLine("  <Import Project=\"$(VCTargetsPath)\\Microsoft.Cpp.Default.props\" />");
            builder.AppendLine("  <PropertyGroup Condition=\"'$(Configuration)|$(Platform)' == 'Debug|Win32'\" Label=\"Configuration\">");
            builder.AppendLine("    <ConfigurationType>Application</ConfigurationType>");
            builder.AppendLine("    <UseDebugLibraries>true</UseDebugLibraries>");
            builder.AppendLine("    <PlatformToolset>v141</PlatformToolset>");
            builder.AppendLine("    <CharacterSet>MultiByte</CharacterSet>");
            builder.AppendLine("  </PropertyGroup>");
            builder.AppendLine("  <PropertyGroup Condition=\"'$(Configuration)|$(Platform)' == 'Release|Win32'\" Label=\"Configuration\">");
            builder.AppendLine("    <ConfigurationType>Application</ConfigurationType>");
            builder.AppendLine("    <UseDebugLibraries>false</UseDebugLibraries>");
            builder.AppendLine("    <PlatformToolset>v141</PlatformToolset>");
            builder.AppendLine("    <WholeProgramOptimization>true</WholeProgramOptimization>");
            builder.AppendLine("    <CharacterSet>MultiByte</CharacterSet>");
            builder.AppendLine("  </PropertyGroup>");
            builder.AppendLine("  <PropertyGroup Condition=\"'$(Configuration)|$(Platform)' == 'Debug|x64'\" Label=\"Configuration\">");
            builder.AppendLine("    <ConfigurationType>Application</ConfigurationType>");
            builder.AppendLine("    <UseDebugLibraries>true</UseDebugLibraries>");
            builder.AppendLine("    <PlatformToolset>v141</PlatformToolset>");
            builder.AppendLine("    <CharacterSet>MultiByte</CharacterSet>");
            builder.AppendLine("  </PropertyGroup>");
            builder.AppendLine("  <PropertyGroup Condition=\"'$(Configuration)|$(Platform)' == 'Release|x64'\" Label=\"Configuration\">");
            builder.AppendLine("    <ConfigurationType>Application</ConfigurationType>");
            builder.AppendLine("    <UseDebugLibraries>false</UseDebugLibraries>");
            builder.AppendLine("    <PlatformToolset>v141</PlatformToolset>");
            builder.AppendLine("    <WholeProgramOptimization>true</WholeProgramOptimization>");
            builder.AppendLine("    <CharacterSet>MultiByte</CharacterSet>");
            builder.AppendLine("  </PropertyGroup>");
            builder.AppendLine("  <Import Project=\"$(VCTargetsPath)\\Microsoft.Cpp.props\" />");
            builder.AppendLine("  <ImportGroup Label=\"ExtensionSettings\">");
            builder.AppendLine("  </ImportGroup>");
            builder.AppendLine("  <ImportGroup Label=\"Shared\">");
            builder.AppendLine("  </ImportGroup>");
            builder.AppendLine("  <ImportGroup Label=\"PropertySheets\" Condition=\"'$(Configuration)|$(Platform)' == 'Debug|Win32'\">");
            builder.AppendLine("    <Import Project=\"$(UserRootDir)\\Microsoft.Cpp.$(Platform).user.props\" Condition=\"exists('$(UserRootDir)\\Microsoft.Cpp.$(Platform).user.props')\" Label=\"LocalAppDataPlatform\" />");
            builder.AppendLine("  </ImportGroup>");
            builder.AppendLine("  <ImportGroup Label=\"PropertySheets\" Condition=\"'$(Configuration)|$(Platform)' == 'Release|Win32'\">");
            builder.AppendLine("    <Import Project=\"$(UserRootDir)\\Microsoft.Cpp.$(Platform).user.props\" Condition=\"exists('$(UserRootDir)\\Microsoft.Cpp.$(Platform).user.props')\" Label=\"LocalAppDataPlatform\" />");
            builder.AppendLine("  </ImportGroup>");
            builder.AppendLine("  <ImportGroup Label=\"PropertySheets\\\" Condition=\"'$(Configuration)|$(Platform)' == 'Debug|x64'\">");
            builder.AppendLine("    <Import Project=\"$(UserRootDir)\\Microsoft.Cpp.$(Platform).user.props\" Condition=\"exists('$(UserRootDir)\\Microsoft.Cpp.$(Platform).user.props')\" Label=\"LocalAppDataPlatform\" />");
            builder.AppendLine("  </ImportGroup>");
            builder.AppendLine("  <ImportGroup Label=\"PropertySheets\" Condition=\"'$(Configuration)|$(Platform)' == 'Release|x64'\">");
            builder.AppendLine("    <Import Project=\"$(UserRootDir)\\Microsoft.Cpp.$(Platform).user.props\" Condition=\"exists('$(UserRootDir)\\Microsoft.Cpp.$(Platform).user.props')\" Label=\"LocalAppDataPlatform\" />");
            builder.AppendLine("  </ImportGroup>");
            builder.AppendLine("  <PropertyGroup Label=\"UserMacros\" />");
            builder.AppendLine("  <PropertyGroup />");
            builder.AppendLine("  <ItemDefinitionGroup Condition=\"'$(Configuration)|$(Platform)' == 'Debug|Win32'\">");
            builder.AppendLine("    <ClCompile>");
            builder.AppendLine("      <WarningLevel>Level3</WarningLevel>");
            builder.AppendLine("      <Optimization>Disabled</Optimization>");
            builder.AppendLine("      <SDLCheck>true</SDLCheck>");
            builder.AppendLine("      <ConformanceMode>true</ConformanceMode>");
            builder.AppendLine("    </ClCompile>");
            builder.AppendLine("  </ItemDefinitionGroup>");
            builder.AppendLine("  <ItemDefinitionGroup Condition=\"'$(Configuration)|$(Platform)' == 'Debug|x64'\">");
            builder.AppendLine("    <ClCompile>");
            builder.AppendLine("      <WarningLevel>Level3</WarningLevel>");
            builder.AppendLine("      <Optimization>Disabled</Optimization>");
            builder.AppendLine("      <SDLCheck>true</SDLCheck>");
            builder.AppendLine("      <ConformanceMode>true</ConformanceMode>");            
            builder.Append(@"      <AdditionalIncludeDirectories>");
            builder.Append(getIncludePath()).AppendLine(";%(AdditionalIncludeDirectories)</AdditionalIncludeDirectories>");
            getDefineToVc(builder);
            builder.AppendLine("    </ClCompile>");
            builder.AppendLine("  </ItemDefinitionGroup>");
            builder.AppendLine("  <ItemDefinitionGroup Condition=\"'$(Configuration)|$(Platform)' == 'Release|Win32'\">");
            builder.AppendLine("    <ClCompile>");
            builder.AppendLine("      <WarningLevel>Level3</WarningLevel>");
            builder.AppendLine("      <Optimization>MaxSpeed</Optimization>");
            builder.AppendLine("      <FunctionLevelLinking>true</FunctionLevelLinking>");
            builder.AppendLine("      <IntrinsicFunctions>true</IntrinsicFunctions>");
            builder.AppendLine("      <SDLCheck>true</SDLCheck>");
            builder.AppendLine("      <ConformanceMode>true</ConformanceMode>");
            builder.AppendLine("    </ClCompile>");
            builder.AppendLine("    <Link>");
            builder.AppendLine("      <EnableCOMDATFolding>true</EnableCOMDATFolding>");
            builder.AppendLine("      <OptimizeReferences>true</OptimizeReferences>");
            builder.AppendLine("    </Link>");
            builder.AppendLine("  </ItemDefinitionGroup>");
            builder.AppendLine("  <ItemDefinitionGroup Condition=\"'$(Configuration)|$(Platform)' == 'Release|x64'\">");
            builder.AppendLine("    <ClCompile>");
            builder.AppendLine("      <WarningLevel>Level3</WarningLevel>");
            builder.AppendLine("      <Optimization>MaxSpeed</Optimization>");
            builder.AppendLine("      <FunctionLevelLinking>true</FunctionLevelLinking>");
            builder.AppendLine("      <IntrinsicFunctions>true</IntrinsicFunctions>");
            builder.AppendLine("      <SDLCheck>true</SDLCheck>");
            builder.AppendLine("      <ConformanceMode>true</ConformanceMode>");
            builder.AppendLine(@"      <AdditionalIncludeDirectories>..\..\..\STDOS\STDOS;..\..\..\STDOS\SYSTEM\STM32F1\CMSIS;..\..\..\STDOS\SYSTEM\STM32F1\FWLib\inc;..\..\..\STDOS\STDOS\Kernel;..\..\..\STDOS\STDOS\Device;..\..\..\STDOS\STDOS\Core;..\..\..\STDOS\SYSTEM\STM32F1\startup;%(AdditionalIncludeDirectories)</AdditionalIncludeDirectories>");
            builder.AppendLine("      <PreprocessorDefinitions>STM32F10X_HD;STM32F1;DEBUG;USE_STDPERIPH_DRIVER;%(PreprocessorDefinitions)</PreprocessorDefinitions>");
            builder.AppendLine("    </ClCompile>");
            builder.AppendLine(@"    <Link>");
            builder.AppendLine(@"      <EnableCOMDATFolding>true</EnableCOMDATFolding>");
            builder.AppendLine(@"      <OptimizeReferences>true</OptimizeReferences>");
            builder.AppendLine(@"    </Link>");
            builder.AppendLine(@"  </ItemDefinitionGroup>");
            builder.AppendLine(@"  <ItemGroup>");
            getGroupsToProj(builder);
            builder.AppendLine(@"  </ItemGroup>");
            builder.AppendLine("  <Import Project=\"$(VCTargetsPath)\\Microsoft.Cpp.targets\" />");
            builder.AppendLine("  <ImportGroup Label=\"ExtensionTargets\">");
            builder.AppendLine(@"  </ImportGroup>");
            builder.AppendLine(@"</Project>");

            var fs = new FileStream(filename, FileMode.Create);
            byte[] data = new UTF8Encoding().GetBytes(builder.ToString());
            fs.Write(data);
            fs.Flush();
            fs.Close();
        }
        void createfilters(string filename)
        {
            var builder = new StringBuilder();

            builder.AppendLine("<?xml version=\"1.0\" encoding=\"utf-8\"?>");
            builder.AppendLine("<Project ToolsVersion=\"4.0\" xmlns=\"http://schemas.microsoft.com/developer/msbuild/2003\">");
            builder.AppendLine("  <ItemGroup>");
            getGrouptoFilters(builder);
            builder.AppendLine("  </ItemGroup>");
            builder.AppendLine("  <ItemGroup>");
            getGroupsToFilters(builder);
            builder.AppendLine("  </ItemGroup>");
            builder.AppendLine("</Project>");

            var fs = new FileStream(filename, FileMode.Create);
            byte[] data = new UTF8Encoding().GetBytes(builder.ToString());
            fs.Write(data);
            fs.Flush();
            fs.Close();
        }

        private void btnTest_Click(object sender, EventArgs e)
        {
            createvcxproj(cfg.vcxproj, @".\demo.dsp");
            createfilters(cfg.filters);
        }

        private void btnOpenDsw_Click(object sender, EventArgs e)
        {
            var fileDlg = new SaveFileDialog();
            fileDlg.Title = "请选择文件";
            fileDlg.Filter = "VC项目|*.filters";
            if (fileDlg.ShowDialog() == DialogResult.OK)
            {
                tboxfilters.Text = fileDlg.FileName;
                cfg.filters = fileDlg.FileName;
                cfg.Save();
            }
        }
    }
}
