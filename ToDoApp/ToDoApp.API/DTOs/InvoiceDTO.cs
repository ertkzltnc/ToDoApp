using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ToDoApp.API.DTOs
{
    public class InvoiceDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime InvoicingDate { get; set; }
        public decimal Amount { get; set; }
        public bool Status { get; set; }
        public int HomeId { get; set; }       
    }
}
