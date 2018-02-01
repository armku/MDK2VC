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
        /// MDK文件包含路径
        /// </summary>
        public string MdkIncludePath { get; set; } = @"C:\Keil_v5\ARM\ARMCC\include";
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
        public string IncludePath
        {
            get;set;
        }
        public string IncludePathVC
        {
            get
            {
                var builder = new StringBuilder();
                builder.Append("      <AdditionalIncludeDirectories>");
                builder.Append(IncludePath).Append(";").Append(this.MdkIncludePath);
                builder.Append(";%(AdditionalIncludeDirectories)</AdditionalIncludeDirectories>");
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
        public string Groups { get; set; }
        public string BuilderGroupsToFilters { get; set; }
        public string BuilderGroupsToProj { get; set; }
        public string BuilderGrouptoFilters { get; set; }
    }
}
static class fff
{
    public static void Write(this FileStream fs, byte[] array)
    {
        fs.Write(array, 0, array.Length);
    }
}
