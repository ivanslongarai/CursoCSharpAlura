using System;

namespace ByteBank.Models.Models
{
	public class Developer : Employee
	{
        public Developer(string name, string documentId, double salary, string password) : base(name, documentId, salary) {}
        

        public override void IncreaseSalary()
        {
            this.Salary *= 1.0;
        }

        internal protected override double Bonification() => this.Salary * 1;
    }
}
