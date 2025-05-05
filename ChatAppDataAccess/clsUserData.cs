using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using SharedDTOs;
using System.Linq;
using System.Text;
using Microsoft.Data.SqlClient;
using System.Threading.Tasks;

namespace MiniChatAppDataAccessLayer
{

   
    public class clsUserData
    {




        //Add User

        public static int AddNewUser(clsAddUserDTO newUser){

            try
            {

                using (SqlConnection conn = new SqlConnection(clsConnectionSettings._connectionString))
                using (SqlCommand cmd = new SqlCommand("AddNewUser", conn))
                {
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Name", newUser.Name);
                    cmd.Parameters.AddWithValue("@UserName", newUser.UserName);

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


        //Get Users

        public static List<clsGetUserDTO> GetUsers()
        {
            List< clsGetUserDTO > UsersList = new List<clsGetUserDTO >();
            try
            {

                using (SqlConnection conn = new SqlConnection(clsConnectionSettings._connectionString))
                using (SqlCommand cmd = new SqlCommand("GetUsers", conn))
                {             
                    
                    conn.Open();
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    
                    using (SqlDataReader reader = cmd.ExecuteReader()) {

                        
                        //Fill The List with Users
                        while (reader.Read()) {

                            UsersList.Add(new clsGetUserDTO() { 
                                ID=reader.GetInt32(reader.GetOrdinal("id")),
                                Name= reader.GetString(reader.GetOrdinal("Name")),
                                UserName= reader.GetString(reader.GetOrdinal("UserName"))

                            });
                            
                        
                        }





                    
                    }

                   

                    

                }



            }
            catch (Exception ex) {
            
                Console.WriteLine(ex.ToString());
            
            
            }



            return UsersList;



        }







    }
}
