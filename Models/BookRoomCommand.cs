namespace DependencyRoomBooking.Models;

public class BookRoomCommand
{
    public BookRoomCommand(string email, DateTime day, CreditCard creditCard)
    {
        Email = email;
        RoomId = Guid.NewGuid().ToString().ToUpper().Substring(0, 8);
        Day = day;
        CreditCard = creditCard;
    }

    public string Email { get; set; }
    public string RoomId { get; set; }
    public DateTime Day { get; set; }
    public CreditCard CreditCard { get; set; }
}   


