using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MiniChatAppbusinessLogicLayer;
using SharedDTOs;

namespace Mini_Chat_App_Server_Side.Controllers
{
    [Route("api/Message")]
    [ApiController]
    public class MessageController : ControllerBase
    {




        [HttpPost(Name = "AddMessage")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]

        public ActionResult<clsGetMessagesDTO> AddMessage(clsAddMessageDTO msgdto)
        {

            //Validation
            if (msgdto == null || string.IsNullOrEmpty(msgdto.ContentType))
            {
                return BadRequest("Invalide user Data");
            }

            //we need to validate the sender and receiver id 
            //if they don t exist we return BadRequest Action result
            //will be implimented later. maybe



            //mapping userdto to user

            clsMessage newMSG = new clsMessage()
            {
                Content = msgdto.Content,
                ContentType = msgdto.ContentType,
                SenderID = msgdto.SenderID,
                ReciverID = msgdto.ReciverID,


            };

           

            if (newMSG.Save())
            {

                return Ok(newMSG.GetMsgDTO);

            }
            else
            {
                return BadRequest("Server error");

            }


        }












    }
}
