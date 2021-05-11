using System;
using ByteBank.Models.Resources;
using ByteBank.Models.Interfaces;

namespace ByteBank.Models.Models
{
	public class InternalSystem
	{
		public bool Login(IAuthenticable authenticable, string password)
        {
            if (authenticable == null)
                throw new ArgumentException(Constants.MsgInvalidParam, "InternalSystem.Constructor.authenticable");
            if (authenticable.Authenticate(password)) 
                return true;
            return false;
        }

    }
}
