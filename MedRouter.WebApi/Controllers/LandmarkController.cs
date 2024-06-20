using CleanArchitecture.Core.Wrappers;
using MedRouter.Core.Entities;
using MedRouter.Core.Exceptions;
using MedRouter.Core.Features.Commands.Landmark;
using MedRouter.Core.Features.Queries.Hotel;
using MedRouter.Core.Features.Queries.Landmark;
using MedRouter.Core.Features.Queries.Location;
using MedRouter.Core.IdentityData;
using MedRouter.Core.Parameters;
using MedRouter.Core.Wrappers;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace MedRouter.WebApi.Controllers;

public class LandmarkController : BaseApiController
{
    // Get api/<controller>
    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(PagedResponse<IEnumerable<GetLandmarkViewModel>>))]
    public async Task<PagedResponse<IEnumerable<GetLandmarkViewModel>>> Get([FromQuery] RequestParameter request)
    {
        return await Mediator.Send(new GetAllLandmarksQuery()
            { PageSize = request.PageSize, PageNumber = request.PageNumber });
    }
    
    // Get api/<controller>/1
    [HttpGet("{id}")]
    public async Task<IActionResult> Get(int id)
    {
        return Ok(await Mediator.Send(new GetLandmarkByIdQuery() { Id = id }));
    }
    
    // Get api/<controller>/filter-name
    [HttpGet("filter-name")]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(Response<IEnumerable<GetLandmarkViewModel>>))]
    public async Task<Response<IEnumerable<GetLandmarkViewModel>>> GetFilterByName([FromQuery]FilterLandmarksByNameQuery request)
    {
        return await Mediator.Send(request);
    }
    
    // Get api/<controller>/filter-location
    [HttpGet("filter-location")]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(Response<IEnumerable<GetLandmarkViewModel>>))]
    public async Task<Response<IEnumerable<GetLandmarkViewModel>>> GetFilterByLocation([FromQuery]FilterLandmarksByLocationQuery request)
    {
        return await Mediator.Send(request);
    }
    
    // Get api/<controller>/filter-name-location
    [HttpGet("filter-name-location")]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(Response<IEnumerable<GetLandmarkViewModel>>))]
    public async Task<Response<IEnumerable<GetLandmarkViewModel>>> GetFilterByNameAndLocation([FromQuery]FilterLandmarksByNameAndLocationQuery request)
    {
        return await Mediator.Send(request);
    }
    
    
    // Post api/<controller>
    [Authorize(Policy = IdentityData.AdminUserPolicyName)]
    [HttpPost]
    public async Task<IActionResult> Post(CreateLandmarkCommand request)
    {
        var landmark = await Mediator.Send(new GetLocationByIdQuery() { Id = request.LocationId });
        if (landmark == null)
        {
            throw new ApiException("No such location found. Landmark cannot be added");
        }
        return Ok(await Mediator.Send(request));
    }
    
    // Put api/<controller>/1
    [Authorize(Policy = IdentityData.AdminUserPolicyName)]
    [HttpPut("{id}")]
    public async Task<IActionResult> Put(UpdateLandmarkCommand request, int id)
    {
        if (id != request.Id)
        {
            throw new ApiException("Bad request. Id's doesn't match");
        }

        return Ok(await Mediator.Send(request));
    }
    
    // Delete api/<controller>/1
    [Authorize(Policy = IdentityData.AdminUserPolicyName)]
    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        return Ok(await Mediator.Send(new DeleteLandmarkCommand() { Id = id }));
    }
    
    
}