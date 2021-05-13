using System;
using System.IO;
using System.Text;

namespace ByteBank.AgencySystem
{
    partial class Program
    {
        static void DealingWithStreamDirectly()
        {
            /* This code is just for test...*/

            var fileToLoad = "../../Acoounts.txt";
            try
            {
                using (var fileFlow = new FileStream(fileToLoad, FileMode.Open)) // using private word key closes the file automatically
                {
                    var buffer = new byte[1024]; // 1kb.
                    var numberOfReadBytes = -1;
                    while (numberOfReadBytes != 0)
                    {
                        numberOfReadBytes = fileFlow.Read(buffer, 0, 1024);
                        var utf = new UTF8Encoding();
                        var text = utf.GetString(buffer, 0, numberOfReadBytes);
                        Console.Write(text);
                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                Console.WriteLine("It was not possible to read the entire file content.");
            }

            Wait();
        }
    }
}