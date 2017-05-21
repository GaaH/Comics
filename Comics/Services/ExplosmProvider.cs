using Comics.Models;
using HtmlAgilityPack;
using System;
using System.Linq;
using System.Threading.Tasks;
using Windows.UI.Xaml.Media.Imaging;

namespace Comics.Services
{
    public class ExplosmProvider : IComicProvider
    {
        public async Task<Comic> LoadLatestComicAsync()
        {
            return await LoadComicAsync(new Uri(Explosm.ExplosmUri, "comics/latest"));
        }

        public async Task<Comic> LoadOldestComicAsync()
        {
            return await LoadComicAsync(new Uri(Explosm.ExplosmUri, "comics/oldest"));
        }

        public async Task<Comic> LoadComicAsync(Uri uri)
        {
            var web = new HtmlWeb();
            var html = await web.LoadFromWebAsync(uri.AbsoluteUri);
            var doc = html.DocumentNode;

            var imgNode = GetComicStripNode(doc);
            var (previousUri, nextUri) = FindPreviousAndNextComicUri(doc);

            var imgSrc = new Uri($"http:{imgNode.Attributes["src"].Value}");
            var comicStrip = new BitmapImage(imgSrc);

            return new Comic(new Explosm(), uri, comicStrip, previousUri, nextUri);
        }

        private HtmlNode GetComicStripNode(HtmlNode doc)
        {
            return doc.Descendants("img")
                    .First((node) => node.Id.Contains("main-comic"));
        }

        private (Uri previous, Uri next) FindPreviousAndNextComicUri(HtmlNode doc)
        {
            var previous = FindNode(doc, "a", "previous-comic")?.Attributes["href"].Value;
            var next = FindNode(doc, "a", "next-comic")?.Attributes["href"].Value;

            var previousUri = previous == null ? null : new Uri($"http://explosm.com{previous}");
            var nextUri = next == null ? null : new Uri($"http://explosm.com{next}");

            return (previousUri, nextUri);
        }

        private HtmlNode FindNode(HtmlNode doc, string htmlTag, string htmlClass)
        {
            bool IsValidNode(HtmlNode n) => n.Attributes.Contains("class") && n.Attributes["class"].Value.Contains(htmlClass) && !n.Attributes["class"].Value.Contains("disabled");

            var node =
                doc.Descendants(htmlTag)
                .FirstOrDefault(IsValidNode);
            return node;
        }
    }
}
