using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vavatech.TicketSystem.Models;

namespace Vavatech.CSharp.HelloWorld
{

    // Klasa generyczna (generic class)
    class Printer
    {
        //private Blabla currentItem;

        //public Blabla GetItem()
        //{
        //    return currentItem;
        //}

        // Metoda generyczna (generic method)
        public void Print<TItem>(TItem item)
        {
            // ..
            Console.WriteLine(item);
        }


        //public void Print(string item)
        //{
        //    // ..

        //    Console.WriteLine(item);
        //}


        //public void Print(int item)
        //{
        //    // ..
        //    Console.WriteLine(item);
        //}

        //public void Print(DateTime item)
        //{
        //    // ..
        //    Console.WriteLine(item);
        //}

        //public void Print(Ticket item)
        //{
        //    // ..
        //    Console.WriteLine(item);
        //}
    }
}
