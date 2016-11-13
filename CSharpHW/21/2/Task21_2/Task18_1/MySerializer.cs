using System;
using System.CodeDom;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Runtime.Serialization.Json;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using ProtoBuf;

namespace Task18_1
{
   
    [Serializable]
   
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
    }
}
