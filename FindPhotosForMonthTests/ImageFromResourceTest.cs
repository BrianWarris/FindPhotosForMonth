using Microsoft.VisualStudio.TestTools.UnitTesting;
using FindPhotosForMonth;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace FindPhotosForMonth.Tests
{
    /// <summary>
    /// ImageFromResource - this class demonstrates that the process of saving an image as a resource strips out the metadata identified by Property Id 36867
    /// </summary>
    [TestClass()]
    public class ImageFromResource
    {
        [TestMethod()]
        public void ImageFromResourceValid()
        {
            // Creates the ResourceManager.   */
            var   rm = new System.Resources.ResourceManager("FindPhotosForMonthTests.Properties.Resources", this.GetType().Assembly);
            System.Drawing.Bitmap im = (System.Drawing.Bitmap)rm.GetObject("testImage01");
            Assert.IsNotNull(im);
            Assert.AreEqual<Int32>(im.Width, 3024);
            Assert.AreEqual<Int32>(im.Height, 4032);
            Assert.AreEqual<Int32>(im.Flags, 73744);
            // retrieve propertyItems
            var val = im.GetPropertyItem(20624);
            Assert.AreEqual<byte>(val.Value[0], (byte)1);
            val = im.GetPropertyItem(20625);
            Assert.AreEqual<byte>(val.Value[0], (byte)1);
        }
        [TestMethod()]
        [ExpectedException(typeof(System.ArgumentException))]
        public void ImageFromResourceInvalidYear()
        {
            // Creates the ResourceManager.   */
            var rm = new System.Resources.ResourceManager("FindPhotosForMonthTests.Properties.Resources", this.GetType().Assembly);
            Image im0 = (System.Drawing.Image)rm.GetObject("testImage01");
            // test year and date
            int year = utilities.GetCreationYear(im0);
            Assert.AreEqual(year, 2015);
        }
        [TestMethod()]

        public void ImageFromResourceInvalidDate()
        {
            // Creates the ResourceManager.   */
            var rm = new System.Resources.ResourceManager("FindPhotosForMonthTests.Properties.Resources", this.GetType().Assembly);
            Image im0 = (System.Drawing.Image)rm.GetObject("testImage01");
            // test year and date
            string dt = utilities.GetCreationDate(im0);
            Assert.IsTrue(string.IsNullOrEmpty(dt));
        }
        [TestMethod()]
        [ExpectedException(typeof(System.ArgumentException))]
        public void ImageFromResourceValidDate()
        {
            // Creates the ResourceManager.   */
            var rm = new System.Resources.ResourceManager("FindPhotosForMonthTests.Properties.Resources", this.GetType().Assembly);
            Image im0 = (System.Drawing.Image)rm.GetObject("testImage02");

            // test year and date
            int year = utilities.GetCreationYear(im0);
            Assert.AreEqual(year, 2015);
        }
        [TestMethod()]
        public void ImageFromResourceValidDatePng()
        {
            // Creates the ResourceManager.   */
            var rm = new System.Resources.ResourceManager("FindPhotosForMonthTests.Properties.Resources", this.GetType().Assembly);
            Image im0 = (System.Drawing.Image)rm.GetObject("testImage03");

            // test year and date
            string dt = utilities.GetCreationDate(im0);
            Assert.IsTrue(string.IsNullOrEmpty(dt));
        }
    }
}