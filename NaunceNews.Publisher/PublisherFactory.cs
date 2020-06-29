using NaunceNews.Core;
using NaunceNews.Publisher.Sources;
using System.Collections.Generic;

namespace NaunceNews.Publisher
{
    public class PublisherFactory : IPublisherFactory
    {
        public List<IAdvertisementSource> GetAdvertisementSources()
        {
            return new List<IAdvertisementSource>()
            {
                new NaunceAdvertisementSource(),
                new GoogleAdvertisementSource(),
                new FacebookAdvertisementSource()
            };
        }

        public List<INewsSource> GetNewsSources()
        {
            return new List<INewsSource>()
            {
                new NaunceNewsSource(),
                //new GoogleNewsSource(),
                //new BBCNewsSource()
            };
        }
    }
}