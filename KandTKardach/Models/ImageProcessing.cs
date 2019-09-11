using System;
using System.IO;
using System.Drawing;
using System.Drawing.Imaging;

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
                CompressImage(orig, thumbName, Constants.THUMBNAIL_FACTOR, img.RawFormat);
            }
            catch
			{ return false; } 

            return true;        
		}

        /// <summary>
        /// Compresses the JPEG by a given factor.
        /// </summary>
        /// <param name="orig">Original.</param>
        /// <param name="dest">Destination.</param>
        /// <param name="factor">Factor.</param>
        public static void CompressJpeg(string orig, string dest, byte factor)
		{
			CompressImage(orig, dest, factor, ImageFormat.Jpeg);
		}

        /// <summary>
        /// Compresses the image by a given factor.
        /// </summary>
        /// <param name="orig">Original.</param>
        /// <param name="dest">Destination.</param>
        /// <param name="factor">Factor.</param>
        /// <param name="format">Format.</param>
        public static void CompressImage(string orig, string dest, byte factor, ImageFormat format)
		{
			using (Bitmap bmp1 = new Bitmap(orig))
			{
				ImageCodecInfo jpgEncoder = GetEncoder(format);
				Encoder encoder = Encoder.Quality;

				EncoderParameters encParams = new EncoderParameters(1);

				EncoderParameter param = new EncoderParameter(encoder, factor);
				encParams.Param[0] = param;
				bmp1.Save(dest, jpgEncoder, encParams);
			}
		}

        private static ImageCodecInfo GetEncoder(ImageFormat format)
        {
            ImageCodecInfo[] codecs = ImageCodecInfo.GetImageDecoders();
            foreach (ImageCodecInfo codec in codecs)
            {
                if (codec.FormatID == format.Guid)
                    return codec;
            }
			return null;
        }
    }
}
