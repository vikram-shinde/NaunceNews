using NaunceNews.Core;
using NaunceNews.Core.Entities;
using System.Collections.Generic;

namespace NaunceNews.Publisher.Sources
{
    public class FacebookAdvertisementSource : IAdvertisementSource
    {
        public List<Advertisement> GetAds()
        {
            return new List<Advertisement>()
            {
                new Advertisement{ Title = "FB: Advertisement Title 1", Description = "Advertisement Description 1"},
                new Advertisement{ Title = "FB: Advertisement Title 2", Description = "Advertisement Description 2"},
                new Advertisement{ Title = "FB: Advertisement Title 3", Description = "Advertisement Description 3"},
                new Advertisement{ Title = "FB: Advertisement Title 4", Description = "Advertisement Description 4"},
                new Advertisement{ Title = "FB: Advertisement Title 5", Description = "Advertisement Description 5"},
                new Advertisement{ Title = "FB: Advertisement Title 6", Description = "Advertisement Description 6"},
            };
        }
    }
}
