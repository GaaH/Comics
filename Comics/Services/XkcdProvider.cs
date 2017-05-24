using Comics.Models;
using HtmlAgilityPack;
using System;
using System.Linq;
using System.Threading.Tasks;
using Windows.UI.Xaml.Media.Imaging;

namespace Comics.Services
{
    public class XkcdProvider : IComicProvider
    {
        public async Task<Comic> LoadLatestComicAsync()
        {
            return await LoadComicAsync(ComicWebsite.Xkcd.HomePageUri);
        }

        public async Task<Comic> LoadOldestComicAsync()
        {
            return await LoadComicAsync(new Uri(ComicWebsite.Xkcd.HomePageUri, "1"));
        }

        public async Task<Comic> LoadComicAsync(Uri uri)
        {
            var web = new HtmlWeb();
            var html = await web.LoadFromWebAsync(uri.AbsoluteUri);
            var doc = html.DocumentNode;

            var imgNode = GetComicStripNode(doc);
            var (previousUri, nextUri) = FindPreviousAndNextComicUri(doc);

            var imgSrc = new Uri($"http:{imgNode.Attributes["src"].Value}");
            var imgTitle = System.Net.WebUtility.HtmlDecode(imgNode.Attributes["title"].Value);
            var comicStrip = new BitmapImage(imgSrc);

            return new XkcdComic(ComicWebsite.Explosm, uri, comicStrip, imgTitle, previousUri, nextUri);
        }

        private HtmlNode GetComicStripNode(HtmlNode doc)
        {
            return doc.Descendants("div")
                    .Single((node) => node.Id == "comic")
                    .Element("img");
        }

        private (Uri previous, Uri next) FindPreviousAndNextComicUri(HtmlNode doc)
        {
            var navigationListNode = doc.Descendants("ul").First(n => n.Attributes.Contains("class") && n.Attributes["class"].Value == "comicNav");
            var previous = FindNode(navigationListNode, "a", "Prev")?.Attributes["href"].Value;
            var next = FindNode(navigationListNode, "a", "Next")?.Attributes["href"].Value;

            var previousUri = previous == null ? null : new Uri(ComicWebsite.Xkcd.HomePageUri, previous);
            var nextUri = next == null ? null : new Uri(ComicWebsite.Xkcd.HomePageUri, next);

            return (previousUri, nextUri);
        }

        private HtmlNode FindNode(HtmlNode doc, string htmlTag, string content)
        {
            bool IsValidNode(HtmlNode n) => n.InnerText.Contains(content) && n.Attributes.Contains("href") && n.Attributes["href"].Value != "#";

            var node =
                doc.Descendants(htmlTag)
                .FirstOrDefault(IsValidNode);
            return node;
        }
    }
}
