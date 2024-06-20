using CleanArchitecture.Core.Wrappers;
using MedRouter.Core.Entities;
using MedRouter.Core.Exceptions;
using MedRouter.Core.Features.Commands.Hospital;
using MedRouter.Core.Features.Queries.Hospital;
using MedRouter.Core.Features.Queries.Hotel;
using MedRouter.Core.Features.Queries.Location;
using MedRouter.Core.IdentityData;
using MedRouter.Core.Parameters;
using MedRouter.Core.Wrappers;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace MedRouter.WebApi.Controllers;

public class HospitalController : BaseApiController
{
    // Get api/<controller>
    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(PagedResponse<IEnumerable<Hospital>>))]
    public async Task<PagedResponse<IEnumerable<GetHospitalViewModel>>> Get([FromQuery] RequestParameter request)
    {
        return await Mediator.Send(new GetAllHospitalsQuery()
            { PageSize = request.PageSize, PageNumber = request.PageNumber });
    }
    
    // Get api/<controller>/1
    [HttpGet("{id}")]
    public async Task<IActionResult> Get(int id)
    {
        return Ok(await Mediator.Send(new GetHospitalByIdQuery() { Id = id }));
    }
    
    // Get api/<controller>/filter-name
    [HttpGet("filter-name")]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(Response<IEnumerable<GetHospitalViewModel>>))]
    public async Task<Response<IEnumerable<GetHospitalViewModel>>> GetFilterByName([FromQuery]FilterHospitalsByNameQuery request)
    {
        return await Mediator.Send(request);
    }
    
    // Get api/<controller>/filter-type
    [HttpGet("filter-type")]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(Response<IEnumerable<GetHospitalViewModel>>))]
    public async Task<Response<IEnumerable<GetHospitalViewModel>>> GetFilterByType([FromQuery]FilterHospitalsByTypeQuery request)
    {
        return await Mediator.Send(request);
    }
    
    // Get api/<controller>/filter-name-type
    [HttpGet("filter-name-type")]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(Response<IEnumerable<GetHospitalViewModel>>))]
    public async Task<Response<IEnumerable<GetHospitalViewModel>>> GetFilterByNameAndType([FromQuery]FilterHospitalsByNameAndTypeQuery request)
    {
        return await Mediator.Send(request);
    }
    
    // Get api/<controller>/filter-location
    [HttpGet("filter-location")]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(Response<IEnumerable<GetHospitalViewModel>>))]
    public async Task<Response<IEnumerable<GetHospitalViewModel>>> GetFilterByLocation([FromQuery]FilterHospitalByLocationQuery request)
    {
        return await Mediator.Send(request);
    }
    
    // Get api/<controller>/filter-name-location
    [HttpGet("filter-name-location")]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(Response<IEnumerable<GetHospitalViewModel>>))]
    public async Task<Response<IEnumerable<GetHospitalViewModel>>> GetFilterByNameAndLocation([FromQuery]FilterHospitalByNameAndLocationQuery request)
    {
        return await Mediator.Send(request);
    }
    
    // Get api/<controller>/filter-type-location
    [HttpGet("filter-type-location")]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(Response<IEnumerable<GetHospitalViewModel>>))]
    public async Task<Response<IEnumerable<GetHospitalViewModel>>> GetFilterByTypeAndLocation([FromQuery]FilterHospitalByTypeAndLocationQuery request)
    {
        return await Mediator.Send(request);
    }
    
    // Get api/<controller>/filter-name-type-location
    [HttpGet("filter-name-type-location")]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(Response<IEnumerable<GetHospitalViewModel>>))]
    public async Task<Response<IEnumerable<GetHospitalViewModel>>> GetFilterByNameAndTypeAndLocation([FromQuery]FilterHospitalByNameAndTypeAndLocationQuery request)
    {
        return await Mediator.Send(request);
    }
    
    
    // Post api/<controller>
    [Authorize(Policy = IdentityData.AdminUserPolicyName)]
    [HttpPost]
    public async Task<IActionResult> Post(CreateHospitalCommand request)
    {
        var hospital = await Mediator.Send(new GetLocationByIdQuery() { Id = request.LocationId });
        if (hospital == null)
        {
            throw new ApiException("No such location found. Hospital cannot be added");
        }
        return Ok(await Mediator.Send(request));
    }
    
    // Put api/<controller>/1
    [Authorize(Policy = IdentityData.AdminUserPolicyName)]
    [HttpPut("{id}")]
    public async Task<IActionResult> Put(UpdateHospitalCommand request, int id)
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
        return Ok(await Mediator.Send(new DeleteHospitalCommand() { Id = id }));
    }
    
    
}