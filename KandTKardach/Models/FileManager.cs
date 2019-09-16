using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace KandTKardach.Models
{
    public class FileManager
    {
        protected bool m_mockMode;

        protected static FileManager m_instance;
        public static FileManager Instance
        {
            get
            {
                if (m_instance == null)
                    m_instance = new FileManager(Configuration.MockEnabled);
                return m_instance;
            }
        }

        private FileManager(bool mock = false)
        {
            m_mockMode = mock;
        }

        public string ThumbnailPath
        {
            get
            {
                if (m_mockMode)
                    return Constants.THUMBNAIL_LOCATION;
                else
                    return Constants.THUMBNAIL_LOCATION_MOCK;
            }
        }

        public string ImagePath
        {
            get
            {
                if (m_mockMode)
                    return Constants.IMAGE_LOCATION;
                else
                    return Constants.IMAGE_LOCATION_MOCK;
            }
        }
    }
}