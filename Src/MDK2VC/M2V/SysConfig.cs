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
        /// <summary>
        /// 仅文件名，不包含路径
        /// </summary>
        public string FileNameOnly
        {
            get
            {
                var filenameoly = MdkPath.Substring(MdkPath.LastIndexOf("\\") + 1, (MdkPath.LastIndexOf(".") - MdkPath.LastIndexOf("\\") - 1)); //文件名

                return filenameoly;
            }
        }
        /// <summary>
        /// 仅仅文件路径，不包含文件名
        /// </summary>
        public string PathNameOnly
        {
            get
            {
                return "";
            }
        }
    }
}
