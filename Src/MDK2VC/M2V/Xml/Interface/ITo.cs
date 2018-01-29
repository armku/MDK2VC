using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MDK2VC.M2V.Xml
{
    /// <summary>
    /// 创建目标工程
    /// </summary>
    public interface ITo
    {
        /// <summary>
        /// 创建工程
        /// </summary>
        /// <param name="cfg"></param>
        void createvcxproj(SysConfig cfg);
        /// <summary>
        /// 创建VCFilters
        /// </summary>
        /// <param name="cfg"></param>
        void createfilters(SysConfig cfg);
        /// <summary>
        /// 创建解决方案
        /// </summary>
        /// <param name="cfg"></param>
        void createsln(SysConfig cfg);
    }
}
