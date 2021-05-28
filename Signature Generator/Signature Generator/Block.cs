namespace Signature_Generator
{
    class Block
    {
        public int Number { get; set; }
    }

    class DataBlock : Block
    {
        public byte[] Data { get; set; }
    }

    class SignatureBlock : Block
    {
        public string Signature { get; set; }
    }
}
