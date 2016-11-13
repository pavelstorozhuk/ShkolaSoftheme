using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task18_1
{
    [OperatorMessage(MessageType.Info)]
    class OperatorInfoMessage
    {
      
    }
     [OperatorMessage(MessageType.Warn)]
    class OperatorWarnMessage
    {
        

        public string Message
        {
            get { return "not enought money"; }
        }
    }
}
