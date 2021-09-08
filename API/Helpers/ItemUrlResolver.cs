using API.Dtos;
using AutoMapper;
using Core.Entities;
using Microsoft.Extensions.Configuration;

namespace API.Helpers
{
    public class ItemUrlResolver : IValueResolver<Item, ItemToReturnDto, string>
    {
        private readonly IConfiguration _config;
        public ItemUrlResolver(IConfiguration config)
        {
            _config = config;
        }

        public string Resolve(Item source, ItemToReturnDto destination, string destMember, ResolutionContext context)
        {
            if (!string.IsNullOrEmpty(source.PictureUrl))
            {
                return _config["ApiUrl"]+ source.PictureUrl;
            }

            return null;
        }
    }
}