using System;
using static System.Net.Mime.MediaTypeNames;

namespace BinaryHeapTree
{
    public class Program
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

        static void Main(string[] args)
        {
           
            List<int> list = [1,7,2,8,9,5,4,3,6];
            var array = list.ToArray();//Randomize(list.ToArray());
            BinaryHeapTree<int>.HeapSortOptimal(array,new MaxComparer());

            BinaryHeapTree<int> min = new BinaryHeapTree<int>(array, new MinComparer());

            //int[] array = new int[list.Count];
           // list.CopyTo(array, 0);
            BinaryHeapTree<int> max = new BinaryHeapTree<int>(list.ToArray(), new MaxComparer());

            for (int i = 0; i < min.tree.Count(); i++)
            {
                Console.Write(min.tree[i] + ", ");
            }
            Console.WriteLine();

            for (int i = 0; i < max.tree.Count(); i++)
            {
                Console.Write(max.tree[i] + ", ");
            }
            Console.WriteLine();

            /*array = Randomize(array);

            array = min.HeapSort(array);

            for (int i = 0; i < array.Length; i++)
            {
                Console.Write(array[i] + ", ");
            }
            Console.WriteLine();*/

        }

        public static int[] Randomize(int[] list)
        { 
            int n = list.Length;
            Random rand = new Random();
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
}
