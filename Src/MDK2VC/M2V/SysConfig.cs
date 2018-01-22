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
        /// MDK 工程文件路径
        /// </summary>
        [Description("MDK 工程文件路径")]
        public string MdkPath { get; set; }
        /// <summary>
        /// vcxproj文件路径
        /// </summary>
        [Description("vcxproj文件路径")]
        public string vcxproj
        {
            get
            {
                return this.DirectoryName +"\\"+ FileNameWithoutExtension + ".vcxproj";
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
                return this.DirectoryName + "\\" + FileNameWithoutExtension + ".vcxproj.filters";
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
                return this.DirectoryName + "\\" + FileNameWithoutExtension + ".sln";
            }
        }
        /// <summary>
        /// 预定义
        /// </summary>
        public string MacroDefine { get; set; }
        /// <summary>
        /// 预定义 VC2017版本
        /// </summary>
        public string MacroDefineVC
        {
            get
            {
                var builder = new StringBuilder();
                builder.Append("      <PreprocessorDefinitions>");
                builder.Append(MacroDefine).Append("%(PreprocessorDefinitions)</PreprocessorDefinitions>");
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
                return Path.GetFileNameWithoutExtension(MdkPath);
            }
        }
        public string DirectoryName
        {
            get
            {
                return Path.GetDirectoryName(MdkPath);
            }
        }
        /// <summary>
        /// 返回扩展名 ：.txt
        /// </summary>
        public string Extension
        {
            get
            {
                return Path.GetExtension(MdkPath);
            }
        }
        /// <summary>
        /// 仅仅文件路径，不包含文件名
        /// </summary>
        public string PathNameOnly
        {
            get
            {                
                return "";
            }
        }
    }
}
