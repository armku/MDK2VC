using Microsoft.Win32;
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
        public IToVC2017 to
        { get; set; }
        /// <summary>
        /// 获取Keil路径
        /// </summary>
        /// <returns></returns>
        static String GetKeil()
        {
            var reg = Registry.LocalMachine.OpenSubKey("Software\\Keil\\Products\\MDK");
            if (reg == null) return null;

            return reg.GetValue("Path") + "";
        }
    }
}
