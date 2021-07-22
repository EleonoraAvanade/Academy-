using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Week2.Loaners.Enums;

namespace Week2.Loaners
{
    public class LoanerCard<T> where T : ILoanItem
    {
        #region properties
        private List<T> items = new List<T>();

        public string Code { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }

        public DateTime RegistrationDate { get; set; }

        public UserRate Rate { get; set; }

        #endregion

        #region ctor

        public LoanerCard(string code, string firstName, string lastName, DateTime registrationDate, UserRate rate)
        {
            Code = code;
            FirstName = firstName;
            LastName = lastName;
            RegistrationDate = registrationDate;
            Rate = rate;
        }

        #endregion

        #region methods

        public void Lend(T item)
        {
            var found = items.FirstOrDefault(i => i.ID == item.ID || i.State == null);

            if (found == null)
            {
                item.State = LoanState.InLoan;
                items.Add(item);
            }
            else
            {
                found.State = LoanState.InLoan;
            }

        }

        public void Return(T item)
        {
            var found = items.FirstOrDefault(i => i.ID == item.ID);

            if (found != null)
                found.State = LoanState.Returned;
        }

        #endregion

       

        #region tostring

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine("--- LOANER DETAILS ---");
            sb.AppendLine($"[{Code}] {FirstName} {LastName} ({Rate})");
            //sb.AppendLine("|--- LOAN HISTORY ---|");
            //foreach (T item in items)
            //    sb.AppendLine($"[{item.ID}] {item.Title} => {item.State}");
            sb.AppendLine("--------------------");

            return sb.ToString();
        }
        #endregion
    }
}
