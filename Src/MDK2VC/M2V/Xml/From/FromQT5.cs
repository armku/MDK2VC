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
    public class FromQT5 : IFrom
    {
        /// <summary>
        /// 获取生成目标
        /// </summary>
        /// <param name="path"></param>
        /// <returns></returns>
        public List<String> GetMacroTarget(string path)
        {
            var ret = new List<String>();

            if (path == "") return ret;


            ret.Add("QT");
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
            var builder = new StringBuilder();

            builder.Append("__CC_ARM;");
            ret.Add("__CC_ARM");
            //return builder.ToString();
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
        public List<String> GetIncludePath(string path)
        {
            var ret = new List<String>();

            return ret;
        }
        /// <summary>
        /// 获取的文件内容
        /// </summary>
        public string files { get; set; } = "";
        /// <summary>
        /// 获取的文件内容
        /// </summary>
        public string SOURCES { get; set; } = "";
        /// <summary>
        /// 获取的文件内容
        /// </summary>
        public string HEADERS { get; set; } = "";




        /// <summary>
        /// 获取工程中文件
        /// </summary>
        /// <param name="filename">工程文件名</param>
        /// <returns></returns>
        [Description("获取工程中文件")]
        public BTree<Node> GetFiles(string filename)
        {
            var tree1 = new BTree<Node>
            {
                Data = new Node("文件", "", true)
            };

            using (StreamReader sr = new StreamReader(filename))
            {
                string line;

                files = "";
                // 从文件读取并显示行，直到文件的末尾 ,文件以;分割
                while ((line = sr.ReadLine()) != null)
                {
                    line = line.Trim();
                    SOURCES = "";
                    HEADERS = "";

                    //注释语句忽略
                    if (line.StartsWith("#"))
                        continue;
                    if (line.Trim().Length == 0)
                        continue;

                    if (line.EndsWith(@"\"))
                    {
                        files += line.Remove(line.Length - 1, 1) + ";";
                    }
                    else
                    {
                        files += line + Environment.NewLine;
                    }
                }

                System.Windows.Forms.MessageBox.Show(files);

                //分析文件
                var fileline = files.Split(Environment.NewLine);
                foreach (var vn in fileline)
                {
                    if (vn.StartsWith("SOURCES"))
                    {
                        SOURCES = vn;
                    }
                }


                System.Windows.Forms.MessageBox.Show(SOURCES);




            }


            var tree2 = new BTree<Node>
            {
                Data = new Node("AA.C", "", false)
            };
            tree1.AddNode(tree2);




            var tree3 = new BTree<Node>
            {
                Data = new Node("BB.C", "", false)
            };
            tree2.AddNode(tree3);




            return tree1;
        }
    }
}
