using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Text;
using System.Windows.Forms;

namespace FindPhotosForMonth
{
    /// <summary>
    /// Summary description for Form1.
    /// </summary>
    public class Form1 : System.Windows.Forms.Form
    {
        #region global private vars
        private System.Windows.Forms.StatusBar statusBar1;
        private Form   openForm;
        private System.Windows.Forms.ToolTip toolTip1;
        private SplitContainer splitContainer1;
        private ListBox lbPhotosFound;
        private ListBox lbYear;
        private ListBox lstDrives;
        private Button btnSearch;
        private ListBox lbMonths;
        private PictureBox pictureBox1;
        private System.ComponentModel.IContainer components;
        private string imageFiles = "*.jpg";
        #endregion

        public Form1()
        {
            //
            // Required for Windows Form Designer support
            //
            InitializeComponent();
            this.Closing += new CancelEventHandler(this.Form1_Closing);
        }
        public void Form1_Closing(object sender,  CancelEventArgs args)
        {
            this.closeOpenForms();
        }
        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        protected override void Dispose( bool disposing )
        {
            if( disposing )
            {
                if (components != null) 
                {
                    components.Dispose();
                }
            }
            base.Dispose( disposing );
        }

        #region Windows Form Designer generated code
        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.statusBar1 = new System.Windows.Forms.StatusBar();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.lbPhotosFound = new System.Windows.Forms.ListBox();
            this.lbYear = new System.Windows.Forms.ListBox();
            this.lstDrives = new System.Windows.Forms.ListBox();
            this.btnSearch = new System.Windows.Forms.Button();
            this.lbMonths = new System.Windows.Forms.ListBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // statusBar1
            // 
            this.statusBar1.Location = new System.Drawing.Point(0, 628);
            this.statusBar1.Name = "statusBar1";
            this.statusBar1.Size = new System.Drawing.Size(968, 18);
            this.statusBar1.TabIndex = 4;
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.lbPhotosFound);
            this.splitContainer1.Panel1.Controls.Add(this.lbYear);
            this.splitContainer1.Panel1.Controls.Add(this.lstDrives);
            this.splitContainer1.Panel1.Controls.Add(this.btnSearch);
            this.splitContainer1.Panel1.Controls.Add(this.lbMonths);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.pictureBox1);
            this.splitContainer1.Size = new System.Drawing.Size(968, 628);
            this.splitContainer1.SplitterDistance = 471;
            this.splitContainer1.TabIndex = 7;
            // 
            // lbPhotosFound
            // 
            this.lbPhotosFound.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lbPhotosFound.ItemHeight = 16;
            this.lbPhotosFound.Location = new System.Drawing.Point(12, 200);
            this.lbPhotosFound.Name = "lbPhotosFound";
            this.lbPhotosFound.Size = new System.Drawing.Size(450, 420);
            this.lbPhotosFound.TabIndex = 8;
            this.lbPhotosFound.SelectedIndexChanged += new System.EventHandler(this.lbPhotosFound_SelectedIndexChanged);
            // 
            // lbYear
            // 
            this.lbYear.ItemHeight = 16;
            this.lbYear.Location = new System.Drawing.Point(356, 44);
            this.lbYear.Name = "lbYear";
            this.lbYear.SelectionMode = System.Windows.Forms.SelectionMode.MultiExtended;
            this.lbYear.Size = new System.Drawing.Size(77, 148);
            this.lbYear.TabIndex = 7;
            // 
            // lstDrives
            // 
            this.lstDrives.ItemHeight = 16;
            this.lstDrives.Location = new System.Drawing.Point(194, 10);
            this.lstDrives.Name = "lstDrives";
            this.lstDrives.SelectionMode = System.Windows.Forms.SelectionMode.MultiExtended;
            this.lstDrives.Size = new System.Drawing.Size(134, 180);
            this.lstDrives.TabIndex = 5;
            // 
            // btnSearch
            // 
            this.btnSearch.Location = new System.Drawing.Point(356, 12);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(77, 28);
            this.btnSearch.TabIndex = 4;
            this.btnSearch.Text = "&Search";
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // lbMonths
            // 
            this.lbMonths.ItemHeight = 16;
            this.lbMonths.Items.AddRange(new object[] {
            "January",
            "February",
            "March",
            "April",
            "May",
            "June",
            "July",
            "August",
            "September",
            "October",
            "November",
            "December"});
            this.lbMonths.Location = new System.Drawing.Point(12, 9);
            this.lbMonths.Name = "lbMonths";
            this.lbMonths.SelectionMode = System.Windows.Forms.SelectionMode.MultiExtended;
            this.lbMonths.Size = new System.Drawing.Size(173, 180);
            this.lbMonths.TabIndex = 3;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pictureBox1.Location = new System.Drawing.Point(0, 0);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(493, 628);
            this.pictureBox1.TabIndex = 6;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.Click += new EventHandler(this.pictureBox1_Click);
            // 
            // Form1
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(6, 15);
            this.ClientSize = new System.Drawing.Size(968, 646);
            this.Controls.Add(this.splitContainer1);
            this.Controls.Add(this.statusBar1);
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Find Photos For Month";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }
        #endregion

        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main() 
        {
            Application.Run(new Form1());
        }

        private void Form1_Load(object sender, System.EventArgs e)
        {
            if (this.lbYear.Items.Count == 0)
            {
                int curYear = DateTime.Now.Year;
                for (int  i = 0; i < 20; i++)
                { 
                    this.lbYear.Items.Add(curYear.ToString());
                    curYear--;
                }
            }
            // what drives are available to search?
            char c;
            ListBox.ObjectCollection  oc    = this.lstDrives.Items;
            for (c = (char)'C'; c <= 'Z'; c++)
            {
                try
                {
                    string rf = string.Format("{0}:{1}", c, Path.DirectorySeparatorChar);
                    System.IO.DirectoryInfo di = new System.IO.DirectoryInfo(rf);
                    if (di.Exists)
                    {
                        string [] folders = Directory.GetDirectories(rf, "*.*");
                        if ((folders != null) && (folders.Length > 0))
                        {
                            oc.Add(rf);
                        }
                    }
                }
                catch (Exception)
                {
                    // ignore non-existent drives
                }
            }

            try
            {
                AppSettingsReader asr = new AppSettingsReader();
                string yearsDefault = string.Empty;
                int curYear = DateTime.Today.Year;
                yearsDefault = curYear.ToString();
                getConfigValue<string>(asr, "yearsDefault", ref yearsDefault, yearsDefault);
                if ((yearsDefault != null) && (yearsDefault.Trim().Length > 0))
                {
                    string[] defaultYears = yearsDefault.Split(new char[] { ',' });
                    if ((defaultYears != null) && (defaultYears.Length > 0))
                    {
                        foreach (string s in defaultYears)
                        {
                            if (this.lbYear.Items.Contains(s))
                            {
                                for (int ii = 0; ii < this.lbYear.Items.Count; ii++)
                                {
                                    string sample = this.lbYear.Items[ii].ToString();
                                    if (sample.CompareTo(s) == 0)
                                    {
                                        this.lbYear.SetSelected(ii, true);
                                        Application.DoEvents();
                                        break;
                                    }
                                }
                            }
                        }
                    }
                }
                // support drivesDefault and imageFiles
                string drivesDefault = @"E:\";
                getConfigValue<string>(asr, "drivesDefault", ref drivesDefault, drivesDefault);
                if ((drivesDefault != null) && (drivesDefault.Trim().Length > 0))
                {
                    string[] defaultDrives = drivesDefault.Split(new char[] { ',' });
                    if ((defaultDrives != null) && (defaultDrives.Length > 0))
                    {
                        foreach (string s in defaultDrives)
                        {
                            for (int ii = 0; ii < this.lstDrives.Items.Count; ii++)
                            {
                                string sample = this.lstDrives.Items[ii].ToString();
                                if (string.Compare(s, sample, true) == 0)
                                {
                                    this.lstDrives.SetSelected(ii, true);
                                    Application.DoEvents();
                                    break;
                                }
                            }
                        }
                    }
                }
                //imageFiles
                getConfigValue<string>(asr, "imageFiles", ref imageFiles, imageFiles);
                imageFiles = imageFiles.Replace("*", string.Empty);
            }
            catch (Exception)
            {
                // permit no config file
            }
            this.toolTip1.SetToolTip(this.lbMonths, "Hold down the Ctrl key while selecting, to toggle a month's selection; none selected means select all.");
            this.toolTip1.SetToolTip(this.lbYear, "Hold down the Ctrl key while selecting, to toggle a year's selection; none selected means select all.");
            this.toolTip1.SetToolTip(this.lstDrives, "Hold down the Ctrl key while selecting, to toggle a drive's selection; none selected means select all.");
            this.toolTip1.SetToolTip(this.pictureBox1, "Click to see this picture in a popup.");
            this.toolTip1.SetToolTip(this.lbPhotosFound, "Select a photo (its path will be copied to the clipboard).");
        }
        private void addUpYears(IList<string> yList, ref List<Int32> years)
        {
            int tmp;
            foreach (var y in yList)
            {
                if (int.TryParse(y.ToString(), out tmp))
                {
                    years.Add(tmp);
                }
            }
        }
        protected void recursiveSearchFolder(string folder)
        {
            this.Cursor = Cursors.WaitCursor;

            try
            {
                this.lbPhotosFound.Items.Clear();
                int selectedMonth = this.lbMonths.SelectedIndex;
                List<int> years = new List<int>();
                IList<string> items = new List<string>();
                if ((this.lbYear.SelectedItems != null) && (this.lbYear.SelectedItems.Count > 0))
                {
                    foreach (var se in this.lbYear.SelectedItems)
                    {
                        items.Add(se.ToString());
                    }
                    addUpYears(items, ref years);
                }
                else
                {
                    foreach (var se in this.lbYear.Items)
                    {
                        items.Add(se.ToString());
                    }
                    addUpYears(items, ref years);
                }
                ImageHandler ih = new ImageHandler();
                IEnumerable<string> filesFound = ih.GetImageFilesMatchingRequest(folder, this.imageFiles,
                    selectedMonth, years, this.statusBar1);
                foreach (string g in filesFound)
                {
                    this.lbPhotosFound.Items.Add(g);
                }
                Application.DoEvents();
            }
            catch (Exception ex)
            {
                // ignore folders to which we do not have permission
                this.statusBar1.Text = ex.Message;
            }
            finally
            {
                this.Cursor = Cursors.Default;

                if (this.lbPhotosFound.Items.Count == 0)
                {
                    StringBuilder sb = new StringBuilder();
                    if ((this.lstDrives.SelectedItems != null) && (this.lstDrives.SelectedItems.Count > 0))
                    {
                        foreach (var si in this.lstDrives.SelectedItems)
                        {
                            if (sb.Length > 0)
                                sb.Append(',');
                            else
                                sb.Append("Drives ");
                            sb.Append($"{si.ToString()} ");
                        }
                        sb.Append("; ");
                    }
                    else
                    {
                        sb.Append("all drives; ");
                    }
                    if ((this.lbMonths.SelectedItems == null) || (this.lbMonths.SelectedItems.Count == 0))
                    {
                        sb.Append("all months; ");
                    }
                    else
                    {
                        foreach (var mi in this.lbMonths.SelectedItems)
                        {
                            sb.Append(mi.ToString());
                        } 
                    }
                    sb.Append(" ");
                    int i = 0;
                    if (this.lbYear.SelectedItems.Count > 0)
                    {
                        foreach (var yi in this.lbYear.SelectedItems)
                        {
                            i++;
                            sb.Append(yi.ToString());
                            if (i < this.lbYear.SelectedItems.Count)
                                sb.Append(", ");
                        }
                    }
                    else
                    {
                        foreach (var yi in this.lbYear.Items)
                        {
                            i++;
                            sb.Append(yi.ToString());
                            if (i < this.lbYear.Items.Count)
                                sb.Append(", ");
                        }
                    }
                    string comment = $"Found no photos with this criteria: {sb.ToString() }";
                    this.statusBar1.Text = comment;
                }
                else
                {
                    this.statusBar1.Text = string.Empty;
                }
            }
        }
        /// <summary>
        /// getConfigValue
        /// </summary>
        /// <typeparam name="T">passed type</typeparam>
        /// <param name="appSettingsReader">System.Configuration.AppSettingsReader</param>
        /// <param name="keyName">string</param>
        /// <param name="keyValue">ref T</param>
        /// <param name="defaultValue">T</param>
        private void getConfigValue<T>(AppSettingsReader appSettingsReader,
            string keyName, ref T keyValue, T defaultValue)
        {
            keyValue = defaultValue; // provide a default
            try
            {
                string tempS = (string)appSettingsReader.GetValue(keyName, typeof(System.String));
                if ((tempS != null) && (tempS.Trim().Length > 0))
                {
                    keyValue = (T)TypeDescriptor.GetConverter(keyValue.GetType()).ConvertFrom(tempS);
                }
                else
                    Debug.WriteLine("Registry failed to read value from " + keyName);
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.ToString());
                // if key does not exist, not a problem. Caller must pre-assign values anyway
            }
        }

        private void btnSearch_Click(object sender, System.EventArgs e)
        {
            if (this.lstDrives.Items.Count > 0)
            {
                this.btnSearch.Enabled = false;
                if ((this.lstDrives.SelectedItems != null) && (this.lstDrives.SelectedItems.Count > 0))
                {
                    foreach (var item in this.lstDrives.SelectedItems)
                    {
                        this.recursiveSearchFolder(item.ToString());
                    }
                }
                else
                {
                    for (int i = 0; i < this.lstDrives.Items.Count; i++)
                    {
                        this.recursiveSearchFolder(this.lstDrives.Items[i].ToString());
                    }
                }
                this.lbPhotosFound.Refresh();
                this.btnSearch.Enabled = true;
            }
        }
        private void closeOpenForms()
        {
            if (this.openForm != null)
            {
                this.openForm.Close();
                this.openForm = null;
            }                
        }

        private void lbPhotosFound_SelectedIndexChanged(object sender, System.EventArgs e)
        {
            this.lbPhotosFound.Enabled = false;
            string path = this.lbPhotosFound.SelectedItem.ToString();
            Clipboard.Clear();
            this.statusBar1.Text = string.Empty;
            if (!string.IsNullOrEmpty(path))
            {
                this.statusBar1.Text = string.Empty;
                utilities.setImageSize(path, this.pictureBox1);
                string date = utilities.GetCreationDate(this.pictureBox1.Image);
                if (string.IsNullOrEmpty(date))
                {
                    FileInfo fi = new System.IO.FileInfo(path);
                    date = fi.CreationTime.ToShortDateString();
                }
                if ((date != null) && (date.Length > 0))
                {
                    this.statusBar1.Text = date.Replace(":", "/");
                }
                Clipboard.SetText(path);
            }
            else
            {
                this.pictureBox1.Image = null;
            }
            this.lbPhotosFound.Enabled = true;
            this.lbPhotosFound.Focus();
        }

        private void pictureBox1_Click(object sender, System.EventArgs e)
        {
            this.closeOpenForms();
            this.openForm = new picture(this.lbPhotosFound.SelectedItem.ToString())
            {
                Text = lbPhotosFound.SelectedItem.ToString()
            };
            this.openForm.Show(this);
            this.openForm.TopMost = true;
        }
    }
}
