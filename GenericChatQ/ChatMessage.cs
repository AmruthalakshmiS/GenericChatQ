using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenericChatQ
{
    public class ChatMessage
    {
        public DateTime TimeStamp { get; set; }
        public int SourceId { get; set; }

        public ChatMessage(DateTime timeStamp, int sourceId)
        {
            TimeStamp = timeStamp;
            SourceId = sourceId;
        }
    }
}
