using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ByteBank.Models.Models
{
    public class BonificationManager
    {
        private double TotalBonifications { get; set; }

        public void Register(Employee employee)
        {
            TotalBonifications += employee.Bonification();
        }

        public double GetBonification() => TotalBonifications;
        
    }
}
