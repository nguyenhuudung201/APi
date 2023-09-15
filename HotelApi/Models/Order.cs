
namespace HotelApi.Models
{
    public class Order
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public int RoomId { get; set; }
        public DateTime CheckIn { get; set; }
        public DateTime ChecKOut { get; set; }
        public double Total { get; set; }
        public int Adult { get; set; }
        public int Child { get; set; }
        public string? OrderStatus { get; set; }
        public string? Request { get; set; }
        
    }
}
    