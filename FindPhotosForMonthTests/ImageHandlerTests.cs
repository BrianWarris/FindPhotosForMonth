using Microsoft.VisualStudio.TestTools.UnitTesting;
using FindPhotosForMonth;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.Diagnostics;
using System.IO;
using System.Windows.Forms;

namespace FindPhotosForMonth.Tests
{
    [TestClass()]
    
    public class ImageHandlerTests
    {
        #region global test-specific defaults
        private string expectedFileName = "IMG_1721.JPG";
        private int expectedMonth = 10; // zero offset means November; 0 is January
        private int expectedYear = 2015;
        private string expectedImgSpec = ".jpg";
        #endregion

        #region positive test cases
        [TestMethod()]
        [DeploymentItem("IMG_1721.JPG")]
        public void GetImageFilesMatchingRequestAllExpected()
        {
            if (File.Exists(expectedFileName))
            {
                Debug.WriteLine($"Found file {expectedFileName}");
                SetupDefaults(out ImageHandler ih, out string folderPath, out List<int> years,
                    out StatusBar statBar, this.expectedYear);
                Assert.IsNotNull(ih);
                List<string> results = new List<string>(ih.GetImageFilesMatchingRequest(folderPath, this.expectedImgSpec,
                    this.expectedMonth, years, statBar));
                Assert.IsNotNull(results);
                int count = results.Count;
                Assert.IsTrue(count >= 1, $"Expect >= one result(s) on all param as expected : {count}");
                Assert.IsTrue(string.IsNullOrEmpty(statBar.Text));
                Image im =  Image.FromFile(results[0]);
                string dt = utilities.GetCreationDate(im);
                Assert.AreEqual(dt, "2015:11:15");
            }
            else
            {
                Assert.Fail($"Failed to find file {expectedFileName}");
            }
        }

        //PictureBox test
        [TestMethod()]
        [DeploymentItem("IMG_1721.JPG")]
        public void GetImageFilesMatchingRequestImageAsPictureBox()
        {
            if (File.Exists(expectedFileName))
            {
                Debug.WriteLine($"Found file {expectedFileName}");
                SetupDefaults(out ImageHandler ih, out string folderPath, out List<int> years,
                    out StatusBar statBar, this.expectedYear);
                Assert.IsNotNull(ih);
                List<string> results = new List<string>(ih.GetImageFilesMatchingRequest(folderPath, this.expectedImgSpec,
                    this.expectedMonth, years, statBar));
                Assert.IsNotNull(results);
                int count = results.Count;
                Assert.IsTrue(count >= 1, $"Expect >= one result(s) on all param as expected : {count}");
                Assert.IsTrue(string.IsNullOrEmpty(statBar.Text));
                GroupBox gb = new GroupBox();
                gb.Width = 640;
                gb.Height = 480;
                PictureBox pb = new PictureBox();
                pb.Parent = gb;
                utilities.setImageSize(results[0], pb);
                Debug.WriteLine($"{pb.ClientSize.Width} by {pb.ClientSize.Height}");
                Assert.AreEqual(pb.ClientSize.Width, 640);
                Assert.AreEqual(pb.ClientSize.Height, 480);
            }
            else
            {
                Assert.Fail($"Failed to find file {expectedFileName}");
            }
        }

        [TestMethod()]
        [DeploymentItem("IMG_1721.JPG")]
        public void GetImageFilesMatchingRequestImageAsPictureBoxOtherArgs()
        {
            if (File.Exists(expectedFileName))
            {
                Debug.WriteLine($"Found file {expectedFileName}");
                SetupDefaults(out ImageHandler ih, out string folderPath, out List<int> years,
                    out StatusBar statBar, this.expectedYear);
                Assert.IsNotNull(ih);
                List<string> results = new List<string>(ih.GetImageFilesMatchingRequest(folderPath, this.expectedImgSpec,
                    this.expectedMonth, years, statBar));
                Assert.IsNotNull(results);
                int count = results.Count;
                Assert.IsTrue(count >= 1, $"Expect >= one result(s) on all param as expected : {count}");
                Assert.IsTrue(string.IsNullOrEmpty(statBar.Text));
                GroupBox gb = new GroupBox();
                gb.Width = 640;
                gb.Height = 480;
                PictureBox pb = new PictureBox();
                pb.Parent = gb;
                utilities.setImageSize(results[0], pb, 40, 30);
                Debug.WriteLine($"{pb.ClientSize.Width} by {pb.ClientSize.Height}");
                Assert.AreEqual(pb.ClientSize.Width, 599);
                Assert.AreEqual(pb.ClientSize.Height, 449);
            }
            else
            {
                Assert.Fail($"Failed to find file {expectedFileName}");
            }
        }
        [TestMethod()]
        [DeploymentItem("IMG_1721.JPG")]
        public void GetImageFilesMatchingRequestImageAsPictureBoxOtherBigArgs()
        {
            if (File.Exists(expectedFileName))
            {
                Debug.WriteLine($"Found file {expectedFileName}");
                SetupDefaults(out ImageHandler ih, out string folderPath, out List<int> years,
                    out StatusBar statBar, this.expectedYear);
                Assert.IsNotNull(ih);
                List<string> results = new List<string>(ih.GetImageFilesMatchingRequest(folderPath, this.expectedImgSpec,
                    this.expectedMonth, years, statBar));
                Assert.IsNotNull(results);
                int count = results.Count;
                Assert.IsTrue(count >= 1, $"Expect >= one result(s) on all param as expected : {count}");
                Assert.IsTrue(string.IsNullOrEmpty(statBar.Text));
                GroupBox gb = new GroupBox();
                gb.Width = 640;
                gb.Height = 480;
                PictureBox pb = new PictureBox();
                pb.Parent = gb;
                utilities.setImageSize(results[0], pb, 494, 371);
                Debug.WriteLine($"{pb.ClientSize.Width} by {pb.ClientSize.Height}");
                Assert.AreEqual(pb.ClientSize.Width, 145);
                Assert.AreEqual(pb.ClientSize.Height, 109);
            }
            else
            {
                Assert.Fail($"Failed to find file {expectedFileName}");
            }
        }
        [TestMethod()]
        [DeploymentItem("IMG_1721.JPG")]
        public void GetImageFilesMatchingRequestImageAsPictureBoxOtherExcessiveArgs()
        {
            if (File.Exists(expectedFileName))
            {
                Debug.WriteLine($"Found file {expectedFileName}");
                SetupDefaults(out ImageHandler ih, out string folderPath, out List<int> years,
                    out StatusBar statBar, this.expectedYear);
                Assert.IsNotNull(ih);
                List<string> results = new List<string>(ih.GetImageFilesMatchingRequest(folderPath, this.expectedImgSpec,
                    this.expectedMonth, years, statBar));
                Assert.IsNotNull(results);
                int count = results.Count;
                Assert.IsTrue(count >= 1, $"Expect >= one result(s) on all param as expected : {count}");
                Assert.IsTrue(string.IsNullOrEmpty(statBar.Text));
                GroupBox gb = new GroupBox();
                gb.Width = 640;
                gb.Height = 480;
                PictureBox pb = new PictureBox();
                pb.Parent = gb;
                utilities.setImageSize(results[0], pb, 589, 439);
                Debug.WriteLine($"{pb.ClientSize.Width} by {pb.ClientSize.Height}");
                Assert.AreEqual(pb.ClientSize.Width, 51);
                Assert.AreEqual(pb.ClientSize.Height, 38);
            }
            else
            {
                Assert.Fail($"Failed to find file {expectedFileName}");
            }
        }
        [TestMethod()]
        [DeploymentItem("IMG_1721.JPG")]
        public void GetImageFilesMatchingRequestAllMonths()
        {
            if (File.Exists(expectedFileName))
            {
                const int allMonths = -1; // simulates no selection => all months
                Debug.WriteLine($"Found file {expectedFileName}");
                SetupDefaults(out ImageHandler ih, out string folderPath, out List<int> years,
                    out StatusBar statBar, this.expectedYear);
                List<string> results = new List<string>(ih.GetImageFilesMatchingRequest(folderPath, this.expectedImgSpec,
                    allMonths, years, statBar));
                Assert.IsNotNull(results);
                int count = results.Count;
                Assert.IsTrue(count >= 1, $"Expect >= one result(s) on all months : {count}");
                Assert.IsTrue(string.IsNullOrEmpty(statBar.Text));
            }
            else
            {
                Assert.Fail($"Failed to find file {expectedFileName}");
            }
        }
        [TestMethod()]
        [DeploymentItem("IMG_1721.JPG")]
        public void GetImageFilesMatchingRequestAllYears()
        {
            if (File.Exists(expectedFileName))
            {
                Debug.WriteLine($"Found file {expectedFileName}");
                SetupDefaults(out ImageHandler ih, out string folderPath, out List<int> years,
                    out StatusBar statBar, this.expectedYear);
                for (int year = 2009; year <= DateTime.Today.Year; year++)
                {
                    if (! years.Contains(year))
                    {
                        years.Add(year);
                    }
                }
                List<string> results = new List<string>(ih.GetImageFilesMatchingRequest(folderPath, this.expectedImgSpec,
                    this.expectedMonth, years, statBar));
                Assert.IsNotNull(results);
                int count = results.Count;
                Assert.IsTrue(count >= 1, $"Expect >= one result(s) on all months : {count}");
                Assert.IsTrue(string.IsNullOrEmpty(statBar.Text));
            }
            else
            {
                Assert.Fail($"Failed to find file {expectedFileName}");
            }
        }
        #endregion
        #region negative test cases

        [TestMethod()]
        [DeploymentItem("IMG_1721.JPG")]
        public void GetImageFilesMatchingRequestWrongMonth()
        {
            if (File.Exists(expectedFileName))
            {
                Debug.WriteLine($"Found file {expectedFileName}");

                int MonthNotExpected = 2;
                SetupDefaults(out ImageHandler ih, out string folderPath, out List<int> years,
                                out StatusBar statBar, this.expectedYear);
                List<string> results = new List<string>(ih.GetImageFilesMatchingRequest(folderPath,
                    this.expectedImgSpec, MonthNotExpected, years, statBar));
                Assert.IsNotNull(results);
                int count = results.Count;
                Assert.IsTrue(count == 0, $"Expect no results on unmatched month {MonthNotExpected}");
                Assert.IsTrue(string.IsNullOrEmpty(statBar.Text));
            }
            else
            {
                Assert.Fail($"Failed to find file {expectedFileName}");
            }
        }
        [TestMethod()]
        [DeploymentItem("IMG_1721.JPG")]
        public void GetImageFilesMatchingRequestMonthOutOfBounds()
        {
            if (File.Exists(expectedFileName))
            {
                Debug.WriteLine($"Found file {expectedFileName}");

                int MonthNotExpected = 13;
                SetupDefaults(out ImageHandler ih, out string folderPath, out List<int> years,
                                out StatusBar statBar, this.expectedYear);
                List<string> results = new List<string>(ih.GetImageFilesMatchingRequest(folderPath,
                    this.expectedImgSpec, MonthNotExpected, years, statBar));
                Assert.IsNotNull(results);
                int count = results.Count;
                Assert.IsTrue(count == 0, $"Expect no results on unmatched month {MonthNotExpected}");
                Assert.IsTrue(string.IsNullOrEmpty(statBar.Text));
            }
            else
            {
                Assert.Fail($"Failed to find file {expectedFileName}");
            }
        }
        [TestMethod()]
        [DeploymentItem("IMG_1721.JPG")]
        public void GetImageFilesMatchingRequestWrongYear()
        {
            if (File.Exists(expectedFileName))
            {
                Debug.WriteLine($"Found file {expectedFileName}");
                int unexpectedYear = 2012;
                SetupDefaults(out ImageHandler ih, out string folderPath, out List<int> years,
                                out StatusBar statBar, unexpectedYear);
                List<string> results = new List<string>(ih.GetImageFilesMatchingRequest(folderPath, this.expectedImgSpec, this.expectedMonth,
                    years, statBar));
                Assert.IsNotNull(results);
                int count = results.Count;
                Assert.IsTrue(count == 0, $"Expect no results on unexpected year {unexpectedYear}");
                Assert.IsTrue(string.IsNullOrEmpty(statBar.Text));
            }
            else
            {
                Assert.Fail($"Failed to find file {expectedFileName}");
            }
        }
        [TestMethod()]
        [DeploymentItem("IMG_1721.JPG")]
        public void GetImageFilesMatchingRequestYearZero()
        {
            if (File.Exists(expectedFileName))
            {
                Debug.WriteLine($"Found file {expectedFileName}");
                int unexpectedYear = 0;
                SetupDefaults(out ImageHandler ih, out string folderPath, out List<int> years,
                                out StatusBar statBar, unexpectedYear);
                List<string> results = new List<string>(ih.GetImageFilesMatchingRequest(folderPath, this.expectedImgSpec, this.expectedMonth,
                    years, statBar));
                Assert.IsNotNull(results);
                int count = results.Count;
                Assert.IsTrue(count == 0, $"Expect no results on unexpected year {unexpectedYear}");
                Assert.IsTrue(string.IsNullOrEmpty(statBar.Text));
            }
            else
            {
                Assert.Fail($"Failed to find file {expectedFileName}");
            }
        }
        [TestMethod()]
        [DeploymentItem("IMG_1721.JPG")]
        public void GetImageFilesMatchingRequestYear3000()
        {
            if (File.Exists(expectedFileName))
            {
                Debug.WriteLine($"Found file {expectedFileName}");
                int unexpectedYear = 3000;
                SetupDefaults(out ImageHandler ih, out string folderPath, out List<int> years,
                                out StatusBar statBar, unexpectedYear);
                List<string> results = new List<string>(ih.GetImageFilesMatchingRequest(folderPath, this.expectedImgSpec, this.expectedMonth,
                    years, statBar));
                Assert.IsNotNull(results);
                int count = results.Count;
                Assert.IsTrue(count == 0, $"Expect no results on unexpected year {unexpectedYear}");
                Assert.IsTrue(string.IsNullOrEmpty(statBar.Text));
            }
            else
            {
                Assert.Fail($"Failed to find file {expectedFileName}");
            }
        }
        [TestMethod()]
        [DeploymentItem("IMG_1721.JPG")]
        public void GetImageFilesMatchingRequestWrongFolder()
        {
            if (File.Exists(expectedFileName))
            {
                Debug.WriteLine($"Found file {expectedFileName}");
                SetupDefaults(out ImageHandler ih, out string folderPath, out List<int> years,
                              out StatusBar statBar, this.expectedYear);
                // prepare params to pass
                var unexpectedFolder = @"c:\someFolder";
                List<string> results = new List<string>(ih.GetImageFilesMatchingRequest(unexpectedFolder, this.expectedImgSpec, this.expectedMonth,
                    years, statBar));
                Assert.IsNotNull(results);
                int count = results.Count;
                Assert.IsTrue(count == 0, $"Expect no results on unexpected folder {unexpectedFolder}");
                Assert.IsTrue(statBar.Text.Contains("Could not find a part of the path"));
            }
            else
            {
                Assert.Fail($"Failed to find file {expectedFileName}");
            }
        }
        [TestMethod()]
        [DeploymentItem("IMG_1721.JPG")]
        public void GetImageFilesMatchingRequestFolderWithoutPermissions()
        {
            if (File.Exists(expectedFileName))
            {
                Debug.WriteLine($"Found file {expectedFileName}");
                SetupDefaults(out ImageHandler ih, out string folderPath, out List<int> years,
                              out StatusBar statBar, this.expectedYear);
                // prepare params to pass
                var unexpectedFolder = @"c:\Program Files\";
                List<string> results = new List<string>(ih.GetImageFilesMatchingRequest(unexpectedFolder, this.expectedImgSpec, this.expectedMonth,
                    years, statBar));
                Assert.IsNotNull(results);
                int count = results.Count;
                Assert.IsTrue(count == 0, $"Expect no results on a subfolder {unexpectedFolder} that we do not have permission to.");
                Assert.IsTrue(statBar.Text.Contains("Access to the path "));
                Assert.IsTrue(statBar.Text.Contains(" is denied."));
            }
            else
            {
                Assert.Fail($"Failed to find file {expectedFileName}");
            }
        }
        [TestMethod()]
        [DeploymentItem("IMG_1721.JPG")]
        public void GetImageFilesMatchingRequestWrongImageSpec()
        {
            if (File.Exists(expectedFileName))
            {
                Debug.WriteLine($"Found file {expectedFileName}");
                SetupDefaults(out ImageHandler ih, out string folderPath, out List<int> years,
                    out StatusBar statBar, this.expectedYear);
                string unexpectedImageSpec = ".tiff";
                List<string> results = new List<string>(ih.GetImageFilesMatchingRequest(folderPath, unexpectedImageSpec, this.expectedMonth,
                    years, statBar));
                Assert.IsNotNull(results);
                int count = results.Count;
                Assert.IsTrue(count == 0, $"Expect no results on unmatched image {unexpectedImageSpec}");
                Assert.IsTrue(string.IsNullOrEmpty(statBar.Text));
            }
            else
            {
                Assert.Fail($"Failed to find file {expectedFileName}");
            }
        }
        [TestMethod()]
        [DeploymentItem("IMG_1721.JPG")]
        public void GetImageFilesMatchingRequestWrongImageSpecs()
        {
            if (File.Exists(expectedFileName))
            {
                SetupDefaults(out ImageHandler ih, out string folderPath, out List<int> years,
                    out StatusBar statBar, this.expectedYear);
                string unexpectedImageSpec = ".img,.jpe,.tiff";
                List<string> results = new List<string>(ih.GetImageFilesMatchingRequest(folderPath, unexpectedImageSpec, this.expectedMonth,
                    years, statBar));
                Assert.IsNotNull(results);
                int count = results.Count;
                Assert.IsTrue(count == 0, $"Expect zero result(s) on unexpected image extensions specified : {count}");
                Assert.IsTrue(string.IsNullOrEmpty(statBar.Text));
            }
            else
            {
                Assert.Fail($"Failed to find file {expectedFileName}");
            }
        }
        #endregion

        #region helper method
        private void SetupDefaults(out ImageHandler ih, out string folderPath,
            out List<int> years, out StatusBar statBar, int yearToTest)
        {
            string GetThreeFoldersUp(string curFolder)
            {
                return Path.GetDirectoryName(string.Format(@"{0}\..\..\..", curFolder));
            }
            Debug.WriteLine($"Found file {this.expectedFileName}");
            ih = new ImageHandler();
            // prepare params to pass
            folderPath = GetThreeFoldersUp(Environment.CurrentDirectory);
            Debug.WriteLine(folderPath);
            years = new List<int>() { yearToTest };
            statBar = new StatusBar();
        }
        #endregion
    }
}

