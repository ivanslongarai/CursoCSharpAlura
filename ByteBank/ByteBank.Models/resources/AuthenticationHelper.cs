using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ByteBank.Models.Resources
{
    internal class AuthenticationHelper
    {
        public static bool ValidPassword(string original_password, string trying_password)
        {
            return original_password == trying_password;
        }
    }
}
