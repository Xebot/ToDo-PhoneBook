using System;
using System.Collections.Generic;
using System.Text;

namespace ToDoPhoneBook.Contracts.Models
{
    public class ToDoItemsListDto
    {
        public int Current { get; set; }

        public int rowCount { get; set; }
        public List<ToDoItemDto> rows { get; set; }

        public int total { get; set; }
    }
}
