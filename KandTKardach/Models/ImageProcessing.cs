using System.IO;
using ImageProcessing;

namespace KandTKardach.Models
{
    public class ImageProcessing
    {

        public ImageProcessing()
        {
        }

        /// <summary>
        /// Gets the thumbnail path for a given image name
        /// </summary>
        /// <returns>The thumbnail path.</returns>
        /// <param name="filename">Filename.</param>
        public static string GetThumbnailPath(string filename)
		{
			return Constants.THUMBNAIL_LOCATION + filename;
		}

        /// <summary>
        /// Creates a thumbnail of the image and stores it in thumbnail folder.
        /// </summary>
        /// <returns><c>true</c>, if thumbnail was created, <c>false</c> otherwise.</returns>
        /// <param name="orig">Original.</param>
        public static bool CreateThumbnail(string orig, string dest)
		{
            try
            {
                if (!File.Exists(orig)) return false;

                string fileName = Path.GetFileName(orig);
                string thumbName = dest + fileName;
                if (File.Exists(thumbName)) return true;

                var img = System.Drawing.Image.FromFile(orig);
                // Remove meta-data from image
                var exifRemoved = Compressor.RemoveExif(orig);
                var resized = Compressor.ResizeImage(exifRemoved, Constants.THUMBNAIL_MAX_DIMENSION);

                Constants.CreateTemp();
                string fileLoc = string.Format(@"{0}\tmpImg.{1}", Constants.TEMP_FOLDER, orig.Substring(orig.LastIndexOf('.') + 1));
                resized.Save(fileLoc, resized.RawFormat);
                Compressor.CompressImage(fileLoc, thumbName, Constants.THUMBNAIL_FACTOR, img.RawFormat);
                Constants.RemoveTemp();
            }
            catch
			{ return false; } 

            return true;        
		}
    }
}
