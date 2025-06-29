using BenchmarkDotNet.Attributes;
using BinaryHeapTree;

[MemoryDiagnoser]
public class HeapTest
{
    class MinComparer : IComparer<int>
    {
        public int Compare(int a, int b)
        {
            return a.CompareTo(b);
        }
    }

    class MaxComparer : IComparer<int>
    {
        public int Compare(int a, int b)
        {
            return b.CompareTo(a);
        }
    }

    [Benchmark]
    public void Recursive()
    {
        List<int> list = [1, 7, 2, 8, 9, 5, 4, 3, 6];
        var array = Randomize(list.ToArray(), new Random(2));

        BinaryHeapTree<int>.HeapSortOptimal(array, new MaxComparer());
        
    }

    [Benchmark]
    public void NonRecursive()
    {
        List<int> list = [1, 7, 2, 8, 9, 5, 4, 3, 6];
        var array = Randomize(list.ToArray(), new Random(2));

        BinaryHeapNonRecursive<int>.HeapSortOptimal(array, new MaxComparer());

    }

    public static int[] Randomize(int[] list, Random rand)
    {
        int n = list.Length;
        while (n > 1)
        {
            int k = rand.Next(n--);
            int temp = list[n];
            list[n] = list[k];
            list[k] = temp;
        }
        return list;
    }
}