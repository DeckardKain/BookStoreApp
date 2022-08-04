using AutoMapper;
using BookStoreApp.API.Data;
using BookStoreApp.API.Models.Author;

namespace BookStoreApp.API.Configurations
{
    public class MapperConfig : Profile
    {
        public MapperConfig()
        {
            CreateMap<UpdateAuthorDTO, Author>().ReverseMap();
            CreateMap<GetAuthorDTO, Author>().ReverseMap();
            CreateMap<BaseAuthorDTO, Author>().ReverseMap();
            CreateMap<GetAuthorsDTO, Author>().ReverseMap();
            CreateMap<CreateAuthorDTO, Author>().ReverseMap();
        }
    }
}
