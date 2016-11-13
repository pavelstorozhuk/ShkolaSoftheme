using System;
using System.IO;
using System.IO.Compression;
using System.Runtime.Serialization.Formatters.Binary;
using System.Runtime.Serialization.Json;
using System.Xml.Serialization;
using ProtoBuf;

namespace Task18_1
{
   
   
   
    class MySerializer
    {

        public void BinarySerialize(string path, object obj)
        {
            using (var stream = new FileStream("SerializedRepository.txt", FileMode.Create))
            {
                var formatter = new BinaryFormatter();
                formatter.Serialize(stream, obj);
               
            }


        }

        public object BinaryDeserialize(string path)
        {
            using (var stream = new FileStream(path, FileMode.Open))
            {
                var formatter = new BinaryFormatter();
                return formatter.Deserialize(stream);
            }
        }

        public void XmlSerialize(string path, object obj)
        {
            using (var stream = new FileStream(path, FileMode.Create))
            {
                var serializer = new XmlSerializer(obj.GetType());
                if (obj is MobileAccount[])
                {
                   MobileAccount[] account = obj as MobileAccount[];
                    serializer.Serialize(stream, obj);
                    return;
                    
                }
                serializer.Serialize(stream,obj);
            }
        }

        public object XmlDeserialize(string path,Type type)
        {
           

            var serializer = new XmlSerializer(type);
            using (var stream = File.OpenRead(path))
            {
                return serializer.Deserialize(stream);
            }
            

        }

        public void JsonSerialize(string path, object obj)
        {
            using (var stream = new FileStream(path, FileMode.Create))
            {
                var ser = new DataContractJsonSerializer(obj.GetType());
                ser.WriteObject(stream, obj);
            }

        }
        public object JsonDeserialize(string path)
        {
            using (var stream = new FileStream(path, FileMode.Open))
            {
                var ser = new DataContractJsonSerializer(typeof(MobileAccount[]));
                return ser.ReadObject(stream);
            }

        }

        public void ProtoSerialize(string path,object obj)
        {
            using (var stream = new FileStream(path, FileMode.Create))
            {
                Serializer.Serialize(stream,obj);
                
            }
            
        }
        public object ProtoDeserialize<T>(string path)
        {
            using (var stream = new FileStream(path, FileMode.Open))
            {
                
                return Serializer.Deserialize<T>(stream);

            }
        }

        public void Compress(string openPath, string createPath)
        {
            var source = File.OpenRead(openPath);
            var destination = File.Create(createPath);
            var compressor = new GZipStream(destination, CompressionMode.Compress);
            int theByte = source.ReadByte();
            while (theByte != -1)
            {
                compressor.WriteByte((byte) theByte);
                theByte = source.ReadByte();
            }

            compressor.Close();
            source.Close();
            destination.Close();
        }

        public void DeCompress(string openPath, string createPath)
        {
            var source = File.OpenRead(openPath);
            var destination = File.Create(createPath);

            var deCompressor = new GZipStream(source, CompressionMode.Decompress);

            int theByte = deCompressor.ReadByte();
            while (theByte != -1)
            {
                destination.WriteByte((byte) theByte);
                theByte = deCompressor.ReadByte();
            }
            destination.Close();
            deCompressor.Close();
            source.Close();
        }
    }
}
