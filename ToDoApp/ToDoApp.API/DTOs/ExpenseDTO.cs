using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ToDoApp.API.DTOs
{
    public class ExpenseDTO
    {
        public int Id { get; set; }
        public int? ShoppingId { get; set; }
        public int? UserId { get; set; }
        public decimal Amount { get; set; }
        public DateTime Date { get; set; }       
    }
}
