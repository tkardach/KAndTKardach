using System;
using System.Collections.Generic;

namespace KandTKardach.Models
{   
    public class Album
	{      
		public Album(int id, string name)
		{
			m_id = id;
			m_albumName = name;
			m_images = new List<Image>();
        }

		protected readonly int m_id;
        /// <summary>
        /// Gets the identifier.
        /// </summary>
        /// <value>The identifier.</value>
        public int Id
		{
			get { return m_id; }
		}

		protected string m_albumName;
        /// <summary>
        /// Gets the name of the album.
        /// </summary>
        /// <value>The name of the album.</value>
        public string AlbumName
		{
			get { return m_albumName; }
		}      

        protected IList<Image> m_images;
        /// <summary>
        /// Gets or sets the list of images.
        /// </summary>
        /// <value>The images.</value>
		public IList<Image> Images
        {
			get { return m_images; }
			set { m_images = value; }
		}
    }
}
