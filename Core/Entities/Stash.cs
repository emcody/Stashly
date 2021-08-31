using System;
using System.Collections.Generic;

namespace Core.Entities
{
    public class Stash : BaseEntity
    {
        public string Name { get; set; }
        //TODO -add identity to the project
        //public User Owner { get; set; }
        public Guid OwnerId { get; set; }
        public string Location { get; set; }
        public string Description { get; set; }
        public ICollection<Item> Items { get; set; }
    }
}