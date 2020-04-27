using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ToDoApp.API.DTOs
{
    public class InvoiceDTO
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "{0} alanı gereklidir.")]
        public string Name { get; set; }
        public DateTime InvoicingDate { get; set; }
        [Range(1,double.MaxValue,ErrorMessage ="{0} alanı  pozitif değer olmalıdır")]
        public decimal Amount { get; set; }
        public bool Status { get; set; }
        public int HomeId { get; set; }       
    }
}
