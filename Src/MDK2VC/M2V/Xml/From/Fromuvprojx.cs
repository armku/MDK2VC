using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Xml.Linq;

namespace MDK2VC.M2V.Xml
{
    public class Fromuvprojx:IFrom
    {
        /// <summary>
        /// 获取宏定义
        /// </summary>
        /// <param name="path"></param>
        /// <returns></returns>
        public List<String> GetMacroDefine(string path)
        {
            var ret = new List<String>();
            var builder = new StringBuilder();
            var doc = XElement.Load(path);
            var Targets = doc.Element("Targets");
            var Target = Targets.Element("Target");
            var TargetOption = Target.Element("TargetOption");
            var TargetArmAds = TargetOption.Element("TargetArmAds");
            var Cads = TargetArmAds.Element("Cads");
            var VariousControls = Cads.Element("VariousControls");
            var Define = VariousControls.Element("Define");
            var strs = Define.Value.ToString().Split(new char[] { ',' });
            foreach (var str in strs)
            {
                builder.Append(str).Append(";");
                ret.Add(str);
            }
            //return builder.ToString();
            return ret;
        }        
        public List<String> getIncludePath(string path)
        {
            var ret = new List<String>();
            var doc = XElement.Load(path);
            var Targets = doc.Element("Targets");
            var Target = Targets.Element("Target");
            var TargetOption = Target.Element("TargetOption");
            var TargetArmAds = TargetOption.Element("TargetArmAds");
            var Cads = TargetArmAds.Element("Cads");
            var VariousControls = Cads.Element("VariousControls");
            var IncludePath = VariousControls.Element("IncludePath");

            var IncludePaths = IncludePath.Value.ToString().Split(new char[] { ';'});
            foreach(var vn in IncludePaths)
            {
                ret.Add("..\\"+vn);
            }
            return ret;
        }
        /// <summary>
        /// 获取工程中文件
        /// </summary>
        /// <param name="filename">工程文件名</param>
        /// <returns></returns>
        [Description("获取工程中文件")]
        public BTree<Node> GetFiles(string filename)
        {
            var tree1 = new BTree<Node>();
            tree1.Data = new Node("文件", true);

            var doc = XElement.Load(filename);
            var Targets = doc.Element("Targets");
            var Target = Targets.Element("Target");
            var Groups = Target.Element("Groups");

            var Group = Groups.Elements("Group");
            foreach (var grou in Group)
            {
                var aa = grou.Element("GroupName");
                var tree2 = new BTree<Node>();
                tree2.Data = new Node(aa.Value, false);
                tree1.AddNode(tree2);

                var Files = grou.Elements("Files");
                foreach (var File in Files)
                {
                    var file = File.Elements("File");
                    foreach (var ff in file)
                    {
                        var FilePath = ff.Element("FilePath");
                        if (FilePath != null)
                        {
                            var tree3 = new BTree<Node>();
                            tree3.Data = new Node(FilePath.Value, false);
                            tree2.AddNode(tree3);
                        }
                    }
                }
            }
            return tree1;
        }
        public String getGroups(string path)
        {
            var builder = new StringBuilder();
            var doc = XElement.Load(path);
            var Targets = doc.Element("Targets");
            var Target = Targets.Element("Target");
            var Groups = Target.Element("Groups");

            var Group = Groups.Elements("Group");
            foreach (var grou in Group)
            {
                var aa = grou.Element("GroupName");
                builder.AppendLine(aa.Value);
                var Files = grou.Elements("Files");
                foreach (var File in Files)
                {
                    var file = File.Elements("File");
                    foreach (var ff in file)
                    {
                        var FilePath = ff.Element("FilePath");
                        if (FilePath != null)
                            builder.AppendLine(FilePath.Value);
                    }
                }
            }
            return builder.ToString();
        }
        public string getGroupsToFilters(string path)
        {
            var builder = new StringBuilder();
            var doc = XElement.Load(path);
            var Targets = doc.Element("Targets");
            var Target = Targets.Element("Target");
            var Groups = Target.Element("Groups");

            var Group = Groups.Elements("Group");
            foreach (var grou in Group)
            {
                var aa = grou.Element("GroupName");
                var Files = grou.Elements("Files");
                foreach (var File in Files)
                {
                    var file = File.Elements("File");
                    foreach (var ff in file)
                    {
                        var FilePath = ff.Element("FilePath");
                        builder.Append("    <ClCompile Include=\"");
                        if (FilePath != null)
                        {
                            if (FilePath.Value.StartsWith(".\\"))
                                builder.Append(FilePath.Value.Replace(".\\","..\\"));
                            else
                                builder.Append("..\\"+FilePath.Value);
                        }
                        builder.AppendLine("\">");
                        builder.Append("      <Filter>").Append(aa.Value).AppendLine("</Filter>");
                        builder.AppendLine("    </ClCompile>");
                    }
                }
            }
            return builder.ToString();
        }
        public string getGroupsToProj(string path)
        {
            var builder = new StringBuilder();
            var doc = XElement.Load(path);
            var Targets = doc.Element("Targets");
            var Target = Targets.Element("Target");
            var Groups = Target.Element("Groups");

            var Group = Groups.Elements("Group");
            foreach (var grou in Group)
            {
                var aa = grou.Element("GroupName");
                var Files = grou.Elements("Files");
                foreach (var File in Files)
                {
                    var file = File.Elements("File");
                    foreach (var ff in file)
                    {
                        var FilePath = ff.Element("FilePath");
                        builder.Append("    <ClCompile Include=\"");
                        if (FilePath != null)
                        {
                            if (FilePath.Value.StartsWith(".\\"))
                                builder.Append(FilePath.Value.Replace(".\\","..\\"));
                            else
                            builder.Append("..\\" + FilePath.Value);
                        }
                        builder.AppendLine("\" /> ");
                    }
                }
            }
            return builder.ToString();
        }
        public String getGrouptoFilters(string path)
        {
            var builder = new StringBuilder();
            var doc = XElement.Load(path);
            var Targets = doc.Element("Targets");
            var Target = Targets.Element("Target");
            var Groups = Target.Element("Groups");

            var Group = Groups.Elements("Group");
            foreach (var grou in Group)
            {
                var aa = grou.Element("GroupName");
                if (aa.Value.StartsWith(".\\"))
                    builder.Append("    <Filter Include=\"").Append(aa.Value.Replace(".\\","..\\")).AppendLine("\">");
                else
                    builder.Append("    <Filter Include=\"").Append(aa.Value).AppendLine("\">");
                builder.Append("      <UniqueIdentifier>").Append(Guid.NewGuid().ToString("B")).AppendLine("</UniqueIdentifier>");
                builder.AppendLine("    </Filter>");
            }
            return builder.ToString();
        }
    }
}
