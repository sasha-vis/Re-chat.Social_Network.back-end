using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApi.BLL.Interfaces;
using WebApi.BLL.ViewModels.Message;

namespace WebApi.WEB.Controllers
{
    [Authorize(AuthenticationSchemes = "Bearer")]
    public class MessageController : BaseController
    {
        IMessageService _messageService;
        public MessageController(IMessageService messageService)
        {
            _messageService = messageService;
        }

        [HttpPost]
        public IActionResult Post(MessageCreateVM message)
        {
            if (!ModelState.IsValid)
            {
                return Post(message);
            }
            _messageService.Create(message, User.Identity.Name);
            return Ok();
        }
    }
}
