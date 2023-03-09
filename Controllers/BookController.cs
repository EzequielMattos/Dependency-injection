using Dapper;
using DependencyRoomBooking.Models;
using DependencyRoomBooking.Repositories.Contracts;
using DependencyRoomBooking.Services.Contracts;
using Microsoft.AspNetCore.Mvc;

namespace DependencyRoomBooking.Controllers;

[ApiController]
public class BookController : ControllerBase
{
    private readonly ICustomerRepository _customerRepository;
    private readonly IAvaliableBookService _avaliableBookService; 
    private readonly IPaymentService _paymentService;

    public BookController(ICustomerRepository customerRepository, IAvaliableBookService avaliableBookService, IPaymentService paymentService)
    {
        _customerRepository = customerRepository;
        _avaliableBookService = avaliableBookService;
        _paymentService = paymentService;
    }

    [Route("v1/orders")]
    [HttpPost]
    public async Task<IActionResult> Book(BookRoomCommand command)
    {
        // Recupera o usuário
        var customer = await _customerRepository.GetByIdAsync(command.Email);
        if (customer == null)
            return NotFound();

        // Verifica se a sala está disponível
        var book = await _avaliableBookService.GetRoomsAsync(command.RoomId, command.Day, command.Day);
        // Se existe uma reserva, a sala está indisponível
        if (book is not null)
            return BadRequest();

        // Tenta fazer um pagamento
        var payment = await _paymentService.GetPaymentAsync(command.Email, command.CreditCard);

        // Se a requisição não pode ser completa
        if (payment is null)
            return BadRequest();

        // Se o status foi diferente de "pago"
        if (payment?.Status != "paid")
            return BadRequest();

        // Cria a reserva
        var completeBook = new BookRoomCommand(customer.Email, command.Day, command.CreditCard);
        return Ok(completeBook.RoomId);
    }
}

