using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vavatech.TicketSystem.Models
{
    public class Ticket : Base
    {
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


        public void Display()
        {
            Console.WriteLine($"Subject: {Subject} - {Description}");
        }

    }
}
