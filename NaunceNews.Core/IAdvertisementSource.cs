using NaunceNews.Core.Entities;
using System.Collections.Generic;

namespace NaunceNews.Core
{
    public interface IAdvertisementSource
    {
        List<Advertisement> GetAds();
    }
}
