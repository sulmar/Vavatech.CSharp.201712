using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Linq;
using Vavatech.TicketSystem.Models;
using Vavatech.TicketSystems.IServices;

namespace Vavatech.TicketSystem.ConsoleClient
{
    class Program
    {


        static void Main(string[] args)
        {
            string filename = @"SampleData\users.txt";

            var users = GetUsers(filename);
            
            string ticketsFilename = @"SampleData\tickets.txt";

            //var tickets = GetTickets(ticketsFilename);

            ITicketsService ticketsService = new MockTicketsService();

            var tickets = ticketsService.Get();


            // SELECT * FROM Tickets WHERE FullName = 'Marcin Sulecki' 
            // ORDER BY Subject

            #region 

            var filteredTickets = new List<Ticket>();

            foreach (var ticket in tickets)
            {
                if (ticket.Author.FullName == "Marcin Sulecki")
                {
                    filteredTickets.Add(ticket);
                }
            }

            #endregion

            var x = new { FirstName = "Marcin", Qty = 100 };



            var totalNumber = tickets
                .Where(t => t.Author.FullName == "Marcin Sulecki")
                .Sum(t=>t.Cost);


            var groupByQuery = tickets
                .GroupBy(ticket => ticket.Author.FullName)
                .Select(group => new { group.Key, group });

            var total = groupByQuery
                    .Select(g => new { Author = g.Key, Qty = g.group.Count() });


            var groupByQuery2 = from ticket in tickets
                                group ticket by ticket.Author into g
                                select new { Author = g.Key, Tickets = g };


            var ticketsGroupedByYear = tickets
                    .GroupBy(ticket => ticket.CreateDate.Year)
                    .Select(g => new { Year = g.Key, Tickets = g });


            var filteredTicketsLambda = tickets
                .Where(ticket => ticket.Author.FullName == "Marcin Sulecki")
                .OrderBy(t => t.Subject)
                .Select(t => new { t.Subject, t.CreateDate });

            // linq expression

            var query = from ticket in tickets
                            join user in users  
                                on ticket.Author.FullName equals user.FullName
                        where ticket.Author.FullName == "Marcin Sulecki"
                        // where ticket.CreateDate.Year == 2017
                        orderby ticket.Subject
                        select new { ticket, user.FirstName, };


            var list = filteredTicketsLambda.ToList();

            foreach (var item in filteredTicketsLambda)
            {
                Console.WriteLine(item.Subject);
            }

            Console.WriteLine();

            // ArrayTest();

            // ManualInputTickets();


            // ClassTest();

            Console.WriteLine();

            Console.WriteLine("Press any key to exit.");

            Console.ReadKey();
        }

        private static List<Ticket> GetTickets(string filename)
        {
            const byte numberOfFields = 4;

            var tickets = new List<Ticket>();

            string[] lines = System.IO.File.ReadAllLines(filename);

            foreach (string line in lines)
            {
                string[] fields = line.Split(';');

                if (fields.Length >= numberOfFields)
                {
                    string subject = fields[0];
                    string description = fields[1];
                    string fullname = fields[2];
                    DateTime createDate = DateTime.Parse(fields[3]);

                    string[] fieldsFullName = fullname.Split(' ');
                    string firstName = fieldsFullName[0];
                    string lastName = fieldsFullName[1];

                    var author = new Employee(firstName, lastName);

                    var ticket = new Ticket(subject, description, author)
                    {
                        CreateDate = createDate
                    };

                    tickets.Add(ticket);
                }
            }

            return tickets;
        }

        private static List<User> GetUsers(string filename)
        {
            const byte numberOfFields = 2;

            List<User> users = new List<User>();

            string[] lines = System.IO.File.ReadAllLines(filename);

            foreach (string line in lines)
            {
                string[] fields = line.Split(';');

                if (fields.Length >= numberOfFields)
                {
                    string firstName = fields[0];
                    string lastName = fields[1];

                    var user = new Employee(firstName, lastName);

                    users.Add(user);
                }
            }

            return users;
        }

        private static void ManualInputTickets()
        {
            List<User> users = new List<User>();

            var developer1 = new Developer("Marcin", "Sulecki");

            users.Add(developer1);
            users.Add(new Developer("Tomasz", "Woźniak"));
            users.Add(new Employee("Kornel", ""));

            foreach (User user in users)
            {
                Console.WriteLine(user.FullName);
            }



            var developerInfo = new { FirstName = developer1.FirstName, Salary = developer1.AmountPerHour };

            // anonymous_23oo45u2395we9iur9w34987w3947w39847


            // x = "Hello";


            Console.WriteLine("Welcome in Ticket System!");

            ConsoleKeyInfo input;

            // Zadanie #1
            // Utwórz ticket na podstawie parametrów wprowadzonych przez użytkownika

            List<Ticket> tickets = new List<Ticket>();

            do
            {
                var ticketParameters = TicketView();
                var user = UserView();

                Developer developer = new Developer(user.firstName, user.lastName);

                // Tworzymy ticket
                Ticket ticket = new Ticket(ticketParameters.subject, ticketParameters.description, developer);

                // Dodajemy do listy ticketów
                tickets.Add(ticket);

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


            Console.WriteLine("Wprowadzone zgłoszenia:");

            foreach (Ticket ticket in tickets)
            {
                Console.WriteLine(ticket.Subject);
            }
        }

        private static void ArrayTest()
        {
            int[] numbers = new int[100000];

            numbers[0] = 10;
            numbers[1] = 5;
            numbers[3] = 2;


            int[] happyNumbers = new int[] { 10, 5, 2 };



            Console.WriteLine(numbers[2]);
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
