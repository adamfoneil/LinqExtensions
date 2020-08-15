[![Build status](https://ci.appveyor.com/api/projects/status/j93j0km26ty53d34?svg=true)](https://ci.appveyor.com/project/adamosoftware/linqextensions)
[![Nuget](https://img.shields.io/nuget/v/AO.Linq.Extensions)](https://www.nuget.org/packages/AO.Linq.Extensions/)

I'm certain there are many full-featured and excellent Linq extension libraries out there. In fact [morelinq](https://www.nuget.org/packages/morelinq) comes to mind, though I haven't actually used it. As usual, this is something I simply enjoy working on, and wanted more practice setting up builds in AppVeyor.

# AO.Linq.Extensions.IEnumerableExtensions [IEnumerableExtensions.cs](https://github.com/adamfoneil/LinqExtensions/blob/master/LinqExtensions/IEnumerableExtensions.cs#L6)
## Methods
- ILookup\<int, T\> [Paginate](https://github.com/adamfoneil/LinqExtensions/blob/master/LinqExtensions/IEnumerableExtensions.cs#L8)
 (this IEnumerable<T> items, int itemsPerPage) Splits a list into equal-sized "pages", maintinaing original item order. The last page can be shorter than the rest.
- ILookup\<int, T\> [Partition](https://github.com/adamfoneil/LinqExtensions/blob/master/LinqExtensions/IEnumerableExtensions.cs#L26)
 (this IEnumerable<T> items, int partitionCount) Splits a list into a fixed number of shorter lists of mostly equal length. Odd partitions will pad the "center" partition.

I went looking for better or compelling `Paginate` implementations, and this [SO answer](https://stackoverflow.com/a/3382769/2023653) is probably my favorite. I found another very similar approach used [here](https://www.davidboike.dev/2010/08/batch-or-partition-a-collection-with-linq/). My approach uses modulus, and for whatever reason I like using `ILookup` as the result.

The `Partition` method has stumped me in the past, and I wanted to write my own version of it.
