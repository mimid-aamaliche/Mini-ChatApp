using MiniChatAppDataAccessLayer;
using SharedDTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace MiniChatAppbusinessLogicLayer
{
    public class clsMessage
    {

        enum enMode { enAddNewMode = 1, enUpdateMode = 2 }
        enMode _CurrentMode = enMode.enAddNewMode;
        public int ID { get; set; }
        public string Content { get; set; }
        public string ContentType { get; set; }
        public int SenderID { get; set; }
        public int ReciverID { get; set; }

        private DateTime SendTime { get; set; }


        public clsGetMessagesDTO GetMsgDTO { 
                                    get { return new clsGetMessagesDTO(ID, Content, ContentType, SenderID, ReciverID, SendTime); }
                                            }


        public clsMessage()
        {
            ID = -1;
            Content = "";
            ContentType = "";
            SenderID = -1;
            ReciverID = -1;

            SendTime=DateTime.Now;

            _CurrentMode = enMode.enAddNewMode;
        }

        public clsMessage(clsGetMessagesDTO message)
        {
            ID = message.ID;
            Content = message.Content;
            ContentType = message.ContentType;
            SenderID = message.SenderID;
            ReciverID = message.ReciverID;

            _CurrentMode = enMode.enUpdateMode;



        }



        //Add New Message


        private bool _AddNewMessage()
        {
            this.ID = clsMessageData.AddNewMessage(new clsAddMessageDTO(Content, ContentType, SenderID, ReciverID));

            return ID != -1;
        }




        //Get The List Of Messages Between tow users

        public static List<clsGetMessagesDTO> GetMessagesBetweenTowUsers(int CurrentUserID,int OtherID)
        {
            return clsMessageData.GetMessages(CurrentUserID, OtherID);
        }


        public bool Save()
        {
            switch (_CurrentMode)
            {

                case enMode.enAddNewMode:
                    if (_AddNewMessage())
                    {
                        this._CurrentMode = enMode.enUpdateMode;
                        return true;

                    }
                    break;



            }

            return false;
        }

    }
}
