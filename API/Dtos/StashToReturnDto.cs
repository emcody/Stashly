using System;
using System.Collections.Generic;

namespace API.Dtos
{
    public class StashToReturnDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public Guid OwnerId { get; set; }
        public string Location { get; set; }
        public string Description { get; set; }
        public ICollection<ItemToReturnDto> Items { get; set; }
    }
}