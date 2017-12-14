using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Vavatech.TicketSystem.Models;
using System.Threading;

namespace Vavatech.TicketSystem.UnitTests
{
    [TestClass]
    public class TicketUnitTests
    {

        [TestMethod]
        public void NewTicketTest()
        {

            // Inicjalizacja

            Ticket ticket = new Ticket();
            ticket.Subject = "Nie działa mainframe";
            ticket.Description = "...";

            User user = new Employee("Tomasz", "Woźniak");

            ticket.Author = user;

            Developer developer = new Developer("Marcin", "Sulecki");

            ticket.Owner = developer;
            ticket.CreateDate = DateTime.Now;



            // Operacja

            // Sprawdzenie

            Assert.AreEqual(TicketStatus.Created, ticket.Status, "Błędny status");

            Assert.IsNull(ticket.SolutionDate, "Data rozwiązania powinna być pusta");




        }

        [TestMethod]
        public void FixedTicketTest()
        {

            // Inicjalizacja

            Ticket ticket = new Ticket();
            ticket.Subject = "Nie działa mainframe";
            ticket.Description = "...";

            User user = new Employee("Tomasz", "Woźniak");

            ticket.Author = user;

            Developer developer = new Developer("Marcin", "Sulecki");

            ticket.Owner = developer;
            ticket.CreateDate = DateTime.Now;

            // Operacja

            Thread.Sleep(TimeSpan.FromSeconds(5));

            ticket.Status = TicketStatus.Fixed;

            // Sprawdzenie

            Assert.IsFalse(string.IsNullOrEmpty(ticket.Subject), "Brak tytułu");

            Assert.IsFalse(string.IsNullOrEmpty(ticket.Description), "Brak opisu");

            Assert.IsNotNull(ticket.Author, "Brak autora");

            Assert.IsNotNull(ticket.CreateDate, "Brak daty utworzenia");


            Assert.IsNotNull(ticket.Owner, "Brak właściciela");

            Assert.AreEqual(TicketStatus.Fixed, ticket.Status, "Błędny status");

            Assert.IsNotNull(ticket.SolutionDate, "Brak daty rozwiązania");

            Assert.IsTrue(ticket.SolutionDate > ticket.CreateDate, "Data rozwiązania jest wcześniejsza niż data utworzenia");





        }
    }
}
