using System;
using System.ServiceModel.Syndication;

namespace MyNews.Models
{
    public class NewsItem
    {
        public NewsItem()
        {
        }

        public NewsItem(SyndicationItem item)
        {
            Title = item.Title.Text;
            Link = item.Links[0].Uri.AbsoluteUri;
            PublishDate = item.PublishDate.DateTime;
            Description = item.Summary.Text;
            var links = item.Links;
            if (links.Count >= 2)
            {
                ImageUrl = links[1].Uri.AbsoluteUri;
            }
            
        }
        public string Title { get; set; }

        public string Description { get; set; }

        public string Link { get; set; }

        public DateTime PublishDate { get; set; }

        public string ImageUrl { get; set; }
    }
}