using System;
using KandTKardach.Models;

namespace KandTKardach.ViewModel
{
    public class ImageViewModel
    {
		public ImageViewModel(string ablum, Image image)
        {
			m_album = Album;
			m_image = image;
        }

		protected Image m_image;
		public Image Image
		{
			get { return m_image; }
		}

		protected string m_album;
        public string Album
		{
			get { return m_album; }
		}
    }
}
