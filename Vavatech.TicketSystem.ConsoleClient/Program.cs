using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vavatech.TicketSystem.Models;

namespace Vavatech.TicketSystem.ConsoleClient
{
    class Program
    {


        static void Main(string[] args)
        {
            Console.WriteLine("Welcome in Ticket System!");

            int x = 10;

            Display(x);

            Console.WriteLine(x);

            User user = new Employee();
            user.FirstName = "Marcin";
            user.LastName = "Sulecki";

            user.Pesel = "01234567891";
            Console.WriteLine(user.Pesel);

            Display(user);

            Console.WriteLine(user.FirstName);


            User user2 = new Employee();
            user2.FirstName = "Tomek";
            user2.LastName = "Woźniak";

            Developer user3 = new Developer();
            user3.FirstName = "Kornel";
            user3.LastName = "Klimczak";

            Ticket ticket1 = new Ticket();
            ticket1.Status = TicketStatus.Created;
            ticket1.Subject = "Mainframe nie działa!";
            ticket1.Description = "nie wiem dlaczego.";
            ticket1.Author = user2;
            ticket1.Owner = user3;
            ticket1.CreateDate = DateTime.Now;


            Ticket ticket2 = new Ticket();
            ticket2 = ticket1;
            ticket2.Author = user;
            ticket2.CreateDate = DateTime.Now;


            Console.WriteLine("Press any key to exit.");

            Console.ReadKey();
        }

        private static void Display(User user)
        {
            Console.WriteLine(user.FirstName);

            user.FirstName = "Jan";

            Console.WriteLine(user.FirstName);
        }

        private static void Display(int number)
        {
            Console.WriteLine(number);

            number++;

            Console.WriteLine(number);
        }

    }
}
