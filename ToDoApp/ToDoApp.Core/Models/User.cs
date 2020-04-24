using System;
using System.Collections.Generic;
using System.Text;

namespace ToDoApp.Core.Models
{
    public class User
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public int HomeId { get; set; }
        public bool IsDeleted { get; set; }
        public virtual Home Home  { get; set; }
        public virtual Expense Expens { get; set; }

    }
}
