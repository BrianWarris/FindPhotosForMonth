using System;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Imaging;
using System.Collections;
using System.ComponentModel;
using System.Text;
using System.Windows.Forms;

namespace FindPhotosForMonth
{
    /// <summary>
    /// Summary description for picture.
    /// </summary>
    public class picture : System.Windows.Forms.Form
    {
        private System.Windows.Forms.PictureBox pictureBox1;
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.Container components = null;

        public picture(string p)
        {
            //
            // Required for Windows Form Designer support
            //
            InitializeComponent();

            Clipboard.SetDataObject(p, true);
            utilities.setImageSize(p, this.pictureBox1);
            this.Load += new EventHandler(this.picture_Load);
        }
        public void picture_Load(object sender, System.EventArgs e)
        {
            this.Focus();
        }
        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        protected override void Dispose( bool disposing )
        {
            if( disposing )
            {
                if(components != null)
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
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.SuspendLayout();
            // 
            // pictureBox1
            // 
            this.pictureBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(292, 266);
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // picture
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
            this.ClientSize = new System.Drawing.Size(292, 266);
            this.Controls.AddRange(new System.Windows.Forms.Control[] {
                                                                          this.pictureBox1});
            this.Name = "picture";
            this.Text = "picture";
            this.ResumeLayout(false);

        }
        #endregion
    }
}
