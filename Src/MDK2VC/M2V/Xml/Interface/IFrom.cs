using System;
using System.Collections.Generic;
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
        /// 获取组
        /// </summary>
        /// <param name="path"></param>
        /// <returns></returns>
        String getGroups(string path);
        String getGroupsToFilters(string path);
        String getGroupsToProj( string path);
        String getGrouptoFilters(string path);
    }
}
