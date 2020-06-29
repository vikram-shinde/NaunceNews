using NaunceNews.Core.Entities;
using NaunceNews.Publisher.Entities;
using System.Collections.Generic;
using System.Linq;

//assumptions are 
//all the news from all the sources are fetched
//call to getAd returns only 2 ads without fail.

namespace NaunceNews.Publisher
{
    public class Publisher
    {
        private readonly IPublisherFactory factory;
        public Publisher(IPublisherFactory publisherFactory) => this.factory = publisherFactory;

        public List<Page> Publish()
        {
            var news = new List<News>();
            var newsSources = factory.GetNewsSources();
            foreach (var newSource in newsSources)
                news.AddRange(newSource.GetNews(NewsPriority.All));

            var ads = new List<Advertisement>();
            var adSources = factory.GetAdvertisementSources();
            foreach (var adSource in adSources)
                ads.AddRange(adSource.GetAds());

            return PageProvider.GetPages(news, ads);
        }
    }
}
