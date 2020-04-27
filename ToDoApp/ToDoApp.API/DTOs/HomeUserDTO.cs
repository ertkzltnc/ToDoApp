using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ToDoApp.API.DTOs
{
    public class HomeUserDTO:HomeDTO
    {
        public IEnumerable<UserDTO> Users { get; set; }
    }
}
