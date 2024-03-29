﻿using AutoMapper;
using BookStoreApp.API.Data;
using BookStoreApp.API.Models.Author;
using BookStoreApp.API.Models.Book;
using BookStoreApp.API.Models.User;

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


            CreateMap<BookCreateDTO, Book>().ReverseMap();
            CreateMap<BookUpdateDTO, Book>().ReverseMap();
            CreateMap<Book, BookReadyOnlyDTO>()
                .ForMember(q => q.AuthorName, d => d.MapFrom(map => $"{map.Author.FirstName} {map.Author.LastName}"))
                .ReverseMap();

            CreateMap<Book, BookDetailsDTO>()
                .ForMember(q => q.AuthorName, d => d.MapFrom(map => $"{map.Author.FirstName} {map.Author.LastName}"))
                .ReverseMap();


            CreateMap<ApiUser, UserDTO>().ReverseMap();



        }
    }
}
