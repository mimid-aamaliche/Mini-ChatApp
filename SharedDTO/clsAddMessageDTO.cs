using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharedDTOs
{
    public class clsAddMessageDTO
    {

        public string Content { get; set; }
        public string ContentType { get; set; }
        public int SenderID { get; set; }
        public int ReciverID { get; set; }

        public clsAddMessageDTO()
        {
        }

        public clsAddMessageDTO(string content, string contentType, int senderID, int reciverID)
        {
            Content = content;
            ContentType = contentType;
            SenderID = senderID;
            ReciverID = reciverID;
        }
    }
}
