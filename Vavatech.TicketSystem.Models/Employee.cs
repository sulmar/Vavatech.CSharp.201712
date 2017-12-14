namespace Vavatech.TicketSystem.Models
{
    public class Employee : User
    {
        public decimal? Salary { get; set; }

        public Employee(string firstName, string lastName)
            : base(firstName, lastName)
        {

        }
    }
}
