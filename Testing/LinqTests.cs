using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Linq;
using AO.Linq.Extensions;

namespace Testing
{
    [TestClass]
    class LinqTests
    {
        [TestMethod]
        public void PaginateSimpleTest()
        {
            var intArray = Enumerable.Range(1, 100);
            var paged = intArray.Paginate(10);
            Assert.IsTrue(paged.All(grp => grp.Count() == 10));
        }

        [TestMethod]
        public void PaginateUnevenTest()
        {
            var intArray = Enumerable.Range(1, 99);
            var paged = intArray.Paginate(10);
            Assert.IsTrue(paged.Where(grp => grp.Key < 10).All(grp => grp.Count() == 10));
            Assert.IsTrue(paged.Where(grp => grp.Key == 10).All(grp => grp.Count() == 9));
        }

        [TestMethod]
        public void PaginateTestLessThanPageSize()
        {
            var intArray = Enumerable.Range(1, 4);
            var paged = intArray.Paginate(10);
            Assert.IsTrue(paged.Count == 1);
            Assert.IsTrue(paged.First().Count() == 4);
        }

        [TestMethod]
        public void PartitionSimpleTest()
        {
            var intArray = Enumerable.Range(1, 100);
            var partitioned = intArray.Partition(4);
            // even distribution is the easy case
            Assert.IsTrue(partitioned.All(p => p.Count() == 25));

            // this uneven case adds one to the last partition
            partitioned = intArray.Partition(3);
            Assert.IsTrue(partitioned.Count() == 3);
            Assert.IsTrue(partitioned[0].Count() == 33);
            Assert.IsTrue(partitioned[1].Count() == 33);
            Assert.IsTrue(partitioned[2].Count() == 34);

            // this will test a really arbitrary/uneven partition
            partitioned = intArray.Partition(7);
            var items = partitioned[4].Select(i => i).ToArray();
            var shouldBe = Enumerable.Range(57, 14).ToArray();
            Assert.IsTrue(items.SequenceEqual(shouldBe));
        }
    }
}
