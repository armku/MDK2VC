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

        void createdsw(string filename, string name)
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
        void createdsp(string filename)
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
            builder.AppendLine("# ADD CPP /nologo /W3 /GX /O2 /D \"WIN32\" /D \"NDEBUG\" /D \"_WINDOWS\" /D \"_MBCS\" /YX /FD /c");
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
            builder.AppendLine(@"# Begin Group ""Source Files""");
            builder.AppendLine(@"");
            builder.AppendLine(@"# PROP Default_Filter ""cpp; c; cxx; rc; def; r; odl; idl; hpj; bat""");
            builder.AppendLine(@"# Begin Source File");
            builder.AppendLine(@"");
            builder.AppendLine(@"SOURCE=..\..\..\MCU\STM32\STDOS\STDOS\Core\Array.cpp");
            builder.AppendLine(@"# End Source File");
            builder.AppendLine(@"# Begin Source File");
            builder.AppendLine(@"");
            builder.AppendLine(@"SOURCE=..\..\..\MCU\STM32\STDOS\STDOS\Core\Buffer.cpp");
            builder.AppendLine(@"# End Source File");
            builder.AppendLine(@"# Begin Source File");
            builder.AppendLine(@"");
            builder.AppendLine(@"SOURCE=..\..\..\MCU\STM32\STDOS\STDOS\Core\Version.cpp");
            builder.AppendLine(@"# End Source File");
            builder.AppendLine(@"# End Group");
            builder.AppendLine(@"# Begin Group ""Header Files""");
            builder.AppendLine(@"");
            builder.AppendLine(@"# PROP Default_Filter ""h; hpp; hxx; hm; inl""");
            builder.AppendLine(@"# Begin Source File");
            builder.AppendLine(@"");
            builder.AppendLine(@"SOURCE=..\..\..\MCU\STM32\STDOS\STDOS\Core\_Core.h");
            builder.AppendLine(@"# End Source File");
            builder.AppendLine(@"# Begin Source File");
            builder.AppendLine(@"");
            builder.AppendLine(@"SOURCE=..\..\..\MCU\STM32\STDOS\STDOS\Core\Type.h");
            builder.AppendLine(@"# End Source File");
            builder.AppendLine(@"# Begin Source File");
            builder.AppendLine(@"");
            builder.AppendLine(@"SOURCE=..\..\..\MCU\STM32\STDOS\STDOS\Core\Version.h");
            builder.AppendLine(@"# End Source File");
            builder.AppendLine(@"# End Group");
            getGroupsToVc(builder);
            builder.AppendLine(@"# Begin Group ""Resource Files""");
            builder.AppendLine(@"");
            builder.AppendLine(@"# PROP Default_Filter ""ico; cur; bmp; dlg; rc2; rct; bin; rgs; gif; jpg; jpeg; jpe""");
            builder.AppendLine(@"# End Group");
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
            createdsw(cfg.vcdsw, @".\demo.dsp");
            createdsp(cfg.vcdsp);
        }

        private void btnOpenDsw_Click(object sender, EventArgs e)
        {
            var fileDlg = new SaveFileDialog();
            fileDlg.Title = "请选择文件";
            fileDlg.Filter = "VC项目|*.dsw";
            if (fileDlg.ShowDialog() == DialogResult.OK)
            {
                tboxdsw.Text = fileDlg.FileName;
                cfg.vcdsw = fileDlg.FileName;
                cfg.Save();
            }
        }
    }
}
