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

            builder.Append("# ADD CPP /nologo /W3 /GX /O2 /D \"WIN32\" /D \"NDEBUG\" /D \"_WINDOWS\" /D \"_MBCS\"");

            var strs = Define.Value.ToString().Split(new char[] { ','});
            foreach(var str in strs)
            {
                builder.Append(" /D ").Append(str);
            }            
            builder.AppendLine(" /YX /FD /c");
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
        void getGroupsToVc(StringBuilder builder)
        {
            var doc = XElement.Load(cfg.MdkPath);
            var Targets = doc.Element("Targets");
            var Target = Targets.Element("Target");
            var Groups = Target.Element("Groups");

            var Group = Groups.Elements("Group");
            foreach (var grou in Group)
            {
                var aa = grou.Element("GroupName");
                builder.Append("# Begin Group \"").Append(aa.Value).AppendLine("\"");
                builder.AppendLine("");
                builder.AppendLine("# PROP Default_Filter \"cpp; c; cxx; rc; def; r; odl; idl; hpj; bat\"");
                
                var Files = grou.Elements("Files");
                foreach (var File in Files)
                {
                    var file = File.Elements("File");
                    foreach (var ff in file)
                    {
                        var FilePath = ff.Element("FilePath");
                        builder.AppendLine("# Begin Source File");
                        builder.AppendLine("");
                        builder.Append("SOURCE=");
                        if (FilePath != null)
                            builder.AppendLine(FilePath.Value);
                        builder.AppendLine("# End Source File");
                    }
                }
                builder.AppendLine("# End Group");
            }
        }

        void createvcxproj(string filename, string name)
        {
            var builder = new StringBuilder();
            builder.AppendLine("<?xml version=\"1.0\" encoding=\"utf - 8\"?>");
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
            builder.AppendLine(@"      <AdditionalIncludeDirectories>..\..\..\STDOS\STDOS;..\..\..\STDOS\\SYSTEM\\STM32F1\\CMSIS;..\..\..\STDOS\SYSTEM\STM32F1\FWLib\inc;..\..\..\STDOS\STDOS\Kernel;..\..\..\STDOS\STDOS\Device;..\..\..\STDOS\STDOS\Core;..\..\..\STDOS\SYSTEM\STM32F1\startup;%(AdditionalIncludeDirectories)</AdditionalIncludeDirectories>");
            builder.AppendLine("      <PreprocessorDefinitions>STM32F10X_HD;STM32F1;DEBUG;USE_STDPERIPH_DRIVER;%(PreprocessorDefinitions)</PreprocessorDefinitions>");
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
            builder.AppendLine("    <ClCompile Include=\"..\\..\\STDOS\\App\\AT.cpp\" />");
            builder.AppendLine("    <ClCompile Include=\"..\\..\\STDOS\\App\\BlinkPort.cpp\" />");
            builder.AppendLine("    <ClCompile Include=\"..\\..\\STDOS\\App\\bspkey.cpp\" />");
            builder.AppendLine("    <ClCompile Include=\"..\\..\\STDOS\\App\\FlushPort.cpp\" />");
            builder.AppendLine("    <ClCompile Include=\"..\\..\\STDOS\\App\\lcd_dr.cpp\" />");
            builder.AppendLine("    <ClCompile Include=\"..\\..\\SYSTEM\\STM32F1\\CMSIS\\core_cm3.c\" />");
            builder.AppendLine("    <ClCompile Include=\"..\\..\\SYSTEM\\STM32F1\\CMSIS\\system_stm32f10x.c\\\" />");
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

            builder.AppendLine(@"# Microsoft Developer Studio Project File - Name=""demo"" - Package Owner=<4>");
            builder.AppendLine(@"# Microsoft Developer Studio Generated Build File, Format Version 6.00");
            builder.AppendLine(@"# ** DO NOT EDIT **");
            builder.AppendLine(@"");
            builder.AppendLine("# TARGTYPE \"Win32(x86) Application\" 0x0101");
            builder.AppendLine(@"");
            builder.AppendLine(@"CFG=demo - Win32 Debug");
            builder.AppendLine(@"!MESSAGE This is not a valid makefile. To build this project using NMAKE,");
            builder.AppendLine(@"!MESSAGE use the Export Makefile command and run");
            builder.AppendLine(@"!MESSAGE ");
            builder.AppendLine("!MESSAGE NMAKE /f \"demo.mak\".");
            builder.AppendLine(@"!MESSAGE ");
            builder.AppendLine(@"!MESSAGE You can specify a configuration when running NMAKE");
            builder.AppendLine(@"!MESSAGE by defining the macro CFG on the command line. For example:");
            builder.AppendLine(@"!MESSAGE");
            builder.AppendLine("!MESSAGE NMAKE /f \"demo.mak\" CFG=\"demo - Win32 Debug\"");
            builder.AppendLine(@"!MESSAGE ");
            builder.AppendLine(@"!MESSAGE Possible choices for configuration are:");
            builder.AppendLine(@"!MESSAGE ");
            builder.AppendLine("!MESSAGE \"demo - Win32 Release\" (based on \"Win32(x86) Application\")");
            builder.AppendLine("!MESSAGE \"demo - Win32 Debug\" (based on \"Win32(x86) Application\")");
            builder.AppendLine(@"!MESSAGE ");
            builder.AppendLine(@"");
            builder.AppendLine(@"# Begin Project");
            builder.AppendLine(@"# PROP AllowPerConfigDependencies 0");
            builder.AppendLine("# PROP Scc_ProjName \"\"");
            builder.AppendLine("# PROP Scc_LocalPath \"\"");
            builder.AppendLine(@"CPP=cl.exe");
            builder.AppendLine(@"MTL=midl.exe");
            builder.AppendLine(@"RSC=rc.exe");
            builder.AppendLine(@"");
            builder.AppendLine("!IF  \"$(CFG)\" == \"demo - Win32 Release\"");
            builder.AppendLine(@"");
            builder.AppendLine(@"# PROP BASE Use_MFC 0");
            builder.AppendLine(@"# PROP BASE Use_Debug_Libraries 0");
            builder.AppendLine("# PROP BASE Output_Dir \"Release\"");
            builder.AppendLine("# PROP BASE Intermediate_Dir \"Release\"");
            builder.AppendLine("# PROP BASE Target_Dir \"\"");
            builder.AppendLine(@"# PROP Use_MFC 0");
            builder.AppendLine(@"# PROP Use_Debug_Libraries 0");
            builder.AppendLine("# PROP Output_Dir \"Release\"");
            builder.AppendLine("# PROP Intermediate_Dir \"Release\"");
            builder.AppendLine("# PROP Target_Dir \"\"");
            builder.AppendLine("# ADD BASE CPP /nologo /W3 /GX /O2 /D \"WIN32\" /D \"NDEBUG\" /D \"_WINDOWS\" /D \"_MBCS\" /YX /FD /c");
            getDefineToVc(builder);
            //builder.AppendLine("# ADD CPP /nologo /W3 /GX /O2 /D \"WIN32\" /D \"NDEBUG\" /D \"_WINDOWS\" /D \"_MBCS\" /YX /FD /c");
            builder.AppendLine("# ADD BASE MTL /nologo /D \"NDEBUG\" /mktyplib203 /win32");
            builder.AppendLine("# ADD MTL /nologo /D \"NDEBUG\" /mktyplib203 /win32");
            builder.AppendLine("# ADD BASE RSC /l 0x804 /d \"NDEBUG\"");
            builder.AppendLine("# ADD RSC /l 0x804 /d \"NDEBUG\"");
            builder.AppendLine(@"BSC32=bscmake.exe");
            builder.AppendLine(@"# ADD BASE BSC32 /nologo");
            builder.AppendLine(@"# ADD BSC32 /nologo");
            builder.AppendLine(@"LINK32=link.exe");
            builder.AppendLine(@"# ADD BASE LINK32 kernel32.lib user32.lib gdi32.lib winspool.lib comdlg32.lib advapi32.lib shell32.lib ole32.lib oleaut32.lib uuid.lib odbc32.lib odbccp32.lib /nologo /subsystem:windows /machine:I386");
            builder.AppendLine(@"# ADD LINK32 kernel32.lib user32.lib gdi32.lib winspool.lib comdlg32.lib advapi32.lib shell32.lib ole32.lib oleaut32.lib uuid.lib odbc32.lib odbccp32.lib /nologo /subsystem:windows /machine:I386");
            builder.AppendLine(@"");
            builder.AppendLine("!ELSEIF  \"$(CFG)\" == \"demo - Win32 Debug\"");
            builder.AppendLine(@"");
            builder.AppendLine(@"# PROP BASE Use_MFC 0");
            builder.AppendLine(@"# PROP BASE Use_Debug_Libraries 1");
            builder.AppendLine("# PROP BASE Output_Dir \"Debug\"");
            builder.AppendLine("# PROP BASE Intermediate_Dir \"Debug\"");
            builder.AppendLine("# PROP BASE Target_Dir \"\"");
            builder.AppendLine(@"# PROP Use_MFC 0");
            builder.AppendLine(@"# PROP Use_Debug_Libraries 1");
            builder.AppendLine("# PROP Output_Dir \"Debug\"");
            builder.AppendLine("# PROP Intermediate_Dir \"Debug\"");
            builder.AppendLine("# PROP Target_Dir \"\"");
            builder.AppendLine("# ADD BASE CPP /nologo /W3 /Gm /GX /ZI /Od /D \"WIN32\" / D \"_DEBUG\" / D \"_WINDOWS\" / D \"_MBCS\" / YX /FD /GZ /c");
            builder.AppendLine("# ADD CPP /nologo /W3 /Gm /GX /ZI /Od /D \"WIN32\" / D \"_DEBUG\" / D \"_WINDOWS\" / D \"_MBCS\" / YX /FD /GZ /c");
            builder.AppendLine("# ADD BASE MTL /nologo /D \"_DEBUG\" / mktyplib203 /win32");
            builder.AppendLine("# ADD MTL /nologo /D \"_DEBUG\" / mktyplib203 /win32");
            builder.AppendLine("# ADD BASE RSC /l 0x804 /d \"_DEBUG\"");
            builder.AppendLine("# ADD RSC /l 0x804 /d \"_DEBUG\"");
            builder.AppendLine(@"BSC32 =bscmake.exe");
            builder.AppendLine(@"# ADD BASE BSC32 /nologo");
            builder.AppendLine(@"# ADD BSC32 /nologo");
            builder.AppendLine(@"LINK32=link.exe");
            builder.AppendLine(@"# ADD BASE LINK32 kernel32.lib user32.lib gdi32.lib winspool.lib comdlg32.lib advapi32.lib shell32.lib ole32.lib oleaut32.lib uuid.lib odbc32.lib odbccp32.lib /nologo /subsystem:windows /debug /machine:I386 /pdbtype:sept");
            builder.AppendLine(@"# ADD LINK32 kernel32.lib user32.lib gdi32.lib winspool.lib comdlg32.lib advapi32.lib shell32.lib ole32.lib oleaut32.lib uuid.lib odbc32.lib odbccp32.lib /nologo /subsystem:windows /debug /machine:I386 /pdbtype:sept");
            builder.AppendLine(@"");
            builder.AppendLine(@"!ENDIF ");
            builder.AppendLine(@"");
            builder.AppendLine(@"# Begin Target");
            builder.AppendLine(@"");
            builder.AppendLine(@"# Name ""demo - Win32 Release""");
            builder.AppendLine(@"# Name ""demo - Win32 Debug""");            
            getGroupsToVc(builder);            
            builder.AppendLine(@"# End Target");
            builder.AppendLine(@"# End Project");
            builder.AppendLine(@"");
            
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
