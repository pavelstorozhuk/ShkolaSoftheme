using System.Linq;
using System.IO;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.Runtime.Serialization.Json;
using System.Xml.Serialization;


namespace Task18_1
{
    internal class MobileAccountsRepository
    {
        private MobileAccount[] _array =
        {
            new MobileAccount("0668348842", 10m),
            new MobileAccount("0637543684", 10m),
            new MobileAccount("0662345623", 10m),
            new MobileAccount("0662345643", 10m),
            new MobileAccount("0662342623", 10m),
            new MobileAccount("0637543684",10m)
        };

        private Serializer _serializer;

        public MobileAccountsRepository()
        {
            _serializer= new Serializer();
        }
        public bool Containts(string phoneNumber)
        {
            if (_array.ToList().Find(m => m.PhoneNumber.Equals(phoneNumber)) != null)
                return true;
            else return false;
        }

        public MobileAccount GetMobileAccountByPhoneNumber(string number)
        {
            return _array.ToList().Find(m => m.PhoneNumber.Equals(number));
        }

        public void SetMobileAccountChanges(MobileAccount account)
        {
            for (int i = 0; i < _array.Length; i++)
            {
                if (_array[i].PhoneNumber == account.PhoneNumber)
                {
                    _array[i] = account;
                }
            }
        }

        public void BinarySerialize()
        {
            _serializer.BinarySerialize("SerializedRepository.txt",_array);
           

        }

        public void BinaryDeserialize()
        {
           _array= (MobileAccount[]) _serializer.BinaryDeserialize("SerializedRepository.txt");
        }

        public void XmlSerialize()
        {
            _serializer.XmlSerialize("SerializedRepository.xml",_array);
        }

        public void XmlDeserialize()
        {
           _array=(MobileAccount[]) _serializer.XmlDeserialize("SerializedRepository.xml",_array.GetType());

        }

        public void JsonSerialize()
        {
            _serializer.JsonSerialize("SerializedRepository.json",_array);

        }
        public void JsonDeserialize()
        {
          _array=(MobileAccount[])  _serializer.JsonDeserialize("SerializedRepository.json");

        }

    }
}