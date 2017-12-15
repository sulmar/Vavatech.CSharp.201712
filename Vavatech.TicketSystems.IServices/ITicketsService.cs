using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vavatech.TicketSystem.Models;

namespace Vavatech.TicketSystems.IServices
{
    public interface ITicketsService
    {
        List<Ticket> Get();

    }


    public class MockTicketsService : ITicketsService
    {
        public void Add(Ticket ticket)
        {

        }

        public List<Ticket> Get()
        {
            var tickets = new List<Ticket>
            {

                new Ticket { Subject = "ticket 1 "},
                new Ticket { Subject = "ticket 2 "},
                new Ticket { Subject = "ticket 3 "},
            };

            return tickets;
        }
    }

    public class FileTicketsService : ITicketsService
    {
        public List<Ticket> Get()
        {
            string ticketsFilename = @"SampleData\tickets.txt";

            var tickets = GetTickets(ticketsFilename);

            return tickets;
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

    }
}
