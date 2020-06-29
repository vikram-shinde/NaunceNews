using NaunceNews.Core.Entities;
using NaunceNews.Publisher.Entities;
using System.Collections.Generic;
using System.Linq;

namespace NaunceNews.Publisher
{
    public static class PageProvider
    {
        public static List<Page> GetPages(List<News> news, List<Advertisement> ads)
        {
            var pages = new List<Page>();
            var highPriorityNewsChunks = news.Where(n => n.Priority == NewsPriority.High).ChunkBy(8).ToList();
            var restOfTheNews = news.Where(n => n.Priority != NewsPriority.High).ToList();

            foreach (var chunk in highPriorityNewsChunks)
            {
                var page = new Page() { News = chunk.ToList() };

                if (page.News.Count < 6)
                {
                    var restOfTheNewsToAdd = 6 - page.News.Count;
                    page.News.AddRange(restOfTheNews.Take(restOfTheNewsToAdd));
                    restOfTheNews.RemoveRange(0, restOfTheNewsToAdd > restOfTheNews.Count ? restOfTheNews.Count : restOfTheNewsToAdd);
                    page.Ads.AddRange(ads.Take(2));
                    ads.RemoveRange(0, 2);
                }
                else if (page.News.Count >= 6 && page.News.Count < 8)
                {
                    page.Ads.AddRange(ads.Take(8 - page.News.Count));
                    ads.RemoveRange(0, (8 - page.News.Count));
                }

                pages.Add(page);
            }

            foreach (var chunk in restOfTheNews.ChunkBy(6))
            {
                var page = new Page() { News = chunk.ToList(), Ads = ads.Take(2).ToList() };
                ads.RemoveRange(0, 2);
                pages.Add(page);
            }

            return pages;
        }
    }
}
