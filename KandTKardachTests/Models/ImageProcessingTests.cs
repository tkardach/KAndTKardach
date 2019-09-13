using Microsoft.VisualStudio.TestTools.UnitTesting;
using KandTKardach.Models;
using System.IO;
using System.Reflection;

namespace KandTKardach.Models.Tests
{
    [TestClass()]
    public class ImageProcessingTests
    {
        private const string TEST_IMAGE = @"\Resources\TestImage.jpg";
        private const string THUMB_OUT = @"\Resources\TestImageThmb.jpg";

        [TestMethod()]
        public void CreateThumbnailTest()
        {
            string dirName = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
            bool success = ImageProcessing.CreateThumbnail(dirName + TEST_IMAGE, dirName + THUMB_OUT);
            if (File.Exists(THUMB_OUT))
                File.Delete(THUMB_OUT);
            Assert.IsTrue(success);
        }
    }
}