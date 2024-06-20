using CleanArchitecture.Core.Wrappers;
using MedRouter.Core.Entities;
using MedRouter.Core.Exceptions;
using MedRouter.Core.Features.Commands.Hotel;
using MedRouter.Core.Features.Queries.Hotel;
using MedRouter.Core.Features.Queries.Location;
using MedRouter.Core.IdentityData;
using MedRouter.Core.Parameters;
using MedRouter.Core.Wrappers;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace MedRouter.WebApi.Controllers;

public class HotelController : BaseApiController
{
    // Get api/<controller>
    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(PagedResponse<IEnumerable<Hotel>>))]
    public async Task<PagedResponse<IEnumerable<GetHotelViewModel>>> Get([FromQuery] RequestParameter request)
    {
        return await Mediator.Send(new GetAllHotelsQuery()
            { PageSize = request.PageSize, PageNumber = request.PageNumber });
    }
    
    // Get api/<controller>/1
    [HttpGet("{id}")]
    public async Task<IActionResult> Get(int id)
    {
        return Ok(await Mediator.Send(new GetHotelByIdQuery() { Id = id }));
    }
    
    // Get api/<controller>/filter-name
    [HttpGet("filter-name")]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(Response<IEnumerable<GetHotelViewModel>>))]
    public async Task<Response<IEnumerable<GetHotelViewModel>>> GetFilterByName([FromQuery]FilterHotelsByNameQuery request)
    {
        return await Mediator.Send(request);
    }
    
    // Get api/<controller>/filter-rating
    [HttpGet("filter-rating")]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(Response<IEnumerable<GetHotelViewModel>>))]
    public async Task<Response<IEnumerable<GetHotelViewModel>>> GetFilterByStarRating([FromQuery]FilterHotelsByStarRatingQuery request)
    {
        return await Mediator.Send(request);
    }
    
    // Get api/<controller>/filter-name-rating
    [HttpGet("filter-name-rating")]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(Response<IEnumerable<GetHotelViewModel>>))]
    public async Task<Response<IEnumerable<GetHotelViewModel>>> GetFilterByNameAndRating([FromQuery]FilterHotelsByNameAndStarRatingsQuery request)
    {
        return await Mediator.Send(request);
    }
    
    // Get api/<controller>/filter-location
    [HttpGet("filter-location")]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(Response<IEnumerable<GetHotelViewModel>>))]
    public async Task<Response<IEnumerable<GetHotelViewModel>>> GetFilterByLocation([FromQuery]FilterHotelsByLocationQuery request)
    {
        return await Mediator.Send(request);
    }
    
    // Get api/<controller>/filter-name-location
    [HttpGet("filter-name-location")]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(Response<IEnumerable<GetHotelViewModel>>))]
    public async Task<Response<IEnumerable<GetHotelViewModel>>> GetFilterByNameAndLocation([FromQuery]FilterHotelsByNameAndLocationQuery request)
    {
        return await Mediator.Send(request);
    }
    
    // Get api/<controller>/filter-rating-location
    [HttpGet("filter-rating-location")]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(Response<IEnumerable<GetHotelViewModel>>))]
    public async Task<Response<IEnumerable<GetHotelViewModel>>> GetFilterByRatingAndLocation([FromQuery] FilterHotelsByRatingAndLocationQuery request)
    {
        return await Mediator.Send(request);
    }
    
        
    // Get api/<controller>/filter-name-rating-location
    [HttpGet("filter-name-rating-location")]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(Response<IEnumerable<GetHotelViewModel>>))]
    public async Task<Response<IEnumerable<GetHotelViewModel>>> GetFilterByNameAndRatingAndLocation([FromQuery] FilterHotelsByNameAndRatingAndLocationQuery request)
    {
        return await Mediator.Send(request);
    }


    
    // Post api/<controller>
    [Authorize(Policy = IdentityData.AdminUserPolicyName)]
    [HttpPost]
    public async Task<IActionResult> Post(CreateHotelCommand request)
    {
        var hotel = await Mediator.Send(new GetLocationByIdQuery() { Id = request.LocationId });
        if (hotel == null)
        {
            throw new ApiException("No such location found. Hotel cannot be added");
        }
        return Ok(await Mediator.Send(request));
    }
    
    // Put api/<controller>/1
    [Authorize(Policy = IdentityData.AdminUserPolicyName)]
    [HttpPut("{id}")]
    public async Task<IActionResult> Put(UpdateHotelCommand request, int id)
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
        return Ok(await Mediator.Send(new DeleteHotelCommand() { Id = id }));
    }

    
    
}