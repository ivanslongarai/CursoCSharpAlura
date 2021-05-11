using System;
using ByteBank.Models.Resources;

namespace ByteBank.Models.Models
{
	public abstract class Employee
	{
        public static int TotalOfEmployee { get; private set; }

        public Employee(string name, string documentId, double salary)
        {
            if (name.Trim() == "")
                throw new ArgumentException(Constants.MsgInvalidParam, "Employee.Constructor.name");

            if (documentId.Trim() == "")
                throw new ArgumentException(Constants.MsgInvalidParam, "Employee.Constructor.documentId");

            if (salary <= 0)
                throw new ArgumentException(Constants.MsgInvalidParam, "Employee.Constructor.salary");

            this.Name = name;
            this.DocumentId = documentId;
            this.Salary = salary;

            TotalOfEmployee++;
        }

        public abstract void IncreaseSalary();
        public string Name { get; set; }
        public string DocumentId { get; set; }
        public double Salary { get; protected set; }
        internal protected abstract double Bonification();
    }
}
