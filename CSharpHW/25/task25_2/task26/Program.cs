using System;


namespace task26
{
    class Program
    {
       
        static void Main(string[] args)
        {
            var compressor = new Decompressor(@"D:\test");
            compressor.Decompress();
            Console.ReadKey();
        }
    }
}
