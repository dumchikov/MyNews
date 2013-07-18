using System;
using System.Linq;
using System.Web.Mvc;
using MyNews.Models;
using MyNews.Services.RssService;

namespace MyNews.Controllers
{
    public class NewsController : Controller
    {
        public ActionResult Index()
        {
            var reader = new RssReader();
            var footballUa = reader.Read("http://football.ua/rss2.ashx").Select(x => new NewsItem(x));
            var iSport = reader.Read("http://isport.ua/hnd/rss.ashx?image=1").Select(x => new NewsItem(x));
            var ligaSport = reader.Read("http://news.liga.net/all/rss.xml").Select(x => new NewsItem(x));
        
            

            var bullNews = new NewsItem
                {
                    Title = "Бык has been detected.",
                    ImageUrl = "http://cs304900.vk.me/v304900749/47f5/E4aGelOC8OQ.jpg",
                    Description =
                        "Задеражан особо опасный пикапер Влад Фесьман по кличке 'Бык'. На счету 'быка' неоднократные попытки(подчёркиваем 'попытки') покушения на честь девушек разных слоёв населения.",
                    Link = "http://dojki.com",
                    PublishDate = DateTime.Now
                };

            var list = footballUa.Concat(iSport).Concat(ligaSport).ToList();
            list.Add(bullNews);
            list = list.OrderByDescending(x => x.PublishDate).ToList();
        
            return View(list);
        }
    }
}
