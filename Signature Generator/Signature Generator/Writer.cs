using System.IO;
using System.Threading;

namespace Signature_Generator
{
    class Writer
    {
        private readonly TextWriter output;
        private readonly Heap heap;
        private int blockNumber;
        private readonly SemaphoreSlim semaphore;

        public Writer(TextWriter output, int bufferSize, SemaphoreSlim semaphore)
        {
            this.output = output;
            heap = new Heap(bufferSize);
            this.semaphore = semaphore;
        }

        public void WriteBlock(SignatureBlock block)
        {
            lock (heap)
            {
                heap.Add(block);
                while (!heap.IsEmpty())
                {
                    SignatureBlock currentBlock = heap.Peek();
                    if (currentBlock.Number != blockNumber) break;
                    blockNumber++;
                    output.WriteLine($"{currentBlock.Number} - {currentBlock.Signature}");
                    heap.Extract();
                    semaphore.Release();
                }
            }
        }
    }
}
