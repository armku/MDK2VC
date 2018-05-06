using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace MDK2VC.M2V.Xml
{
    public class ToVC2017 : IToVC2017
    {
        private String getMacroDefineVC(string definestr)
        {
            var builder = new StringBuilder();
            builder.Append("      <PreprocessorDefinitions>");
            builder.Append(definestr).Append("%(PreprocessorDefinitions)</PreprocessorDefinitions>");
            return builder.ToString();
        }
        private String getIncludePathVC(SysConfig cfg)
        {
            var builder = new StringBuilder();
            builder.Append("      <AdditionalIncludeDirectories>");
            builder.Append(cfg.IncludePathStr);
            builder.Append(";%(AdditionalIncludeDirectories)</AdditionalIncludeDirectories>");
            return builder.ToString();
        }

        public void createvcxproj(SysConfig cfg)
        {
            var builder = new StringBuilder();

            builder.AppendLine("<?xml version=\"1.0\" encoding=\"utf-8\"?>");
            builder.AppendLine("<Project DefaultTargets=\"Build\" ToolsVersion=\"15.0\" xmlns=\"http://schemas.microsoft.com/developer/msbuild/2003\">");
            builder.AppendLine("  <ItemGroup Label=\"ProjectConfigurations\">");
            //builder.AppendLine("    <ProjectConfiguration Include=\"rtt_stm32|Win32\">");
            builder.Append("    <ProjectConfiguration Include=\"");
            builder.Append(cfg.FileNameWithoutExtension);
            builder.AppendLine("|Win32\">");

            //builder.AppendLine("      <Configuration>rtt_stm32</Configuration>");
            builder.Append("      <Configuration>");
            builder.Append(cfg.FileNameWithoutExtension);
            builder.AppendLine("</Configuration>");


            builder.AppendLine("      <Platform>Win32</Platform>");
            builder.AppendLine("    </ProjectConfiguration>");
            builder.AppendLine("  </ItemGroup>");
            builder.AppendLine("  <PropertyGroup Label=\"Globals\">");
            builder.AppendLine("    <ProjectGuid>{e7b8d0e4-50a4-40fd-a6bd-3e7c38558110}</ProjectGuid>");
            //builder.Append("    <ProjectGuid>");
            //builder.Append(cfg.projguidvc);
            //builder.AppendLine("</ProjectGuid>");
            
            builder.AppendLine("    <Keyword>MakeFileProj</Keyword>");
            builder.AppendLine("    <WindowsTargetPlatformVersion>10.0.16299.0</WindowsTargetPlatformVersion>");
            builder.AppendLine("  </PropertyGroup>");
            builder.AppendLine("  <Import Project=\"$(VCTargetsPath)\\Microsoft.Cpp.Default.props\" />");
            //builder.AppendLine("  <PropertyGroup Condition=\"'$(Configuration)|$(Platform)'=='rtt_stm32|Win32'\" Label=\"Configuration\">");
            builder.Append("  <PropertyGroup Condition=\"'$(Configuration)|$(Platform)'=='");
            builder.Append(cfg.FileNameWithoutExtension);
            builder.AppendLine("|Win32'\" Label=\"Configuration\">");

            builder.AppendLine("    <ConfigurationType>Makefile</ConfigurationType>");
            builder.AppendLine("    <UseDebugLibraries>true</UseDebugLibraries>");
            builder.AppendLine("    <PlatformToolset>v141</PlatformToolset>");
            builder.AppendLine("  </PropertyGroup>");
            builder.AppendLine("  <Import Project=\"$(VCTargetsPath)\\Microsoft.Cpp.props\" />");
            builder.AppendLine("  <ImportGroup Label=\"ExtensionSettings\" />");
            //builder.AppendLine("  <ImportGroup Condition=\"'$(Configuration)|$(Platform)'=='rtt_stm32|Win32'\" Label=\"PropertySheets\">");
            builder.Append("  <ImportGroup Condition=\"'$(Configuration)|$(Platform)'=='");
            builder.Append(cfg.FileNameWithoutExtension);
            builder.AppendLine("|Win32'\" Label=\"PropertySheets\">");
            
            builder.AppendLine("    <Import Project=\"$(UserRootDir)\\Microsoft.Cpp.$(Platform).user.props\" Condition=\"exists('$(UserRootDir)\\Microsoft.Cpp.$(Platform).user.props')\" Label=\"LocalAppDataPlatform\" />");
            builder.AppendLine("  </ImportGroup>");
            builder.AppendLine("  <PropertyGroup Label=\"UserMacros\" />");
            //builder.AppendLine("  <PropertyGroup Condition=\"'$(Configuration)|$(Platform)'=='rtt_stm32|Win32'\">");
            builder.Append("  <PropertyGroup Condition=\"'$(Configuration)|$(Platform)'=='");
            builder.Append(cfg.FileNameWithoutExtension);
            builder.AppendLine("|Win32'\">");
            
            //builder.AppendLine("    <NMakeOutput>rtt_stm32.exe</NMakeOutput>");
            builder.Append("    <NMakeOutput>");
            builder.Append(cfg.FileNameWithoutExtension);
            builder.AppendLine(".exe</NMakeOutput>");
            
            //builder.AppendLine("    <NMakePreprocessorDefinitions>STM32F10X_HD, USE_STDPERIPH_DRIVER</NMakePreprocessorDefinitions>");
            builder.Append("    <NMakePreprocessorDefinitions>");
            builder.Append(cfg.MacroDefineStrCNMake);
            builder.AppendLine("</NMakePreprocessorDefinitions>");

            //builder.AppendLine(@"    <IncludePath>..\Application;..\Drivers;..\RT_Thread\components\finsh;..\RT_Thread\include;..\RT_Thread\libcpu\arm\common;..\RT_Thread\libcpu\arm\cortex-m3;..\ST_Library\STM32F10x_StdPeriph_Driver\inc;..\ST_Library\CMSIS\CM3\DeviceSupport\ST\STM32F10x;..\ST_Library\CMSIS\CM3\CoreSupport</IncludePath>");
            builder.Append(@"    <IncludePath>");
            builder.Append(cfg.IncludePathStr);
            builder.AppendLine(@"</IncludePath>");

            //builder.AppendLine("    <NMakeBuildCommandLine>\"C:\\Keil\\UV4\\Uv4.exe \" -b ..\\rtt_stm32.uvprojx -t \"rtt_stm32\" -j0 -o Build.log");
            builder.Append("    <NMakeBuildCommandLine>\"C:\\Keil\\UV4\\Uv4.exe \" -b ..\\");
            builder.Append(cfg.FileNameWithoutExtension);
            builder.Append(".uvprojx -t \"");
            builder.Append(cfg.FileNameWithoutExtension);
            builder.AppendLine("\" -j0 -o Build.log");
            
            builder.AppendLine("type ..\\build.log</NMakeBuildCommandLine>");
            //builder.AppendLine("    <NMakeReBuildCommandLine>\"C:\\Keil\\UV4\\Uv4.exe \" -r ..\\rtt_stm32.uvprojx -t \"rtt_stm32\" -j0 -o Build.log");
            builder.Append("    <NMakeReBuildCommandLine>\"C:\\Keil\\UV4\\Uv4.exe \" -r ..\\");
            builder.Append(cfg.FileNameWithoutExtension);
            builder.Append(".uvprojx -t \"");
            builder.Append(cfg.FileNameWithoutExtension);
            builder.AppendLine("\" -j0 -o Build.log");

            builder.AppendLine("type ..\\build.log</NMakeReBuildCommandLine>");
            //builder.AppendLine("    <NMakeCleanCommandLine>\"C:\\Keil\\UV4\\Uv4.exe \" -f ..\\rtt_stm32.uvprojx -t \"rtt_stm32\" -j0 -o flash_download.log");
            builder.Append("    <NMakeCleanCommandLine>\"C:\\Keil\\UV4\\Uv4.exe \" -f ..\\");
            builder.Append(cfg.FileNameWithoutExtension);
            builder.Append(".uvprojx -t \"");
            builder.Append(cfg.FileNameWithoutExtension);
            builder.AppendLine("\" -j0 -o flash_download.log");
            
            builder.AppendLine("type ..\\flash_download.log");
            builder.AppendLine("</NMakeCleanCommandLine>");
            builder.AppendLine("  </PropertyGroup>");
            builder.AppendLine("  <ItemDefinitionGroup>");
            builder.AppendLine("  </ItemDefinitionGroup>");
            builder.AppendLine("  <ItemGroup>");
            builder.Append(cfg.ToProj_Files.ToString());
            builder.AppendLine("  </ItemGroup>");
            builder.AppendLine("  <Import Project=\"$(VCTargetsPath)\\Microsoft.Cpp.targets\" />");
            builder.AppendLine("  <ImportGroup Label=\"ExtensionTargets\">");
            builder.AppendLine("  </ImportGroup>");
            builder.AppendLine("</Project>");
            
            if (!Directory.Exists(cfg.VCPath))
            {
                Directory.CreateDirectory(cfg.VCPath);
            }
            var fs = new FileStream(cfg.vcxproj, FileMode.Create);
            byte[] data = new UTF8Encoding().GetBytes(builder.ToString());
            fs.Write(data);
            fs.Flush();
            fs.Close();
        }
        public void createfilters(SysConfig cfg)
        {
            var builder = new StringBuilder();

            builder.AppendLine("<?xml version=\"1.0\" encoding=\"utf-8\"?>");
            builder.AppendLine("<Project DefaultTargets=\"Build\" ToolsVersion=\"4.0\" xmlns=\"http://schemas.microsoft.com/developer/msbuild/2003\">");
            builder.AppendLine("  <ItemGroup>");
            builder.Append(cfg.ToFilter_files.ToString());            
            builder.AppendLine("  </ItemGroup>");
            builder.AppendLine("  <ItemGroup>");
            builder.Append(cfg.ToFilter_FileFolders.ToString());
            builder.AppendLine("  </ItemGroup>");
            builder.AppendLine("</Project>");

            var fs = new FileStream(cfg.filters, FileMode.Create);
            byte[] data = new UTF8Encoding().GetBytes(builder.ToString());
            fs.Write(data);
            fs.Flush();
            fs.Close();
        }
        /// <summary>
        /// 生成日志文件
        /// </summary>
        /// <param name="cfg">配置文件</param>
        public void createlog(SysConfig cfg)
        {
            var Buildlog =cfg.DirectoryName+ "\\Build.log";
            var flash_downloadlog = cfg.DirectoryName + "\\flash_download.log";
            if (!File.Exists(Buildlog))
                File.Create(Buildlog);
            if (!File.Exists(flash_downloadlog))
                File.Create(flash_downloadlog);
        }
        public void createsln(SysConfig cfg)
        {
            var builder = new StringBuilder();

            builder.AppendLine("Microsoft Visual Studio Solution File, Format Version 12.00");
            builder.AppendLine("# Visual Studio 2013");
            builder.AppendLine("VisualStudioVersion = 12.0.21005.1");
            builder.AppendLine("MinimumVisualStudioVersion = 10.0.40219.1");
            //builder.AppendLine("Project(\"{8BC9CEB8-8B4A-11D0-8D11-00A0C91BC942}\") = \"rtt_stm32\", \"rtt_stm32.vcxproj\", \"{E7B8D0E4-50A4-40FD-A6BD-3E7C38558110}\"");
            builder.Append("Project(\"{8BC9CEB8-8B4A-11D0-8D11-00A0C91BC942}\") = \"");
            builder.Append(cfg.FileNameWithoutExtension);
            builder.Append("\", \"");
            builder.Append(cfg.FileNameWithoutExtension);
            builder.Append(".vcxproj\", \"{E7B8D0E4-50A4-40FD-A6BD-3E7C38558110}\"");
            builder.Append(cfg.FileNameWithoutExtension);
            builder.AppendLine(".vcxproj\", \"{E7B8D0E4-50A4-40FD-A6BD-3E7C38558110}\"");
            
            builder.AppendLine("EndProject");
            builder.AppendLine("Global");
            builder.AppendLine("	GlobalSection(SolutionConfigurationPlatforms) = preSolution");
            //builder.AppendLine("		rtt_stm32|Win32 = rtt_stm32|Win32");
            builder.Append("		");
            builder.Append(cfg.FileNameWithoutExtension);
            builder.Append("|Win32 = ");
            builder.Append(cfg.FileNameWithoutExtension);
            builder.AppendLine("|Win32");

            builder.AppendLine("	EndGlobalSection");
            builder.AppendLine("	GlobalSection(ProjectConfigurationPlatforms) = postSolution");
            //builder.AppendLine("		{E7B8D0E4-50A4-40FD-A6BD-3E7C38558110}.rtt_stm32|Win32.ActiveCfg = rtt_stm32|Win32");
            builder.Append("		{E7B8D0E4-50A4-40FD-A6BD-3E7C38558110}.");
            builder.Append(cfg.FileNameWithoutExtension);
            builder.Append("|Win32.ActiveCfg = ");
            builder.Append(cfg.FileNameWithoutExtension);
            builder.AppendLine("|Win32");

            //builder.AppendLine("		{E7B8D0E4-50A4-40FD-A6BD-3E7C38558110}.rtt_stm32|Win32.Build.0 = rtt_stm32|Win32");
            builder.Append("		{E7B8D0E4-50A4-40FD-A6BD-3E7C38558110}.");
            builder.Append(cfg.FileNameWithoutExtension);
            builder.Append("|Win32.Build.0 = ");
            builder.Append(cfg.FileNameWithoutExtension);
            builder.AppendLine("|Win32");

            builder.AppendLine("	EndGlobalSection");
            builder.AppendLine("	GlobalSection(SolutionProperties) = preSolution");
            builder.AppendLine("		HideSolutionNode = FALSE");
            builder.AppendLine("	EndGlobalSection");
            builder.AppendLine("EndGlobal");

            var fs = new FileStream(cfg.sln, FileMode.Create);
            byte[] data = new UTF8Encoding().GetBytes(builder.ToString());
            fs.Write(data);
            fs.Flush();
            fs.Close();
        }
        /// <summary>
        /// 创建users文件
        /// </summary>
        /// <param name="cfg"></param>
        public void createvcxusers(SysConfig cfg)
        {
            var builder = new StringBuilder();
            builder.AppendLine("<?xml version=\"1.0\" encoding=\"utf - 8\"?>");
            builder.AppendLine("<Project ToolsVersion=\"4.0\" xmlns=\"http://schemas.microsoft.com/developer/msbuild/2003\">");
            builder.AppendLine("  <PropertyGroup Condition=\"'$(Configuration)|$(Platform)'=='rtt_stm32|Win32'\">");
            builder.AppendLine(@"    <LocalDebuggerCommand>C:\Keil\UV4\UV4.exe </LocalDebuggerCommand>");
            //builder.AppendLine("    <LocalDebuggerCommandArguments>-d rtt_stm32.uvproj -t \"rtt_stm32\"</LocalDebuggerCommandArguments>");
            builder.Append("    <LocalDebuggerCommandArguments>-d ");
            builder.Append(cfg.FileNameWithoutExtension);
            builder.Append(".uvproj -t \"");
            builder.Append(cfg.FileNameWithoutExtension);
            builder.Append("\"</LocalDebuggerCommandArguments>");
            builder.AppendLine("\"</LocalDebuggerCommandArguments>");

            //builder.AppendLine(@"    <LocalDebuggerWorkingDirectory>..\MDK_Project\</LocalDebuggerWorkingDirectory>");
            builder.Append(@"    <LocalDebuggerWorkingDirectory>");
            builder.Append(@"..\");
            builder.AppendLine(@"</LocalDebuggerWorkingDirectory>");

            builder.AppendLine("    <DebuggerFlavor>WindowsLocalDebugger</DebuggerFlavor>");
            builder.AppendLine("  </PropertyGroup>");
            builder.AppendLine("  <PropertyGroup>");
            builder.AppendLine("    <ShowAllFiles>false</ShowAllFiles>");
            builder.AppendLine("  </PropertyGroup>");
            builder.AppendLine("</Project>");
            var fs = new FileStream(cfg.vcusers, FileMode.Create);
            byte[] data = new UTF8Encoding().GetBytes(builder.ToString());
            fs.Write(data);
            fs.Flush();
            fs.Close();
        }
        /// <summary>
        /// 获取所有文件列表
        /// </summary>
        /// <param name="cfg"></param>
        /// <returns></returns>
        public string Get_ToProj_Files(SysConfig cfg)
        {
            var builder = new StringBuilder();

            if (cfg.ProjFiles.Nodes.Count != 0)
            {
                for (int i = 0; i < cfg.ProjFiles.Nodes.Count; i++)
                {
                    for (int j = 0; j < cfg.ProjFiles.Nodes[i].Nodes.Count; j++)
                    {
                        if (cfg.ProjFiles.Nodes[i].Nodes[j].Nodes.Count == 0)
                        {
                            if (cfg.ProjFiles.Nodes[i].Nodes[j].Data.Name != null)
                            {
                                builder.Append("    <ClCompile Include=\"");
                                if (cfg.ProjFiles.Nodes[i].Nodes[j].Data.Name.StartsWith(".\\"))
                                    builder.Append(cfg.ProjFiles.Nodes[i].Nodes[j].Data.Name.Replace(".\\", "..\\"));
                                else
                                    builder.Append("..\\" + cfg.ProjFiles.Nodes[i].Nodes[j].Data.Name);
                                builder.AppendLine("\" /> ");
                            }
                        }
                        for (int k = 0; k < cfg.ProjFiles.Nodes[i].Nodes[j].Nodes.Count; k++)
                        {
                            if (cfg.ProjFiles.Nodes[i].Nodes[j].Nodes[k].Nodes.Count == 0)
                            {
                                if (cfg.ProjFiles.Nodes[i].Nodes[j].Nodes[k].Data.Name != null)
                                {
                                    builder.Append("    <ClCompile Include=\"");
                                    if (cfg.ProjFiles.Nodes[i].Nodes[j].Nodes[k].Data.Name.StartsWith(".\\"))
                                        builder.Append(cfg.ProjFiles.Nodes[i].Nodes[j].Nodes[k].Data.Name.Replace(".\\", "..\\"));
                                    else
                                        builder.Append("..\\" + cfg.ProjFiles.Nodes[i].Nodes[j].Nodes[k].Data.Name);
                                    builder.AppendLine("\" /> ");
                                }
                            }
                            for (int l = 0; l < cfg.ProjFiles.Nodes[i].Nodes[j].Nodes[k].Nodes.Count; l++)
                            {
                                if (cfg.ProjFiles.Nodes[i].Nodes[j].Nodes[k].Nodes[l].Nodes.Count == 0)
                                {
                                    if (cfg.ProjFiles.Nodes[i].Nodes[j].Nodes[k].Nodes[l].Data.Name != null)
                                    {
                                        builder.Append("    <ClCompile Include=\"");
                                        if (cfg.ProjFiles.Nodes[i].Nodes[j].Nodes[k].Nodes[l].Data.Name.StartsWith(".\\"))
                                            builder.Append(cfg.ProjFiles.Nodes[i].Nodes[j].Nodes[k].Nodes[l].Data.Name.Replace(".\\", "..\\"));
                                        else
                                            builder.Append("..\\" + cfg.ProjFiles.Nodes[i].Nodes[j].Nodes[k].Nodes[l].Data.Name);
                                        builder.AppendLine("\" /> ");
                                    }
                                }

                            }
                        }
                    }
                }
            }
            return builder.ToString();
        }
        /// <summary>
        /// 获取过滤器文件、文件夹列表
        /// </summary>
        /// <param name="cfg"></param>
        /// <returns></returns>
        public string Get_ToFilter_FolderFiles(SysConfig cfg)
        {
            var builder = new StringBuilder();

            for (int i = 0; i < cfg.ProjFiles.Nodes.Count; i++)
            {
                for (int j = 0; j < cfg.ProjFiles.Nodes[i].Nodes.Count; j++)
                {
                    for (int k = 0; k < cfg.ProjFiles.Nodes[i].Nodes[j].Nodes.Count; k++)
                    {
                        for (int l = 0; l < cfg.ProjFiles.Nodes[i].Nodes[j].Nodes[k].Nodes.Count; l++)
                        {
                            for (int m = 0; m < cfg.ProjFiles.Nodes[i].Nodes[j].Nodes[k].Nodes[l].Nodes.Count; m++)
                            {

                                                                
                                if (cfg.ProjFiles.Nodes[i].Nodes[j].Nodes[k].Nodes[l].Nodes.Count == 0)
                                {
                                    builder.Append("    <ClCompile Include=\"");
                                    if (cfg.ProjFiles.Nodes[i].Nodes[j].Nodes[k].Nodes[l].Nodes[m].Data != null)
                                    {
                                        if (cfg.ProjFiles.Nodes[i].Nodes[j].Nodes[k].Nodes[l].Nodes[m].Data.Name.StartsWith(".\\"))
                                            builder.Append(cfg.ProjFiles.Nodes[i].Nodes[j].Nodes[k].Nodes[l].Nodes[m].Data.Name.Replace(".\\", "..\\"));
                                        else
                                            builder.Append("..\\" + cfg.ProjFiles.Nodes[i].Nodes[j].Nodes[k].Nodes[l].Nodes[m].Data.Name);
                                    }
                                    builder.AppendLine("\">");
                                    var path2 = cfg.ProjFiles.Data.Name + @"\" +
                                                cfg.ProjFiles.Nodes[i].Data.Name + @"\" +
                                                cfg.ProjFiles.Nodes[i].Nodes[j].Data.Name + @"\" +
                                                cfg.ProjFiles.Nodes[i].Nodes[j].Nodes[k].Data.Name + @"\" +
                                                cfg.ProjFiles.Nodes[i].Nodes[j].Nodes[l].Nodes[m].Data.Name;
                                    builder.Append("      <Filter>").Append(path2).AppendLine("</Filter>");
                                    builder.AppendLine("    </ClCompile>");
                                }
                                else { }
                            }
                            
                            if (cfg.ProjFiles.Nodes[i].Nodes[j].Nodes[k].Nodes[l].Nodes.Count == 0)
                            {
                                builder.Append("    <ClCompile Include=\"");
                                if (cfg.ProjFiles.Nodes[i].Nodes[j].Nodes[k].Nodes[l].Data != null)
                                {
                                    if (cfg.ProjFiles.Nodes[i].Nodes[j].Nodes[k].Nodes[l].Data.Name.StartsWith(".\\"))
                                        builder.Append(cfg.ProjFiles.Nodes[i].Nodes[j].Nodes[k].Nodes[l].Data.Name.Replace(".\\", "..\\"));
                                    else
                                        builder.Append("..\\" + cfg.ProjFiles.Nodes[i].Nodes[j].Nodes[k].Nodes[l].Data.Name);
                                }
                                builder.AppendLine("\">");
                                var path2 = cfg.ProjFiles.Data.Name + @"\" +
                                            cfg.ProjFiles.Nodes[i].Data.Name + @"\" +
                                            cfg.ProjFiles.Nodes[i].Nodes[j].Data.Name + @"\" +
                                            cfg.ProjFiles.Nodes[i].Nodes[j].Nodes[k].Data.Name;
                                builder.Append("      <Filter>").Append(path2).AppendLine("</Filter>");
                                builder.AppendLine("    </ClCompile>");
                            }
                            else { }
                        }

                        if (cfg.ProjFiles.Nodes[i].Nodes[j].Nodes[k].Nodes.Count == 0)
                        {
                            builder.Append("    <ClCompile Include=\"");
                            if (cfg.ProjFiles.Nodes[i].Nodes[j].Nodes[k].Data != null)
                            {
                                if (cfg.ProjFiles.Nodes[i].Nodes[j].Nodes[k].Data.Name.StartsWith(".\\"))
                                    builder.Append(cfg.ProjFiles.Nodes[i].Nodes[j].Nodes[k].Data.Name.Replace(".\\", "..\\"));
                                else
                                    builder.Append("..\\" + cfg.ProjFiles.Nodes[i].Nodes[j].Nodes[k].Data.Name);
                            }
                            builder.AppendLine("\">");
                            var path2 = cfg.ProjFiles.Data.Name + @"\" +
                                        cfg.ProjFiles.Nodes[i].Data.Name + @"\" +
                                        cfg.ProjFiles.Nodes[i].Nodes[j].Data.Name;
                            builder.Append("      <Filter>").Append(path2).AppendLine("</Filter>");
                            builder.AppendLine("    </ClCompile>");
                        }
                        else { }
                    }

                    if (cfg.ProjFiles.Nodes[i].Nodes[j].Nodes.Count == 0)
                    {
                        builder.Append("    <ClCompile Include=\"");
                        if (cfg.ProjFiles.Nodes[i].Nodes[j].Data != null)
                        {
                            if (cfg.ProjFiles.Nodes[i].Nodes[j].Data.Name.StartsWith(".\\"))
                                builder.Append(cfg.ProjFiles.Nodes[i].Nodes[j].Data.Name.Replace(".\\", "..\\"));
                            else
                                builder.Append("..\\" + cfg.ProjFiles.Nodes[i].Nodes[j].Data.Name);
                        }
                        builder.AppendLine("\">");
                        var path2 = cfg.ProjFiles.Data.Name + @"\" +
                                    cfg.ProjFiles.Nodes[i].Data.Name;
                        builder.Append("      <Filter>").Append(path2).AppendLine("</Filter>");
                        builder.AppendLine("    </ClCompile>");
                    }
                    else { }
                }

                if (cfg.ProjFiles.Nodes[i].Nodes.Count == 0)
                {
                    builder.Append("    <ClCompile Include=\"");
                    if (cfg.ProjFiles.Nodes[i].Data != null)
                    {
                        if (cfg.ProjFiles.Nodes[i].Data.Name.StartsWith(".\\"))
                            builder.Append(cfg.ProjFiles.Nodes[i].Data.Name.Replace(".\\", "..\\"));
                        else
                            builder.Append("..\\" + cfg.ProjFiles.Nodes[i].Data.Name);
                    }
                    builder.AppendLine("\">");
                    var path2 = cfg.ProjFiles.Data.Name;
                    builder.Append("      <Filter>").Append(path2).AppendLine("</Filter>");
                    builder.AppendLine("    </ClCompile>");
                }
                else { }
            }
            return builder.ToString();
        }
        /// <summary>
        /// 获取过滤器目录列表
        /// </summary>
        /// <param name="cfg"></param>
        /// <returns></returns>
        public String Get_ToFilter_Folders(SysConfig cfg)
        {
            var builder = new StringBuilder();
                        
            for (int i = 0; i < cfg.ProjFiles.Nodes.Count; i++)
            {                
                for (int j = 0; j < cfg.ProjFiles.Nodes[i].Nodes.Count; j++)
                {                    
                    for (int k = 0; k < cfg.ProjFiles.Nodes[i].Nodes[j].Nodes.Count; k++)
                    {
                        var path2 = cfg.ProjFiles.Data.Name + @"\" + cfg.ProjFiles.Nodes[i].Data.Name + @"\" + cfg.ProjFiles.Nodes[i].Nodes[j].Data.Name + @"\";

                        if (cfg.ProjFiles.Nodes[i].Nodes[j].Nodes[k].Nodes.Count > 0)
                        {
                            if (cfg.ProjFiles.Nodes[i].Nodes[j].Nodes[k].Data.Name.StartsWith(".\\"))
                                builder.Append("    <Filter Include=\"").Append(cfg.ProjFiles.Nodes[i].Nodes[j].Nodes[k].Data.Name.Replace(".\\", "..\\")).AppendLine("\">");
                            else
                                builder.Append("    <Filter Include=\"").Append(path2 + cfg.ProjFiles.Nodes[i].Nodes[j].Nodes[k].Data.Name).AppendLine("\">");
                            builder.Append("      <UniqueIdentifier>").Append(Guid.NewGuid().ToString("B")).AppendLine("</UniqueIdentifier>");
                            builder.AppendLine("    </Filter>");
                        }
                    }

                    if (cfg.ProjFiles.Nodes[i].Nodes[j].Nodes.Count != 0)
                    {
                        var path1 = cfg.ProjFiles.Data.Name + @"\" + cfg.ProjFiles.Nodes[i].Data.Name + @"\";

                        if (cfg.ProjFiles.Nodes[i].Nodes[j].Data.Name.StartsWith(".\\"))
                            builder.Append("    <Filter Include=\"").Append(cfg.ProjFiles.Nodes[i].Nodes[j].Data.Name.Replace(".\\", "..\\")).AppendLine("\">");
                        else
                            builder.Append("    <Filter Include=\"").Append(path1 + cfg.ProjFiles.Nodes[i].Nodes[j].Data.Name).AppendLine("\">");
                        builder.Append("      <UniqueIdentifier>").Append(Guid.NewGuid().ToString("B")).AppendLine("</UniqueIdentifier>");
                        builder.AppendLine("    </Filter>");
                    }
                }

                if (cfg.ProjFiles.Nodes[i].Nodes.Count != 0)
                {
                    var path0 = cfg.ProjFiles.Data.Name + @"\";

                    if (cfg.ProjFiles.Nodes[i].Data.Name.StartsWith(".\\"))
                        builder.Append("    <Filter Include=\"").Append(cfg.ProjFiles.Nodes[i].Data.Name.Replace(".\\", "..\\")).AppendLine("\">");
                    else
                        builder.Append("    <Filter Include=\"").Append(path0 + cfg.ProjFiles.Nodes[i].Data.Name).AppendLine("\">");
                    builder.Append("      <UniqueIdentifier>").Append(Guid.NewGuid().ToString("B")).AppendLine("</UniqueIdentifier>");
                    builder.AppendLine("    </Filter>");
                }
                else { }
            }

            if (cfg.ProjFiles.Nodes.Count != 0)
            {
                if (cfg.ProjFiles.Data.Name.StartsWith(".\\"))
                    builder.Append("    <Filter Include=\"").Append(cfg.ProjFiles.Data.Name.Replace(".\\", "..\\")).AppendLine("\">");
                else
                    builder.Append("    <Filter Include=\"").Append(cfg.ProjFiles.Data.Name).AppendLine("\">");
                builder.Append("      <UniqueIdentifier>").Append(Guid.NewGuid().ToString("B")).AppendLine("</UniqueIdentifier>");
                builder.AppendLine("    </Filter>");
            }
            else { }

            return builder.ToString();
        }
    }
}
