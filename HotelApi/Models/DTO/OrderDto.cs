namespace HotelApi.Models.DTO
{
    public class OrderDto
    {
        public string UserName { get; set; }
        public string RoomName { get; set; }
        public  DateTime CheckIn { get; set; }
        public DateTime CheckOut { get; set; }
        public double Total { get; set; }
        public int Adult { get; set; }
        public int Child { get; set; }
        public string? OrderStatus { get; set; }
        public string? Request { get; set; }
    }
}
