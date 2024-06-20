using AutoMapper;
using MedRouter.Core.Entities;
using MedRouter.Core.Features.Commands.Hospital;
using MedRouter.Core.Features.Commands.Hotel;
using MedRouter.Core.Features.Commands.Landmark;
using MedRouter.Core.Features.Commands.Location;
using MedRouter.Core.Features.Commands.Route;
using MedRouter.Core.Features.Queries.Hospital;
using MedRouter.Core.Features.Queries.Hotel;
using MedRouter.Core.Features.Queries.Landmark;
using MedRouter.Core.Features.Queries.Location;
using MedRouter.Core.Features.Queries.Route;

namespace MedRouter.Core.Mappings;


public class GeneralProfile : Profile
{
    public GeneralProfile()
    {
        CreateMap<CreateLocationCommand, Location>();
        CreateMap<Location, GetLocationViewModel>();
        CreateMap<UpdateLocationCommand, Location>();
        CreateMap<CreateHospitalCommand, Hospital>();
        CreateMap<Hospital, GetHospitalViewModel>();
        CreateMap<UpdateHospitalCommand, Hospital>();
        CreateMap<CreateHotelCommand, Hotel>();
        CreateMap<UpdateHotelCommand, Hotel>();
        CreateMap<Hotel, GetHotelViewModel>();
        CreateMap<Landmark, GetLandmarkViewModel>();
        CreateMap<CreateLandmarkCommand, Landmark>();
        CreateMap<UpdateLandmarkCommand, Landmark>();
        CreateMap<CreateRouteCommand, Route>();
        CreateMap<UpdateRouteCommand, Route>();
        CreateMap<Route, GetRouteViewModel>();
        CreateMap<Route, GetRouteViewModel>();
    }
}
