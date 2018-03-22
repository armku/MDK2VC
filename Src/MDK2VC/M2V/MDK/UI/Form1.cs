using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Runtime.InteropServices;
using System.Text;
using System.Windows.Controls;
using System.Windows.Forms;
using System.Windows.Forms.Integration;
using System.Xml;
using System.Xml.Linq;
namespace MDK
{
    public partial class Form1 : Form
    {
        public ElementHost elementHost;
        CoreManager manager = new CoreManager();
        /// <summary>
        /// 项目配置
        /// </summary>
        SysConfig cfg = new SysConfig();
        public Form1()
        {
            this.InitializeComponent();
        }
        private void CreateButton_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog dialog = new FolderBrowserDialog();
            dialog.RootFolder = Environment.SpecialFolder.MyComputer;
            dialog.Description = "Please select the Visual Studio Project Path";
            dialog.SelectedPath = manager.ProjectIno.MDK_Project_Path;
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                string[] paths = new string[] { dialog.SelectedPath, "Visual Studio Project" };
                manager.ProjectIno.VCProject_Path = Path.Combine(paths) + @"\";
            }
            else
                return;
            if (!Directory.Exists(manager.ProjectIno.VCProject_Path)) Directory.CreateDirectory(manager.ProjectIno.VCProject_Path);
            string[] targets = manager.MDK_TargetRead(manager.ProjectIno.MDK_Project_File);
            string relativePath = manager.GetRelativePath(manager.ProjectIno.VCProject_Path, manager.ProjectIno.MDK_Project_File);
            manager.ProjectIno.NMakeBuildCommandLine = "\"" + manager.ProjectIno.UV4_Path + "\" -b " + relativePath + " -t \"Target\" -j0 -o Build.log";
            manager.ProjectIno.LocalDebuggerCommandArguments = "-d " + manager.ProjectIno.ProjectName + ".uvproj -t \"Target\"";
            string docName = manager.ProjectIno.VCProject_Path + manager.ProjectIno.ProjectName + ".sln";
            manager.to.VC_Creat_Sln(docName, manager.ProjectIno.ProjectName, targets);
            docName = manager.ProjectIno.VCProject_Path + manager.ProjectIno.VC_Filters_Name;
            manager.VC_Filters_Create(docName, targets);
            docName = manager.ProjectIno.VCProject_Path + manager.ProjectIno.VcxprojName;
            manager.VC_vcxproj_Create(docName, targets);
            manager.ProjectIno.LocalDebuggerWorkingDirectory = manager.GetRelativePath(manager.ProjectIno.VCProject_Path, manager.ProjectIno.MDK_Project_Path);
            docName = manager.ProjectIno.VCProject_Path + manager.ProjectIno.VC_UserFileName;
            manager.VC_Create_UserFile(docName, manager.ProjectIno.LocalDebuggerCommandArguments, manager.ProjectIno.LocalDebuggerWorkingDirectory, targets);
            docName = manager.ProjectIno.VCProject_Path + "readme.txt";
            manager.to.VC_Creat_readme(docName, manager.ProjectIno.ProjectName);
            MessageBox.Show("The Visual Studio Project Creat Complete!");
            Process.Start(manager.ProjectIno.VCProject_Path);
        }

        private void FileBox_DoubleClick(object sander, EventArgs e)
        {
            if (this.FileBox.SelectedIndex >= 0)
            {
                string targetPat = this.FileBox.SelectedItem.ToString();
                targetPat = manager.GetFullPath(manager.ProjectIno.MDK_Project_Path, targetPat);
                Process process = new Process();
                process.StartInfo.FileName = "notepad.exe";
                process.StartInfo.Arguments = targetPat;
                process.Start();
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            this.elementHost.Child = this.TargetListBOX;
            this.TargetListBOX.SelectionChanged += new SelectionChangedEventHandler(this.TargetListBOX_SelectionChanged);
            this.GroupListBox.SelectedIndexChanged += new EventHandler(this.GroupListBox_SelectedIndexChanged);
            this.FileBox.DoubleClick += new EventHandler(this.FileBox_DoubleClick);
            this.SourcePathBOX.DoubleClick += new EventHandler(this.SourcePathBOX_DoubleClick);
            this.SourcePathBOX.DragDrop += new DragEventHandler(this.SourcePathBOX_DragDrop);
            this.SourcePathBOX.DragEnter += new DragEventHandler(this.SourcePathBOX_DragEnter);
            base.AutoScaleMode = AutoScaleMode.None;
            manager.ProjectIno.NMakeCleanCommandLine = "";
            this.CreateButton.Enabled = false;
            string[] paths = new string[] { Path.GetDirectoryName(Application.ExecutablePath), "" };
            paths[1] = "Config.xml";
            manager.Config.DocName = Path.Combine(paths);
            manager.ReadConfig(manager.Config.DocName);
            manager.ProjectIno.UV4_Path = manager.Config.UV4Path + " ";
        }


        private void GroupListBox_Add(string[] Items)
        {
            this.GroupListBox.Items.Clear();
            foreach (string str in Items)
            {
                this.GroupListBox.Items.Add(str);
            }
            this.GroupListBox.SelectedIndex = 0;
        }

        private void GroupListBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (manager.FileName != "")
            {
                string[] strArray = manager.MDK_TargetRead(manager.FileName);
                string[] strArray2 = manager.MDK_GroupRead(manager.FileName, strArray[this.TargetListBOX.SelectedIndex]);
                string[] items = manager.MDK_SrcRead(manager.FileName, strArray[this.TargetListBOX.SelectedIndex], strArray2[this.GroupListBox.SelectedIndex]);
                this.SrcFileBox_Add(items);
            }
        } 


        private void SourcePathBOX_DoubleClick(object sender, EventArgs e)
        {
            OpenFileDialog dialog = new OpenFileDialog();
            dialog.DefaultExt = "uvproj";
            dialog.Filter = "MDK Project File (*.uvproj)|*.uvproj|All files (*.*)|*.*";
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                string fileName = dialog.FileName;
                if (fileName == "")
                {
                    this.SourcePathBOX.Text = "Double-click or drag and drop The MDK the Project File here";
                    this.SourcePathBOX.ForeColor = Color.Gray;
                    manager.FileName = "";
                    this.CreateButton.Enabled = false;
                }
                else if (this.MDK_Display_Info(fileName))
                {
                    this.SourcePathBOX.ForeColor = Color.Black;
                    this.SourcePathBOX.Text = dialog.FileName;
                    manager.FileName = dialog.FileName;
                    manager.ProjectIno.MDK_Project_File = dialog.FileName;
                    manager.ProjectIno.MDK_Project_Path = manager.ProjectIno.MDK_Project_File.Replace(dialog.SafeFileName, "");
                    manager.ProjectIno.ProjectName = dialog.SafeFileName.Remove(dialog.SafeFileName.IndexOf("."));
                    manager.ProjectIno.VcxprojName = manager.ProjectIno.ProjectName + ".vcxproj";
                    manager.ProjectIno.VC_Filters_Name = manager.ProjectIno.VcxprojName + ".filters";
                    manager.ProjectIno.VC_UserFileName = manager.ProjectIno.VcxprojName + ".user";
                }
                else
                {
                    this.SourcePathBOX.Text = "Double-click or drag and drop The MDK the Project File to here";
                    this.SourcePathBOX.ForeColor = Color.Gray;
                    manager.FileName = "";
                    this.CreateButton.Enabled = false;
                }
            }
        }

        private void SourcePathBOX_DragDrop(object sender, DragEventArgs e)
        {
            this.SourcePathBOX.ForeColor = Color.Black;
            this.SourcePathBOX.Text = ((Array) e.Data.GetData(DataFormats.FileDrop)).GetValue(0).ToString();
            string text = this.SourcePathBOX.Text;
            if (this.MDK_Display_Info(text))
            {
                manager.FileName = text;
                manager.ProjectIno.MDK_Project_File = text;
                manager.ProjectIno.MDK_Project_Path = Path.GetDirectoryName(text) + @"\";
                manager.ProjectIno.ProjectName = Path.GetFileNameWithoutExtension(text);
                manager.ProjectIno.VcxprojName = manager.ProjectIno.ProjectName + ".vcxproj";
                manager.ProjectIno.VC_Filters_Name = manager.ProjectIno.VcxprojName + ".filters";
                manager.ProjectIno.VC_UserFileName = manager.ProjectIno.VcxprojName + ".user";
            }
            else
            {
                this.SourcePathBOX.Text = "Double-click or drag and drop The MDK the Project File to here";
                this.SourcePathBOX.ForeColor = Color.Gray;
                manager.FileName = "";
                this.CreateButton.Enabled = false;
            }
        }

        private void SourcePathBOX_DragEnter(object sander, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop))
                e.Effect = DragDropEffects.Link;
            else
                e.Effect = DragDropEffects.None;
        }

        private void SrcFileBox_Add(string[] Items)
        {
            this.FileBox.Items.Clear();
            foreach (string str in Items)
            {
                this.FileBox.Items.Add(str);
            }
        }

        private void TargetListBox_Add(string[] Items)
        {
            this.TargetListBOX.Items.Clear();
            foreach (string str in Items)
            {
                this.TargetListBOX.Items.Add(str);
            }
            this.TargetListBOX.SelectedIndex = 0;
        }

        private void TargetListBOX_SelectionChanged(object sander, EventArgs e)
        {
            if (this.TargetListBOX.SelectedIndex >= 0 && manager.FileName != "")
            {
                string[] strArray = manager.MDK_TargetRead(manager.FileName);
                string[] items = manager.MDK_GroupRead(manager.FileName, strArray[this.TargetListBOX.SelectedIndex]);
                this.GroupListBox_Add(items);
                string[] strArray3 = manager.MDK_SrcRead(manager.FileName, strArray[this.TargetListBOX.SelectedIndex], items[0]);
                this.SrcFileBox_Add(strArray3);
                string str = manager.MDK_TargetStatusRead(manager.FileName, strArray[this.TargetListBOX.SelectedIndex]);
                this.TargetStatusBox_Add(str);
            }
        }

        private void TargetStatusBox_Add(string Str)
        {
            this.TargetStatus.Text = Str;
        }
        private bool MDK_Display_Info(string DocName)
        {
            if (!manager.MDK_CheckProject(DocName))
            {
                MessageBox.Show("This File Is Not Keil uVision Project File!!", "Error", MessageBoxButtons.OKCancel, MessageBoxIcon.Exclamation);
                return false;
            }
            try
            {
                string[] items = manager.MDK_TargetRead(DocName);
                this.TargetListBox_Add(items);
                manager.ProjectIno.MDK_Target = items[0];
                manager.ProjectIno.IncludePath = manager.MDK_IncludePathRead(DocName, items[0]);
                manager.ProjectIno.NMakePreprocessorDefinitions = manager.MDK_DefineRead(DocName, items[0]);
                string[] strArray2 = manager.MDK_GroupRead(DocName, manager.ProjectIno.MDK_Target);
                this.GroupListBox_Add(strArray2);
                string[] strArray3 = manager.MDK_SrcRead(DocName, items[0], strArray2[0]);
                this.SrcFileBox_Add(strArray3);
                string str = manager.MDK_TargetStatusRead(DocName, items[0]);
                this.TargetStatusBox_Add(str);
                this.CreateButton.Enabled = true;
                return true;
            }
            catch
            {
                MessageBox.Show("Read File Error! Maybe it is't MDK Project File", "Error", MessageBoxButtons.OKCancel, MessageBoxIcon.Exclamation);
                return false;
            }
        }
        private void button1_Click(object sender, EventArgs e)
        {
            manager.to = new ToVC2017();
            manager.from = new Fromuvproj();
        }
    }
}

