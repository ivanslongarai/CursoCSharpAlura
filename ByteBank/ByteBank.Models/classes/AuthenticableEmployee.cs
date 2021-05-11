using System;
using ByteBank.Models.Interfaces;
using ByteBank.Models.Resources;

namespace ByteBank.Models.Models
{
	public abstract class AuthenticableEmployee : Employee, IAuthenticable
    {
        protected AuthenticableEmployee(string name, string documentId, double salary, string password) : base(name, documentId, salary)
        {
            if (password.Trim() == "")
                throw new ArgumentException(Constants.MsgInvalidParam, "AuthenticableEmployee.Contructor.password");
            this.Password = password;
        }

        public string Password { get; }

        public bool Authenticate(string password) => AuthenticationHelper.ValidPassword(Password, password);
    }
}
