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
                .ForMember(dest => dest.CreatedDate, opt => opt.MapFrom(src => DateTime.UtcNow))
                .ForMember(dest => dest.UpdatedDate, opt => opt.MapFrom(src => DateTime.UtcNow));
        }
    }
}
