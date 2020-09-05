using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ToDoPhoneBook.Models
{
    public class SearchFilter
    {
        public int Current { get; set; }

        public int RowCount { get; set; }

        public string SearchPhrase { get; set; }
    }
}
