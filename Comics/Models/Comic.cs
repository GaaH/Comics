using System;
using Windows.UI.Xaml.Media.Imaging;

namespace Comics.Models
{
    public class Comic
    {
        public ComicWebsite ComicWebsite { get; }
        public Uri ComicUri { get; }
        public BitmapImage ComicStrip { get; }

        public Comic(ComicWebsite website, Uri uri, BitmapImage comicStrip)
        {
            ComicWebsite = website;
            ComicUri = uri;
            ComicStrip = comicStrip;
        }
    }
}
