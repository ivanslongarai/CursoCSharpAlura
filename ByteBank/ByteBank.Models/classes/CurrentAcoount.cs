using System;
using ByteBank.Models.Resources;
using ByteBank.Models.Exceptions;

namespace ByteBank.Models.Models
{
    /// <summary> This class defines a corrent acoount at ByteBank Bank. </summary>
    public class CurrentAcoount
    {

        public static int TotalOfCurrentAccount { get; private set; }
        public double OperationFee { get; private set; }

        /// <summary>
        /// Create an instance of Current Account using the params informed
        /// </summary>
        /// <param name="agency">Property <see cref="Agency"/>. Its value is required</param>
        /// <param name="number">Property <see cref="Number"/>. Its value is required</param>
        /// <param name="customer">Property <see cref="Customer"/>. Its value is required and has to receive an Customer instance</param>
        public CurrentAcoount(string agency, string number, Customer customer)
        {
            if (agency.Trim() == "")
                throw new ArgumentException(Constants.MsgInvalidParam, "CurrentAcoount.Constructor.agency");
            if (number.Trim() == "")
                throw new ArgumentException(Constants.MsgInvalidParam, "CurrentAcoount.Constructor.number");
            this.Agency = agency;
            this.Number = number;
            this.Customer = customer ?? throw new ArgumentException(Constants.MsgInvalidParam, "CurrentAcoount.Constructor.customer");
            TotalOfCurrentAccount++;
            OperationFee = 30 / TotalOfCurrentAccount;
        }

        public string Agency { get; }
        public string Number { get; }
        public double Balance { get; protected set; }
        public Customer Customer { get; protected set; }

        public override bool Equals(object obj)
        {
            CurrentAcoount o = (obj as CurrentAcoount);
            if (o == null) 
                return false;                
            return this.Agency == o.Agency &&
                this.Number == o.Number &&
                this.Customer.Name == o.Customer.Name &&
                this.Customer.DocumentId == o.Customer.DocumentId;
        }

        public override string ToString()
        {
            return $"Agency {this.Agency}" +
                   $", Number {this.Number}" +
                   $", Balance {this.Balance}" +
                   $", CustomerName {this.Customer.Name}" +
                   $", CustomerDocumentId {this.Customer.DocumentId}" +
                   $", CustomerProfession {this.Customer.Profession}";
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }


        public bool CashOut(double value)
        {
            if (value <= 0)
                throw new ArgumentException(Constants.MsgInvalidParam, "CurrentAccount.CashOut.value");
            if (this.Balance >= value)
            {
                this.Balance -= value;
                return true;
            }
            throw new InsufficientBalanceException(Constants.MsgInvalidParam, "CurrentAccount.CashOut.value");
        }

        public void Deposit(double value)
        {
            if (value <= 0)
                throw new ArgumentException(Constants.MsgInvalidParam, "CurrentAccount.Deposit.value");
            this.Balance += value;
        }

        public bool Transfer(CurrentAcoount destiny, double value)
        {
            if (destiny == null)
                throw new ArgumentException(Constants.MsgInvalidParam, "CurrentAcoount.Transfer.destiny");
            if (value <= 0)
                throw new ArgumentException(Constants.MsgInvalidParam, "CurrentAcoount.Transfer.value");
            if (this.CashOut(value))
            {
                destiny.Deposit(value);
                return true;
            }
            return false;
        }

    }
}