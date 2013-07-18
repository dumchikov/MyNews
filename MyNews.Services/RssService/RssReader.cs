using System.Collections.Generic;
using System.ServiceModel.Syndication;
using System.Xml;

namespace MyNews.Services.RssService
{
    public class RssReader : IRssReader
    {
        // test: http://football.ua/rss2.ashx
        public IEnumerable<SyndicationItem> Read(string url)
        {
            var reader = XmlReader.Create(url);
            SyndicationFeed feed = SyndicationFeed.Load(reader);
            if (feed != null) return feed.Items;
            return new List<SyndicationItem>();
        }
    }    
}
