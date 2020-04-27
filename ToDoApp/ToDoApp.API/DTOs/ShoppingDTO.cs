using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ToDoApp.API.DTOs
{
    public class ShoppingDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public float Unit { get; set; }
        public bool Status { get; set; }
        public int HomeId { get; set; }       
    }
}
