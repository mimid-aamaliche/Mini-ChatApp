using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharedDTOs
{
    public class clsGetMessagesDTO
    {
        public int ID { get; set; }
        public string Content { get; set; }
        public string ContentType { get; set; }
        public int SenderID { get; set; }
        public int ReciverID { get; set; }

        public DateTime SendTime { get; set; }

        public clsGetMessagesDTO()
        {
        }

        public clsGetMessagesDTO(int iD, string content, string contentType, int senderID, int reciverID, DateTime sendTime)
        {
            ID = iD;
            Content = content;
            ContentType = contentType;
            SenderID = senderID;
            ReciverID = reciverID;
            SendTime = sendTime;
        }
    }
}
