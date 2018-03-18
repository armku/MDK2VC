using MDK2VC.M2V.Xml;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Text;

namespace MDK2VC.M2V
{
    /// <summary>
    /// 系统参数配置
    /// </summary>
    public class SysConfig 
    {
        /// <summary>
        /// 工程文件路径
        /// </summary>
        [Description("工程文件路径")]
        public string FromFilePath { get; set; }
        /// <summary>
        public string VCPath
        {
            get
            {
                return this.DirectoryName + "\\VC2017";
            }
        }
        /// <summary>
        /// vcxproj文件路径
        /// </summary>
        [Description("vcxproj文件路径")]
        public string vcxproj
        {
            get
            {
                return this.VCPath + "\\"+ FileNameWithoutExtension + ".vcxproj";
            }
        }
        /// <summary>
        /// filters文件路径
        /// </summary>
        [Description("filters文件路径")]
        public string filters
        {
            get
            {
                return this.VCPath + "\\" + FileNameWithoutExtension + ".vcxproj.filters";
            }
        }
        /// <summary>
        /// sln文件路径
        /// </summary>
        [Description("sln文件路径")]
        public string sln
        {
            get
            {
                return this.VCPath + "\\" + FileNameWithoutExtension + ".sln";
            }
        }
        /// <summary>
        /// 宏定义
        /// </summary>
        public List<string> MacroDefine { private get; set; }
        /// <summary>
        /// 预定义
        /// </summary>
        public string MacroDefineStr
        {
            get
            {
                var builder = new StringBuilder();
                foreach(var str in MacroDefine)
                {
                    builder.Append(str.Trim()).Append(";");
                }
                return builder.ToString();
            }
        }
        /// <summary>
        /// 
        /// </summary>
        public string projguid { get; set; }
        public string projguidvc
        {
            get
            {
                var builder = new StringBuilder();
                builder.Append(projguid);
                return builder.ToString();
            }
        }
        /// <summary>
        /// 文件路径
        /// </summary>
        public List<String> IncludePath { private get; set; }
        /// <summary>
        /// 项目包含文件
        /// </summary>
        public BTree<Node> ProjFiles { get; set; }
        /// <summary>
        /// 文件路径
        /// </summary>
        public string IncludePathStr
        {
            get
            {
                var builder = new StringBuilder();
                for(int i=0;i<IncludePath.Count;i++)
                {
                    builder.Append(IncludePath[i]);
                    if (i != IncludePath.Count - 1)
                        builder.Append(";");
                }
                return builder.ToString();
            }
        }
        /// <summary>
        /// 仅文件名，不包含路径 hello
        /// </summary>
        public string FileNameWithoutExtension
        {
            get
            {
                return Path.GetFileNameWithoutExtension(FromFilePath);
            }
        }
        public string DirectoryName
        {
            get
            {
                return Path.GetDirectoryName(FromFilePath);
            }
        }
        /// <summary>
        /// 返回扩展名 ：.txt
        /// </summary>
        public string Extension
        {
            get
            {
                return Path.GetExtension(FromFilePath);
            }
        }
        /// <summary>
        /// 过滤器文件、目录列表
        /// </summary>
        public string ToFilter_FileFolders { get; set; }
        /// <summary>
        /// 所有文件列表
        /// </summary>
        public string ToProj_Files { get; set; }
        /// <summary>
        /// 过滤器目录列表
        /// </summary>
        public string ToFilter_files { get; set; }
    }
}
static class fff
{
    public static void Write(this FileStream fs, byte[] array)
    {
        fs.Write(array, 0, array.Length);
    }
}
