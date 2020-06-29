using NaunceNews.Core.Entities;
using System.Collections.Generic;

namespace NaunceNews.Core
{
    public class NaunceAdvertisementSource : IAdvertisementSource
    {
        public List<Advertisement> GetAds()
        {
            return new List<Advertisement>()
            {
                new Advertisement{ Title = "NA: Advertisement Title 1", Description = "Advertisement Description 1"},
                new Advertisement{ Title = "NA: Advertisement Title 2", Description = "Advertisement Description 2"},
                new Advertisement{ Title = "NA: Advertisement Title 3", Description = "Advertisement Description 3"},
                new Advertisement{ Title = "NA: Advertisement Title 4", Description = "Advertisement Description 4"},
                new Advertisement{ Title = "NA: Advertisement Title 5", Description = "Advertisement Description 5"},
                new Advertisement{ Title = "NA: Advertisement Title 6", Description = "Advertisement Description 6"},
            };
        }
    }
}
