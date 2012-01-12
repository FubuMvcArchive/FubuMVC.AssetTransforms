using System.Collections.Generic;
using FubuMVC.Core.Urls;
using HelloWorld.Less;
using HelloWorld.Sass;

namespace HelloWorld.Home
{
    public class HomeController
    {
        private readonly IUrlRegistry _urls;
        public HomeController(IUrlRegistry urls)
        {
            _urls = urls;
        }

        public HomeOutput Index(HomeIn homeIn)
        {
            var links = new List<Link>
            {
                new Link { Url = _urls.UrlFor<LessIn>(), Text = "Less" },
                new Link { Url = _urls.UrlFor<SassIn>(), Text = "Sass" }
            };

            return new HomeOutput { Links = links };
        }
    }

    public class HomeIn { }
    public class HomeOutput
    {
        public IEnumerable<Link> Links { get; set; }
    }

    public class Link
    {
        public string Url { get; set; }
        public string Text { get; set; }
    }
}