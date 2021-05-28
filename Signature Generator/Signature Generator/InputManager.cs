using System;

namespace Signature_Generator
{
    class InputManager
    {
        public static void ProcessInput(string[] args, out string path, out int blockSize)
        {
            if (args == null) throw new ArgumentNullException(nameof(args));
            if (args.Length != 2) throw new ArgumentException("Incorrect count of command line arguments", nameof(args));
            path = args[0];
            blockSize = int.Parse(args[1]);
            if (blockSize <= 0) throw new ArgumentException("Block size should be greater than zero", nameof(blockSize));
        }
    }
}
