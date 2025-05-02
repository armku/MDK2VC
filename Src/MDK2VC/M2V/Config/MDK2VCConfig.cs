using NewLife.Xml;
using System.Collections.Generic;
using System.ComponentModel;

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
        public bool OutputPathManulSet { get; set; } = false;
        /// <summary>
        /// 输出工程目标
        /// </summary>
        [Description("输出工程目标")]
        public string StrOutputPathTarget { get; set; } = "VC2019";
        /// <summary>
        /// mdk工程路径
        /// </summary>
        [Description("mdk工程路径")]
        public string StrMDKFilePath { get; set; } = "";
        /// <summary>
        /// QT工程路径
        /// </summary>
        [Description("QT工程路径")]
        public string StrQTFilePath { get; set; } = "";
        /// <summary>
        /// QTVs工程路径
        /// </summary>
        [Description("QTVs工程路径")]
        public string StrQTVsFilePath { get; set; } = "";
        /// <summary>
        /// 历史
        /// </summary>
        [Description("历史")]
        public List<string> StrMDKFilePathHis { get; set; } = new List<string>();
    }
}
