using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Week2.Loaners.Enums;

namespace Week2.Loaners
{
    class Book : ILoanItem
    {
        public int ID { get; set; }
        public LoanState? State { get; set; }
        public string Title { get; set; }
        public string Author { get; set; }
        public string ISBN { get; set; }
        

        public Book(int id, string title, string author, string isbn)
        {
            ID = id;
            Title = title;
            Author = author;
            ISBN = isbn;
        }
    }
}
