using Microsoft.AspNetCore.Hosting.Server;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Data.SqlClient;
using System.Data;
using SharedDTOs;
using MiniChatAppbusinessLogicLayer;

namespace Mini_Chat_App_Server_Side.Controllers
{
    [Route("api/User")]
    [ApiController]
    public class UserController : ControllerBase
    {



        [HttpPost(Name ="AddUser")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]

        public ActionResult<clsGetUserDTO> AddUser(clsAddUserDTO userdto)
        {

            //Validation
            if(userdto == null || string.IsNullOrEmpty(userdto.UserName) || string.IsNullOrEmpty(userdto.Name))
            {
                return BadRequest("Invalide user Data");
            }

            //UserName Must be Unique so we must check if it s already used 
            //...



            //mapping userdto to user
            clsUser newUser = new clsUser()
            {
                Name = userdto.Name,
                UserName = userdto.UserName,
            };

            if (newUser.Save())
            {
                
                return Ok(newUser.UserDTO);

            }
            else
            {
                return  BadRequest("Server error");

            }


        }





        [HttpGet("{UserName}",Name = "GetUserByUserName")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]

        public ActionResult<clsGetUserDTO> GetUserByUserName(string UserName)
        {






            return Ok("Not Implimented Yet !!!!");




        }






        //Get Users 



        [HttpGet("GetAll", Name = "GetUsers")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]

        public ActionResult<IEnumerable<clsGetUserDTO>> GetAll() {


            var userList = MiniChatAppbusinessLogicLayer.clsUser.GetAllUser();
            if(userList.Count ==0)
                return NoContent();
        
            return Ok(userList);
        
        }


















    }
}
