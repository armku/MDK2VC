using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Forms.Integration;
using System.Xml;
using System.Xml.Linq;

namespace MDK
{
    public class CoreManager
    {
        /// <summary>
        /// 来源
        /// </summary>
        public IFrom from { get; set; }
        /// <summary>
        /// 目标
        /// </summary>
        public IToVC2017 to
        { get; set; }
        public MDK2VC.M2V._Config Config;
        public XDocument document = new XDocument();
        
        public string FileName = "";
        public MDK2VC.M2V.SysConfig ProjectIno;
        public XmlDocument xmlDoc = new XmlDocument();
        public void Creat_Config(string DocName)
        {
            if (DocName != "")
            {
                this.Config.ToolName = "MDK Project Convert To Visual Studio Project";
                this.Config.ToolsVersion = "0.1";
                XNamespace namespace2 = "jtl605@163.com";
                new XElement((XName)(namespace2 + "Tool"), new object[] { new XAttribute("Name", this.Config.ToolName), new XAttribute("Author", "Ka_Chen"), new XAttribute("ToolsVersion", this.Config.ToolsVersion), new XElement((XName)(namespace2 + "UV4Path"), this.Config.UV4Path) }).Save(DocName);
            }
        }

        public string GetFullPath(string basePath, string targetPat)
        {
            Uri baseUri = new Uri(basePath);
            Uri uri2 = new Uri(baseUri, targetPat);
            return uri2.ToString().Replace("/", @"\").Replace(@"file:\\\", "");
        }

        public string GetRelativePath(string basePath, string targetPath)
        {
            Uri uri = new Uri(basePath);
            Uri uri2 = new Uri(targetPath);
            return uri.MakeRelativeUri(uri2).ToString().Replace("/", @"\");
        }

        public bool MDK_CheckProject(string DocName)
        {
            if (DocName == "") return false;
            try
            {
                this.xmlDoc.Load(DocName);
                XmlNode node = this.xmlDoc.SelectSingleNode(".//Header");
                if (node == null) return false;
                return (node.InnerText == "### uVision Project, (C) Keil Software");
            }
            catch
            {
                return false;
            }
        }

        public string MDK_DefineRead(string Doc, string TargetName)
        {
            if (Doc == "") return "";
            if (TargetName == "") return "";
            this.xmlDoc.Load(Doc);
            foreach (XmlNode node in this.xmlDoc.SelectNodes(".//Targets/Target"))
            {
                if (node.SelectSingleNode("./TargetName").InnerText == TargetName) return node.SelectSingleNode(".//VariousControls/Define").InnerText;
            }
            return null;
        }



        public string[] MDK_GroupRead(string Doc, string TargetName)
        {
            if (Doc != "")
            {
                if (TargetName == "") return null;
                this.xmlDoc.Load(Doc);
                foreach (XmlNode node in this.xmlDoc.SelectNodes(".//Targets/Target"))
                {
                    if (node.SelectSingleNode("./TargetName").InnerText == TargetName)
                    {
                        XmlNodeList list2 = node.SelectNodes(".//Groups/*");
                        string[] strArray = new string[list2.Count];
                        int index = 0;
                        foreach (XmlNode node2 in list2)
                        {
                            strArray[index] = node2.SelectSingleNode("./GroupName").InnerText;
                            index++;
                        }
                        return strArray;
                    }
                }
            }
            return null;
        }

        public string MDK_IncludePathRead(string Doc, string TargetName)
        {
            if (Doc == "") return "";
            if (TargetName == "") return "";
            this.xmlDoc.Load(Doc);
            foreach (XmlNode node in this.xmlDoc.SelectNodes(".//Targets/Target"))
            {
                if (node.SelectSingleNode("./TargetName").InnerText == TargetName) return node.SelectSingleNode(".//VariousControls/IncludePath").InnerText;
            }
            return null;
        }

        public string[] MDK_SrcRead(string Doc, string TargetName, string Group)
        {
            if (Doc != "")
            {
                if (Group == "") return null;
                this.xmlDoc.Load(Doc);
                foreach (XmlNode node in this.xmlDoc.SelectNodes(".//Targets/Target"))
                {
                    if (node.SelectSingleNode("./TargetName").InnerText == TargetName)
                    {
                        foreach (XmlNode node2 in node.SelectNodes(".//Groups/Group"))
                        {
                            if (node2.SelectSingleNode("./GroupName").InnerText == Group)
                            {
                                XmlNodeList list3 = node2.SelectNodes("./Files/File");
                                string[] strArray = new string[list3.Count];
                                int index = 0;
                                foreach (XmlNode node3 in list3)
                                {
                                    strArray[index] = node3.SelectSingleNode("./FilePath").InnerText;
                                    index++;
                                }
                                return strArray;
                            }
                        }
                        continue;
                    }
                }
            }
            return null;
        }

        public string[] MDK_TargetRead(string Doc)
        {
            if (Doc == "") return null;
            this.xmlDoc.Load(Doc);
            XmlNodeList list = this.xmlDoc.SelectNodes(".//Targets/*");
            string[] strArray = new string[list.Count];
            int index = 0;
            foreach (XmlNode node in list)
            {
                strArray[index] = node.SelectSingleNode("./TargetName").InnerText;
                index++;
            }
            return strArray;
        }

        public string MDK_TargetStatusRead(string Doc, string TargetName)
        {
            if (Doc == "") return "";
            if (TargetName == "") return "";
            this.xmlDoc.Load(Doc);
            foreach (XmlNode node in this.xmlDoc.SelectNodes(".//Targets/Target"))
            {
                if (node.SelectSingleNode("./TargetName").InnerText == TargetName)
                {
                    string str = "";
                    str = (((((str + "Device: " + node.SelectSingleNode(".//Device").InnerText + "\r\n") + "Error: " + node.SelectSingleNode(".//TargetStatus/Error").InnerText + "\r\n") + "ListingPath: " + node.SelectSingleNode(".//TargetCommonOption/ListingPath").InnerText + "\r\n") + "OutputDirectory: " + node.SelectSingleNode(".//TargetCommonOption/OutputDirectory").InnerText + "\r\n") + "Define: " + node.SelectSingleNode(".//VariousControls/Define").InnerText + "\r\n") + "IncludePath: \r\n";
                    string str2 = node.SelectSingleNode(".//VariousControls/IncludePath").InnerText.Replace(@"..\", @"**\").Replace(@".\", @"..\").Replace(@"**\", @"..\").Replace(";", ";\r\n");
                    return (str + str2);
                }
            }
            return null;
        }

        public void ReadConfig(string DocName)
        {
            if (!File.Exists(DocName))
            {
                //MessageBox.Show("Select the Keil Vision4 installation directory when you first times use the tool");
                var dialog = new System.Windows.Forms.OpenFileDialog();
                dialog.DefaultExt = "exe";
                dialog.Filter = "Keil Exe File (UV4.exe)|UV4.exe";
                dialog.Title = "Select Keil Vision4 Exe Path";
                if (dialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {
                    this.Config.UV4Path = dialog.FileName;
                    this.Creat_Config(this.Config.DocName);
                }
                //else
                //    base.Close();
            }
            else
            {
                XNamespace namespace2 = "jtl605@163.com";
                XDocument document = XDocument.Load(DocName);
                this.Config.UV4Path = document.Root.Element((XName)(namespace2 + "UV4Path")).Value;
            }
        }

        public void VC_Create_UserFile(string DocName, string Debugcmd, string WorkingDirectory, string[] Targets)
        {
            if (DocName != "")
            {
                XNamespace namespace2 = "http://schemas.microsoft.com/developer/msbuild/2003";
                XElement element = new XElement((XName)(namespace2 + "Project"), new XAttribute("ToolsVersion", "4.0"));
                foreach (string str in Targets)
                {
                    element.Add(new XElement((XName)(namespace2 + "PropertyGroup"), new object[] { new XAttribute("Condition", "'$(Configuration)|$(Platform)'=='Target|Win32'".Replace("Target", str)), new XElement((XName)(namespace2 + "LocalDebuggerCommand"), this.ProjectIno.UV4_Path), new XElement((XName)(namespace2 + "LocalDebuggerCommandArguments"), Debugcmd.Replace("Target", str)), new XElement((XName)(namespace2 + "LocalDebuggerWorkingDirectory"), WorkingDirectory), new XElement((XName)(namespace2 + "DebuggerFlavor"), "WindowsLocalDebugger") }));
                }
                element.Save(DocName);
            }
        }

        public void VC_Filters_Create(string DocName, string[] Targets)
        {
            if (DocName != "")
            {
                XNamespace namespace2 = "http://schemas.microsoft.com/developer/msbuild/2003";
                XElement element = new XElement((XName)(namespace2 + "Project"), new object[] { new XAttribute("DefaultTargets", "Build"), new XAttribute("ToolsVersion", "4.0") });
                XElement content = new XElement((XName)(namespace2 + "ItemGroup"), "");
                string str = "源文件";
                content.Add(new object[] { new XElement((XName)(namespace2 + "Filter"), new object[] { new XAttribute("Include", str), new XElement((XName)(namespace2 + "UniqueIdentifier"), Guid.NewGuid().ToString("B")), new XElement((XName)(namespace2 + "Extensions"), "cpp;c;cc;cxx;def;odl;idl;hpj;bat;asm;asmx") }), new XElement((XName)(namespace2 + "Filter"), new object[] { new XAttribute("Include", "头文件"), new XElement((XName)(namespace2 + "UniqueIdentifier"), Guid.NewGuid().ToString("B")), new XElement((XName)(namespace2 + "Extensions"), "h;hpp;hxx;hm;inl;inc;xsd") }), new XElement((XName)(namespace2 + "Filter"), new object[] { new XAttribute("Include", "项目说明"), new XElement((XName)(namespace2 + "UniqueIdentifier"), Guid.NewGuid().ToString("B")), new XElement((XName)(namespace2 + "Extensions"), "txt") }) });
                string[] strArray = this.MDK_GroupRead(this.ProjectIno.MDK_Project_File, this.ProjectIno.MDK_Target);
                foreach (string str2 in strArray)
                {
                    content.Add(new XElement((XName)(namespace2 + "Filter"), new object[] { new XAttribute("Include", str + @"\" + str2), new XElement((XName)(namespace2 + "UniqueIdentifier"), Guid.NewGuid().ToString("B")) }));
                }
                element.Add(content);
                content = new XElement((XName)(namespace2 + "ItemGroup"), "");
                XElement element3 = new XElement((XName)(namespace2 + "ItemGroup"), "");
                foreach (string str3 in strArray)
                {
                    foreach (string str4 in this.MDK_SrcRead(this.ProjectIno.MDK_Project_File, Targets[0], str3))
                    {
                        string targetPath = "";
                        targetPath = this.GetFullPath(this.ProjectIno.MDK_Project_Path, str4);
                        targetPath = this.GetRelativePath(this.ProjectIno.VCProject_Path, targetPath);
                        if (targetPath.EndsWith(".c"))
                            element3.Add(new XElement((XName)(namespace2 + "ClCompile"), new object[] { new XAttribute("Include", targetPath), new XElement((XName)(namespace2 + "Filter"), str + @"\" + str3) }));
                        else
                            content.Add(new XElement((XName)(namespace2 + "None"), new object[] { new XAttribute("Include", targetPath), new XElement((XName)(namespace2 + "Filter"), str + @"\" + str3) }));
                    }
                }
                content.Add(new XElement((XName)(namespace2 + "None"), new object[] { new XAttribute("Include", "Readme.txt"), new XElement((XName)(namespace2 + "Filter"), @"项目说明\") }));
                element.Add(element3);
                element.Add(content);
                element.Save(DocName);
            }
        }

        public void VC_vcxproj_Create(string DocName, string[] Targets)
        {
            if (DocName != "")
            {
                XNamespace namespace2 = "http://schemas.microsoft.com/developer/msbuild/2003";
                XElement element = new XElement((XName)(namespace2 + "Project"), new object[] { new XAttribute("DefaultTargets", "Build"), new XAttribute("ToolsVersion", "4.0") });
                XElement content = new XElement((XName)(namespace2 + "ItemGroup"), new XAttribute("Label", "ProjectConfigurations"));
                foreach (string str in Targets)
                {
                    content.Add(new XElement((XName)(namespace2 + "ProjectConfiguration"), new object[] { new XAttribute("Include", "Target|Win32".Replace("Target", str)), new XElement((XName)(namespace2 + "Configuration"), str), new XElement((XName)(namespace2 + "Platform"), "Win32") }));
                }
                element.Add(content);
                XElement element3 = new XElement((XName)(namespace2 + "PropertyGroup"), new object[] { new XAttribute("Label", "Globals"), new XElement((XName)(namespace2 + "ProjectGuid"), Guid.NewGuid().ToString("B")), new XElement((XName)(namespace2 + "Keyword"), "MakeFileProj") });
                element.Add(element3);
                element.Add(new XElement((XName)(namespace2 + "Import"), new XAttribute("Project", @"$(VCTargetsPath)\Microsoft.Cpp.Default.props")));
                foreach (string str2 in Targets)
                {
                    element.Add(new XElement((XName)(namespace2 + "PropertyGroup"), new object[] { new XAttribute("Condition", "'$(Configuration)|$(Platform)'=='Target|Win32'".Replace("Target", str2)), new XAttribute("Label", "Configuration"), new XElement((XName)(namespace2 + "ConfigurationType"), "Makefile"), new XElement((XName)(namespace2 + "UseDebugLibraries"), "true") }));
                }
                element.Add(new object[] { new XElement((XName)(namespace2 + "Import"), new XAttribute("Project", @"$(VCTargetsPath)\Microsoft.Cpp.props")), new XElement((XName)(namespace2 + "ImportGroup"), new XAttribute("Label", "ExtensionSettings")) });
                foreach (string str3 in Targets)
                {
                    element.Add(new XElement((XName)(namespace2 + "ImportGroup"), new object[] { new XAttribute("Condition", "'$(Configuration)|$(Platform)'=='Target|Win32'".Replace("Target", str3)), new XAttribute("Label", "PropertySheets"), new XElement((XName)(namespace2 + "Import"), new object[] { new XAttribute("Project", @"$(UserRootDir)\Microsoft.Cpp.$(Platform).user.props"), new XAttribute("Condition", @"exists('$(UserRootDir)\Microsoft.Cpp.$(Platform).user.props')"), new XAttribute("Label", "LocalAppDataPlatform") }) }));
                }
                element.Add(new XElement((XName)(namespace2 + "PropertyGroup"), new XAttribute("Label", "UserMacros")));
                foreach (string str4 in Targets)
                {
                    string[] strArray = this.MDK_IncludePathRead(this.ProjectIno.MDK_Project_File, str4).Split(new char[] { ';' });
                    string targetPath = null;
                    string str7 = null;
                    for (int i = 0; i < strArray.Length; i++)
                    {
                        targetPath = this.GetFullPath(this.ProjectIno.MDK_Project_Path, strArray[i]);
                        str7 = str7 + this.GetRelativePath(this.ProjectIno.VCProject_Path, targetPath) + ";";
                    }
                    element.Add(new XElement((XName)(namespace2 + "PropertyGroup"), new object[] { new XAttribute("Condition", "'$(Configuration)|$(Platform)'=='Target|Win32'".Replace("Target", str4)), new XElement((XName)(namespace2 + "NMakeOutput"), "Template.exe".Replace("Template", this.ProjectIno.ProjectName)), new XElement((XName)(namespace2 + "NMakePreprocessorDefinitions"), this.MDK_DefineRead(this.ProjectIno.MDK_Project_File, str4)), new XElement((XName)(namespace2 + "IncludePath"), str7), new XElement((XName)(namespace2 + "NMakeBuildCommandLine"), this.ProjectIno.NMakeBuildCommandLine.Replace("Target", str4)) }));
                }
                element.Add(new XElement((XName)(namespace2 + "ItemDefinitionGroup"), ""));
                string[] strArray2 = this.MDK_GroupRead(this.ProjectIno.MDK_Project_File, Targets[0]);
                XElement element4 = new XElement((XName)(namespace2 + "ItemGroup"), "");
                XElement element5 = new XElement((XName)(namespace2 + "ItemGroup"), "");
                foreach (string str8 in strArray2)
                {
                    foreach (string str9 in this.MDK_SrcRead(this.ProjectIno.MDK_Project_File, Targets[0], str8))
                    {
                        string fullPath = "";
                        fullPath = this.GetFullPath(this.ProjectIno.MDK_Project_Path, str9);
                        fullPath = this.GetRelativePath(this.ProjectIno.VCProject_Path, fullPath);
                        if (fullPath.EndsWith(".c"))
                            element5.Add(new XElement((XName)(namespace2 + "ClCompile"), new XAttribute("Include", fullPath)));
                        else
                            element4.Add(new XElement((XName)(namespace2 + "None"), new XAttribute("Include", fullPath)));
                    }
                }
                element4.Add(new XElement((XName)(namespace2 + "None"), new XAttribute("Include", "Readme.txt")));
                element.Add(element4);
                element.Add(element5);
                element.Add(new XElement((XName)(namespace2 + "Import"), new XAttribute("Project", @"$(VCTargetsPath)\Microsoft.Cpp.targets")));
                element.Add(new XElement((XName)(namespace2 + "ImportGroup"), new object[] { new XAttribute("Label", "ExtensionTargets"), "" }));
                element.Save(DocName);
            }
        }



    }
}
