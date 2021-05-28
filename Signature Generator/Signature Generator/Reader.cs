using System;
using System.IO;
using System.Threading;

namespace Signature_Generator
{
    class Reader : IDisposable
    {
        private readonly FileStream fs;
        private int blockNumber;
        private readonly int blockSize;
        private readonly SemaphoreSlim semaphore;
        
        public Reader(string path, int blockSize, SemaphoreSlim semaphore)
        {
            fs = new FileStream(path, FileMode.Open);
            this.blockSize = blockSize;
            this.semaphore = semaphore;
        }

        public DataBlock GetNextBlock()
        {
            semaphore.Wait();
            byte[] data = new byte[blockSize];
            int size = fs.Read(data, 0, blockSize);
            if (size == 0) return null;
            if (size != blockSize) Array.Resize(ref data, size);
            return new DataBlock() { Number = blockNumber++, Data = data };
        }
        public void Dispose()
        {
            fs.Close();
        }
    }
}
