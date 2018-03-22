namespace MDK
{
    public partial class Form1
    {
        private System.ComponentModel.IContainer components;
        private System.Windows.Forms.Button CreateButton;
        private System.Windows.Forms.ListBox FileBox;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.GroupBox groupBox5;
        private System.Windows.Forms.ListBox GroupListBox;
        private System.Windows.Forms.TextBox SourcePathBOX;
        private System.Windows.Controls.ComboBox TargetListBOX = new System.Windows.Controls.ComboBox();
        private System.Windows.Forms.TextBox TargetStatus;
        protected override void Dispose(bool disposing)
        {
            if (disposing && this.components != null) this.components.Dispose();
            base.Dispose(disposing);
        }
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.CreateButton = new System.Windows.Forms.Button();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.elementHost = new System.Windows.Forms.Integration.ElementHost();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.TargetStatus = new System.Windows.Forms.TextBox();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.FileBox = new System.Windows.Forms.ListBox();
            this.GroupListBox = new System.Windows.Forms.ListBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.SourcePathBOX = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.groupBox3.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.groupBox5.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // CreateButton
            // 
            this.CreateButton.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.CreateButton.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.CreateButton.Font = new System.Drawing.Font("Consolas", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CreateButton.Location = new System.Drawing.Point(5, 480);
            this.CreateButton.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.CreateButton.Name = "CreateButton";
            this.CreateButton.Padding = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.CreateButton.Size = new System.Drawing.Size(767, 42);
            this.CreateButton.TabIndex = 8;
            this.CreateButton.Text = "Create Visual Studio Project";
            this.CreateButton.UseVisualStyleBackColor = true;
            this.CreateButton.Click += new System.EventHandler(this.CreateButton_Click);
            // 
            // groupBox3
            // 
            this.groupBox3.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox3.Controls.Add(this.elementHost);
            this.groupBox3.Font = new System.Drawing.Font("Consolas", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox3.Location = new System.Drawing.Point(5, 55);
            this.groupBox3.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Padding = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.groupBox3.Size = new System.Drawing.Size(767, 48);
            this.groupBox3.TabIndex = 20;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Target Groups";
            // 
            // elementHost
            // 
            this.elementHost.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.elementHost.Location = new System.Drawing.Point(6, 16);
            this.elementHost.Name = "elementHost";
            this.elementHost.Size = new System.Drawing.Size(755, 25);
            this.elementHost.TabIndex = 11;
            this.elementHost.Text = "elementHost1";
            this.elementHost.Child = null;
            // 
            // groupBox4
            // 
            this.groupBox4.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox4.Controls.Add(this.TargetStatus);
            this.groupBox4.Font = new System.Drawing.Font("Consolas", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox4.Location = new System.Drawing.Point(5, 106);
            this.groupBox4.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Padding = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.groupBox4.Size = new System.Drawing.Size(767, 158);
            this.groupBox4.TabIndex = 5;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Target Info";
            // 
            // TargetStatus
            // 
            this.TargetStatus.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.TargetStatus.BackColor = System.Drawing.SystemColors.Window;
            this.TargetStatus.Font = new System.Drawing.Font("Consolas", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TargetStatus.Location = new System.Drawing.Point(5, 19);
            this.TargetStatus.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.TargetStatus.Multiline = true;
            this.TargetStatus.Name = "TargetStatus";
            this.TargetStatus.ReadOnly = true;
            this.TargetStatus.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.TargetStatus.Size = new System.Drawing.Size(755, 134);
            this.TargetStatus.TabIndex = 0;
            // 
            // groupBox5
            // 
            this.groupBox5.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox5.Controls.Add(this.FileBox);
            this.groupBox5.Controls.Add(this.GroupListBox);
            this.groupBox5.Font = new System.Drawing.Font("Consolas", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox5.Location = new System.Drawing.Point(5, 265);
            this.groupBox5.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Padding = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.groupBox5.Size = new System.Drawing.Size(767, 207);
            this.groupBox5.TabIndex = 6;
            this.groupBox5.TabStop = false;
            this.groupBox5.Text = "Source Groups";
            // 
            // FileBox
            // 
            this.FileBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.FileBox.FormattingEnabled = true;
            this.FileBox.HorizontalScrollbar = true;
            this.FileBox.IntegralHeight = false;
            this.FileBox.ItemHeight = 14;
            this.FileBox.Location = new System.Drawing.Point(264, 16);
            this.FileBox.Name = "FileBox";
            this.FileBox.Size = new System.Drawing.Size(496, 186);
            this.FileBox.TabIndex = 1;
            // 
            // GroupListBox
            // 
            this.GroupListBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.GroupListBox.BackColor = System.Drawing.SystemColors.Window;
            this.GroupListBox.Font = new System.Drawing.Font("Consolas", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.GroupListBox.FormattingEnabled = true;
            this.GroupListBox.HorizontalScrollbar = true;
            this.GroupListBox.IntegralHeight = false;
            this.GroupListBox.ItemHeight = 14;
            this.GroupListBox.Location = new System.Drawing.Point(5, 16);
            this.GroupListBox.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.GroupListBox.Name = "GroupListBox";
            this.GroupListBox.Size = new System.Drawing.Size(255, 186);
            this.GroupListBox.TabIndex = 0;
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Controls.Add(this.SourcePathBOX);
            this.groupBox1.Font = new System.Drawing.Font("Consolas", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(5, 5);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.groupBox1.Size = new System.Drawing.Size(767, 48);
            this.groupBox1.TabIndex = 9;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Keil Project File Path";
            // 
            // SourcePathBOX
            // 
            this.SourcePathBOX.AllowDrop = true;
            this.SourcePathBOX.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.SourcePathBOX.BackColor = System.Drawing.SystemColors.Window;
            this.SourcePathBOX.Font = new System.Drawing.Font("Consolas", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.SourcePathBOX.ForeColor = System.Drawing.SystemColors.AppWorkspace;
            this.SourcePathBOX.Location = new System.Drawing.Point(5, 17);
            this.SourcePathBOX.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.SourcePathBOX.Name = "SourcePathBOX";
            this.SourcePathBOX.ReadOnly = true;
            this.SourcePathBOX.Size = new System.Drawing.Size(755, 22);
            this.SourcePathBOX.TabIndex = 1;
            this.SourcePathBOX.Text = "Double-click or drag and drop The MDK the Project File to here";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(579, 489);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(165, 23);
            this.button1.TabIndex = 21;
            this.button1.Text = "button1";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(778, 529);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.groupBox5);
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.CreateButton);
            this.Font = new System.Drawing.Font("Consolas", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Keil Project Convert To Visual Studio Project";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.groupBox3.ResumeLayout(false);
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.groupBox5.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        private System.Windows.Forms.Button button1;
    }
}