using System;

namespace Comics.Models
{
    public class Explosm : ComicWebsite
    {
        public static string ExplosmName = "Explosm";
        public static Uri ExplosmUri = new Uri("http://explosm.com");

        public Explosm() : base(ExplosmName, ExplosmUri)
        {

        }
    }
}
