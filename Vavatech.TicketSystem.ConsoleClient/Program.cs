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


            // Zadanie #1
            // Utwórz ticket na podstawie parametrów wprowadzonych przez użytkownika

            Console.Write("Podaj temat: ");

            string subject = Console.ReadLine();

            Console.Write("Podaj opis: ");

            string description = Console.ReadLine();

            Console.Write("Podaj imię autora: ");

            string firstName = Console.ReadLine();

            Console.Write("Podak nazwisko autora: ");

            string lastName = Console.ReadLine();

            Developer developer = new Developer(firstName, lastName);

            Ticket ticket = new Ticket(subject, description, developer);

            // Wyświetl komunikat:
            // "Dziękujemy {imię autora} {nazwisko autora} za utworzenie zgłoszenia"

            Console.WriteLine($"Dziękujemy {ticket.Author.FirstName} {ticket.Author.LastName} za utworzenie zgłoszenia");


            // ClassTest();

            Console.WriteLine("Press any key to exit.");

            Console.ReadKey();
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
