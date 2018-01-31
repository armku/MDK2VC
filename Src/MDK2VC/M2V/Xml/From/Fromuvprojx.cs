using System;
using System.Collections.Generic;
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
        public String GetMacroDefine(string path)
        {
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
            }
            return builder.ToString();
        }
        public string getIncludePath(string path)
        {
            var doc = XElement.Load(path);
            var Targets = doc.Element("Targets");
            var Target = Targets.Element("Target");
            var TargetOption = Target.Element("TargetOption");
            var TargetArmAds = TargetOption.Element("TargetArmAds");
            var Cads = TargetArmAds.Element("Cads");
            var VariousControls = Cads.Element("VariousControls");
            var IncludePath = VariousControls.Element("IncludePath");

            return IncludePath.Value;
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
