using Application.Features.Contacts.Commands.Create;
using Application.Features.Contacts.Dtos;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebAPI.Controllers.Base;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContactsController : BaseController
    {
        [HttpPost]
        public async Task<IActionResult> Add([FromBody] CreateContactCommand createContactCommand)
        {
            CreatedContactResponse response = await Mediator.Send(createContactCommand);
            return Ok(response);
        }
    }
}
