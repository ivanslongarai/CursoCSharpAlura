using System;
using ByteBank.Models.Models;
using ByteBank.AgencySystem.Helpers;
using System.Text.RegularExpressions;
using ByteBank.AgencySystem.List;

namespace ByteBank.AgencySystem
{
    class Program
    {
        static void Main(string[] args)
        {

            /* This code is just for test...*/

            GenericList<Customer> list = new GenericList<Customer>();

            Customer[] customerList = new Customer[]
            {
                new Customer("Ivan", "000000", "Developer"),
                new Customer("Maria", "000000", "Director"),
                new Customer("José", "000000", "Driver")
            };

            list.Add(customerList);
            Console.WriteLine(list.Count());
            list.ListAll();
            list.Remove(new Customer("Maria", "000000", "Director"));
            Console.WriteLine(list.Count());
            list.ListAll();

            Console.WriteLine("");
            Console.WriteLine($"Indexer {0}: {list[0]}");
            Console.WriteLine($"Indexer {1}: {list[1]}");

            list.Add(customerList);

            Wait();

        }

        static void ModuleSeven04()
        {
            /* This code is just for test...*/

            ObjectList list = new ObjectList();

            Customer[] customerList = new Customer[]
            {
                new Customer("Ivan", "000000", "Developer"),
                new Customer("Maria", "000000", "Director"),
                new Customer("José", "000000", "Driver")
            };

            list.Add(customerList);
            Console.WriteLine(list.Count());
            list.ListAll();
            list.Remove(new Customer("Maria", "000000", "Director"));
            Console.WriteLine(list.Count());
            list.ListAll();

            Console.WriteLine("");
            Console.WriteLine($"Indexer {0}: {list[0]}");
            Console.WriteLine($"Indexer {1}: {list[1]}");

            list.Add(customerList);

            Wait();
        }

        static void ModuleSeven03()
        {
            /* This code is just for test...*/

            CurrentAccountArrayList list = new CurrentAccountArrayList();

            Customer customer = new Customer("Ivan", "12345678911", "Developer");


            CurrentAcoount[] currentAcoountArray = new CurrentAcoount[]
            {
                new CurrentAcoount("123", "000000", customer),
                new CurrentAcoount("456", "000000", customer),
                new CurrentAcoount("789", "000000", customer)
            };

            list.Add(currentAcoountArray);

            list.Add(
                new CurrentAcoount("123", "000000", customer),
                new CurrentAcoount("456", "000000", customer),
                new CurrentAcoount("789", "000000", customer));

            foreach (CurrentAcoount cc in currentAcoountArray)
                list.Add(cc);

            Console.WriteLine(list.Count());
            list.ListAll();
            list.Remove(new CurrentAcoount("456", "000000", customer));
            Console.WriteLine(list.Count());
            list.ListAll();

            try
            {
                int index = 1;
                Console.WriteLine($"ByIndex {index}: {list.GetByIndex(index)}");
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }

            try
            {
                Console.WriteLine($"Indexer {1}: {list[100]}");
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }

            Console.WriteLine();
            Wait();
        }

        static void ModuleSeven02()
        {

            /* This code is just for test...*/

            Customer customer = new Customer("Ivan", "12345678911", "Developer");
            
            CurrentAcoount[] currentAcoountArray = new CurrentAcoount[] 
            {
                new CurrentAcoount("123", "112233", customer),
                new CurrentAcoount("456", "445566", customer),
                new CurrentAcoount("789", "778899", customer)
            };

            foreach (CurrentAcoount cc in currentAcoountArray) {
                Console.WriteLine(cc.ToString());
            }

            Array.Resize(ref currentAcoountArray, currentAcoountArray.Length + 1);
                currentAcoountArray[3] = new CurrentAcoount("000", "999999", customer);
            Console.WriteLine(currentAcoountArray[3].ToString());

            Wait();

        }

        static void ModuleSeven01()
        {
            /* This code is just for test...*/

            int[] ages = new int[3];

            ages[0] = 10;
            ages[1] = 20;
            ages[2] = 30;

            float average = 0;

            for (int i = 0; i < ages.Length; i++)
            {
                average += ages[i];
            }

            average /= ages.Length;
            Console.WriteLine($"The average of the ages array values is {average}");

            Wait();
        }

        static void ModuleSix()
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

            Wait();

        }

        static void Wait()
        {
            Console.WriteLine("");
            Console.WriteLine("Press any key to finish it...");
            Console.ReadLine();
        }
    }
}
