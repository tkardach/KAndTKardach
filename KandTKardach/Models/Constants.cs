
namespace KandTKardach
{
    public static class Constants
    {
        public static byte      THUMBNAIL_FACTOR = 35;
        public static int       THUMBNAIL_MAX_DIMENSION = 512;
        public static string    THUMBNAIL_LOCATION = "~/Content/Thumbnails/";
        public const string     TEMP_FOLDER = "tmp";

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