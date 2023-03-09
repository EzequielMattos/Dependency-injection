using Dapper;
using DependencyRoomBooking.Models;
using DependencyRoomBooking.Services.Contracts;
using Microsoft.Data.SqlClient;

namespace DependencyRoomBooking.Services
{
    public class AvaliableBookService : IAvaliableBookService
    {
        private readonly SqlConnection _connection;
        public AvaliableBookService(SqlConnection connection) => _connection = connection;

        public async Task<Book?> GetRoomsAsync(string roomId, DateTime start, DateTime end)
        {
            const string query = "SELECT * FROM [Book] WHERE [Room]=@room AND [Date] BETWEEN @dateStart AND @dateEnd";
            return await _connection.QueryFirstOrDefaultAsync<Book?>(query,
                new
                {
                    Room = roomId,
                    DateStart = start,
                    DateEnd = end.Date.AddDays(1).AddTicks(-1),
                });
        }
    }
}
