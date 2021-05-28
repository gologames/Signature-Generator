using System;
using System.Threading;
using System.Diagnostics;

namespace Signature_Generator
{
    class ThreadBalancer
    {
        private const int THREAD_MEMORY_COEF = 10;
        private static long GetMemorySizeKB()
        {
            ProcessStartInfo info = new()
            {
                FileName = "wmic",
                Arguments = "OS get TotalVisibleMemorySize /Value",
                RedirectStandardOutput = true
            };
            using Process process = Process.Start(info);
            string output = process.StandardOutput.ReadToEnd().Trim();
            return int.Parse(output[(output.IndexOf('=') + 1)..]);
        }
        public static void SetupCountOfThreads(int blockSize, out int threadsCount)
        {
            long memorySize = GetMemorySizeKB() * 1024;
            int maxThreadsCount = (int)(memorySize / blockSize / THREAD_MEMORY_COEF);
            threadsCount = Math.Clamp(maxThreadsCount, 1, Environment.ProcessorCount);
        }

        public static void InitSemaphore(int threadsCount, out SemaphoreSlim semaphore)
        {
            semaphore = new(threadsCount, threadsCount);
        }
    }
}
