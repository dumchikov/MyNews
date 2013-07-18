using System.Collections.Generic;
using System.ServiceModel.Syndication;

namespace MyNews.Services.RssService
{
    interface IRssReader
    {
        IEnumerable<SyndicationItem> Read(string url);
    }
}
