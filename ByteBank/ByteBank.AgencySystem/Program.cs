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
using ByteBank.AgencySystem.Helpers;
using System.Text.RegularExpressions;

namespace ByteBank.AgencySystem
{
    class Program
    {
        static void Main(string[] args)
        {

            /* This code is just for test...*/

            Customer c = new Customer("Ivan", "888", "Developer");
            CurrentAcoount cc = new CurrentAcoount("123", "654", c);

            Customer c1 = new Customer("Ivan", "888", "Programador");
            CurrentAcoount cc1 = new CurrentAcoount("123", "654", c1);

            if (cc.Equals(cc1))
                Console.WriteLine("Those are the same");
            else
                Console.WriteLine("Those are different");

            /********************************************************************************************************/

            string pattern = "[0-9]{4,5}-?[0-9]{4}";

            string text01 = "Lorem Ipsum is simply dummy 12345-6789 text of the printing and typesetting";
            string text02 = "Lorem Ipsum is simply dummy 0123-4567 text of the printing and typesetting";

            Match result01 = Regex.Match(text01, pattern);
            Match result02 = Regex.Match(text02, pattern);

            Console.WriteLine(result01);
            Console.WriteLine(result02);

            /********************************************************************************************************/

            Console.WriteLine(cc.ToString());

            string url0 = "https://www.bytebank.com.br/cambio?moedaOrigem=real&moedaDestino=dolar&valor=1500";
            UrlArgumentsExtractor extractor = new UrlArgumentsExtractor(url0);
            Console.WriteLine(extractor.GetValue("moedaOrigem"));
            Console.WriteLine(extractor.GetValue("moedaDestino"));
            Console.WriteLine(extractor.GetValue("valor"));

            Console.WriteLine("");
            Console.WriteLine("Press any key to finish it...");
            Console.ReadLine();

        }
    }
}
