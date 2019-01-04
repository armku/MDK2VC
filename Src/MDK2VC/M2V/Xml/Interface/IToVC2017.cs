using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MDK2VC.M2V.Xml
{
    /// <summary>
    /// 创建目标工程
    /// </summary>
    public interface IToVC2017
    {
        /// <summary>
        /// 创建工程
        /// </summary>
        /// <param name="cfg"></param>
        void Createvcxproj(SysConfig cfg);
        /// <summary>
        /// 创建VCFilters
        /// </summary>
        /// <param name="cfg"></param>
        void Createfilters(SysConfig cfg);
        /// <summary>
        /// 创建users文件
        /// </summary>
        /// <param name="cfg"></param>
        void Createvcxusers(SysConfig cfg);
        /// <summary>
        /// 创建解决方案
        /// </summary>
        /// <param name="cfg"></param>
        void Createsln(SysConfig cfg);
        /// <summary>
        /// 生成日志文件
        /// </summary>
        /// <param name="cfg">配置文件</param>
        void Createlog(SysConfig cfg);
        /// <summary>
        /// 获取过滤器文件、文件夹列表
        /// </summary>
        /// <param name="cfg"></param>
        /// <returns></returns>
        String Get_ToFilter_FolderFiles(SysConfig cfg);
        /// <summary>
        /// 获取所有文件列表
        /// </summary>
        /// <param name="cfg"></param>
        /// <returns></returns>
        String Get_ToProj_Files(SysConfig cfg);
        /// <summary>
        /// 获取过滤器目录列表
        /// </summary>
        /// <param name="cfg"></param>
        /// <returns></returns>
        String Get_ToFilter_Folders(SysConfig cfg);
    }
}
