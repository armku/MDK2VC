using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;

namespace MDK2VC.M2V.Xml
{
    /// <summary>
    /// 
    /// </summary>
    public interface IFrom
    {        
        /// <summary>
        /// 获取宏定义
        /// </summary>
        /// <param name="path"></param>
        /// <returns></returns>
        List<String> GetMacroDefine(string path);
        /// <summary>
        /// 获取包含路径
        /// </summary>
        /// <param name="path"></param>
        /// <returns></returns>
        List<String> getIncludePath(string path);
        /// <summary>
        /// 获取工程中文件
        /// </summary>
        /// <param name="filename">工程文件名</param>
        /// <returns></returns>
        [Description("获取工程中文件")]
        BTree<Node> GetFiles(string filename);
    }
}
