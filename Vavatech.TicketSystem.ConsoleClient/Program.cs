using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Vavatech.TicketSystem.Models;

namespace Vavatech.TicketSystem.ConsoleClient
{
    class Program
    {


        static void Main(string[] args)
        {
            var developer1 = new Developer("Marcin", "Sulecki");

            var developerInfo = new { FirstName = developer1.FirstName, Salary = developer1.AmountPerHour };

            // anonymous_23oo45u2395we9iur9w34987w3947w39847


            // x = "Hello";


            Console.WriteLine("Welcome in Ticket System!");

            ConsoleKeyInfo input;

            // Zadanie #1
            // Utwórz ticket na podstawie parametrów wprowadzonych przez użytkownika

            do
            {
                var ticketParameters = TicketView();
                var user = UserView();

                Developer developer = new Developer(user.firstName, user.lastName);

                // Tworzymy ticket
                Ticket ticket = new Ticket(ticketParameters.subject, ticketParameters.description, developer);

                // Wyświetl komunikat:
                Display(ticket);

                // Przetwarzanie 
                Proccess(ticket);

                // Zakończenie
                Finish(ticket);

                Console.WriteLine("(q)uit");

                input = Console.ReadKey();

            }
            // while (input.KeyChar != 'Q' && input.KeyChar != 'q');
            while (!IsExitKey(input.KeyChar));


            // ClassTest();

            Console.WriteLine();

            Console.WriteLine("Press any key to exit.");

            Console.ReadKey();
        }

        private static void Display(Ticket ticket)
        {
            Console.WriteLine($"Dziękujemy {ticket.Author.FullName} za utworzenie zgłoszenia");
        }

        private static void Finish(Ticket ticket)
        {
            ticket.Status = TicketStatus.Fixed;
        }

        private static (string subject, string description) TicketView()
        {
            Console.Write("Podaj temat: ");
            string subject = Console.ReadLine();

            Console.Write("Podaj opis: ");
            string description = Console.ReadLine();

            return (subject, description);

        }

        // Install-Package System.ValueTypes
        private static (string firstName, string lastName) UserView()
        {
            Console.Write("Podaj imię autora: ");
            string firstName = Console.ReadLine();

            Console.Write("Podak nazwisko autora: ");
            string lastName = Console.ReadLine();

            return (firstName, lastName);
        }

        private static void Proccess(Ticket ticket)
        {
            Console.WriteLine("Przetwarzanie zgłoszenia...");
            ticket.Status = TicketStatus.InProgress;
            ticket.Owner = new Developer("Marcin", "Sulecki");

            Thread.Sleep(TimeSpan.FromSeconds(5));
        }

        private static bool IsExitKey(char sign)
        {
            return sign == 'Q' || sign == 'q';
        }

        private static void ClassTest()
        {
            int x = 10;

            Display(x);

            Console.WriteLine(x);

            User user = new Employee("Marcin", "Sulecki");

            user.Pesel = "01234567891";
            Console.WriteLine(user.Pesel);

            Display(user);

            Console.WriteLine(user.FirstName);


            User user2 = new Employee("Tomek", "Woźniak");

            Developer user3 = new Developer("Kornel", "Klimczak");

            Ticket ticket1 = new Ticket();
            ticket1.Subject = "Mainframe nie działa!";
            ticket1.Description = "nie wiem dlaczego.";
            ticket1.Author = user2;
            ticket1.Owner = user3;
            ticket1.CreateDate = DateTime.Now;


            Ticket ticket2 = new Ticket();
            ticket2 = ticket1;
            ticket2.Author = user;
            ticket2.CreateDate = DateTime.Now;
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
