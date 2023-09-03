using AutoMapper;

using LayeredArchitecture.Controllers;

using LayeredArchitecture.Services.Models;

namespace LayeredArchitecture.Configurations;

public class ServiceControllerProfile : Profile
{
    public ServiceControllerProfile()
    {
        CreateMap<BookModel, BookResponse>();
    }
}