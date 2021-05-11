using System;

namespace ByteBank.Models.Interfaces
{
    public interface IAuthenticable
    { bool Authenticate(string password); }
}
