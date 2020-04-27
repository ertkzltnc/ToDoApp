using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ToDoApp.API.DTOs
{
    public class ShoppingDTO
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "{0} alanı gereklidir.")]
        public string Name { get; set; }
        public float Unit { get; set; }
        public bool Status { get; set; }
        public int HomeId { get; set; }       
    }
}
