using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Running;
using BinaryHeapTree;

namespace HeapTreeBenchmark
{
    internal class Program
    {
        static void Main(string[] args)
        {
            BenchmarkRunner.Run<HeapTest>();
        }
    }
}
