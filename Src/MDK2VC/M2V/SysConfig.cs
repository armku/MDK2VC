using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;

namespace MDK2VC.M2V
{
    /// <summary>
    /// 系统参数配置
    /// </summary>
    public class SysConfig 
    {
        /// <summary>
        /// MDK 工程文件路径
        /// </summary>
        [Description("MDK 工程文件路径")]
        public string MdkPath { get; set; }
        /// <summary>
        /// vcxproj文件路径
        /// </summary>
        [Description("vcxproj文件路径")]
        public string vcxproj { get; set; }
        /// <summary>
        /// filters文件路径
        /// </summary>
        [Description("filters文件路径")]
        public string filters { get; set; }
        /// <summary>
        /// sln文件路径
        /// </summary>
        [Description("sln文件路径")]
        public string sln { get; set; }
    }
}
