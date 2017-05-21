using System;

namespace Comics.Models
{
    public class Explosm : ComicWebsite
    {
        static string ExplosmName = "Explosm";
        static Uri ExplosmUri = new Uri("http://explosm.com");

        public Explosm() : base(ExplosmName, ExplosmUri)
        {

        }
    }
}
