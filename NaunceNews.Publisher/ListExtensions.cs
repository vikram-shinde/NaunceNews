using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NaunceNews.Publisher
{
    public static class ListExtensions
    {
        public static IEnumerable<IEnumerable<TSource>> ChunkBy<TSource>(this IEnumerable<TSource> source, int chunkSize)
        {
            while (source.Any())
            {
                yield return source.Take(chunkSize); // return a chunk of chunkSize
                source = source.Skip(chunkSize);     // skip the returned chunk
            }
        }
    }
}
