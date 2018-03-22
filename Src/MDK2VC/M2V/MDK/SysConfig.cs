using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;

namespace MDK
{
    [StructLayout(LayoutKind.Sequential)]
    public struct SysConfig
    {
        /// <summary>
        /// 
        /// </summary>
        [Description("")]
        public string UV4_Path { get; set; }
        /// <summary>
        /// 
        /// </summary>
        [Description("")]
        public string MDK_Project_Path { get; set; }
        /// <summary>
        /// 
        /// </summary>
        [Description("")]
        public string MDK_Project_File { get; set; }
        /// <summary>
        /// 
        /// </summary>
        [Description("")]
        public string MDK_Target { get; set; }
        /// <summary>
        /// 
        /// </summary>
        [Description("")]
        public string ProjectName { get; set; }
        /// <summary>
        /// 
        /// </summary>
        [Description("")]
        public string IncludePath { get; set; }
        /// <summary>
        /// vcxproj文件路径
        /// </summary>
        [Description("vcxproj文件路径")]
        public string VCProject_Path { get; set; }
        /// <summary>
        /// 
        /// </summary>
        [Description("")]
        public string VcxprojName { get; set; }
        /// <summary>
        /// 
        /// </summary>
        [Description("")]
        public string VC_Filters_Name { get; set; }
        /// <summary>
        /// 
        /// </summary>
        [Description("")]
        public string VC_UserFileName { get; set; }
        /// <summary>
        /// 
        /// </summary>
        [Description("")]
        public string NMakePreprocessorDefinitions { get; set; }
        /// <summary>
        /// 
        /// </summary>
        [Description("")]
        public string NMakeBuildCommandLine { get; set; }
        /// <summary>
        /// 
        /// </summary>
        [Description("")]
        public string NMakeCleanCommandLine { get; set; }
        /// <summary>
        /// 
        /// </summary>
        [Description("")]
        public string LocalDebuggerCommandArguments { get; set; }
        /// <summary>
        /// 
        /// </summary>
        [Description("")]
        public string LocalDebuggerWorkingDirectory { get; set; }
    }
    [StructLayout(LayoutKind.Sequential)]
    public struct _Config
    {
        /// <summary>
        /// 
        /// </summary>
        [Description("")]
        public string ToolName { get; set; }
        /// <summary>
        /// 
        /// </summary>
        [Description("")]
        public string ToolsVersion { get; set; }
        /// <summary>
        /// 
        /// </summary>
        [Description("")]
        public string UV4Path { get; set; }
        /// <summary>
        /// 
        /// </summary>
        [Description("")]
        public string DocName { get; set; }
    }
}
