using System;
using System.IO;
using System.Threading.Tasks;

namespace task26_1
{
    internal class FilesEditor:IDisposable
    {
        private readonly string _path;
        private readonly string _extension;
        private static FileStream _stream;
        private static  StreamWriter _streamWriter;
        private string _text;
        private string _replaceText;
       
     
        public FilesEditor(string path, string extention)
        {
            _path = path;
            _extension = extention;
            if (!File.Exists("log.txt"))
            {
                File.Create("log.txt");
            }

            _stream = new FileStream("log.txt",FileMode.Append);
            _streamWriter = new StreamWriter(_stream);
        }

       
        public void Change(string text, string changeText)
        {
            _text = text;
            _replaceText = changeText;

            var directoryInfo = new DirectoryInfo(_path);
            EditFilesInDirectory(directoryInfo);
        }

        public void AsyncChange(string text, string changeText)
        {
            _text = text;
            _replaceText = changeText;
            var directoryInfo = new DirectoryInfo(_path);
            AsyncEditFilesInDirectory(directoryInfo);

        }

        private void EditFilesInDirectory(DirectoryInfo directoryInfo)
        {

            foreach (var file in directoryInfo.GetFiles("*."+_extension))
            {
                ChangeFile(file.FullName);
            }
            foreach (var directory in directoryInfo.GetDirectories())
            {
                EditFilesInDirectory(directory);
            }
        }

        private void AsyncEditFilesInDirectory(DirectoryInfo directoryInfo)
        {
            var files = directoryInfo.GetFiles("*." + _extension);
            var tasks = new Task[files.Length];
            for (var index = 0; index < files.Length; ++index)
            {

                Action<object> action = o => ChangeFile(((FileInfo) o).FullName);
                 tasks[index] = Task.Factory.StartNew(action, files[index]);
            }

            foreach (var directory in directoryInfo.GetDirectories())
            {

                AsyncEditFilesInDirectory(directory);

            }
            Task.WaitAll(tasks);
           
        }

        private void ChangeFile(string path)
        {

            var text = File.ReadAllText(path);
            var stream = File.OpenWrite(path);
            var writer = new StreamWriter(stream);
            using (var reader = new StringReader(text))
            {
                var line = reader.ReadLine();
                while (line != null)
                {

                    if (line.IndexOf(_text) == -1)
                    {
                        writer.WriteLine(line);
                        line = reader.ReadLine();
                        continue;
                    }
                    var replaceLine = line.Replace(_text, _replaceText);
                    writer.WriteLine(replaceLine);
                    lock (_stream)
                    {
                        _streamWriter.WriteLine("In File {0} the line {1} has been changed to {2}",
                            path, line, replaceLine);
                       
                    }
                    line = reader.ReadLine();
                }
            }

            writer.Close();
            stream.Close();
        }

        public void Dispose()
        {
           _streamWriter.Close();
            _stream.Close();
        }
    }
}
