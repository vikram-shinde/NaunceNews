using NaunceNews.Core;
using System.Collections.Generic;

namespace NaunceNews.Publisher
{
    public interface IPublisherFactory
    {
        List<INewsSource> GetNewsSources();

        List<IAdvertisementSource> GetAdvertisementSources();
    }
}