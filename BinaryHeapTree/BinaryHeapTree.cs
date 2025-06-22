using System.Xml.Schema;

namespace BinaryHeapTree
{
    public class BinaryHeapTree<T>
    {
        public T[] tree;

        public int Count { get; private set; }

        public IComparer<T> Comparer { get; private set; }

        //Constructor
        public BinaryHeapTree(IComparer<T> comparer)
        {
            Comparer = comparer;
            Count = 0;
        }
        public BinaryHeapTree(T[] array, IComparer<T> comparer)
        {
            Comparer = comparer;
            Count = array.Length;
            tree = array;
            //only can call count/2 + 1 amount of times
            int runTimes = (array.Length + 1) / 2;
            for (int i = Count - 1; i >= runTimes; i--)
            {
                HeapifyUp(i);
            }
            ;
            //only works if heapify up continues to check upwards instead of stopping at parent value
        }


        public void Insert(T value)
        {
            SizeUp();

            //Inserts at tracked empty Slot
            tree[Count] = value;
            HeapifyUp(Count);
            //Increase Count because more values
            Count++;
        }

        public T Pop()
        {
            //store for return
            T removed = tree[0];

            //swap
            tree[0] = tree[Count - 1];

            //adjust the amount of values and size down
            Count--;
            //SizeDown();
            HeapifyDown(0);


            return removed;
        }

        //Made size change constructors for easier testing and to use my heap sort
        private void SizeUp()
        {
            if (Count == tree.Length)
            {
                T[] temp = new T[tree.Length * 2];
                tree.CopyTo(temp, 0);
                tree = temp;
            }

        }

        private void SizeDown()
        {
            if (Count < tree.Length)
            {
                T[] newList = new T[Count];
                for (int i = 0; i < newList.Length; i++)
                {
                    newList[i] = tree[i];
                }
                tree = newList;
            }
        }

        //didn't want to repeat
        private static void Swap<T>(ref T first, ref T second)
        {
            T temp = first;
            first = second;
            second = temp;
        }

        //recursive
        public void HeapifyUp(int index)
        {
            //base case
            if (index == 0 || Count == 0)
            {
                return;
            }
            //guessed the math
            int parent = (index - 1) / 2;
            //changed for new way heap sort

            if (Comparer.Compare(tree[index], tree[parent]) < 0)
            {
                Swap(ref tree[index], ref tree[parent]);
            }

            HeapifyUp(parent);

        }

        public void HeapifyDown(int index)
        {
            //base case

            int leftChild = index * 2 + 1;
            int rightChild = index * 2 + 2;
            int child;
            //checks if is at leaf
            if (leftChild >= Count)
            {
                return;
            }
            else if (rightChild >= Count)
            {
                child = leftChild;
            }
            //checks that rightChild isn't greater than amount of Values and then which child is smaller
            else if (Comparer.Compare(tree[rightChild], tree[leftChild]) < 0)
            {
                //set smaller child to child
                child = rightChild;
            }
            else
            {
                child = leftChild;
            }

            //another base case to see whether it needs to move down further
            if (Comparer.Compare(tree[index], tree[child]) > 0)
            {
                Swap(ref tree[index], ref tree[child]);
                //running till case or last

            }
            HeapifyDown(child);
        }

        public T[] HeapSort(T[] array)
        {
            BinaryHeapTree<T> sort = new BinaryHeapTree<T>(array, Comparer);

            //sorts into heap tree
            foreach (T val in array)
            {
                sort.Insert(val);
            }
            //Pop all previous values till 0 remain
            for (int i = 0; sort.Count > 0; i++)
            {
                array[i] = sort.Pop();
            }


            return array;
        }

        //try to make heapsort without new array
        //max better
        public static T[] HeapSortOptimal(T[] list, IComparer<T> maxComparer)
        {
            T[] arr = new T[list.Length];
            for(int i = 0; i < list.Length; i++)
            {
                arr[i] = list[i];
            }
            ;
            BinaryHeapTree<T> maxTree = new BinaryHeapTree<T>(list, maxComparer);
            ;
            for (int i = list.Length - 1; i >= 0; i--)
            {
                list[i] = maxTree.Pop();
            }
            return list;
        }
    }
}
