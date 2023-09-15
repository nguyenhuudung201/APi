using HotelApi.Data;
using HotelApi.Models;
using HotelApi.Repository.Abastract;

namespace HotelApi.Repository.Implementation
{
    public class RoomRepostory : IRoomRepository
    {
        private readonly DatabaseContext _context;
		public RoomRepostory(DatabaseContext context)
		{
			this._context = context;
		}
        public bool Add(Room model)
        {
			try
			{
				_context.Rooms.Add(model);
				_context.SaveChanges();
				return true;
			}
			catch (Exception ex)
			{

				return false;
			}
        }

       
       
    }
}
