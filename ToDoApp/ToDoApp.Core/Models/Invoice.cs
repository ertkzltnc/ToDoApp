using System;
using System.Collections.Generic;
using System.Text;

namespace ToDoApp.Core.Models
{
   public  class Invoice
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime InvoicingDate { get; set; }
        public decimal Amount{ get; set; }
        public bool Status{ get; set; }
        public int HomeId { get; set; }
        public bool IsDeleted { get; set; }
        public virtual Home Home { get; set; }
    }
}
