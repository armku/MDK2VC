using MDK2VC.M2V;
using MDK2VC.M2V.Config;
using MDK2VC.M2V.Xml;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Reflection;
using System.Text;
using System.Windows.Forms;
using System.Xml;
using System.Xml.Linq;

namespace MDK2VC
{
    public partial class FormMain : Form
    {
        CoreManager manager = new CoreManager();
        /// <summary>
        /// 项目配置
        /// </summary>
        SysConfig cfg = new SysConfig();
        public FormMain()
        {
            InitializeComponent();
        }

        private void FormMain_Load(object sender, EventArgs e)
        {
            cfg.FromFilePath = Properties.Settings.Default.LastFileName;
            if (cfg.FromFilePath.Length < 5)
                cfg.FromFilePath = ".uvprojx";
            comboBoxMDKPath.Text = cfg.FromFilePath;
            tBoxSlnPath.Text = cfg.Sln;
            this.Text = "MDK4 MDK5 2 VC Ver:"+ Assembly.GetExecutingAssembly().GetName().Version.ToString() + " Net:"+System.Environment.Version.ToString();
            switch(cfg.TargetType)
            {
                case 2019:
                    comboBoxOutTarget.Text = "VC2019";
                    break;
                case 2017:
                    comboBoxOutTarget.Text = "VC2017";
                    break;
                default:
                    comboBoxOutTarget.Text = "VC2019";
                    break;
            }
            checkBoxManulSetTarget.Checked = MDK2VCConfig.Current.OutputPathManulSet;
            comboBoxOutTarget.Text = MDK2VCConfig.Current.StrOutputPathTarget;
            comboBoxMDKPath.Text = MDK2VCConfig.Current.StrMDKFilePath;
            comboBoxMDKPath.Items.Clear();
            foreach(var v in MDK2VCConfig.Current.StrMDKFilePathHis)
            {
                comboBoxMDKPath.Items.Add(v);
            }
        }
        private void BtnTrans_Click(object sender, EventArgs e)
        {
            if (comboBoxOutTarget.Text.Contains("2019"))
            {
                cfg.TargetType = 2019;
            }
            else if (comboBoxOutTarget.Text.Contains("2017"))
            {
                cfg.TargetType = 2017;
            }
            else
            {
                cfg.TargetType = 2019;
            }
            if ((cfg.FromFilePath == null) || (!File.Exists(cfg.FromFilePath)))
            {
                MessageBox.Show("请选择正确的文件");
                return;
            }
            switch (Path.GetExtension(cfg.FromFilePath))
            {
                case ".uvproj":
                    manager.From = new Fromuvproj();
                    break;
                case ".uvprojx":
                    manager.From = new Fromuvprojx();
                    break;
                case ".cyprj":
                    manager.From = new Fromcyprj();
                    break;
                default:
                    break;
            }
            if (cfg.TargetType == 2017)
            {
                manager.To = new ToVC2017();
            }
            else if (cfg.TargetType == 2019)
            {
                manager.To = new ToVC2019();
            }

            else
            {
                manager.To = new ToVC2019();
            }

            cfg.UV4_Path = "C:\\Keil_v5\\UV4\\Uv4.exe";
            cfg.MacroDefine = manager.From.GetMacroDefine(cfg.FromFilePath);
            cfg.IncludePathOld = manager.From.GetIncludePath(cfg.FromFilePath);
            cfg.ProjFiles = manager.From.GetFiles(cfg.FromFilePath);
            cfg.TargetName = manager.From.GetTargetName(cfg.FromFilePath);
            this.ShowFiles(cfg.ProjFiles);

            cfg.ToFilter_FileFolders = manager.To.Get_ToFilter_FolderFiles(cfg);
            cfg.ToProj_Files = manager.To.Get_ToProj_Files(cfg);
            cfg.ToFilter_files = manager.To.Get_ToFilter_Folders(cfg);
            cfg.Projguid = Guid.NewGuid().ToString("B");

            var builder = new StringBuilder();
            builder.AppendLine(cfg.MacroDefineStr);
            builder.AppendLine(cfg.IncludePathStr);

            TargetStatus.Text= builder.ToString();
            
            comboBoxTarget.Items.Clear();
            foreach (var vn in manager.From.GetMacroTarget(cfg.FromFilePath))
            {
                comboBoxTarget.Items.Add(vn);
            }
            if (comboBoxTarget.Items.Count > 0)
            {
                comboBoxTarget.SelectedIndex = 0;
            }
            else
                comboBoxTarget.Text = "";
            //var aa = GetRelativePath(manager.ProjectIno.VCProject_Path, manager.ProjectIno.MDK_Project_File);
        }
        public string GetRelativePath(string basePath, string targetPath)
        {
            Uri uri = new Uri(basePath);
            Uri uri2 = new Uri(targetPath);
            return uri.MakeRelativeUri(uri2).ToString().Replace("/", @"\");
        }

        private void BtnTest_Click(object sender, EventArgs e)
        {
            BtnTrans_Click(sender, e);
            if (manager.From.GetMacroTarget(cfg.FromFilePath).Count > 0)
                cfg.TargetName = manager.From.GetMacroTarget(cfg.FromFilePath)[0];
            else
                cfg.TargetName = cfg.FileNameWithoutExtension;
            
            manager.To.Createvcxproj(cfg);
            manager.To.Createfilters(cfg);
            manager.To.Createsln(cfg);
            manager.To.Createlog(cfg);
            //manager.to.createvcxusers(cfg);
            label5.Text = "转换完：" + DateTime.Now.ToString("HH:mm:ss");
            bool has = false;
            
            foreach(var v in MDK2VCConfig.Current.StrMDKFilePathHis)
            {
                if (v.Equals(MDK2VCConfig.Current.StrMDKFilePath))
                    has = true;
            }
            if(!has)
            {
                MDK2VCConfig.Current.StrMDKFilePathHis.Add(MDK2VCConfig.Current.StrMDKFilePath);
                MDK2VCConfig.Current.Save();
            }
        }
        /// <summary>
        /// 打开文件
        /// </summary>
        /// <param name="file"></param>
        private void OpenFile(string file)
        {
            if (File.Exists(file))
                System.Diagnostics.Process.Start(file);
            else
                MessageBox.Show("文件不存在 " + file);
        }

        private void NotifyIcon1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (WindowState == FormWindowState.Minimized)
            {
                //还原窗体显示    
                WindowState = FormWindowState.Normal;
                //激活窗体并给予它焦点
                this.Activate();
                //任务栏区显示图标
                this.ShowInTaskbar = true;
                //托盘区图标隐藏
                notifyIcon1.Visible = false;
            }
        }

        private void 显示ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Normal;
        }

        private void 退出ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("是否确认退出程序？", "退出", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
            {
                // 关闭所有的线程
                this.Dispose();
                this.Close();
            }
        }

        private void FormMain_SizeChanged(object sender, EventArgs e)
        {
            //判断是否选择的是最小化按钮
            if (WindowState == FormWindowState.Minimized)
            {
                //隐藏任务栏区图标
                this.ShowInTaskbar = false;
                //图标显示在托盘区
                notifyIcon1.Visible = true;
            }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void NotifyIcon1_DoubleClick(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Normal;
        }
        BTree<Node> GetFiles(string filename)
        {
            var tree1 = new BTree<Node>
            {
                Data = new Node("文件", "", true)
            };

            var doc = XElement.Load(cfg.FromFilePath);
            var Targets = doc.Element("Targets");
            var Target = Targets.Element("Target");
            var Groups = Target.Element("Groups");

            var Group = Groups.Elements("Group");
            foreach (var grou in Group)
            {
                var aa = grou.Element("GroupName");
                var tree2 = new BTree<Node>
                {
                    Data = new Node(aa.Value, tree1.Data.Name, false)
                };
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
                            var tree3 = new BTree<Node>
                            {
                                Data = new Node(FilePath.Value, tree2.Data.Name, false)
                            };
                            tree2.AddNode(tree3);
                        }
                    }
                }
            }
            return tree1;
        }
        void ShowFiles(BTree<Node> tree1)
        {
            var tn = new TreeNode
            {
                Tag = tree1,
                Text = tree1.Data.Name
            };
            for (int i = 0; i < tree1.Nodes.Count; i++)
            {
                var tn1 = new TreeNode
                {
                    Tag = tree1.Nodes[i],
                    Text = tree1.Nodes[i].Data.Name
                };

                for (int j = 0; j < tree1.Nodes[i].Nodes.Count; j++)
                {
                    var tn2 = new TreeNode
                    {
                        Tag = tree1.Nodes[i].Nodes[j],
                        Text = tree1.Nodes[i].Nodes[j].Data.Name
                    };
                    for (int k = 0; k < tree1.Nodes[i].Nodes[j].Nodes.Count; k++)
                    {
                        var tn3 = new TreeNode
                        {
                            Tag = tree1.Nodes[i].Nodes[j].Nodes[k],
                            Text = tree1.Nodes[i].Nodes[j].Nodes[k].Data.Name
                        };

                        for (int l = 0; l < tree1.Nodes[i].Nodes[j].Nodes[k].Nodes.Count; l++)
                        {
                            var tn4 = new TreeNode
                            {
                                Tag = tree1.Nodes[i].Nodes[j].Nodes[k].Nodes[l],
                                Text = tree1.Nodes[i].Nodes[j].Nodes[k].Nodes[l].Data.Name
                            };

                            tn3.Nodes.Add(tn4);
                        }

                        tn2.Nodes.Add(tn3);
                    }
                    tn1.Nodes.Add(tn2);
                }
                tn.Nodes.Add(tn1);
            }
            treeView1.Nodes.Clear();
            treeView1.Nodes.Add(tn);
        }

        private void LabelOpenProj_Click(object sender, EventArgs e)
        {
            this.OpenFile(cfg.FromFilePath);
        }
        
        private void LabelOpenVC_Click(object sender, EventArgs e)
        {
            this.OpenFile(cfg.Sln);
        }

        private void BtnSelFileName_Click(object sender, EventArgs e)
        {
            var fileDlg = new OpenFileDialog
            {
                Multiselect = true,
                Title = "请选择文件",
                Filter = "MDK|*.uvprojx;*.uvproj;*cyprj"
            };
            if (fileDlg.ShowDialog() == DialogResult.OK)
            {
                cfg.FromFilePath = fileDlg.FileName;
                comboBoxMDKPath.Items.Add(comboBoxMDKPath.Text);
                comboBoxMDKPath.Text = cfg.FromFilePath;
                tBoxSlnPath.Text = cfg.Sln;

                Properties.Settings.Default.LastFileName = cfg.FromFilePath;
                Properties.Settings.Default.Save();
            }
            MDK2VCConfig.Current.StrMDKFilePath = comboBoxMDKPath.Text;
            MDK2VCConfig.Current.Save();
        }

        private void checkBoxManulSetTarget_CheckedChanged(object sender, EventArgs e)
        {
            var chk = sender as CheckBox;
            buttonLoadManulTarget.Visible = chk.Checked;
            MDK2VCConfig.Current.OutputPathManulSet = checkBoxManulSetTarget.Checked;
            MDK2VCConfig.Current.Save();
        }

        private void comboBoxOutTarget_SelectedIndexChanged(object sender, EventArgs e)
        {
            var cmb = sender as ComboBox;
            MDK2VCConfig.Current.StrOutputPathTarget = cmb.Text;
            MDK2VCConfig.Current.Save();
        }

        private void comboBoxMDKPath_SelectedIndexChanged(object sender, EventArgs e)
        {
            var cmb = sender as ComboBox;
            MDK2VCConfig.Current.StrMDKFilePath = cmb.Text;
            MDK2VCConfig.Current.Save();
        }
    }
}
