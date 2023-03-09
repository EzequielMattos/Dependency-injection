using Dapper;
using DependencyRoomBooking.Models;
using DependencyRoomBooking.Repositories.Contracts;
using Microsoft.Data.SqlClient;

namespace DependencyRoomBooking.Repositories
{
    public class CustumerRepository : ICustomerRepository
    {
        private readonly SqlConnection _connection;

        public CustumerRepository(SqlConnection connection) => _connection = connection;

        public async Task<Customer?> GetByIdAsync(string email)
        {
            const string query = "SELECT * FROM [Customer] WHERE [Email]=@email";
            return await _connection.QueryFirstAsync<Customer?>(query, new { email = email });
        }
    }
}
