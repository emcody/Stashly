using System;

namespace API.Dtos
{
    public class ItemToReturnDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Quantity { get; set; }
        public string Description { get; set; }
        public string PictureUrl { get; set; }
        public DateTime? ExpirationDate { get; set; }
    }
}