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
        public void Createfilters()
        {
            var builder = new StringBuilder();

            builder.AppendLine("<?xml version=\"1.0\" encoding=\"utf-8\"?>");
            builder.AppendLine("<Project DefaultTargets=\"Build\" ToolsVersion=\"4.0\" xmlns=\"http://schemas.microsoft.com/developer/msbuild/2003\">");
            builder.AppendLine("  <ItemGroup>");
            builder.Append(cfg.ToFilter_files.ToString());
            //Fromuvprojx.getGrouptoFilters(builder, cfg.MdkPath);
            builder.AppendLine("  </ItemGroup>");
            builder.AppendLine("  <ItemGroup>");
            builder.Append(cfg.ToFilter_FileFolders.ToString());
            //Fromuvprojx.getGroupsToFilters(builder, cfg.MdkPath);
            builder.AppendLine("  </ItemGroup>");
            builder.AppendLine("</Project>");
            var fs = new FileStream(cfg.Filters, FileMode.Create);
            byte[] data = new UTF8Encoding().GetBytes(builder.ToString());
            fs.Write(data);
            fs.Flush();
            fs.Close();
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
        private String GetMacroDefineVC(string definestr)
        {
            var builder = new StringBuilder();
            builder.Append("      <PreprocessorDefinitions>");
            builder.Append(definestr).Append("%(PreprocessorDefinitions)</PreprocessorDefinitions>");
            return builder.ToString();
        }
        private String GetIncludePathVC()
        {
            var builder = new StringBuilder();
            builder.Append("      <AdditionalIncludeDirectories>");
            builder.Append(cfg.IncludePathStr);
            builder.Append(";%(AdditionalIncludeDirectories)</AdditionalIncludeDirectories>");
            return builder.ToString();
        }
        public void Createvcxproj()
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
            builder.Append("    <ProjectGuid>").Append(cfg.Projguidvc).AppendLine("</ProjectGuid>");
            builder.AppendLine("    <RootNamespace>STM32F1</RootNamespace>");
            builder.AppendLine("    <WindowsTargetPlatformVersion>10.0</WindowsTargetPlatformVersion>");
            builder.AppendLine("  </PropertyGroup>");
            builder.AppendLine("  <Import Project=\"$(VCTargetsPath)\\Microsoft.Cpp.Default.props\" />");
            builder.AppendLine("  <PropertyGroup Condition=\"'$(Configuration)|$(Platform)' == 'Debug|Win32'\" Label=\"Configuration\">");
            builder.AppendLine("    <ConfigurationType>Application</ConfigurationType>");
            builder.AppendLine("    <UseDebugLibraries>true</UseDebugLibraries>");
            builder.AppendLine("    <PlatformToolset>v142</PlatformToolset>");
            builder.AppendLine("    <CharacterSet>MultiByte</CharacterSet>");
            builder.AppendLine("  </PropertyGroup>");
            builder.AppendLine("  <PropertyGroup Condition=\"'$(Configuration)|$(Platform)' == 'Release|Win32'\" Label=\"Configuration\">");
            builder.AppendLine("    <ConfigurationType>Application</ConfigurationType>");
            builder.AppendLine("    <UseDebugLibraries>false</UseDebugLibraries>");
            builder.AppendLine("    <PlatformToolset>v142</PlatformToolset>");
            builder.AppendLine("    <WholeProgramOptimization>true</WholeProgramOptimization>");
            builder.AppendLine("    <CharacterSet>MultiByte</CharacterSet>");
            builder.AppendLine("  </PropertyGroup>");
            builder.AppendLine("  <PropertyGroup Condition=\"'$(Configuration)|$(Platform)' == 'Debug|x64'\" Label=\"Configuration\">");
            builder.AppendLine("    <ConfigurationType>Application</ConfigurationType>");
            builder.AppendLine("    <UseDebugLibraries>true</UseDebugLibraries>");
            builder.AppendLine("    <PlatformToolset>v142</PlatformToolset>");
            builder.AppendLine("    <CharacterSet>MultiByte</CharacterSet>");
            builder.AppendLine("  </PropertyGroup>");
            builder.AppendLine("  <PropertyGroup Condition=\"'$(Configuration)|$(Platform)' == 'Release|x64'\" Label=\"Configuration\">");
            builder.AppendLine("    <ConfigurationType>Application</ConfigurationType>");
            builder.AppendLine("    <UseDebugLibraries>false</UseDebugLibraries>");
            builder.AppendLine("    <PlatformToolset>v142</PlatformToolset>");
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
            builder.AppendLine(this.GetIncludePathVC());
            builder.AppendLine(this.GetMacroDefineVC(cfg.MacroDefineStr));
            builder.AppendLine("    </ClCompile>");
            builder.AppendLine("  </ItemDefinitionGroup>");
            builder.AppendLine("  <ItemDefinitionGroup Condition=\"'$(Configuration)|$(Platform)' == 'Debug|x64'\">");
            builder.AppendLine("    <ClCompile>");
            builder.AppendLine("      <WarningLevel>Level3</WarningLevel>");
            builder.AppendLine("      <Optimization>Disabled</Optimization>");
            builder.AppendLine("      <SDLCheck>true</SDLCheck>");
            builder.AppendLine("      <ConformanceMode>true</ConformanceMode>");
            builder.AppendLine(this.GetIncludePathVC());
            builder.AppendLine(this.GetMacroDefineVC(cfg.MacroDefineStr));
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
            builder.AppendLine(this.GetIncludePathVC());
            builder.AppendLine(this.GetMacroDefineVC(cfg.MacroDefineStr));
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
            builder.AppendLine(this.GetIncludePathVC());
            builder.AppendLine(this.GetMacroDefineVC(cfg.MacroDefineStr));
            builder.AppendLine("    </ClCompile>");
            builder.AppendLine(@"    <Link>");
            builder.AppendLine(@"      <EnableCOMDATFolding>true</EnableCOMDATFolding>");
            builder.AppendLine(@"      <OptimizeReferences>true</OptimizeReferences>");
            builder.AppendLine(@"    </Link>");
            builder.AppendLine(@"  </ItemDefinitionGroup>");
            builder.AppendLine(@"  <ItemGroup>");
            //Fromuvprojx.getGroupsToProj(builder, cfg.MdkPath);
            builder.Append(cfg.ToProj_Files.ToString());
            builder.AppendLine(@"  </ItemGroup>");
            builder.AppendLine("  <Import Project=\"$(VCTargetsPath)\\Microsoft.Cpp.targets\" />");
            builder.AppendLine("  <ImportGroup Label=\"ExtensionTargets\">");
            builder.AppendLine(@"  </ImportGroup>");
            builder.AppendLine(@"</Project>");

            if (!Directory.Exists(cfg.VCPath))
            {
                Directory.CreateDirectory(cfg.VCPath);
            }
            var fs = new FileStream(cfg.Vcxproj, FileMode.Create);
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
            Createvcxproj();
            Createfilters();

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

        public string Filters;
        public string ToFilter_FileFolders;
        public string ToFilter_files;
        public string ToProj_Files;
        public string VCPath;
        public string Vcxproj;
        public string MacroDefineStr;
        public string IncludePathStr;
    }
}
