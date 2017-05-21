namespace Comics.Models
{
    public class PageLink
    {
        public ComicWebsite Comic { get; }
        public string PageKey { get; }

        public PageLink(ComicWebsite comic, string pageKey)
        {
            Comic = comic;
            PageKey = pageKey;
        }
    }
}
