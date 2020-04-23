using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace ToDoApp.Core.Models
{
    public class Home
    {
        public Home()
        {
            Users = new Collection<User>();
            Invoices= new Collection<Invoice>();
            Shoppings = new Collection<Shopping>();
        }
        public int Id { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public bool IsDeleted { get; set; }
        public ICollection<User> Users { get; set; }
        public ICollection<Invoice> Invoices { get; set; }
        public ICollection<Shopping> Shoppings { get; set; }


    }
}
