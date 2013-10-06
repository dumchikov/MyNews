using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

namespace MyNews.Models
{
    public class NewsPageModel
    {
        public NewsPageModel(IEnumerable<RssSource> sources, int id)
        {
            this.Sources = sources.Select(x => new SelectListItem
                        {
                            Text = x.Name, 
                            Value = x.Id.ToString(),
                            Selected = x.Id == id
                        }).ToList();
        }

        public string SourceName { get; set; }

        public IEnumerable<NewsItem> NewsItems { get; set; }

        public IEnumerable<SelectListItem> Sources { get; set; } 
    }
}