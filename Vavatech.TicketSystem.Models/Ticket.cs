using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vavatech.TicketSystem.Models
{
    public class Ticket : Base
    {
        #region Properties

        public string Subject { get; set; }

        public string Description { get; set; }

        public DateTime CreateDate { get; set; }

        public DateTime? SolutionDate { get; set; }

        public User Author { get; set; }

        public Developer Owner { get; set; }

        private TicketStatus status;
        public TicketStatus Status
        {
            get
            {
                return status;
            }

            set
            {
                this.status = value;

                if (this.status == TicketStatus.Fixed)
                {
                    SolutionDate = DateTime.Now;
                }
            }
        }

        #endregion

        #region  Constructor

        
        public Ticket(string subject, string description, User author)
            : this()
        {
            this.Subject = subject;
            this.Description = description;
            this.Author = author;
        }

        public Ticket()
        {
            this.CreateDate = DateTime.Now;
            this.Status = TicketStatus.Created;
        }

        #endregion

        #region Methods

        public void Display()
        {
            Console.WriteLine($"Subject: {Subject} - {Description}");
        }

        #endregion


    }
}
