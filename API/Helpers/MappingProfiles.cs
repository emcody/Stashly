using System.Collections.Generic;
using API.Dtos;
using AutoMapper;
using Core.Entities;

namespace API.Helpers
{
    public class MappingProfiles : Profile
    {
        public MappingProfiles()
        {
            CreateMap<Stash,StashToReturnDto>();
            CreateMap<Item,ItemToReturnDto>()
                .ForMember(i=>i.PictureUrl, o=> o.MapFrom<ItemUrlResolver>());
        }
    }
}