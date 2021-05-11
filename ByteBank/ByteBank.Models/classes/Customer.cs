using System;
using ByteBank.Models.Resources;

namespace ByteBank.Models.Models
{
    public class Customer
    {
        public static int TotalOfCustomer { get; private set; }

        public Customer(string name, string documentId, string profession)
        {

            if (name.Trim() == "")
                throw new ArgumentException(Constants.MsgInvalidParam, "Customer.Constructor.name");

            if (documentId.Trim() == "")
                throw new ArgumentException(Constants.MsgInvalidParam, "Customer.Constructor.documentId");

            this.Name = name;
            this.DocumentId = documentId;           
            this.Profession = profession; /* optional */

            TotalOfCustomer++;
        }

        public String Name { get; }
        public String DocumentId { get; }
        public String Profession { get; set; }
    }
}
