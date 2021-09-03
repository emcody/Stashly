using System;

namespace Core.Entities
{
    public class Item : BaseEntity
    {
        public string Name { get; set; }
        public int Quantity { get; set; }
        public string Description { get; set; }
        public string PictureUrl { get; set; }
        public DateTime? ExpirationDate { get; set; }
        public int StashId { get; set; }
        public Stash Stash { get; set; }
    }
}