using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CallForCode.Model.Whatsapp.Messages
{
    public class MessageSend
    {
        public string from { get; set; }
        public string to { get; set; }
        public ContentSend[] contents { get; set; }
    }

    public class ContentSend
    {
        public string type { get; set; }
        public string text { get; set; }
    }
}
