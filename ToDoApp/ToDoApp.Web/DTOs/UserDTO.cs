using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ToDoApp.Web.DTOs
{
    public class UserDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }
        [Required(ErrorMessage = "{0} alanı gereklidir.")]
        public string UserName { get; set; }
        public string Password { get; set; }
        public int HomeId { get; set; }        
       
    }
}
