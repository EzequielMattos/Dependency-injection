using DependencyRoomBooking.Models;

namespace DependencyRoomBooking.Repositories.Contracts
{
    public interface ICustomerRepository
    {
        Task<Customer?> GetByIdAsync(string email);
    }
}
