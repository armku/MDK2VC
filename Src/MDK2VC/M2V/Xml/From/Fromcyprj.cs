using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Xml;
using System.Xml.Linq;

namespace MDK2VC.M2V.Xml
{
    class Fromcyprj : IFrom
    {
        /// <summary>
        /// 获取生成目标
        /// </summary>
        /// <param name="path"></param>
        /// <returns></returns>
        public List<String> GetMacroTarget(string path)
        {
            var ret = new List<String>();

            return ret;
        }



        /// <summary>
        /// 获取宏定义
        /// </summary>
        /// <param name="path"></param>
        /// <returns></returns>
        public List<String> GetMacroDefine(string path)
        {
            var ret = new List<String>();
                       
            ret.Add("DEBUG");
            return ret;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="path"></param>
        /// <returns></returns>
        public String GetTargetName(string path)
        {
            return "DEBUG";
        }
        public List<String> getIncludePath(string path)
        {
            var ret = new List<String>();

            ret.Add(@"..");
            ret.Add(@"..\Generated_Source\PSoC5");
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
                       
            var namegroup = "";
            var currentnode = treelevel_0;
            var parentnode = treelevel_0;//上一级
            var grandparentnode = treelevel_0;//上上级
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
                                    tnode.Data = new Node(namegroup, "", true);
                                    
                                    if (hasfiles)
                                    {
                                        //已经有文件
                                        parentnode.AddNode(tnode);
                                        currentnode = tnode;                                    
                                    }
                                    else
                                    {
                                        //一直是文件夹
                                        currentnode.AddNode(tnode);
                                        grandparentnode = parentnode;
                                        parentnode = currentnode;
                                        currentnode = tnode;
                                    }
                                    hasfiles = false;
                                }
                                else
                                {
                                    //文件
                                    if (ssequals[1].Split('"')[1].IndexOf(".cyprj") >= 0)
                                    {
                                        //工程名称
                                        treelevel_0.Data.Name = ssequals[1].Split('"')[1];
                                        hasfiles = false;
                                    }
                                    else if (ssequals[1].Split('"')[1].IndexOf(".cydwr") >= 0)
                                    {
                                        //特殊目录
                                        hasfiles = false;
                                    }
                                    else if (ssequals[1].Split('"')[1].IndexOf("TopDesign") >= 0)
                                    {
                                        //特殊目录
                                        hasfiles = false;
                                    }
                                    else if ((ssequals[1].Split('"')[1].IndexOf("Generated_Source") >= 0)&&((ssequals[1].Split('"')[1].Length== "Generated_Source".Length)))
                                    {
                                        //特殊目录
                                        var tree3 = new BTree<Node>();
                                        tree3.Data = new Node(ssequals[1].Split('"')[1]);
                                        treelevel_0.AddNode(tree3);

                                        grandparentnode = treelevel_0;
                                        parentnode = treelevel_0;
                                        currentnode = tree3;
                                        hasfiles = false;
                                    }
                                    else if ((ssequals[1].Split('"')[1].IndexOf(@"Generated_Source\PSoC5") >= 0) && ((ssequals[1].Split('"')[1].Length == @"Generated_Source\PSoC5".Length)))
                                    {
                                        //特殊目录
                                        var tree3 = new BTree<Node>();
                                        tree3.Data = new Node(ssequals[1].Split('"')[1]);
                                        tree3.Data.Name = "PSoC5";
                                        currentnode.AddNode(tree3);

                                        grandparentnode = parentnode;
                                        parentnode = currentnode;
                                        currentnode = tree3;

                                        grandparentnode = parentnode;
                                        parentnode = currentnode;
                                        
                                        hasfiles = false;
                                    }
                                    else
                                    {
                                        //常规文件
                                        var tree3 = new BTree<Node>();
                                        tree3.Data = new Node(ssequals[1].Split('"')[1]);
                                        currentnode.AddNode(tree3);
                                        hasfiles = true;
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
