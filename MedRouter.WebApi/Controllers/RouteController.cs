using MedRouter.Core.Exceptions;
using MedRouter.Core.Features.Commands.Route;
using MedRouter.Core.Features.Queries.Route;
using MedRouter.Core.IdentityData;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace MedRouter.WebApi.Controllers;

public class RouteController : BaseApiController
{
    // post api/<controller>
    [HttpPost]
    public async Task<IActionResult> Create(CreateRouteCommand request)
    {
        return Ok(await Mediator.Send(request));
    }
    
    // get api/<controller>/example.mail.com
    [HttpGet]
    public async Task<IActionResult> GetRoutes(string mail)
    {
        return Ok(await Mediator.Send(new GetAllRoutesByMailQuery(){Mail = mail}));
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateRoute(int id, UpdateRouteCommand request)
    {
        if (id != request.Id)
        {
            throw new ApiException("Bad request. Id's doesn't match");
        }

        return Ok(await Mediator.Send(request));
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        return Ok(await Mediator.Send(new DeleteRouteCommand() { Id = id }));
    }
    
}