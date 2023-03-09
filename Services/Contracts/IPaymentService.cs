using DependencyRoomBooking.Models;

namespace DependencyRoomBooking.Services.Contracts
{
    public interface IPaymentService
    {
        Task<PaymentResponse?> GetPaymentAsync(string email, CreditCard creditCard);
    }
}
