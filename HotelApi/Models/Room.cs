using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace HotelApi.Models
{
    public class Room
    {
        public int Id { get; set; }
        [Required]
        public string? Name { get; set; }
        public string?  Desc { get;  set; }
        public double Price { get; set; }
        public string? Type { get; set; }
        public string? Image { get; set; }
        [NotMapped]
        public IFormFile? ImageFile { get; set; }
        public string? ImageDetai { get; set; }
        [NotMapped]
        public IFormFile? ImageFileDetai { get; set; }
    }
}
