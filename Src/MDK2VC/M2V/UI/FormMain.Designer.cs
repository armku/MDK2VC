namespace MDK2VC
{
    partial class FormMain
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.tBoxMDKPath = new System.Windows.Forms.TextBox();
            this.tBoxVCPath = new System.Windows.Forms.TextBox();
            this.btnTrans = new System.Windows.Forms.Button();
            this.textBoxDemo = new System.Windows.Forms.TextBox();
            this.btnSelMDKPath = new System.Windows.Forms.Button();
            this.btnSelectVCPath = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 25);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(47, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "MDK项目";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(18, 57);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(41, 12);
            this.label2.TabIndex = 1;
            this.label2.Text = "VC项目";
            // 
            // tBoxMDKPath
            // 
            this.tBoxMDKPath.Location = new System.Drawing.Point(65, 22);
            this.tBoxMDKPath.Name = "tBoxMDKPath";
            this.tBoxMDKPath.Size = new System.Drawing.Size(367, 21);
            this.tBoxMDKPath.TabIndex = 2;
            // 
            // tBoxVCPath
            // 
            this.tBoxVCPath.Location = new System.Drawing.Point(65, 54);
            this.tBoxVCPath.Name = "tBoxVCPath";
            this.tBoxVCPath.Size = new System.Drawing.Size(367, 21);
            this.tBoxVCPath.TabIndex = 3;
            // 
            // btnTrans
            // 
            this.btnTrans.Location = new System.Drawing.Point(143, 81);
            this.btnTrans.Name = "btnTrans";
            this.btnTrans.Size = new System.Drawing.Size(75, 23);
            this.btnTrans.TabIndex = 4;
            this.btnTrans.Text = "转换";
            this.btnTrans.UseVisualStyleBackColor = true;
            // 
            // textBoxDemo
            // 
            this.textBoxDemo.Location = new System.Drawing.Point(32, 117);
            this.textBoxDemo.Multiline = true;
            this.textBoxDemo.Name = "textBoxDemo";
            this.textBoxDemo.Size = new System.Drawing.Size(419, 153);
            this.textBoxDemo.TabIndex = 5;
            // 
            // btnSelMDKPath
            // 
            this.btnSelMDKPath.Location = new System.Drawing.Point(438, 20);
            this.btnSelMDKPath.Name = "btnSelMDKPath";
            this.btnSelMDKPath.Size = new System.Drawing.Size(75, 23);
            this.btnSelMDKPath.TabIndex = 6;
            this.btnSelMDKPath.Text = "...";
            this.btnSelMDKPath.UseVisualStyleBackColor = true;
            this.btnSelMDKPath.Click += new System.EventHandler(this.btnSelMDKPath_Click);
            // 
            // btnSelectVCPath
            // 
            this.btnSelectVCPath.Location = new System.Drawing.Point(438, 52);
            this.btnSelectVCPath.Name = "btnSelectVCPath";
            this.btnSelectVCPath.Size = new System.Drawing.Size(75, 23);
            this.btnSelectVCPath.TabIndex = 7;
            this.btnSelectVCPath.Text = "...";
            this.btnSelectVCPath.UseVisualStyleBackColor = true;
            this.btnSelectVCPath.Click += new System.EventHandler(this.btnSelectVCPath_Click);
            // 
            // FormMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(524, 300);
            this.Controls.Add(this.btnSelectVCPath);
            this.Controls.Add(this.btnSelMDKPath);
            this.Controls.Add(this.textBoxDemo);
            this.Controls.Add(this.btnTrans);
            this.Controls.Add(this.tBoxVCPath);
            this.Controls.Add(this.tBoxMDKPath);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "FormMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "MDK2VC";
            this.Load += new System.EventHandler(this.FormMain_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox tBoxMDKPath;
        private System.Windows.Forms.TextBox tBoxVCPath;
        private System.Windows.Forms.Button btnTrans;
        private System.Windows.Forms.TextBox textBoxDemo;
        private System.Windows.Forms.Button btnSelMDKPath;
        private System.Windows.Forms.Button btnSelectVCPath;
    }
}

