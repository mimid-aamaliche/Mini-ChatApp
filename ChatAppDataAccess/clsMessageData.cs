using SharedDTOs;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Data.SqlClient;

namespace MiniChatAppDataAccessLayer
{
    public class clsMessageData
    {


        //Add Message 
        public static int AddNewMessage(clsAddMessageDTO newMessage)
        {

            try
            {

                using (SqlConnection conn = new SqlConnection(clsConnectionSettings._connectionString))
                using (SqlCommand cmd = new SqlCommand("AddNewMessage", conn))
                {
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@Content", newMessage.Content);
                    cmd.Parameters.AddWithValue("@ContentType", newMessage.ContentType);
                    cmd.Parameters.AddWithValue("@SenderID", newMessage.SenderID);
                    cmd.Parameters.AddWithValue("@ReciverID", newMessage.ReciverID);




                    cmd.Parameters.Add(new SqlParameter("@InsertedID", SqlDbType.Int)
                    {
                        Direction = System.Data.ParameterDirection.Output
                    });

                    conn.Open();
                    cmd.ExecuteNonQuery();

                    return (int)cmd.Parameters["@InsertedID"].Value;

                }



            }
            catch (Exception ex)
            {
                //Handel the error
                Console.WriteLine(ex.ToString());


            }


            return -1;

        }

        //Get Messages Between Tow Users
        public static List<clsGetMessagesDTO> GetMessages(int CurrentUserID,int OtherID)
        {
            List < clsGetMessagesDTO > messages = new List < clsGetMessagesDTO >();
            try
            {

                using (SqlConnection conn = new SqlConnection(clsConnectionSettings._connectionString))
                using (SqlCommand cmd = new SqlCommand("GetMessagesBetweenTowUsers", conn))
                {
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@CurrentUserID", CurrentUserID);
                    cmd.Parameters.AddWithValue("@OtherUserID", OtherID);
                    conn.Open();
                    using (SqlDataReader reader = cmd.ExecuteReader()) {

                        while (reader.Read()) {

                            messages.Add(new clsGetMessagesDTO()
                            {
                                ID = reader.GetInt32(reader.GetOrdinal("id")),
                                Content = reader.GetString(reader.GetOrdinal("Content")),
                                ContentType = reader.GetString(reader.GetOrdinal("ContentType")),
                                SenderID = reader.GetInt32(reader.GetOrdinal("SenderID")),
                                ReciverID = reader.GetInt32(reader.GetOrdinal("ReceiverID")),
                                SendTime = reader.GetDateTime(reader.GetOrdinal("SendTime"))

                            });
                        
                        
                        }
                    
                    
                    
                    
                    }
                    


                   


                }



            }
            catch (Exception ex)
            {
                //Handel the error
                Console.WriteLine(ex.ToString());


            }


            return messages;

        }










    }
}
