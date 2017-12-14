namespace Vavatech.TicketSystem.Models
{
    public class Developer : User
    {
        public decimal AmountPerHour { get; set; }

        public Developer(string firstName, string lastName, decimal amountPerHour = 100)
            : base(firstName, lastName)
        {
            this.AmountPerHour = amountPerHour;
        }
    }
}
