using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Xml.Linq;

namespace MDK2VC.M2V.Xml
{
    class Fromcyprj : IFrom
    {/// <summary>
     /// 获取宏定义
     /// </summary>
     /// <param name="path"></param>
     /// <returns></returns>
        public List<String> GetMacroDefine(string path)
        {
            XElement Define = null;

            var ret = new List<String>();
            //var builder = new StringBuilder();
            //var doc = XElement.Load(path);
            //var Targets = doc.Element("Targets");
            //var Target = Targets.Element("Target");
            //var TargetOption = Target.Element("TargetOption");

            //var TargetArmAds51 = TargetOption.Element("Target51");
            //var TargetArmAdsM3 = TargetOption.Element("TargetArmAds");
            //if (TargetArmAds51 != null && TargetArmAds51.HasElements)
            //{
            //    var Cads = TargetArmAds51.Element("C51");
            //    var VariousControls = Cads.Element("VariousControls");
            //    Define = VariousControls.Element("Define");
            //}
            //else if (TargetArmAdsM3 != null && TargetArmAdsM3.HasElements)
            //{
            //    var Cads = TargetArmAdsM3.Element("Cads");
            //    var VariousControls = Cads.Element("VariousControls");
            //    Define = VariousControls.Element("Define");
            //}
            //else { }

            //if (Define != null)
            //{
            //    var strs = Define.Value.ToString().Split(new char[] { ',' });
            //    foreach (var str in strs)
            //    {
            //        builder.Append(str).Append(";");
            //        ret.Add(str);
            //    }
            //}
            ret.Add("DEBUG");
            return ret;
        }
        public List<String> getIncludePath(string path)
        {
            XElement IncludePath = null;

            var ret = new List<String>();
            //var doc = XElement.Load(path);
            //var Targets = doc.Element("Targets");
            //var Target = Targets.Element("Target");
            //var TargetOption = Target.Element("TargetOption");

            //var TargetArmAds51 = TargetOption.Element("Target51");
            //var TargetArmAdsM3 = TargetOption.Element("TargetArmAds");
            //if (TargetArmAds51 != null && TargetArmAds51.HasElements)
            //{
            //    var Cads = TargetArmAds51.Element("C51");
            //    var VariousControls = Cads.Element("VariousControls");
            //    IncludePath = VariousControls.Element("IncludePath");
            //}
            //else if (TargetArmAdsM3 != null && TargetArmAdsM3.HasElements)
            //{
            //    var Cads = TargetArmAdsM3.Element("Cads");
            //    var VariousControls = Cads.Element("VariousControls");
            //    IncludePath = VariousControls.Element("IncludePath");
            //}
            //else { }

            //var IncludePaths = IncludePath.Value.ToString().Split(new char[] { ';' });
            //foreach (var vn in IncludePaths)
            //{
            //    ret.Add("..\\" + vn);
            //}
            ret.Add("DEBUG");
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
            var treelevel_0 = new BTree<Node>();
            treelevel_0.Data = new Node("文件", "", true);

            var i = 1;
            var namegroup = "";
            var parent = treelevel_0;
            bool hasfiles = false;
            if (File.Exists(filename))
            {
                using (var sr = File.OpenText(filename))
                {
                    var s = "";
                    while ((s = sr.ReadLine()) != null)
                    {
                        if (s.IndexOf("type_name") <= 0)
                            continue;
                        if (s.IndexOf("xml_contents_version") >= 0)
                            continue;
                        var ssspaces = s.Split(' ');
                        foreach (var sss in ssspaces)
                        {
                            var ssequals = sss.Split('=');
                            if ((ssequals != null) && ssequals.Length == 2 && ssequals[0].Equals("name"))
                            {
                                namegroup = ssequals[1].Split('"')[1];
                            }
                            if ((ssequals != null) && ssequals.Length == 2 && ssequals[0].Equals("persistent"))
                            {
                                if (ssequals[1].Split('"')[1].Length == 0)
                                {
                                    //文件夹
                                    var tnode = new BTree<Node>();
                                    tnode.Data = new Node(namegroup + i.ToString(), "", true);
                                    parent.AddNode(tnode);
                                    if (hasfiles)
                                    {
                                        parent = tnode;
                                    }
                                    hasfiles = true;
                                    //treelevel_0.AddNode(treenodes[i]);
                                    i++;
                                }
                                else
                                {
                                    //文件
                                    if (ssequals[1].Split('"')[1].IndexOf(".cyprj") >= 0)
                                    {
                                        //工程名称
                                        treelevel_0.Data.Name = ssequals[1].Split('"')[1];
                                        hasfiles = true;
                                    }
                                    else
                                    {
                                        var tree3 = new BTree<Node>();
                                        tree3.Data = new Node(ssequals[1].Split('"')[1]);
                                        parent.AddNode(tree3);
                                        hasfiles = true;
                                        //treenodes[i - 1].AddNode(tree3);
                                        //i++;
                                    }
                                }
                            }
                        }

                    }
                }
            }
            return treelevel_0;
        }
    }
}
