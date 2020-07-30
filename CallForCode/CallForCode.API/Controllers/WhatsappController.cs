using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CallForCode.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WhatsappController : ControllerBase
    {
        [HttpPost("webhookstatus")]
        public IActionResult WebhookMessageStatus([FromBody] Model.Whatsapp.WebHook.StatusWebHook message)
        {
            if (ModelState.IsValid)
            {
                if (message != null)
                {
                    if (message.type == "MESSAGE_STATUS")
                    {
                        //Gravando LOG do status da mensagem no banco                        
                    }
                }
            }

            return Ok();
        }
        
        [HttpPost("webhookmessage")]
        public IActionResult WebhookMessage([FromBody] Model.Whatsapp.WebHook.MessageWebHook message)
        {
            if (ModelState.IsValid)
            {
                if (message != null)
                {
                    //Quando recebe realmente a resposta do cliente
                    if (message.type == "MESSAGE")
                    {
                        //Fazendo uma resposta de teste...
                        var x = new Clients.WhatsappClient("qwXNkAVQQ6WUAni_BrTOkN0BFg-zOkc3AjiZ");

                        var numeroRandom = new Random().Next(1, 9999);

                        var msg = new Model.Whatsapp.Messages.MessageSend()
                        {
                            from = "few-jumper",
                            to = "5511989259128", //"5547999167022", //"5517991815083", //"5517991119839",
                            contents = new Model.Whatsapp.Messages.ContentSend[]
                            {
                                new Model.Whatsapp.Messages.ContentSend()
                                {
                                    text = $"Feedback do webhook pela API propria - {numeroRandom}",
                                    type = "text"
                                }
                            }
                        };
                        x.SendMessage(msg);
                    }
                }

                return Ok();
            }

            return NotFound();
        }

        [HttpPost("sendmessage")]
        public IActionResult Send([FromBody] Model.Whatsapp.Messages.MessageSend message)
        {
            if (ModelState.IsValid)
            {
                if (message != null)
                {
                    var x = new Clients.WhatsappClient("qwXNkAVQQ6WUAni_BrTOkN0BFg-zOkc3AjiZ");
                    x.SendMessage(message);
                }

                return Ok();
            }

            return BadRequest();
        }
    }
}
