namespace DependencyRoomBooking.Models
{
    public class Book
    {
        public string Email { get; set; }
        public Guid Room { get; set; }
        public DateTime Date { get; set; }
    }
}
