namespace PKG_Manager
{
    partial class FormMain
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
            this.DoButton = new System.Windows.Forms.Button();
            this.progressBar = new System.Windows.Forms.ProgressBar();
            this.fileDirBrowser = new FormControls.FileDirBrowser();
            this.SuspendLayout();
            // 
            // DoButton
            // 
            this.DoButton.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.DoButton.Enabled = false;
            this.DoButton.Location = new System.Drawing.Point(369, 70);
            this.DoButton.Name = "DoButton";
            this.DoButton.Size = new System.Drawing.Size(137, 23);
            this.DoButton.TabIndex = 18;
            this.DoButton.Text = "Extract package";
            this.DoButton.UseVisualStyleBackColor = false;
            this.DoButton.Click += new System.EventHandler(this.DoButton_Click);
            // 
            // progressBar
            // 
            this.progressBar.Location = new System.Drawing.Point(12, 128);
            this.progressBar.Name = "progressBar";
            this.progressBar.Size = new System.Drawing.Size(494, 19);
            this.progressBar.TabIndex = 21;
            // 
            // fileDirBrowser
            // 
            this.fileDirBrowser.BrowseBackColor = System.Drawing.Color.Empty;
            this.fileDirBrowser.BrowseDialogTitle = "";
            this.fileDirBrowser.BrowseFor = FormControls.FileDirBrowser.BrowseType.FileOpen;
            this.fileDirBrowser.BrowseForeColor = System.Drawing.Color.Empty;
            this.fileDirBrowser.Description = "Select a PS3/PSP Retail pkg file:";
            this.fileDirBrowser.DescriptionColor = System.Drawing.Color.Empty;
            this.fileDirBrowser.FileDescription = "Pkg files";
            this.fileDirBrowser.FileExtension = "pkg";
            this.fileDirBrowser.FileName = "*";
            this.fileDirBrowser.InitDirUseLastDir = true;
            this.fileDirBrowser.InitialDirectory = System.Environment.SpecialFolder.Desktop;
            this.fileDirBrowser.Location = new System.Drawing.Point(12, 12);
            this.fileDirBrowser.Name = "fileDirBrowser";
            this.fileDirBrowser.PathBackColor = System.Drawing.Color.Empty;
            this.fileDirBrowser.PathFileDir = "Browse to or Drag here...";
            this.fileDirBrowser.PathForeColor = System.Drawing.Color.Empty;
            this.fileDirBrowser.Size = new System.Drawing.Size(494, 36);
            this.fileDirBrowser.TabIndex = 22;
            this.fileDirBrowser.PathChanged += new FormControls.FileDirBrowser.PathChangedHandler(this.fileDirBrowser_PathChanged);
            // 
            // FormMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(518, 153);
            this.Controls.Add(this.fileDirBrowser);
            this.Controls.Add(this.progressBar);
            this.Controls.Add(this.DoButton);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Margin = new System.Windows.Forms.Padding(2);
            this.MaximizeBox = false;
            this.Name = "FormMain";
            this.Text = "PS3/PSP Retail PKG Decrypter & Extractor";
            this.Load += new System.EventHandler(this.FormMain_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button DoButton;
        private FormControls.FileDirBrowser fileDirBrowser;
        private System.Windows.Forms.ProgressBar progressBar;
    }
}

