using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;

namespace FormControls
{
    public partial class FileDirBrowser : UserControl
    {
        public enum BrowseType { FileOpen, FileSave, Directory };

        private Color pathForeColor;
        private Color pathBackColor;
        private Color descriptionColor;
        private Color browseForeColor;
        private Color browseBackColor;
        private BrowseType browseFor;
        private string description = "Description:";
        private string pathFileDir = "Browse to or Drag [...] here first...";
        private string fileName = "*";
        private string fileExtension = "*";
        private string fileDescription = "All files";
        private string browseDialogTitle = "";
        private Environment.SpecialFolder initialDirectory = Environment.SpecialFolder.Desktop;
        private bool initDirUseLastDir = true;

        #region Custom Properties

        // Property PathBackColor.
        public Color PathBackColor
        {
            get
            {
                return pathBackColor;
            }
            set
            {
                pathBackColor = value;
                txtPath.BackColor = pathBackColor;
            }
        }

        // Property PathForeColor.
        public Color PathForeColor
        {
            get
            {
                return pathForeColor;
            }
            set
            {
                pathForeColor = value;
                txtPath.ForeColor = pathForeColor;
            }
        }

        // Property DescriptionColor.
        public Color DescriptionColor
        {
            get
            {
                return descriptionColor;
            }
            set
            {
                descriptionColor = value;
                lblDescription.ForeColor = descriptionColor;
            }
        }

        // Property BrowseForeColor.
        public Color BrowseForeColor
        {
            get
            {
                return browseForeColor;
            }
            set
            {
                browseForeColor = value;
                btnBrowse.ForeColor = browseForeColor;
            }
        }

        // Property BrowseForeColor.
        public Color BrowseBackColor
        {
            get
            {
                return browseBackColor;
            }
            set
            {
                browseBackColor = value;
                btnBrowse.BackColor = browseBackColor;
            }
        }

        // Property BrowseForeColor.
        public BrowseType BrowseFor
        {
            get
            {
                return browseFor;
            }
            set
            {
                browseFor = value;
            }
        }

        // Property BrowseForeColor.
        public string Description
        {
            get
            {
                return description;
            }
            set
            {
                description = value;
                lblDescription.Text = description;
            }
        }

        public string PathFileDir
        {
            get
            {
                return pathFileDir;
            }
            set
            {
                pathFileDir = value;
                txtPath.Text = pathFileDir;
            }
        }

        public string FileName
        {
            get
            {
                return fileName;
            }
            set
            {
                fileName = value;
            }
        }

        public string FileExtension
        {
            get
            {
                return fileExtension;
            }
            set
            {
                fileExtension = value;
            }
        }

        public string FileDescription
        {
            get
            {
                return fileDescription;
            }
            set
            {
                fileDescription = value;
            }
        }

        public string BrowseDialogTitle
        {
            get
            {
                return browseDialogTitle;
            }
            set
            {
                browseDialogTitle = value;
            }
        }

        public Environment.SpecialFolder InitialDirectory
        {
            get
            {
                return initialDirectory;
            }
            set
            {
                initialDirectory = value;
            }
        }

        public bool InitDirUseLastDir
        {
            get
            {
                return initDirUseLastDir;
            }
            set
            {
                initDirUseLastDir = value;
            }
        }

        #endregion Custom Properties

        #region Custom Events
        
        // Declare delegate for Path Changed
        public delegate void PathChangedHandler();

        // Declare the event, which is associated with our
        // delegate PathChangedHandler(). Add some attributes
        // for the Visual C# control property.
        [Category("Action")]
        [Description("Fires when the Submit button is clicked.")]
        public event PathChangedHandler PathChanged;
        // Add a protected method called OnPathChanged().
        // You may use this in child classes instead of adding
        // event handlers.
        protected virtual void OnPathChanged()
        {
            // If an event has no subscribers registerd, it will
            // evaluate to null. The test checks that the value is not
            // null, ensuring that there are subsribers before
            // calling the event itself.
            if (PathChanged != null)
            {
                PathChanged();  // Notify Subscribers
            }
        }
        // Handler for Submit Button. Do some validation before
        // calling the event.
        private void txtPath_TextChanged(object sender, EventArgs e)
        {
            switch (browseFor)
            {
                case BrowseType.FileOpen:
                    if (File.Exists(txtPath.Text))
                        pathFileDir = txtPath.Text;
                    break;

                case BrowseType.FileSave:
                    pathFileDir = txtPath.Text;
                    break;

                case BrowseType.Directory:
                    if (Directory.Exists(txtPath.Text))
                        pathFileDir = txtPath.Text;
                    break;

                default:
                    break;
            }

            OnPathChanged();
        }

        #endregion Custom Events
        
        public FileDirBrowser()
        {
            InitializeComponent();
        }

        private void FileDirBrowser_Load(object sender, EventArgs e)
        {

        }

        private void btnBrowse_Click(object sender, EventArgs e)
        {
            switch (browseFor)
            {
                case BrowseType.FileOpen:
                    OpenFileDialog ofdlg = new OpenFileDialog();
                    ofdlg.Title = browseDialogTitle;

                    if (File.Exists(txtPath.Text) && InitDirUseLastDir)
                        ofdlg.InitialDirectory = Path.GetDirectoryName(txtPath.Text);
                    else
                        ofdlg.InitialDirectory = Environment.GetFolderPath(InitialDirectory);

                    ofdlg.Filter = fileDescription + " (" + fileName + "." + fileExtension + ")|" + fileName + "." + fileExtension + "|" + fileDescription + " (" + fileName + "." + fileExtension + ")|" + fileName + "." + fileExtension;
                    ofdlg.FilterIndex = 1;
                    ofdlg.RestoreDirectory = true;
                    if (ofdlg.ShowDialog() == DialogResult.OK)
                    {
                        if (File.Exists(ofdlg.FileName))
                            txtPath.Text = ofdlg.FileName;
                    }
                    break;

                case BrowseType.FileSave:
                    SaveFileDialog sfdlg = new SaveFileDialog();
                    sfdlg.Title = browseDialogTitle;

                    if (File.Exists(txtPath.Text) && InitDirUseLastDir)
                        sfdlg.InitialDirectory = Path.GetDirectoryName(txtPath.Text);
                    else
                        sfdlg.InitialDirectory = Environment.GetFolderPath(InitialDirectory);

                    sfdlg.Filter = fileDescription + " (" + fileName + "." + fileExtension + ")|" + fileName + "." + fileExtension + "|" + fileDescription + " (" + fileName + "." + fileExtension + ")|" + fileName + "." + fileExtension;
                    sfdlg.FilterIndex = 2;
                    sfdlg.RestoreDirectory = true;
                    if (sfdlg.ShowDialog() == DialogResult.OK)
                    {
                        txtPath.Text = sfdlg.FileName;
                    }
                    break;

                case BrowseType.Directory:
                    FolderBrowserDialog fbdlg = new FolderBrowserDialog();
                    fbdlg.Description = browseDialogTitle;
                    // Allow the user to create new Folders via the FolderBrowserDialog.
                    fbdlg.ShowNewFolderButton = true;

                    if (Directory.Exists(txtPath.Text) && InitDirUseLastDir)
                    {
                        fbdlg.SelectedPath = txtPath.Text;
                    }
                    else
                        fbdlg.RootFolder = InitialDirectory;

                    if (fbdlg.ShowDialog() == DialogResult.OK)
                    {
                        if (Directory.Exists(fbdlg.SelectedPath))
                            txtPath.Text = fbdlg.SelectedPath;
                    }
                    break;

                default:
                    break;
            }

        }

        private void txtPath_DragDrop(object sender, DragEventArgs e)
        {
            try
            {
                Array array = (Array)e.Data.GetData(DataFormats.FileDrop);
                if (array != null)
                {
                    string filePath = array.GetValue(0).ToString();
                    this.Focus();

                    switch (browseFor)
                    {
                        case BrowseType.FileOpen:
                            if (File.Exists(filePath))
                            {
                                if (fileName == "*" && fileExtension == "*")
                                {
                                    PathFileDir = filePath;
                                    return;
                                }

                                if ((fileName != "*" && fileExtension == "*") &&
                                    (Path.GetFileNameWithoutExtension(filePath).ToUpper() == fileName.ToUpper()))
                                {
                                    PathFileDir = filePath;
                                    return;
                                }

                                if ((fileName == "*" && fileExtension != "*") &&
                                    (Path.GetExtension(filePath).ToUpper() == "." + fileExtension.ToUpper()))
                                {
                                    PathFileDir = filePath;
                                    return;
                                }

                                if ((fileName != "*" && fileExtension != "*") &&
                                    (Path.GetFileNameWithoutExtension(filePath).ToUpper() == fileName.ToUpper()) &&
                                    (Path.GetExtension(filePath).ToUpper() == "." + fileExtension.ToUpper()))
                                {
                                    PathFileDir = filePath;
                                    return;
                                }

                            }
                            else return;
                            break;

                        case BrowseType.FileSave:
                            if ((Path.GetExtension(filePath) == "." + fileExtension) || fileExtension == "*")
                            {
                                PathFileDir = filePath;
                            }
                            else return;
                            break;

                        case BrowseType.Directory:
                            if (Directory.Exists(filePath))
                            {
                                PathFileDir = filePath;
                            }
                            else return;
                            break;

                        default:
                            break;
                    }
                }
            }
            catch (Exception ex)
            { }
        }

        private void txtPath_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop))
                e.Effect = DragDropEffects.Copy;
            else
                e.Effect = DragDropEffects.None;
        }

        private void FileDirBrowser_DragDrop(object sender, DragEventArgs e)
        {
            txtPath_DragDrop(sender, e);
        }

        private void FileDirBrowser_DragEnter(object sender, DragEventArgs e)
        {
            txtPath_DragEnter(sender, e);
        }
    }
}
