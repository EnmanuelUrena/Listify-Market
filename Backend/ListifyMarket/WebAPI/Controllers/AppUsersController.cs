using Application.AppUsers.Commands.UserLogin;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    public class AppUsersController : ApiControllerBase
    {
        public IMediator Mediator;

        public AppUsersController(IMediator mediator)
        {
            Mediator = mediator;
        }

        [HttpPost]
        public async Task<Guid> Create([FromBody] UserLoginCommand command)
        {
            var result = await Mediator.Send(command);
            return result;
        }
    }
}
