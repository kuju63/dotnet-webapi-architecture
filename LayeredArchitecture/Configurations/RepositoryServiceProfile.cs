using AutoMapper;

using LayeredArchitecture.Repositories.Models;
using LayeredArchitecture.Services.Models;

namespace LayeredArchitecture.Configurations;

public class RepositoryServiceProfile : Profile
{
    public RepositoryServiceProfile()
    {
        CreateMap<Book, BookModel>();
    }
}