using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ByteBank.AgencySystem.Extensions
{
    public static class ExtensionList
    {

        public static void Add<T>(this List<T> itemsList, params T[] items)
        {
            foreach (T item in items)
                itemsList.Add(item);
        }

        public static void ListAll<T>(List<T> itemsList)
        {
            for (int i = 0; i < itemsList.Count; i++) { 
                if (!(itemsList[i] == null))
                    Console.WriteLine($" Index: {i}, Object: {itemsList[i].ToString()}");
            }
        }

    }
}
