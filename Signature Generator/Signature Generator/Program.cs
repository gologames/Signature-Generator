using System;
using System.Threading;

namespace Signature_Generator
{
    class Program
    {
        static void Main(string[] args)
        {
            ExceptionsHandler.HandleAllExceptions();
            InputManager.ProcessInput(args, out string path, out int blockSize);
            ThreadBalancer.SetupCountOfThreads(blockSize, out int threadsCount);
            ThreadBalancer.InitSemaphore(threadsCount, out SemaphoreSlim semaphore);
            using Reader reader = new(path, blockSize, semaphore);
            Writer writer = new(Console.Out, threadsCount, semaphore);
            SignatureGenerator.GenerateSignature(reader, writer, threadsCount);
        }
    }
}
