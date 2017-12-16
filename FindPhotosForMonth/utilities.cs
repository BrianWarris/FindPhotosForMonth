using System;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Imaging;
using System.Windows.Forms;
using System.Text;

namespace FindPhotosForMonth
{
    /// <summary>
    /// Summary description for utilities.
    /// </summary>
    public class utilities
    {
        const int ImageDatePropertyId = 36867;

        static public void setImageSize(string path, PictureBox pb, int widthOfOtherControls = 0, int heightofOtherControls = 0)
        {
            int xSize;
            int ySize;
            float xReduce;
            float yReduce;
            pb.Image = (Image)null;  // take out the old one
            // Sets up an image object to be displayed.

            // Stretches the image to fit the pictureBox.
            pb.SizeMode = PictureBoxSizeMode.StretchImage;
            pb.Image  = new Bitmap(path);
            SizeF sizeF = new SizeF(pb.Image.PhysicalDimension);

            xReduce =  (float)(pb.Parent.Width - (float)(pb.Left +  widthOfOtherControls)) / (float)(sizeF.Width);
            yReduce =  (float)(pb.Parent.Height - (float)(pb.Top  +  heightofOtherControls)) / (float)sizeF.Height;
            Debug.Assert(xReduce > 0);
            Debug.Assert(yReduce > 0);
            if (sizeF.Width < sizeF.Height )
            {
                xSize = (int)(yReduce * sizeF.Width);
                ySize = (int)(yReduce * sizeF.Height);
            }
            else
            {
                xSize = (int)(xReduce * sizeF.Width);
                ySize = (int)(xReduce * sizeF.Height);
            }
            pb.ClientSize = new Size(xSize, ySize);
        }
        static public int GetCreationYear(Image i)
        {
            int rv = 0;
            PropertyItem P =   i.GetPropertyItem(ImageDatePropertyId);
            string val = System.Text.Encoding.ASCII.GetString((byte [])P.Value);
            try
            {
                rv = int.Parse(val.Substring(0, 4));
            }
            catch (Exception)
            {
            }

            return(rv);
        }
        static public string  GetCreationDate(Image i)
        {
            string rv = string.Empty;
            try
            {
                PropertyItem P = i.GetPropertyItem(ImageDatePropertyId);
                string val = System.Text.Encoding.ASCII.GetString((byte[])P.Value);

                rv = val.Substring(0, 10);
            }
            catch (System.ArgumentException)
            {
                // propertyItem was not found, which is OK
            }
            catch (Exception e0)
            {
                Debug.WriteLine(e0.ToString());
            }

            return(rv);
        }
    }
}
