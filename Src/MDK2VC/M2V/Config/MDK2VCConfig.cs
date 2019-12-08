using NewLife.Xml;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;

namespace MDK2VC.M2V.Config
{
    /// <summary>
    /// 
    /// </summary>
    [XmlConfigFile(@"Config/MDK2VCConfig.config")]
    [Description("系统参数")]
    public class MDK2VCConfig : XmlConfig<MDK2VCConfig>
    {
        /// <summary>
        /// 手动设置输出路径
        /// </summary>
        [Description("手动设置输出路径")]
        public Boolean OutputPathManulSet { get; set; } = false;
        /// <summary>
        /// 输出工程目标
        /// </summary>
        [Description("输出工程目标")]
        public String StrOutputPathTarget { get; set; } = "VC2019";
    }
}
