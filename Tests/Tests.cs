using Microsoft.VisualStudio.TestTools.UnitTesting;
using Algor;
using System.Collections.Generic;
using System.Linq;

namespace Tests
{
    [TestClass]
    public class Tests
    {
        [TestMethod]
        public void SortTest()
        {
            var actual = new List<(int, int)>()
            {
                (1,3),
                (4,5),
                (2,9),
                (4, 8),
                (6, 9),
                (2, 5),
                (4,7)
            };
            Program.MySort(actual);

            var expected = new List<(int, int)>()
            {
                (1,3),
                (2,5),
                (2,9),
                (4,5),
                (4,7),
                (4,8),
                (6,9)
            };

            Assert.IsTrue(actual.SequenceEqual(expected));
        }

        [TestMethod]
        public void ArgsTest()
        {
            var args = new string[]
            {
                "3",
                "2 4",
                "5 6",
                "3 5"
            };
            var expected = new List<(int, int)>()
            
            {
                (2,4),
                (5,6),
                (3,5)
            };

            var actual = Program.HandleArgs(args);

            Assert.IsTrue(actual.Item2.SequenceEqual(expected));
        }

        [TestMethod]
        public void CalculateTest()
        {
            var args = new string[]
            {
                "4",
                "4 7",
                "1 3",
                "2 5",
                "5 6"
            };

            var parsed = Program.HandleArgs(args);
            Program.MySort(parsed.Item2);

            var expected = 2;

            var actual = Program.Calculate(parsed.Item2);

            Assert.AreEqual(expected, actual.Count);

        }
    }
}
