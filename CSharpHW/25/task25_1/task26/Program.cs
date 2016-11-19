using System;


namespace task26
{
    class Program
    {
       
        static void Main(string[] args)
        {
            var compressor = new Compressor(@"D:\test");
            compressor.AsyncCompress();
            Console.ReadKey();
        }
    }
}
