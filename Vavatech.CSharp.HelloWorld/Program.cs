using System;

namespace Vavatech.CSharp.HelloWorld
{
    class Program
    {
        static void Main(string[] args)
        {
            InputIntTest();

            // VariableTest();

           //  InputTest();

            // HelloWorldTest();

            Console.WriteLine("Press any key to exit.");

            Console.ReadKey();
        }


        static void InputIntTest()
        {
            Console.Write("Podaj temp.: ");

            string input = Console.ReadLine();

            sbyte temp = sbyte.Parse(input);

            Console.WriteLine($"Temp: {temp}C");
        }

        static void VariableTest()
        {
            // 0..255
            byte age = 99;

            Console.WriteLine($"byte {byte.MinValue} .. {byte.MaxValue}");

            sbyte temp = -40;

            Console.WriteLine($"sbyte {sbyte.MinValue} .. {sbyte.MaxValue}");

            // Int 16, -32768..32767
            short x = 32000;

            Console.WriteLine($"short {short.MinValue} .. {short.MaxValue}");

            ushort z = 64000;

            Console.WriteLine($"ushort {ushort.MinValue} .. {ushort.MaxValue}");

            // Int 32, -2147483648..2147483647
            int number = 99;

            Console.WriteLine($"int {int.MinValue} .. {int.MaxValue}");

            uint a = 3000;

            Console.WriteLine($"uint {uint.MinValue} .. {uint.MaxValue}");

            // Int64 -9223372036854775808..9223372036854775807
            long y = 100;

            Console.WriteLine($"long {long.MinValue} .. {long.MaxValue}");

            ulong b = 2000;

            Console.WriteLine($"ulong {ulong.MinValue} .. {ulong.MaxValue}");

        }

        static void InputTest()
        {
            Console.Write("Podaj imię: ");

            string firstName = Console.ReadLine();

            Console.Write("Podaj nazwisko: ");

            string lastName = Console.ReadLine();

            // zła praktyka:
            // string message = "Witaj " + firstName + " " + lastName + "!";

            // string message = String.Format("Witaj {0} {2}!", firstName, lastName);

            // Interpolacja C# 6.0 .NET 4.5 
            string message = $"Witaj {firstName} {lastName}!";

            Console.WriteLine(message);
        }


        static void HelloWorldTest()
        {
            Console.WriteLine("Hello World!");
        }
    }
}
