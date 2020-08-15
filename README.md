[![Build status](https://ci.appveyor.com/api/projects/status/j93j0km26ty53d34?svg=true)](https://ci.appveyor.com/project/adamosoftware/linqextensions)
[![Nuget](https://img.shields.io/nuget/v/AO.Linq.Extensions)](https://www.nuget.org/packages/AO.Linq.Extensions/)

I'm certain there are many full-featured and excellent Linq extension libraries out there. In fact [morelinq](https://www.nuget.org/packages/morelinq) comes to mind. As usual, this is something I simply enjoy working on, and wanted more practice setting up builds in AppVeyor.

# AO.Linq.Extensions.IEnumerableExtensions [IEnumerableExtensions.cs](https://github.com/adamfoneil/LinqExtensions/blob/master/LinqExtensions/IEnumerableExtensions.cs#L6)
## Methods
- ILookup\<int, T\> [Paginate](https://github.com/adamfoneil/LinqExtensions/blob/master/LinqExtensions/IEnumerableExtensions.cs#L8)
 (this IEnumerable<T> items, int itemsPerPage)
- ILookup\<int, T\> [Partition](https://github.com/adamfoneil/LinqExtensions/blob/master/LinqExtensions/IEnumerableExtensions.cs#L26)
 (this IEnumerable<T> items, int partitionCount)
