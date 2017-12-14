using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vavatech.TicketSystem.Models
{
    public abstract class User : Base
    {
        private string firstName;

        public string FirstName
        {
            get
            {
                return firstName;
            }

            set
            {
                firstName = value;
            }
        }

        public string LastName { get; set; }

        // back field
        private string pesel;

        // property (właściwość)
        public string Pesel
        {
            set
            {
                
                if (value.Length!=11)
                {
                    throw new ArgumentException("Pesel musi mieć 11 znaków.");
                }

                // TODO: sprawdzenie sumy kontrolnej

                this.pesel = value;

                // TODO recalculate Birthday
            }

            get
            {
                return this.pesel;
            }
        }

        //public void SetPesel(string pesel)
        //{
        //    this.pesel = pesel;
        //}

        //public string GetPesel()
        //{
        //    return this.pesel;
        //}

        public DateTime? Birthday { get; set; }

        public User(string firstName, string lastName)
        {
            this.FirstName = firstName;
            this.LastName = lastName;
        }

    }
}
