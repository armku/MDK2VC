using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;

namespace MDK
{
    [StructLayout(LayoutKind.Sequential)]
    public struct SysConfig
    {
        public string UV4_Path;
        public string MDK_Project_Path;
        public string MDK_Project_File;
        public string MDK_Target;
        public string ProjectName;
        public string IncludePath;
        public string VCProject_Path;
        public string VcxprojName;
        public string VC_Filters_Name;
        public string VC_UserFileName;
        public string NMakePreprocessorDefinitions;
        public string NMakeBuildCommandLine;
        public string NMakeCleanCommandLine;
        public string LocalDebuggerCommandArguments;
        public string LocalDebuggerWorkingDirectory;
    }
    [StructLayout(LayoutKind.Sequential)]
    public struct _Config
    {
        public string ToolName;
        public string ToolsVersion;
        public string UV4Path;
        public string DocName;
    }
}
