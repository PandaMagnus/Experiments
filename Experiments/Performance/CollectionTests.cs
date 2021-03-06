using System;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace Performance
{
    public class CollectionTests : TestBase
    {
        private readonly HashSet<object> _HashSet = new();
        private readonly HashSet<int> _PopulatedHashSet = new(new int[] { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 });
        //private object[] _Array = Array.Empty<object>();
        private readonly int[] _PopulatedArray = new int[] { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };
        private readonly List<object> _List = new();
        private readonly List<int> _PopulatedList = new() { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };
        private readonly Dictionary<int, int> _PopulatedDictionary = new() { { 0, 0 }, { 1, 1 }, { 2, 2 }, { 3, 3 }, { 4, 4 }, { 5, 5 }, { 6, 6 }, { 7, 7 }, { 8, 8 }, { 9, 9 }, { 10, 10 } };

        [Fact]
        public void Tuple()
        {

        }

        [Fact]
        public void TestAddToHashSet()
        {
            IterateOverAction(i => _HashSet.Add(i));
        }

        // This doesn't work for some reason. Seems like maybe a deadlock?
        // Investigate further.
        //[Fact]
        //public void TestAddToArray()
        //{
        //    IterateOverAction(AddToArray);

        //    void AddToArray(int i)
        //    {
        //        object[] temp = _Array;
        //        _Array = temp.Concat(new object[] { i }).ToArray();
        //    }
        //}

        [Fact]
        public void TestAddToList()
        {
            IterateOverAction(i => _List.Add(i));
        }

        [Fact]
        public void TestSearchThroughHashSet()
        {
            // So far, this is faster than FirstOrDefault calls, and List.BinarySearch.
            // Fetching by index on an array is faster, but that presumes we know the index.
            IterateOverAction(i => _PopulatedHashSet.TryGetValue(i, out _));
        }

        [Fact]
        public void TestSearchThroughArray()
        {
            IterateOverAction(i => _ = _PopulatedArray[i]);
        }

        [Fact]
        public void TestSearchThroughList()
        {
            IterateOverAction(i =>
            {
                int index = _PopulatedList.BinarySearch(i);
                _ = _PopulatedList[index];
            });
        }

        [Fact]
        public void TestSearchThroughDictionary()
        {
            IterateOverAction(i => _PopulatedDictionary.TryGetValue(i, out _));
        }

        [Fact]
        public void TestForEachLoopThroughHashSet()
        {
            IterateOverAction(i =>
            {
                foreach (int p in _PopulatedHashSet)
                {
                    System.Diagnostics.Debug.WriteLine(p.GetType());
                }
            });
        }

        [Fact]
        public void TestForLoopThroughHashSet()
        {
            IterateOverAction(i =>
            {
                for (int f = 0; f < _PopulatedHashSet.Count; f++)
                {
                    System.Diagnostics.Debug.WriteLine(_PopulatedHashSet.ElementAt(f).GetType());
                }
            });
        }

        [Fact]
        public void TestForEachLoopThroughArray()
        {
            IterateOverAction(i =>
            {
                foreach (int p in _PopulatedArray)
                {
                    System.Diagnostics.Debug.WriteLine(p.GetType());
                }
            });
        }

        [Fact]
        public void TestForLoopThroughArray()
        {
            IterateOverAction(i =>
            {
                for (int f = 0; f < _PopulatedArray.Length; f++)
                {
                    System.Diagnostics.Debug.WriteLine(_PopulatedArray[f].GetType());
                }
            });
        }

        [Fact]
        public void TestForEachLoopThroughList()
        {
            IterateOverAction(i =>
            {
                foreach (int p in _PopulatedList)
                {
                    System.Diagnostics.Debug.WriteLine(p.GetType());
                }
            });
        }

        [Fact]
        public void TestForLoopThroughList()
        {
            IterateOverAction(i =>
            {
                for (int f = 0; f < _PopulatedList.Count; f++)
                {
                    System.Diagnostics.Debug.WriteLine(_PopulatedList[f].GetType());
                }
            });
        }

        [Fact]
        public void TestForEachLoopThroughDict()
        {
            IterateOverAction(i =>
            {
                foreach (KeyValuePair<int, int> p in _PopulatedDictionary)
                {
                    System.Diagnostics.Debug.WriteLine(p.GetType());
                }
            });
        }

        [Fact]
        public void TestForLoopThroughDict()
        {
            IterateOverAction(i =>
            {
                for (int f = 0; f < _PopulatedDictionary.Count; f++)
                {
                    System.Diagnostics.Debug.WriteLine(_PopulatedDictionary[f].GetType());
                }
            });
        }
    }
}