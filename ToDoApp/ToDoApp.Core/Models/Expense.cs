using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace ToDoApp.Core.Models
{
    public class Expense
    {
        public int Id { get; set; }
        public int? ShoppingId { get; set; }      
        public int? UserId { get; set; }
        public decimal Amount { get; set; }
        public DateTime Date { get; set; }
        public virtual User User { get; set; }
        public virtual Shopping Shopping { get; set; }

    }
}
