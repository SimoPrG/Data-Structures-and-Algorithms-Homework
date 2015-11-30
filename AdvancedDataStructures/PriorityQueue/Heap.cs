namespace PriorityQueue
{
    using System;

    public class Heap<T> where T : IComparable<T>
    {
        private const int InitialCapacity = 16;

        private T[] elements;
        private readonly bool isMinHeap;

        public Heap(bool isMinHeap)
        {
            this.elements = new T[Heap<T>.InitialCapacity];
            this.isMinHeap = isMinHeap;
        }

        public int Count { get; private set; }
        
        public void Add(T element)
        {
            this.CheckCapacity();

            this.elements[this.Count] = element;

            this.ArrangeElementsOnAdd(this.Count);

            this.Count++;
        }

        public T First()
        {
            return this.elements[0];
        }

        public void DeleteFirst()
        {
            var swapper = this.elements[0];
            this.elements[0] = this.elements[--this.Count];
            this.elements[this.Count] = swapper;

            this.ArrangeElementsOnDelete(0);
        }

        private void ArrangeElementsOnAdd(int indexToCheck)
        {
            while (true)
            {
                int parentElement = (indexToCheck - 1) / 2;

                int comparison = this.elements[indexToCheck].CompareTo(this.elements[parentElement]);

                if (this.isMinHeap ? comparison >= 0 : comparison <= 0)
                {
                    return;
                }

                var swapper = this.elements[indexToCheck];
                this.elements[indexToCheck] = this.elements[parentElement];
                this.elements[parentElement] = swapper;

                indexToCheck = parentElement;
            }
        }

        private void ArrangeElementsOnDelete(int indexToCheck)
        {
            while (true)
            {
                int left = indexToCheck * 2 + 1;
                int right = left + 1;

                if (left >= this.Count)
                {
                    return;
                }

                int comparison = this.elements[indexToCheck].CompareTo(this.elements[left]);

                if (this.isMinHeap ? comparison > 0 : comparison < 0)
                {
                    var swapper = this.elements[indexToCheck];
                    this.elements[indexToCheck] = this.elements[left];
                    this.elements[left] = swapper;

                    indexToCheck = left;
                    continue;
                }

                if (right < this.Count)
                {
                    comparison = this.elements[indexToCheck].CompareTo(this.elements[right]);
                    if (this.isMinHeap ? comparison > 0 : comparison < 0)
                    {
                        var swapper = this.elements[indexToCheck];
                        this.elements[indexToCheck] = this.elements[right];
                        this.elements[right] = swapper;

                        indexToCheck = right;
                        continue;
                    }
                }

                break;
            }
        }

        private void CheckCapacity()
        {
            if (this.Count != this.elements.Length)
            {
                return;
            }

            var newElements = new T[this.elements.Length * 2];
            for (int i = 0; i < this.elements.Length; i++)
            {
                newElements[i] = this.elements[i];
            }

            this.elements = newElements;
        }

        public override string ToString()
        {
            return string.Join(", ", this.elements);
        }
    }
}
