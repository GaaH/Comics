using System;

namespace Comics.Models
{
    public class ComicWebsite
    {
        public static readonly ComicWebsite Explosm = new ComicWebsite("Explosm", new Uri("http://explosm.com"));
        public static readonly ComicWebsite Xkcd = new ComicWebsite("Xkcd", new Uri("https://www.xkcd.com"));


        public string Name { get; }
        public Uri HomePageUri { get; }

        private ComicWebsite(string name, Uri homePageUri)
        {
            Name = name;
            HomePageUri = homePageUri;
        }
    }
}
