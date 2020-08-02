using AutoMapper;
using HexadLMServices.Models;
using System;
using DataModels = HexadLMServices.Repositories.Models;

namespace HexadLMServices.Utilities
{
    public class AutoMapperHelper : Profile
    {
        public AutoMapperHelper()
        {
            CreateMap<Book, DataModels.Book>()
                .ForMember(dest => dest.BookId, opt => opt.MapFrom(src => src.Id))
                .ForMember(dest => dest.CreatedDate, opt => opt.MapFrom(src => DateTime.UtcNow))
                .ForMember(dest => dest.UpdatedDate, opt => opt.MapFrom(src => DateTime.UtcNow));

            CreateMap<Book, DataModels.BookStore>()
                .ForMember(dest => dest.BookId, opt => opt.MapFrom(src => src.Id))
                .ForMember(dest => dest.StockCount, opt => opt.MapFrom(src => src.StockCount))
                .ForMember(dest => dest.CreatedDate, opt => opt.MapFrom(src => DateTime.UtcNow))
                .ForMember(dest => dest.UpdatedDate, opt => opt.MapFrom(src => DateTime.UtcNow));

            CreateMap<DataModels.Book, Book>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.BookId))
                .ForMember(dest => dest.StockCount, opt => opt.MapFrom(src => src.BookStore.StockCount));
        }
    }
}
