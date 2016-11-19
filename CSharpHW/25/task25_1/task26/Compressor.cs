using System;
using System.Threading.Tasks;
using System.IO;
using System.IO.Compression;


namespace task26
{
    internal class Compressor
    {
        private readonly string _path;


        public Compressor(string path)
        {
            _path = path;

        }

        public void Compress()
        {

            var directoryInfo = new DirectoryInfo(_path);
            CompressInDirectory(directoryInfo);

        }

        public void AsyncCompress()
        {
            var directoryInfo = new DirectoryInfo(_path);
            AsyncCompressInDirectory(directoryInfo);

        }

        private void CompressInDirectory(DirectoryInfo directoryInfo)
        {

            foreach (var file in directoryInfo.GetFiles())
            {
                CompressFile(file.FullName);
            }
            foreach (var directory in directoryInfo.GetDirectories())
            {
                CompressInDirectory(directory);
            }
        }

        private void AsyncCompressInDirectory(DirectoryInfo directoryInfo)
        {

            foreach (var file in directoryInfo.GetFiles())
            {

                Action<object> action = o => CompressFile(((FileInfo)o).FullName);
                var task = Task.Factory.StartNew(action, file);

            }
            foreach (var directory in directoryInfo.GetDirectories())
            {

                AsyncCompressInDirectory(directory);

            }
        }

        private void CompressFile(string path)
        {
            var source = File.OpenRead(path);
            var zipFullName = Path.GetDirectoryName(path) + @"/" +
                                          Path.GetFileNameWithoutExtension(path) + ".zip";
            if (File.Exists(zipFullName))
            {
                return;
            }
            var destination = File.Create(zipFullName);
            var compressor = new GZipStream(destination, CompressionMode.Compress);
            var theByte = source.ReadByte();
            while (theByte != -1)
            {
                compressor.WriteByte((byte)theByte);
                theByte = source.ReadByte();
            }
            compressor.Close();
            destination.Close();
        }


    }
}
