using System;

namespace ByteBank.Models.Models
{
	public class Director : AuthenticableEmployee
	{
        public Director(string name, string documentId, double salary, string password) : base(name, documentId, salary, password) {}

        public override void IncreaseSalary()
        {
            this.Salary *= 2;
        }

        internal protected override double Bonification() => this.Salary * 2.0;
    }
}
