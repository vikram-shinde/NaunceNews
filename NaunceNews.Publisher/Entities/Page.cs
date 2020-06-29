using NaunceNews.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NaunceNews.Publisher.Entities
{
    public class Page
    {
        public Page()
        {
            News = new List<News>();
            Ads = new List<Advertisement>();
        }

        public List<News> News { get; set; }
        public List<Advertisement> Ads { get; set; }
    }
}
