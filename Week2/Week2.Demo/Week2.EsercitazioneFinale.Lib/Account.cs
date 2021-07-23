using System;
using System.Collections.Generic;
using System.Text;
using Week2.EsercitazioneFinale.Lib.Movements;

namespace Week2.EsercitazioneFinale.Lib
{
    public class Account
    {
        public string AccountNumber { get; set; }
        public string BankName { get; set; }
        public DateTime LastOperation { get; set; }
        public decimal Balance { get; set; }

        private List<IMovement> _movements; //= new List<IMovement>();

        public Account(string bankName, string accountNum, decimal initialBalance)
        {
            if (string.IsNullOrEmpty(bankName))
            {
                throw new ArgumentException("Invalid name");
            }
            if (string.IsNullOrEmpty(accountNum))
            {
                throw new ArgumentException("Invalid number");
            }
            if(initialBalance < 0)
            {
                throw new ArgumentException("Initial balance must be positive");
            }
            _movements = new List<IMovement>();
            LastOperation = DateTime.Now;
            BankName = bankName;
            AccountNumber = accountNum;
            Balance = initialBalance;
            //
            //_movements.Add(new CashMovement());
        }

        public static Account operator +(Account account, IMovement movement)
        {
            if(movement.Amount <= 0)
            {
                throw new ArgumentException("Amount must be positive");
            }

            //aggiungo il movimento
            account._movements.Add(movement);

            //aggiorno i dati dell'account
            account.Balance += movement.Amount;
            account.LastOperation = movement.DateMovement;

            return account;
        }

        public static Account operator -(Account account, IMovement movement)
        {
            if(movement.Amount <= 0)
            {
                throw new ArgumentException("Amount must be positive");
            }

            account._movements.Add(movement);

            account.Balance -= movement.Amount;
            account.LastOperation = movement.DateMovement;

            return account;
        }

        public string Statement()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"====== ACCOUNT NUM {AccountNumber} {BankName}=====");
            sb.AppendLine($"BALANCE: {Balance} \t\t Last Operation: {LastOperation.ToShortDateString()}");
            sb.AppendLine("=============== MOVEMENTS ============");
            foreach(var mvm in _movements)
            {
                sb.AppendLine(mvm.ToString());
            }
            sb.AppendLine("============================================");
            return sb.ToString();
        }


    }
}
