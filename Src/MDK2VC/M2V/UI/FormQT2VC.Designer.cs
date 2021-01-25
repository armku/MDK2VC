
namespace MDK2VC.M2V.UI
{
    partial class FormQT2VC
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.mDK2VCToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnSelFileName = new System.Windows.Forms.Button();
            this.comboBoxMDKPath = new System.Windows.Forms.ComboBox();
            this.labelOpenProj = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.buttonLoadManulTarget = new System.Windows.Forms.Button();
            this.checkBoxManulSetTarget = new System.Windows.Forms.CheckBox();
            this.labelOpenVC = new System.Windows.Forms.Label();
            this.tBoxSlnPath = new System.Windows.Forms.TextBox();
            this.elementHost1 = new System.Windows.Forms.Integration.ElementHost();
            this.btnTest = new System.Windows.Forms.Button();
            this.menuStrip1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mDK2VCToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(800, 25);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // mDK2VCToolStripMenuItem
            // 
            this.mDK2VCToolStripMenuItem.Name = "mDK2VCToolStripMenuItem";
            this.mDK2VCToolStripMenuItem.Size = new System.Drawing.Size(72, 21);
            this.mDK2VCToolStripMenuItem.Text = "MDK2VC";
            this.mDK2VCToolStripMenuItem.Click += new System.EventHandler(this.mDK2VCToolStripMenuItem_Click);
            // 
            // statusStrip1
            // 
            this.statusStrip1.Location = new System.Drawing.Point(0, 428);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(800, 22);
            this.statusStrip1.TabIndex = 1;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // toolStrip1
            // 
            this.toolStrip1.Location = new System.Drawing.Point(0, 25);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(800, 25);
            this.toolStrip1.TabIndex = 2;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Controls.Add(this.btnSelFileName);
            this.groupBox1.Controls.Add(this.comboBoxMDKPath);
            this.groupBox1.Controls.Add(this.labelOpenProj);
            this.groupBox1.Location = new System.Drawing.Point(12, 53);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(760, 54);
            this.groupBox1.TabIndex = 20;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Project File Path";
            // 
            // btnSelFileName
            // 
            this.btnSelFileName.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.btnSelFileName.Location = new System.Drawing.Point(699, 18);
            this.btnSelFileName.Name = "btnSelFileName";
            this.btnSelFileName.Size = new System.Drawing.Size(51, 23);
            this.btnSelFileName.TabIndex = 5;
            this.btnSelFileName.Text = "...";
            this.btnSelFileName.UseVisualStyleBackColor = true;
            this.btnSelFileName.Click += new System.EventHandler(this.btnSelFileName_Click);
            // 
            // comboBoxMDKPath
            // 
            this.comboBoxMDKPath.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.comboBoxMDKPath.FormattingEnabled = true;
            this.comboBoxMDKPath.Location = new System.Drawing.Point(44, 19);
            this.comboBoxMDKPath.Name = "comboBoxMDKPath";
            this.comboBoxMDKPath.Size = new System.Drawing.Size(648, 20);
            this.comboBoxMDKPath.TabIndex = 4;
            // 
            // labelOpenProj
            // 
            this.labelOpenProj.AutoSize = true;
            this.labelOpenProj.Location = new System.Drawing.Point(9, 23);
            this.labelOpenProj.Name = "labelOpenProj";
            this.labelOpenProj.Size = new System.Drawing.Size(29, 12);
            this.labelOpenProj.TabIndex = 3;
            this.labelOpenProj.Text = "Open";
            // 
            // groupBox2
            // 
            this.groupBox2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox2.Controls.Add(this.buttonLoadManulTarget);
            this.groupBox2.Controls.Add(this.checkBoxManulSetTarget);
            this.groupBox2.Controls.Add(this.labelOpenVC);
            this.groupBox2.Controls.Add(this.tBoxSlnPath);
            this.groupBox2.Controls.Add(this.elementHost1);
            this.groupBox2.Font = new System.Drawing.Font("Consolas", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox2.Location = new System.Drawing.Point(12, 124);
            this.groupBox2.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Padding = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.groupBox2.Size = new System.Drawing.Size(760, 85);
            this.groupBox2.TabIndex = 25;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Target";
            // 
            // buttonLoadManulTarget
            // 
            this.buttonLoadManulTarget.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.buttonLoadManulTarget.Location = new System.Drawing.Point(700, 22);
            this.buttonLoadManulTarget.Name = "buttonLoadManulTarget";
            this.buttonLoadManulTarget.Size = new System.Drawing.Size(51, 23);
            this.buttonLoadManulTarget.TabIndex = 15;
            this.buttonLoadManulTarget.Text = "...";
            this.buttonLoadManulTarget.UseVisualStyleBackColor = true;
            this.buttonLoadManulTarget.Visible = false;
            // 
            // checkBoxManulSetTarget
            // 
            this.checkBoxManulSetTarget.AutoSize = true;
            this.checkBoxManulSetTarget.Location = new System.Drawing.Point(13, 50);
            this.checkBoxManulSetTarget.Name = "checkBoxManulSetTarget";
            this.checkBoxManulSetTarget.Size = new System.Drawing.Size(166, 18);
            this.checkBoxManulSetTarget.TabIndex = 14;
            this.checkBoxManulSetTarget.Text = "手动设置输出工程路径";
            this.checkBoxManulSetTarget.UseVisualStyleBackColor = true;
            // 
            // labelOpenVC
            // 
            this.labelOpenVC.AutoSize = true;
            this.labelOpenVC.Location = new System.Drawing.Point(10, 25);
            this.labelOpenVC.Name = "labelOpenVC";
            this.labelOpenVC.Size = new System.Drawing.Size(35, 14);
            this.labelOpenVC.TabIndex = 13;
            this.labelOpenVC.Text = "Open";
            // 
            // tBoxSlnPath
            // 
            this.tBoxSlnPath.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tBoxSlnPath.Location = new System.Drawing.Point(45, 22);
            this.tBoxSlnPath.Name = "tBoxSlnPath";
            this.tBoxSlnPath.ReadOnly = true;
            this.tBoxSlnPath.Size = new System.Drawing.Size(649, 22);
            this.tBoxSlnPath.TabIndex = 12;
            // 
            // elementHost1
            // 
            this.elementHost1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.elementHost1.Location = new System.Drawing.Point(6, 16);
            this.elementHost1.Name = "elementHost1";
            this.elementHost1.Size = new System.Drawing.Size(748, 62);
            this.elementHost1.TabIndex = 11;
            this.elementHost1.Text = "elementHost1";
            this.elementHost1.Child = null;
            // 
            // btnTest
            // 
            this.btnTest.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnTest.Location = new System.Drawing.Point(25, 278);
            this.btnTest.Name = "btnTest";
            this.btnTest.Size = new System.Drawing.Size(75, 23);
            this.btnTest.TabIndex = 26;
            this.btnTest.Text = "转换";
            this.btnTest.UseVisualStyleBackColor = true;
            this.btnTest.Click += new System.EventHandler(this.btnTest_Click);
            // 
            // FormQT2VC
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.btnTest);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.toolStrip1);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "FormQT2VC";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "FormQT2VC";
            this.Load += new System.EventHandler(this.FormQT2VC_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem mDK2VCToolStripMenuItem;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btnSelFileName;
        private System.Windows.Forms.ComboBox comboBoxMDKPath;
        private System.Windows.Forms.Label labelOpenProj;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button buttonLoadManulTarget;
        private System.Windows.Forms.CheckBox checkBoxManulSetTarget;
        private System.Windows.Forms.Label labelOpenVC;
        private System.Windows.Forms.TextBox tBoxSlnPath;
        public System.Windows.Forms.Integration.ElementHost elementHost1;
        private System.Windows.Forms.Button btnTest;
    }
}