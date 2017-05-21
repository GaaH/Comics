using System;
using Windows.UI.Xaml.Media.Imaging;

namespace Comics.Models
{
    public class Comic
    {
        public ComicWebsite ComicWebsite { get; }
        public Uri ComicUri { get; }
        public BitmapImage ComicStrip { get; }
        public Uri NextComic { get; }
        public Uri PreviousComic { get; }

        public bool HasNextComic => NextComic != null;
        public bool HasPreviousComic => PreviousComic != null;

        public Comic(ComicWebsite website, Uri uri, BitmapImage comicStrip, Uri previousComic, Uri nextComic)
        {
            ComicWebsite = website;
            ComicUri = uri;
            ComicStrip = comicStrip;
            NextComic = nextComic;
            PreviousComic = previousComic;
        }
    }
}
