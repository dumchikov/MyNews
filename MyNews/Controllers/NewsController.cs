using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using MyNews.Models;
using MyNews.Services.RssService;

namespace MyNews.Controllers
{
    public class NewsController : Controller
    {
        private readonly RssReader _reader;

        private static readonly ICollection<RssSource> _newsSources = new List<RssSource>
            {
                new RssSource{ Id=1,Name = "Football.ua", Url = "http://football.ua/rss2.ashx" },
                new RssSource{ Id = 2, Name = "iSport", Url="http://isport.ua/hnd/rss.ashx?image=1" },
                new RssSource{ Id=3, Name="Liga", Url = "http://news.liga.net/all/rss.xml" }
            };

        public NewsController()
        {
            this._reader = new RssReader();
        }


        public ActionResult Index(int? id)
        {
            if (!id.HasValue || id == 0)
            {
                id = 1;
            }

            var source = _newsSources.Single(x => x.Id == id);
            var news = _reader.Read(source.Url).Select(x => new NewsItem(x));
            news = news.OrderByDescending(x => x.PublishDate).ToList();

            var model = new NewsPageModel(_newsSources, id.Value)
                {
                    NewsItems = news,
                    SourceName = source.Name
                };

            return View(model);
        }

        public ActionResult Create()
        {
            ViewBag.Sources = _newsSources;
            return this.View(new RssSource());
        }

        [HttpPost]
        public ActionResult Create(RssSource model)
        {
            _newsSources.Add(model);
            return RedirectToAction("Create");
        }
    }
}
