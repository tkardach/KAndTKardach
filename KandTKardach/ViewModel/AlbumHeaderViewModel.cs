using KandTKardach.Models;

namespace KandTKardach.ViewModel
{
    public class AlbumHeaderViewModel
    {
        public AlbumHeaderViewModel(Album album, string quote1, string quote2)
        {
            m_album = album;
            m_quote1 = quote1;
            m_quote2 = quote2;
        }

        protected Album m_album;
        public Album Album
        {
            get { return m_album; }
        }

        protected string m_quote1;
        public string TopQuote
        {
            get { return m_quote1; }
        }

        protected string m_quote2;
        public string BottomQuote
        {
            get { return m_quote2; }
        }
    }
}