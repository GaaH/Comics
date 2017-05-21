using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Comics.Models
{
    public class ComicWebsite
    {
        public string Name { get; }
        public Uri HomePageUri { get; }

        public ComicWebsite(string name, Uri homePageUri)
        {
            Name = name;
            HomePageUri = homePageUri;
        }
    }
}
