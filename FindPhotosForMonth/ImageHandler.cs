using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FindPhotosForMonth
{
    public class ImageHandler
    {
        // constructor
        public ImageHandler()
        {

        }
        public IEnumerable<string> GetImageFilesMatchingRequest(string folder, string imageFiles, 
            int selectedMonth, IList<int> years, StatusBar statusBar1)
        {
            List<string> ListOfImageFiles = new List<string>();

            try
            {
                string[] folders = null;
                try
                {
                    folders = Directory.GetDirectories(folder, "*.*");
                }
                catch (System.UnauthorizedAccessException uae)
                {
                    statusBar1.Text = $"Access was denied to {folder} {uae.Message}";
                }
                if ((folders != null) && (folders.Length > 0))
                {
                    foreach (string f in folders)
                    {
                        ListOfImageFiles.AddRange(GetImageFilesMatchingRequest(f, imageFiles,
                            selectedMonth,years, statusBar1));
                    }
                }
                // see https://stackoverflow.com/questions/7039580/multiple-file-extensions-searchpattern-for-system-io-directory-getfiles
                string[] allowedExtensions = imageFiles.ToLower().Split(new char [] { ',' }, StringSplitOptions.RemoveEmptyEntries);
                Debug.WriteLine($"Looking at {folder} for files {allowedExtensions}");
                string[] files = (from fi in new DirectoryInfo(folder).GetFiles()
                                where allowedExtensions.Contains(fi.Extension.ToLower())
                                orderby fi.FullName
                                select fi.FullName
                                ).ToArray();

                if ((files != null) && (files.Length != 0))
                {
                    foreach (string g in files)
                    {
                        // why GetLastWriteTime and not GetCreationTime: on observation that GetCreationTime will be time of the copy and not the original datetime
                        DateTime dt = File.GetLastWriteTime(g);
                        if ((selectedMonth == -1) || (dt.Month == (selectedMonth + 1)))
                        {
                            // qualify by year if one is selected
                            if (years.Contains(dt.Year))
                            {
                                ListOfImageFiles.Add(g);
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                statusBar1.Text = ex.Message;
            }

            return ListOfImageFiles.ToArray();
        }
    }
}
