using System;
using System.Threading;
using System.Security.Cryptography;

namespace Signature_Generator
{
    class SignatureGenerator
    {
        public static void GenerateSignature(Reader reader, Writer writer, int threadsCount)
        {
            for (int i = 0; i < threadsCount; i++) new Thread(Worker).Start();
            while (true)
            {
                DataBlock block = reader.GetNextBlock();
                if (block == null)
                {
                    TaskQueue.Done();
                    break;
                }
                TaskQueue.EnqueueTask(() => ProcessBlock(writer, block));
            }
        }

        private static void Worker()
        {
            while (true)
            {
                Action task = TaskQueue.DequeueTask();
                if (task == null) break;
                task();
            }
        }

        private static string DataToSignature(DataBlock block)
        {
            using SHA256 sha256 = SHA256.Create();
            byte[] hash = sha256.ComputeHash(block.Data, 0, block.Data.Length);
            return BitConverter.ToString(hash).Replace("-", "");
        }
        private static void ProcessBlock(Writer writer, DataBlock block)
        {
            string sha256 = DataToSignature(block);
            SignatureBlock signature = new() { Number = block.Number, Signature = sha256 };
            writer.WriteBlock(signature);
        }
    }
}
