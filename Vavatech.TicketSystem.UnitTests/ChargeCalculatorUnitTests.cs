using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Vavatech.TicketSystem.Logic;

namespace Vavatech.TicketSystem.UnitTests
{
    [TestClass]
    public class ChargeCalculatorUnitTests
    {
        private ChargeCalculator chargeCalculator;


        [TestInitialize]
        public void Init()
        {
            // Inicjalizacja
            chargeCalculator = new ChargeCalculator();
        }

        [TestMethod]
        public void CalculateTest()
        {
            // Przypadek testowy 
            decimal amountPerHour = 100;
            TimeSpan period = TimeSpan.FromHours(2);

            // Akcja
            decimal totalAmount = chargeCalculator.Calculate(amountPerHour, period);

            // Sprawdzenie 

            Assert.AreEqual(200, totalAmount);

        }

        [ExpectedException(typeof(ArgumentNullException))]
        [TestMethod]
        public void CalculateZeroTest()
        {
            // Przypadek testowy 
            decimal amountPerHour = 0;
            TimeSpan period = TimeSpan.FromHours(2);

            // Akcja
            decimal totalAmount = chargeCalculator.Calculate(amountPerHour, period);

            // Sprawdzenie 

            Assert.AreEqual(0, totalAmount);

        }
    }
}
