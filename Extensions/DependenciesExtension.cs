using DependencyRoomBooking.Repositories;
using DependencyRoomBooking.Repositories.Contracts;
using DependencyRoomBooking.Services;
using DependencyRoomBooking.Services.Contracts;
using Microsoft.Data.SqlClient;

namespace DependencyRoomBooking.Extensions;

public static class DependenciesExtension
{
    //exemplo
    public static void AddSqlConnections(this IServiceCollection services, string connectionString)
    {
        services.AddScoped(x => new SqlConnection(connectionString));
    }

    public static void AddRepositories(this IServiceCollection services)
    {
        services.AddTransient<ICustomerRepository, CustumerRepository>();
    }

    public static void AddServices(this IServiceCollection services)
    {
        services.AddTransient<IAvaliableBookService, AvaliableBookService>();
        services.AddTransient<IPaymentService, PaymentService>();
    }
}
