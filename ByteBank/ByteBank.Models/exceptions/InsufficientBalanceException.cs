using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ByteBank.Models.Exceptions
{
    public class InsufficientBalanceException : ArgumentException
    {
        public InsufficientBalanceException(string message, string paramname) : base(message, paramname)
        {
        }
    }
}
