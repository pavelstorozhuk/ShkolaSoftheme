using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using  System.IO;

namespace Task9_1
{
    static class FileOperations
    {
        public static FileHandle OpenForRead(string path)
        {
            var info = new FileInfo(path);


            return new FileHandle()
            {
                FileAccess = FileAccessEnum.OpenForRead,
                FileName = info.Name,
                FileSize = info.Length,
                Path = info.FullName
            };
        }
        public static FileHandle OpenForWrite(string path)
        {
            var info = new FileInfo(path);


            return new FileHandle()
            {
                FileAccess = FileAccessEnum.OpenForWrite,
                FileName = info.Name,
                FileSize = info.Length,
                Path = info.FullName
            };
        }

        public static FileHandle OpenFile(string path, FileAccessEnum access)
        {
            var info = new FileInfo(path);
            return new FileHandle()
            {
                FileAccess = access,
                FileName = info.Name,
                FileSize = info.Length,
                Path = info.FullName
            };
        }
    }
}
