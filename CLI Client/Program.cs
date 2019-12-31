using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace CLI_Client
{
    class Program
    {
        static void Main(string[] args) {
            Console.ForegroundColor = ConsoleColor.Yellow;

            int i;
            for (i = 1; i <= 100; i++) {
                Print();
            }

            void Print() {
                Console.WriteLine(i);
            }

            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("Press any key to continue... ");
            Console.ReadKey();
        }
    }
}
