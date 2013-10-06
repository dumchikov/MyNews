using System.ComponentModel.DataAnnotations;

namespace MyNews.Models
{
    public class RssSource
    {
        public int Id { get; set; }

        [Display(Name = "Имя")]
        public string Name { get; set; }

        [Display(Name = "Адрес")]
        public string Url { get; set; }
    }
}