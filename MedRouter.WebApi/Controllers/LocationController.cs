using CleanArchitecture.Core.Wrappers;
using MedRouter.Core.Entities;
using MedRouter.Core.Exceptions;
using MedRouter.Core.Features.Commands.Location;
using MedRouter.Core.Features.Queries.Location;
using MedRouter.Core.IdentityData;
using MedRouter.Core.Parameters;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace MedRouter.WebApi.Controllers;

public class LocationController : BaseApiController
{
    // Get api/<controller>
    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(PagedResponse<IEnumerable<Location>>))]
    public async Task<PagedResponse<IEnumerable<GetLocationViewModel>>> Get([FromQuery] RequestParameter request)
    {
        return await Mediator.Send(new GetAllLocationsQuery()
            { PageSize = request.PageSize, PageNumber = request.PageNumber });
    }
    
    // Get api/<controller>/1
    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(int id)
    {
        return Ok(await Mediator.Send(new GetLocationByIdQuery() { Id = id }));
    }
    
    // Post api/<controller>
    [Authorize(Policy = IdentityData.AdminUserPolicyName)]
    [HttpPost]
    public async Task<IActionResult> Post(CreateLocationCommand request)
    {
        return Ok(await Mediator.Send(request));
    }
    
    // Put api/<controller>/1
    [Authorize(Policy = IdentityData.AdminUserPolicyName)]
    [HttpPut("{id}")]
    public async Task<IActionResult> Put(int id, UpdateLocationCommand request)
    {
        if (id != request.Id)
        {
            throw new ApiException("Bad request. Id's don't match");
        }
        return Ok(await Mediator.Send(request));
    }
    
    // Delete api/<controller>/1
    [Authorize(Policy = IdentityData.AdminUserPolicyName)]
    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        return Ok(await Mediator.Send(new DeleteLocationCommand() { Id = id }));
    }
}