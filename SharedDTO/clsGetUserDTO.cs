using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharedDTOs
{
    public class clsGetUserDTO
    {


        public int ID { get; set; }
        public string Name { get; set; }
        public string UserName { get; set; }

        public clsGetUserDTO()
        {
        }

        public clsGetUserDTO(int iD, string name, string userName)
        {
            ID = iD;
            Name = name;
            UserName = userName;
        }
    }
}
