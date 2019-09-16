using System;
namespace KandTKardach.Models
{
    public class Image
    {
        public Image(int id, string name, string url)
        {
			m_id = id;
			m_name = name;
			m_url = url;
        }
        public Image(int id, string name, string url, string thmbUrl)
        {
            m_id = id;
            m_name = name;
            m_url = url;
            m_thmbUrl = thmbUrl;
        }

        protected int m_id;
        /// <summary>
        /// Gets the identifier.
        /// </summary>
        /// <value>The identifier.</value>
        public int Id
		{
			get { return m_id; }
		}

		protected string m_name;
        /// <summary>
        /// Gets the name of the album.
        /// </summary>
        /// <value>The name.</value>
        public string Name
		{
			get { return m_name; }
		}

		protected string m_url;
        /// <summary>
        /// Gets the URL of the image.
        /// </summary>
        /// <value>The URL.</value>
        public string Url
		{
			get { return m_url; }
		}

        protected string m_thmbUrl;
        public string ThumbnailUrl
        {
            get { return m_thmbUrl; }
        }
    }
}
