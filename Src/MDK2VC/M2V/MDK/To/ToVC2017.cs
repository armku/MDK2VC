using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace MDK
{
    public  class ToVC2017:IToVC2017
    {
        public void VC_Creat_Sln(string DocName, string ProjectName, string[] Targets)
        {
            StringBuilder builder = new StringBuilder();
            builder.Append("Microsoft Visual Studio Solution File, Format Version 11.00\r\n");
            builder.Append("# Visual Studio 2010\r\n");
            builder.Append("Project(\"{8BC9CEB8-8B4A-11D0-8D11-00A0C91BC942}\") = \"Template\", \"Template.vcxproj\", \"{630C639D-C434-4F17-AB2D-5D46AF7B2116}\"");
            builder.Append("\r\nEndProject\r\n");
            builder.Append("Global\r\n");
            builder.Append("\tGlobalSection(SolutionConfigurationPlatforms) = preSolution\r\n");
            foreach (string str in Targets)
            {
                string str2 = "\t\tDebug|Win32 = Debug|Win32\r\n";
                str2 = str2.Replace("Debug", str);
                builder.Append(str2);
            }
            builder.Append("\tEndGlobalSection\r\n");
            builder.Append("\tGlobalSection(ProjectConfigurationPlatforms) = postSolution\r\n");
            string newValue = Guid.NewGuid().ToString("B");
            foreach (string str4 in Targets)
            {
                string str5 = "\t\tGUID.Debug|Win32.ActiveCfg = Debug|Win32\r\n";
                string str6 = "\t\tGUID.Debug|Win32.Build.0 = Debug|Win32\r\n";
                str5 = str5.Replace("GUID", newValue).Replace("Debug", str4);
                str6 = str6.Replace("GUID", newValue).Replace("Debug", str4);
                builder.Append(str5);
                builder.Append(str6);
            }
            builder.Append("\tEndGlobalSection\r\n");
            builder.Append("\t\tGlobalSection(SolutionProperties) = preSolution\r\n");
            builder.Append("\t\tHideSolutionNode = FALSE\r\n");
            builder.Append("\tEndGlobalSection\r\n");
            builder.Append("EndGlobal\r\n");
            builder = builder.Replace("Template", ProjectName);
            FileStream stream = File.OpenWrite(DocName);
            byte[] bytes = new UTF8Encoding(true).GetBytes(builder.ToString());
            stream.Write(bytes, 0, bytes.Length);
            stream.Close();
            builder.Clear();
        }
        public void VC_Creat_readme(string DocName, string ProjectName)
        {
            StringBuilder builder = new StringBuilder();
            builder.Append("========================================================================\r\n");
            builder.Append("    生成文件项目：Template 项目概述\r\n");
            builder.Append("========================================================================\r\n");
            builder.Append("\r\n");
            builder.Append("本文件概要介绍组成 Template 项目的每个文件的内容。\r\n");
            builder.Append("\r\n");
            builder.Append("Template.sln\r\n");
            builder.Append("    这是Template项目的解决方案文件\r\n");
            builder.Append("\r\n");
            builder.Append("Template.vcxproj\r\n");
            builder.Append("    这是Template项目的主项目文件\r\n");
            builder.Append("    其中包含了这个项目中的各个Target，\r\n");
            builder.Append("    以及Include Path、所有源文件的路径、编译命令。\r\n");
            builder.Append("\r\n");
            builder.Append("Template.vcxproj.filters\r\n");
            builder.Append("    这是Template项目的项目筛选器文件。\r\n");
            builder.Append("    它包含了这个项目中的所有源文件分组及源文件的路径。\r\n");
            builder.Append("\r\n");
            builder.Append("Template.vcxproj.user\r\n");
            builder.Append("    这是Template项目的 用户文件，\r\n");
            builder.Append("    它包含了这个项目中的各个Target的 Debug命令。\r\n");
            builder.Append("\r\n");
            builder.Append("以上文件由MDK Project  To Visual Studio Project 工具读取 Keil uVision4\r\n");
            builder.Append("的项目文件：Template.uvproj 中的设定，按照Visual Studio 2010\r\n");
            builder.Append("中VC++ “生成文件项目” 的模板文件来生成的，如有疑问，请看MSDN~\r\n");
            builder.Append("\r\n");
            builder.Append("2012-6-18\r\n");
            builder.Append("Ka_Chen\r\n");
            builder.Append("/////////////////////////////////////////////////////////////////////////////\r\n");
            builder = builder.Replace("Template", ProjectName);
            FileStream stream = File.OpenWrite(DocName);
            byte[] bytes = new UTF8Encoding(true).GetBytes(builder.ToString());
            stream.Write(bytes, 0, bytes.Length);
            stream.Close();
        }
    }
}
