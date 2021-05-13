using System;
using ByteBank.Models.Models;
using ByteBank.AgencySystem.Helpers;
using System.Text.RegularExpressions;
using ByteBank.AgencySystem.Lists;
using System.Collections.Generic;
using ByteBank.AgencySystem.Extensions;
using ByteBank.AgencySystem.Interfaces;
using System.Linq;
using System.IO;
using System.Text;

namespace ByteBank.AgencySystem
{
    partial class Program
    {
        static void Main(string[] args)
        {            
            ModuleNine08();
        }

        static void ModuleNine08()
        {
            /* This code is just for testing...*/

            // Waring, it allocates memory for all the AcoountsWithComma file
            // it should be used just with small files... for big ones, we can use the others previous options....

            var lines = File.ReadAllLines("../../AcoountsWithComma.txt");
            Console.WriteLine(lines.Length);
            foreach (var line in lines)
                Console.WriteLine(line);

            File.WriteAllText("../../testing File.WriteAllText Method.txt", "any text....");

            var readBytes = File.ReadAllBytes("../../AcoountsWithComma.txt");
            Console.WriteLine($"The AcoountsWithComma.txt file has {readBytes.Length / 1000} Kilobytes...");

            Console.WriteLine("Inform your name please:");
            var pensonName = Console.ReadLine();
            Console.WriteLine($"The person name is: {pensonName}");
            Wait();
        }

        //using the Stream from the input console
        static void ModuleNine07()
        {
            /* This code is just for testing...*/

            using (var inputFlow = Console.OpenStandardInput())
                using (var fs = new FileStream("../../ConsoleInput.txt", FileMode.Create))
            {
                var buffer = new byte[1024];
                while (true)
                {
                    var readBytes = inputFlow.Read(buffer, 0, 1024);
                    if (readBytes <= 2)
                        break;
                    fs.Write(buffer, 0, readBytes);
                    fs.Flush();
                    Console.WriteLine($"Bytes read from the Console: {readBytes}");
                }
            }

            Wait();
        }

        //Binary writing and reading
        static void ModuleNine06()
        {
            /* This code is just for testing...*/

            //writing as binary file format
            using (var fs = new FileStream("../../CurrentAccount.txt", FileMode.Create))
                using (var writer = new BinaryWriter(fs))
            {
                writer.Write(123488); // agency
                writer.Write(567866); // number acoount
                writer.Write(9101.5); // balance
                writer.Write("Ivan"); // customer.name
            }

            //reading a binary file format
            using (var fs2 = new FileStream("../../CurrentAccount.txt", FileMode.Open))
                using (var reader = new BinaryReader(fs2))
                {
                    var agency = reader.ReadInt32();
                    var number = reader.ReadInt32();
                    var balance = reader.ReadDouble();
                    var customerName = reader.ReadString();
                    Console.WriteLine($"Agency { agency }, Number {number}, Balance {balance}, CustomerName {customerName}");
                }

            Wait();
        }

        //using Flush();
        static void ModuleNine05()
        {
            /* This code is just for testing...*/

            var pathNewFile = "../../ExportedAccounts.csv";
            using (var fileFlow = new FileStream(pathNewFile, FileMode.Create)) // FileMode.Create: override the original file
            {
                using (var writer = new StreamWriter(fileFlow, Encoding.UTF8))
                {
                    for (int i=0; i < 10; i++)
                    {
                        writer.WriteLine("line " + i);
                        Console.WriteLine($"Line {i} written, press Enter to continue...");
                        writer.Flush();
                        Console.ReadLine();
                    }                                      
                }
            }

            Wait();
        }

        //creating a CSV file using StreamWriter
        static void ModuleNine04()
        {
            /* This code is just for testing...*/

            var pathNewFile = "../../ExportedAccounts.csv";
            using (var fileFlow = new FileStream(pathNewFile, FileMode.Create)) // FileMode.Create: override the original file
            {
                using (var writer = new StreamWriter(fileFlow, Encoding.UTF8))
                    writer.Write("456, 45874, 9.652, Ivan S. Longarai");
            }
            
            Wait();
        }

        //creating a CSV file dealing with bytes
        static void ModuleNine03()
        {
            /* This code is just for testing...*/

            var pathNewFile = "../../ExportedAccounts.csv";
            using (var fileFlow = new FileStream(pathNewFile, FileMode.Create))
            {
                var currentAcoountAsString = "456, 45874, 9.652, Ivan Longarai";
                var encoding = Encoding.UTF8;
                fileFlow.Write(encoding.GetBytes(currentAcoountAsString), 0, encoding.GetByteCount(currentAcoountAsString));
            }

            Wait();
        }

        // using StreamReader
        static void ModuleNine02()
        {
            /* This code is just for testing...*/

            var fileToLoad = "../../AcoountsWithComma.txt";
            try
            {
                var list = new List<CurrentAcoount>();

                using (var fileFlow = new FileStream(fileToLoad, FileMode.Open)) // using private word key closes the file automatically                
                    using (var reader = new StreamReader(fileFlow))
                    {
                        while (!reader.EndOfStream)
                        {
                            var line = reader.ReadLine();                            
                            var currentAccount = convertStringToCurrentAcoount(line);
                            list.Add(currentAccount);
                        }
                    }

                ExtensionList.ListAll(list);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                Console.WriteLine("It was not possible to read the entire file content.");
            }

            Wait();
        }

        static CurrentAcoount convertStringToCurrentAcoount(string line)
        {           
            var fields = line.Split(',');          
            string agency = fields[0];
            string number = fields[1];
            string balance = fields[2].Replace('.', ',');
            string customerName = fields[3];
            Customer customer = new Customer(customerName, "000", "Developer");
            var currentAcoount = new CurrentAcoount(agency, number, customer);
            currentAcoount.Deposit(double.Parse(balance));
            return currentAcoount;
        }

        static void ModuleNine01()
        {
            DealingWithStreamDirectly();
        }

        static void ModuleEighth04()
        {
            /* This code is just for testing...*/

            var customer01 = new Customer("Zé", "000", "Developer");
            var customer02 = new Customer("José", "000", "Analyst");
            var customer04 = new Customer("Bianca", "000", "Tester");
            var customer03 = new Customer("Alexandre", "000", "Quality Analyst");           

            var currentAcoountList = new List<CurrentAcoount>()
            {
                new CurrentAcoount("B123", "005", customer01),
                new CurrentAcoount("C123", "002", customer02),
                new CurrentAcoount("A123", "007", customer03),
                null, // testing with a null value
                new CurrentAcoount("D123", "001", customer04)
            };

            try
            {

                ExtensionList.ListAll(currentAcoountList);
                Console.WriteLine("Sorting items by Agency");
                currentAcoountList.Sort(new CurrentAcoountCompareByAgency());
                ExtensionList.ListAll(currentAcoountList);
                Console.WriteLine("Sorting items by Number");
                currentAcoountList.Sort(new CurrentAcoountCompareByNumber());
                ExtensionList.ListAll(currentAcoountList);
                
                Console.WriteLine("Sorting items by Customer.Name");                
                var sortedCurrentAcoountsByCustomerName = currentAcoountList.OrderBy(currentAcoount => {
                                                                                                 /* ^
                                                                                                     `- Lambda expression */
                    if (!(currentAcoount == null) && !(currentAcoount.Customer == null) && !(currentAcoount.Customer.Name == null))
                            return currentAcoount.Customer.Name;
                        return "ZZZ";
                    });

                foreach (var item in sortedCurrentAcoountsByCustomerName)
                {
                    if (!(item == null))
                        Console.WriteLine(item.ToString());
                }

                Console.WriteLine("Sorting items by Customer.Profession");

                var sortedCurrentAcoountsByCustomerProfession = currentAcoountList
                        //System.Linq
                        .Where(currentAcoount => currentAcoount != null)
                        .OrderBy(currentAcoount => currentAcoount.Customer.Profession);

                foreach (var item in sortedCurrentAcoountsByCustomerProfession)
                    Console.WriteLine(item.ToString());

            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }

            Wait();
        }

        static void ModuleEighth03()
        {
            /* This code is just for testing...*/

            var list = new List<int>();

            Console.WriteLine("Adding many items without sorting method");
            list.Add(10, 5, 8, 9, 6, 3, 2);
            ExtensionList.ListAll<int>(list);

            Console.WriteLine("Sorting items");
            list.Sort();
            ExtensionList.ListAll<int>(list);

            var list2 = new List<string>();

            Console.WriteLine("Adding many items without sorting method");
            list2.Add("Zé", "Taís", "Bruno", "André", "Fábio", "Josefine", "Carlos", "Pedro");
            ExtensionList.ListAll<string>(list2);

            Console.WriteLine("Sorting items");
            list2.Sort();
            ExtensionList.ListAll<string>(list2);


            Wait();
        }

        static void ModuleEighth02()
        {
            /* This code is just for testing...*/

            var customer = new Customer("Ivan", "000", "Developer");
            var currentAcoount = new CurrentAcoount("123", "456", customer);
            currentAcoount.Deposit(2000);
            Console.WriteLine(currentAcoount.Balance);

            Wait();
        }

        static void ModuleEighth01()
        {
            /* This code is just for testing...*/

            List<int> list = new List<int>();

            Console.WriteLine("Adding item value 10");
            list.Add(10);
            Console.WriteLine("Adding item value 20");
            list.Add(20);
            Console.WriteLine("Adding item value 30");
            list.Add(30);

            Console.WriteLine("Adding item values 40, 50, 60");
            list.AddRange(new int[] { 40, 50, 60 });

            Console.WriteLine("Adding item values 70, 80, 90");
            list.Add<int>(70, 80, 90);

            Console.WriteLine("Count: " + list.Count);
            ExtensionList.ListAll<int>(list);
            Console.WriteLine("Removing item value 10");
            list.Remove(10);
            Console.WriteLine("Count: " + list.Count);
            ExtensionList.ListAll<int>(list);

            Console.WriteLine("");
            Console.WriteLine($"Indexer {0}: {list[0]}");
            Console.WriteLine($"Indexer {1}: {list[1]}");

            Wait();
        }

        static void ModuleSeven05()
        {
            /* This code is just for testing...*/

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
            /* This code is just for testing...*/

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
            /* This code is just for testing...*/

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

            /* This code is just for testing...*/

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
            /* This code is just for testing...*/

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
            /* This code is just for testing...*/

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
