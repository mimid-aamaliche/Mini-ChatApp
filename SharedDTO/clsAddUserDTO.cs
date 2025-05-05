using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharedDTOs
{
    public class clsAddUserDTO
    {

        public string Name { get; set; }
        public string UserName { get; set; }

        public clsAddUserDTO()
        {
        }

        public clsAddUserDTO(string name, string userName)
        {
            Name = name;
            UserName = userName;
        }
    }
}
