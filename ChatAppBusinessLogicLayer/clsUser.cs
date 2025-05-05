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
    public class clsUser
    {

        enum enMode { enAddNewMode=1,enUpdateMode=2}
        enMode _CurrentMode = enMode.enAddNewMode;
        public int ID { get; set; }
        public string Name { get; set; }
        public string UserName { get; set; }

        public clsGetUserDTO UserDTO { 
             get { return new clsGetUserDTO(ID, Name, UserName); } 
        }


        public clsUser()
        {
            ID = -1;
            Name = "";
            UserName = "";

            _CurrentMode = enMode.enAddNewMode;
        }

        public clsUser(clsGetUserDTO user)
        {
            ID=user.ID;
            Name = user.Name;
            UserName = user.Name;

            _CurrentMode = enMode.enUpdateMode;



        }



        //Add New

        private bool _AddNewUser()
        {
            this.ID=clsUserData.AddNewUser(new clsAddUserDTO() { Name = this.Name, UserName = this.UserName });

            return ID != -1;
        }





        //Get All The Users In The System

        public static List<clsGetUserDTO> GetAllUser()
        {
            return clsUserData.GetUsers();
        }




        public bool Save()
        {
            switch (_CurrentMode) { 
            
                case enMode.enAddNewMode:
                    if (_AddNewUser())
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
