using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vavatech.TicketSystem.Logic
{
    public interface IChargeCalculator
    {
        decimal Calculate(decimal amountPerHour, TimeSpan workTime);
    }

    public class HolidaysChargeCalculator : IChargeCalculator
    {
        public decimal Calculate(decimal amountPerHour, TimeSpan workTime)
        {
            return 100;
        }
    }
}
