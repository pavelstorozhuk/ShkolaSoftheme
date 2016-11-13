using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task18_1
{
    enum MessageType
    {
        Info,
        Warn
    }
     [AttributeUsage(AttributeTargets.Class, AllowMultiple = false)]
    class OperatorMessageAttribute :System.Attribute
    {
        public OperatorMessageAttribute(MessageType type)
        {
            _type = type;
        }
        private MessageType _type;
        public MessageType Type
        {
            get { return _type; }
        }

       
  
    }
}
