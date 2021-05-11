using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ByteBank.Models.Resources;
using ByteBank.Models.Exceptions;
using ByteBank.Models.Interfaces;
using ByteBank.Models.Models;
using Humanizer;


namespace ByteBank.AgencySystem
{
    class Program
    {
        static void Main(string[] args)
        {
            Customer customer = new Customer("Ivan", "012345", "Developer");
            CurrentAcoount cc = new CurrentAcoount("12345", "678910", customer);
            Console.WriteLine(cc.ToString());

            Director director = new Director("Maria", "456", 10.500, "123456789");
            Console.WriteLine(director.Authenticate("123456789"));

            DateTime dt = new DateTime(1976, 5, 21);

            Console.WriteLine(dt);

            TimeSpan diff = TimeSpan.FromMinutes(40);
            string msg = "Due date in " + TimeSpanHumanizeExtensions.Humanize(diff);
            Console.WriteLine(msg);

            Console.WriteLine("");
            Console.WriteLine("Press any key to finish it...");
            Console.ReadLine();
        }
    }
}
