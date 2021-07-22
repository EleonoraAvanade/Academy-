using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Week2.Loaners.Enums;

namespace Week2.Loaners
{
    public interface ILoanItem
    {
        int ID { get; set; }
        LoanState? State { get; set; }
    }
}
