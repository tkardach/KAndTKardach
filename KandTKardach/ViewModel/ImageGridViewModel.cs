using System;
using KandTKardach.Models;

namespace KandTKardach.ViewModel
{
    public class ImageGridViewModel
    {      
        public ImageGridViewModel()
        {
        }


    
        protected Album m_album;
        public Album Album
        {
			get { return m_album; }
			set { m_album = value; }
		}
	}
}
