using NewLife;
using NewLife.Xml;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;

namespace MDK2VC.M2V
{
    [XmlConfigFile(@"Config/SysConfig.config")]
    public class SysConfig : XmlConfig<SysConfig>
    {
        /// <summary>
        /// MDK 工程文件路径
        /// </summary>
        [Description("MDK 工程文件路径")]
        public string MdkPath { get; set; }
        /// <summary>
        /// VC 工程文件路径
        /// </summary>
        [Description("VC 工程文件路径")]
        public string vcxproj { get; set; }
        public string filters { get; set; }
        public string sln { get; set; }
    }
}
