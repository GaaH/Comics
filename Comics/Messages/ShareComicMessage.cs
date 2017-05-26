using Comics.Models;

namespace Comics.Messages
{
    public class ShareComicMessage
    {
        public Comic Comic { get; }

        public ShareComicMessage(Comic comic)
        {
            Comic = comic;
        }
    }
}
