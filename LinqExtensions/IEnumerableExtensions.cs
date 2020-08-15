using System.Collections.Generic;
using System.Linq;

namespace AO.Linq.Extensions
{
    public static class IEnumerableExtensions
    {
        public static ILookup<int, T> Paginate<T>(this IEnumerable<T> items, int itemsPerPage)
        {
            var paged = items.Select((item, index) => new
            {
                Item = item,
                Page = getPage(index + 1)
            });

            return paged.ToLookup(item => item.Page, item => item.Item);

            int getPage(int index)
            {
                int result = index / itemsPerPage;
                int leftover = (index % itemsPerPage > 0) ? 1 : 0;
                return result + leftover;
            }
        }

        public static ILookup<int, T> Partition<T>(this IEnumerable<T> items, int partitionCount)
        {
            int count = items.Count();
            int partitionaSize = count / partitionCount;

            // need to know if the partitions are unequal
            int padding = count % partitionaSize;
            bool isOdd = padding != 0;

            // for odd partitions, what is the center?
            int center = (partitionCount / 2) + 1;
                       
            // figure out the start and end of each partition (bucket)
            var partitions = Enumerable.Range(0, partitionCount).Select(p =>
            {
                int start = (p * partitionaSize) + 1;
                if ((p + 1 > center) && isOdd) start += padding;

                int end = (p + 1) * partitionaSize;                
                if ((p + 1 >= center) && isOdd) end += padding;                

                return new
                {
                    Index = p,
                    Range = Enumerable.Range(start, end - start + 1).ToArray()
                };
            })
            // flatten these ranges into a single sequence
            .SelectMany(partition => partition.Range, (partition, value) => new
            {
                Partition = partition.Index,
                Value = value
            })
            // key the partition values to each array index
            .ToDictionary(row => row.Value, row => row.Partition);

            // group all the items by their related partition
            return items.Select((item, index) => new
            {
                Item = item,
                Partition = partitions[index + 1]
            }).ToLookup(item => item.Partition, item => item.Item);
        }
    }
}
