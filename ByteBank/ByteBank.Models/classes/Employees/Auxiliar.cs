using System;

namespace ByteBank.Models.Models
{
    public class Auxiliar : Employee
    {
        public Auxiliar(string name, string documentId, double salary, string password) : base(name, documentId, salary) { }


        public override void IncreaseSalary()
        {
            this.Salary *= 0.2;
        }

        internal protected override double Bonification() => this.Salary * 0.2;
    }
}
