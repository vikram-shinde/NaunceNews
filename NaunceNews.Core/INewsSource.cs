using NaunceNews.Core.Entities;
using System.Collections.Generic;

namespace NaunceNews.Core
{
    public interface INewsSource
    {
        List<News> GetNews(params NewsPriority[] priority);
    }
}
