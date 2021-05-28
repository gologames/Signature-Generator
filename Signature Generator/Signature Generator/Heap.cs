using System;

namespace Signature_Generator
{
    class Heap
    {
        private int size;
        private readonly SignatureBlock[] heap;

        public Heap(int maxSize)
        {
            heap = new SignatureBlock[maxSize];
        }

        public bool IsEmpty()
        {
            return size == 0;
        }
        public SignatureBlock Peek()
        {
            if (IsEmpty()) throw new InvalidOperationException(nameof(Peek));
            return heap[0];
        }

        public void Extract()
        {
            if (IsEmpty()) throw new InvalidOperationException(nameof(Extract));
            heap[0] = heap[size-- - 1];
            int i = 0;
            while (2 * i + 1 < size)
            {
                int left = 2 * i + 1;
                int right = 2 * i + 2;
                int j = left;
                if (right < size && heap[right].Number < heap[left].Number)
                {
                    j = right;
                }
                if (heap[i].Number <= heap[j].Number) break;
                SignatureBlock temp = heap[i];
                heap[i] = heap[j];
                heap[j] = temp;
                i = j;
            }
        }

        public void Add(SignatureBlock block)
        {
            if (size == heap.Length) throw new InvalidOperationException(nameof(Add));
            heap[size++] = block;
            int i = size - 1;
            while (heap[i].Number < heap[(i - 1) / 2].Number)
            {
                SignatureBlock temp = heap[i];
                int j = (i - 1) / 2;
                heap[i] = heap[j];
                heap[j] = temp;
                i = j;
            }
        }
    }
}
