using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WebApi.BLL.DTO.Message;
using WebApi.BLL.Interfaces;
using WebApi.WEB.Filters;

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
        [ValidateModel]
        public IActionResult Post(MessageCreateDTO message)
        {
            _messageService.Create(message, User.Identity.Name);
            return Ok();
        }
    }
}
