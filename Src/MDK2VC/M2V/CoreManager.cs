using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MDK2VC.M2V.Xml
{
    public class CoreManager
    {
        /// <summary>
        /// 来源
        /// </summary>
        public  IFrom from { get; set; }
        /// <summary>
        /// 目标
        /// </summary>
        public ITo to
        { get; set; }
    }
}
