namespace BinaryHeapTree
{
    public class BinaryHeapTree<T> where T : IComparable
    {
        public T[] minTree ;

        int Count { get; set; }

        //Constructor
        public BinaryHeapTree(int value)
        {
            minTree = new T [value]; 
            Count = 0;
        }
        public BinaryHeapTree(T[] array)
        {
            Count = array.Length;
            minTree = array;
            //only can call count/2 + 1 amount of times
            for(int i = 0; i < Count/2 + 1; i++) 
            {
               HeapifyUp(i);
               HeapifyDown(i);
            }
        }

        
        public void Insert(T value)
        {
            SizeUp();

            //Inserts at tracked empty Slot
            minTree[Count] = value;
            HeapifyUp(Count);
            //Increase Count because more values
            Count++;
        }

        public T Pop()
        {
            //store for return
            T removed = minTree[0];

            //swap
            minTree[0] = minTree[Count - 1];

            //adjust the amount of values and size down
            Count--;
            SizeDown();
            HeapifyDown(0);

            
            return removed;
        }

        //Made size change constructors for easier testing and to use my heap sort
        private void SizeUp()
        {
            if (Count == minTree.Length)
            {
                T[] temp = new T[minTree.Length * 2];
                minTree.CopyTo(temp, 0);
                minTree = temp;
            }
        
        }

        private void SizeDown()
        {
            if (Count < minTree.Length)
            {
                T[] newList = new T[Count];
                for (int i = 0; i < newList.Length; i++)
                {
                    newList[i] = minTree[i];
                }
                minTree = newList;
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
            if(index == 0 && Count == 0)
            {
                return;
            }
            //guessed the math
            int parent = (index - 1) / 2;
            if (index != 0 && minTree[index].CompareTo(minTree[parent]) < 0)
            {
                Swap(ref minTree[index], ref minTree[parent]);
                //running till case or first
                HeapifyUp(parent);
            }
            
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
            //checks that rightChild isn't greater than amount of Values and then which child is smaller
            if (rightChild < Count && minTree[rightChild].CompareTo(minTree[leftChild]) < 0)
            {
                //set smaller child to child
                child = rightChild;
            }
            else
            {
                child = leftChild;
            }

            //another base case to see whether it needs to move down further
            if (minTree[index].CompareTo(minTree[child]) > 0)
            {
                Swap(ref minTree[index], ref minTree[child]);
                //running till case or last
                HeapifyDown(child);
            }
          
        }

        public T[] HeapSort(T[] list)
        {
            BinaryHeapTree<T> sort = new BinaryHeapTree<T>(list.Length);
           
                //sorts into heap tree
              foreach(T val in list)
               {
                   sort.Insert(val);
               }
              //Pop all previous values till 0 remain
               for(int i = 0; sort.Count > 0; i++)
               {
                   list[i] = sort.Pop();
                }


            return list;
        }
    }
}
