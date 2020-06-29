using NaunceNews.Core.Entities;
using System.Collections.Generic;

namespace NaunceNews.Core
{
    public class NaunceNewsSource : INewsSource
    {
        public List<News> GetNews(params NewsPriority[] priority)
        {
            return new List<News>()
            {
                new News{ Priority = NewsPriority.High, Title = "NN: Political News Title 1", Description = "Political News Description 1", Category = Category.Political },
                new News{ Priority = NewsPriority.Normal, Title = "NN: Political News Title 2", Description = "Political News Description 2", Category = Category.Political },
                new News{ Priority = NewsPriority.High, Title = "NN: Political News Title 3", Description = "Political News Description 3", Category = Category.Political },
                new News{ Priority = NewsPriority.Normal, Title = "NN: Sports News Title 1", Description = "Sports News Description 1", Category = Category.Sports },
                new News{ Priority = NewsPriority.High, Title = "NN: Sports News Title 2", Description = "Sports News Description 2", Category = Category.Sports },
                new News{ Priority = NewsPriority.Low, Title = "NN: Travel News Title 1", Description = "Travel News Description 1", Category = Category.Travel },
            };
        }
    }
}
