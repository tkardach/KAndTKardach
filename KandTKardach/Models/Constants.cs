
namespace KandTKardach
{
    public static class Constants
    {
        public static byte      THUMBNAIL_FACTOR = 35;
        public static int       THUMBNAIL_MAX_DIMENSION = 512;

        #region File Locations
        public static string    THUMBNAIL_LOCATION      = "~/Content/Thumbnails/";
        public static string    THUMBNAIL_LOCATION_MOCK = "~/Content/Mock/Thumbnails/";
        public static string    IMAGE_LOCATION      = "~/Content/Images/";
        public static string    IMAGE_LOCATION_MOCK = "~/Content/Mock/Images/";
        public const string     TEMP_FOLDER = "tmp";
        #endregion
        public static void CreateTemp()
        {
            if (!System.IO.Directory.Exists(TEMP_FOLDER))
                System.IO.Directory.CreateDirectory(TEMP_FOLDER);
        }

        public static void RemoveTemp()
        {
            if (System.IO.Directory.Exists(TEMP_FOLDER))
                System.IO.Directory.Delete(TEMP_FOLDER, true);
        }
    }
}