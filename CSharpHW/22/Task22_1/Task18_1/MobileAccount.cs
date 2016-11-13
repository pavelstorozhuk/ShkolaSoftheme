using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.Xml.Serialization;
using System.Runtime.Serialization;
using ProtoBuf;

namespace Task18_1
{
       public delegate void AccountSmsStateHandler(object sender, string message);
       public  delegate void AccountCallStateHandler(object sender);

    [Serializable]
    [DataContract]
    [ProtoContract]
    public class MobileAccount : IMobileAccount
    {
        private event AccountSmsStateHandler _getMessage;
        private event AccountCallStateHandler _getCall;
        private List<string> keyList;
        private List<string> valueList;

         [ProtoMember(1)]
        [XmlAttribute]
        [DataMember]
        public string PhoneNumber { get; set; }
         [ProtoMember(2)]
        [XmlAttribute]
        [DataMember]
        public decimal Money { get; set; }

        [DataMember]
        [XmlAttribute]
        [ProtoMember(3)]
        public List<string> KeysList
        {
            get { return keyList; }
            set { keyList = value; }


        }

        [DataMember]
        [XmlAttribute]
        [ProtoMember(4)]
        public List<string> ValueList
        {
            get { return valueList; }
            set { valueList = value; }

        }




        public MobileAccount()
        {

        }

        public MobileAccount(string phoneNumber)
        {
            PhoneNumber = phoneNumber;
            Money = MobileOperator.GetBalance(this);
        }

        public MobileAccount(string phoneNumber, decimal money)
        {
            Money = money;
            PhoneNumber = phoneNumber;
        }

        public MobileAccount(string phoneNumber, Dictionary<string, string> addressBook)
        {
            PhoneNumber = phoneNumber;
            valueList = addressBook.Values.ToList();
            keyList = addressBook.Keys.ToList();

            Money = MobileOperator.GetBalance(this);
        }



        public event AccountSmsStateHandler GetMessageEvent
        {
            add { _getMessage += value; }
            remove { _getMessage -= value; }
        }

        public event AccountCallStateHandler GetCallEvent
        {
            add { _getCall += value; }
            remove { _getCall -= value; }
        }

        public void GetMessage(IMobileAccount account, string message)
        {
            if (_getMessage != null)
            {
                if (this.FindNameFromAddressBook(account.PhoneNumber) != null)
                {
                    this.GetMessageEvent -= MobileOperator.ShowSms;
                    this.GetMessageEvent += this.ShowSmsFromKnowNumber;
                }
                _getMessage.Invoke(account, message);
                _getMessage = null;
            }
        }

        public void GetCall(IMobileAccount account)
        {
            if (_getCall != null)
            {
                if (this.FindNameFromAddressBook(account.PhoneNumber) != null)
                {
                    this.GetCallEvent -= MobileOperator.ShowMessage;
                    this.GetCallEvent += this.ShowCallFromKnowNumber;
                }
                _getCall.Invoke(account);
                _getCall = null;
            }
        }

        public void Call(IMobileAccount account)
        {


            MobileOperator.Connect(this, (MobileAccount) account);

        }

        public void GetMessageFromOperator(object message)
        {

            OperatorMessageAttribute myAttribute =
                (OperatorMessageAttribute)
                Attribute.GetCustomAttribute(message.GetType(), typeof(OperatorMessageAttribute));
            if (myAttribute.Type == MessageType.Warn)
            {
                OperatorWarnMessage messageWarn = message as OperatorWarnMessage;
                Console.WriteLine(messageWarn.Message);
            }
        }

        public void SendSms(IMobileAccount account, string message)
        {

            MobileOperator.SendSms(this, account, message);
        }

        private void ShowSmsFromKnowNumber(object sender, string message)
        {
            if (sender is IMobileAccount)
            {
                Console.WriteLine(String.Format("you have received the message {0} from name {1}", message,
                    FindNameFromAddressBook(((IMobileAccount) sender).PhoneNumber)));
            }
        }

        private void ShowCallFromKnowNumber(object sender)
        {
            if (sender is IMobileAccount)
            {
                Console.WriteLine(String.Format("you were called from name {0}",
                    FindNameFromAddressBook(((IMobileAccount) sender).PhoneNumber)));
            }
        }

        public string FindNameFromAddressBook(string number)
        {
            if (keyList == null)
                return null;
            if (keyList.Contains(number))
                return valueList[KeysList.IndexOf(number)];
            return null;
        }
    }
}
