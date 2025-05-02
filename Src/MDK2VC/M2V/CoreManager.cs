using Microsoft.Win32;

namespace MDK2VC.M2V.Xml
{
    public class CoreManager
    {
        /// <summary>
        /// 来源
        /// </summary>
        public  IFrom From { get; set; }
        /// <summary>
        /// 目标
        /// </summary>
        public IToVC To
        { get; set; }
        /// <summary>
        /// 获取Keil路径
        /// </summary>
        /// <returns></returns>
        static string GetKeil()
        {
            var reg = Registry.LocalMachine.OpenSubKey("Software\\Keil\\Products\\MDK");
            if (reg == null) return null;

            return reg.GetValue("Path") + "";
        }
    }
}
