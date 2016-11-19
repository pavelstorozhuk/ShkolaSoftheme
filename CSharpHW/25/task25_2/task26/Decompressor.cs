using System;
using System.Threading.Tasks;
using System.IO;
using System.IO.Compression;


namespace task26
{
    internal class Decompressor
    {
        private readonly string _path;

        public Decompressor(string path)
        {
            _path = path;

        }

        public void Decompress()
        {

            var directoryInfo = new DirectoryInfo(_path);
            DecompressInDirectory(directoryInfo);
        }

        public void AsyncDecompress()
        {
            var directoryInfo = new DirectoryInfo(_path);
            AsyncDecompressInDirectory(directoryInfo);

        }

        private void DecompressInDirectory(DirectoryInfo directoryInfo)
        {

            foreach (var file in directoryInfo.GetFiles("*.zip"))
            {
                DecompressFile(file.FullName);
            }
            foreach (var directory in directoryInfo.GetDirectories())
            {
                DecompressInDirectory(directory);
            }
        }

        private void AsyncDecompressInDirectory(DirectoryInfo directoryInfo)
        {

            foreach (var file in directoryInfo.GetFiles("*.zip"))
            {

                Action<object> action = o => DecompressFile(((FileInfo)o).FullName);
                var task = Task.Factory.StartNew(action, file);

            }
            foreach (var directory in directoryInfo.GetDirectories())
            {

                AsyncDecompressInDirectory(directory);

            }
        }

        private void DecompressFile(string path)
        {
            var source = File.OpenRead(path);
            var unZipFullName = Path.GetDirectoryName(path) + @"/" +
                                          Path.GetFileNameWithoutExtension(path)+".txt";
            if (File.Exists(unZipFullName))
            {
                return;
            }
            var destination = File.Create(unZipFullName);
            var deCompressor = new GZipStream(source, CompressionMode.Decompress);
            var theByte = deCompressor.ReadByte();
            while (theByte != -1)
            {
                destination.WriteByte((byte)theByte);
                theByte = deCompressor.ReadByte();
            } 
            deCompressor.Close();
            destination.Close();
        }
    }
}
