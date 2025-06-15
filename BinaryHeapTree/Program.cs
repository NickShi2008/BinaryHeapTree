using System;
using static System.Net.Mime.MediaTypeNames;

namespace BinaryHeapTree
{
    public class Program
    {
         static void Main(string[] args)
        {
           
            List<int> list = [9,8,7,6,5,4,3,2,1];
            BinaryHeapTree<int> min = new BinaryHeapTree<int>(list.ToArray());
            int[] array = new int[list.Count];
            list.CopyTo(array, 0);
           
           
            min.Pop();
            for (int i = 0; i < min.minTree.Length; i++)
            {
                Console.Write(min.minTree[i] + ", ");
            }
            Console.WriteLine();

            array = Randomize(array);

            array = min.HeapSort(array);

            for (int i = 0; i < array.Length; i++)
            {
                Console.Write(array[i] + ", ");
            }
            Console.WriteLine();

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
