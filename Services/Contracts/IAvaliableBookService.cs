using DependencyRoomBooking.Models;

namespace DependencyRoomBooking.Services.Contracts
{
    public interface IAvaliableBookService
    {
        Task<Book?> GetRoomsAsync(string roomId, DateTime start, DateTime end);
    }
}
