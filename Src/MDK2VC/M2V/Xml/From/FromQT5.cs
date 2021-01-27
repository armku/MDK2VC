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
            var aa = Path.GetDirectoryName(path);
            ret.Add(aa);

            var qtPath = @"C:\Qt\Qt5.10.0\5.10.0\mingw53_32\include\";

            ret.Add(qtPath+@"ActiveQt");
            ret.Add(qtPath + @"Qt3DAnimation");
            ret.Add(qtPath + @"Qt3DCore");
            ret.Add(qtPath + @"Qt3DExtras");
            ret.Add(qtPath + @"Qt3DInput");
            ret.Add(qtPath + @"Qt3DLogic");
            ret.Add(qtPath + @"Qt3DQuick");
            ret.Add(qtPath + @"Qt3DQuickAnimation");
            ret.Add(qtPath + @"Qt3DQuickExtras");
            ret.Add(qtPath + @"Qt3DQuickInput");
            ret.Add(qtPath + @"Qt3DQuickRender");
            ret.Add(qtPath + @"Qt3DQuickScene2D");
            ret.Add(qtPath + @"Qt3DRender");
            ret.Add(qtPath + @"QtAccessibilitySupport");
            ret.Add(qtPath + @"QtANGLE\EGL");
            ret.Add(qtPath + @"QtANGLE\GLES2");
            ret.Add(qtPath + @"QtANGLE\GLES3");
            ret.Add(qtPath + @"QtANGLE\KHR");
            ret.Add(qtPath + @"QtBluetooth");
            ret.Add(qtPath + @"QtCharts");
            ret.Add(qtPath + @"QtConcurrent");
            ret.Add(qtPath + @"QtCore");
            ret.Add(qtPath + @"QtDataVisualization");
            ret.Add(qtPath + @"QtDBus");
            ret.Add(qtPath + @"QtDesigner");
            ret.Add(qtPath + @"QtDesignerComponents");
            ret.Add(qtPath + @"QtDeviceDiscoverySupport");
            ret.Add(qtPath + @"QtEdidSupport");
            ret.Add(qtPath + @"QtEglSupport");
            ret.Add(qtPath + @"QtEventDispatcherSupport");
            ret.Add(qtPath + @"QtFbSupport");
            ret.Add(qtPath + @"QtFontDatabaseSupport");
            ret.Add(qtPath + @"QtGamepad");
            ret.Add(qtPath + @"QtGui");
            ret.Add(qtPath + @"QtHelp");
            ret.Add(qtPath + @"QtLocation");
            ret.Add(qtPath + @"QtMultimedia");
            ret.Add(qtPath + @"QtMultimediaQuick");
            ret.Add(qtPath + @"QtMultimediaWidgets");
            ret.Add(qtPath + @"QtNetwork");
            ret.Add(qtPath + @"QtNetworkAuth");
            ret.Add(qtPath + @"QtNfc");
            ret.Add(qtPath + @"QtOpenGL");
            ret.Add(qtPath + @"QtOpenGLExtensions");
            ret.Add(qtPath + @"QtPacketProtocol");
            ret.Add(qtPath + @"QtPlatformCompositorSupport");
            ret.Add(qtPath + @"QtPlatformHeaders");
            ret.Add(qtPath + @"QtPositioning");
            ret.Add(qtPath + @"QtPrintSupport");
            ret.Add(qtPath + @"QtQml");
            ret.Add(qtPath + @"QtQmlDebug");
            ret.Add(qtPath + @"QtQuick");
            ret.Add(qtPath + @"QtQuickControls2");
            ret.Add(qtPath + @"QtQuickParticles");
            ret.Add(qtPath + @"QtQuickTemplates2");
            ret.Add(qtPath + @"QtQuickTest");
            ret.Add(qtPath + @"QtQuickWidgets");
            ret.Add(qtPath + @"QtRemoteObjects");
            ret.Add(qtPath + @"QtRepParser");
            ret.Add(qtPath + @"QtScript");
            ret.Add(qtPath + @"QtScriptTools");
            ret.Add(qtPath + @"QtScxml");
            ret.Add(qtPath + @"QtSensors");
            ret.Add(qtPath + @"QtSerialBus");
            ret.Add(qtPath + @"QtSerialPort");
            ret.Add(qtPath + @"QtSql");
            ret.Add(qtPath + @"QtSvg");
            ret.Add(qtPath + @"QtTest");
            ret.Add(qtPath + @"QtTextToSpeech");
            ret.Add(qtPath + @"QtThemeSupport");
            ret.Add(qtPath + @"QtUiPlugin");
            ret.Add(qtPath + @"QtUiTools");
            ret.Add(qtPath + @"QtWebChannel");
            ret.Add(qtPath + @"QtWebSockets");
            ret.Add(qtPath + @"QtWidgets");
            ret.Add(qtPath + @"QtWinExtras");
            ret.Add(qtPath + @"QtXml");
            ret.Add(qtPath + @"QtXmlPatterns");
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
            var tree2 = new BTree<Node>
            {
                Data = new Node("QT", "", false)
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

                //System.Windows.Forms.MessageBox.Show(files);

                //分析文件
                var fileline = files.Split(Environment.NewLine);
                foreach (var vn in fileline)
                {
                    if (vn.StartsWith("SOURCES"))
                    {
                        SOURCES = vn;
                    }
                    if (vn.StartsWith("HEADERS"))
                    {
                        HEADERS = vn;
                    }
                }
                var sourceline = SOURCES.Split(";");
                foreach(var vn in sourceline)
                {
                    if (vn.StartsWith("SOURCES"))
                        continue;

                    var vns = vn.Split('/');

                    if (vns.Length == 1)
                    {
                        var tree00 = new BTree<Node>
                        {
                            Data = new Node(vn, "", false)
                        };
                        tree2.AddNode(tree00);
                    }
                    else if(vns.Length==2)
                    {
                        var tree00 = new BTree<Node>
                        {
                            Data = new Node(vns[0], "", false)
                        };
                        var tree01 = new BTree<Node>
                        {
                            Data = new Node(vn, "", false)
                        };
                        tree00.AddNode(tree01);

                        tree2.AddNode(tree00);
                    }
                    else if (vns.Length == 3)
                    {
                        var tree00 = new BTree<Node>
                        {
                            Data = new Node(vns[0], "", false)
                        };
                        var tree01 = new BTree<Node>
                        {
                            Data = new Node(vns[1], "", false)
                        };
                        var tree02 = new BTree<Node>
                        {
                            Data = new Node(vn, "", false)
                        };

                        tree01.AddNode(tree02);

                        tree00.AddNode(tree01);

                        tree2.AddNode(tree00);
                    }
                    else if (vns.Length == 4)
                    {
                        var tree00 = new BTree<Node>
                        {
                            Data = new Node(vns[0], "", false)
                        };
                        var tree01 = new BTree<Node>
                        {
                            Data = new Node(vns[1], "", false)
                        };
                        var tree02 = new BTree<Node>
                        {
                            Data = new Node(vns[2], "", false)
                        };
                        var tree03 = new BTree<Node>
                        {
                            Data = new Node(vn, "", false)
                        };

                        tree02.AddNode(tree03);

                        tree01.AddNode(tree02);

                        tree00.AddNode(tree01);

                        tree2.AddNode(tree00);
                    }
                }

                //System.Windows.Forms.MessageBox.Show(SOURCES);
                //System.Windows.Forms.MessageBox.Show(HEADERS);

            }

            tree1.AddNode(tree2);

            return tree1;
        }
    }
}
