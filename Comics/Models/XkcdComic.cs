using System;
using Windows.UI.Xaml.Media.Imaging;

namespace Comics.Models
{
    public class XkcdComic : Comic
    {
        public string Description { get; }

        public XkcdComic(ComicWebsite website, Uri uri, BitmapImage comicStrip, string description, Uri previousComic, Uri nextComic) : base(website, uri, comicStrip, previousComic, nextComic)
        {
            Description = description;
        }
    }
}
