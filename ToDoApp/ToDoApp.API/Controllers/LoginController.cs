using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ToDoApp.API.DTOs;
using ToDoApp.Core.Models;
using ToDoApp.Core.Services;

namespace ToDoApp.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        private readonly IUserService _userService;
        private readonly IMapper _mapper;
        public LoginController(IUserService userService, IMapper mapper)
        {
            _userService = userService;
            _mapper = mapper;
        }
        //[ServiceFilter(typeof(NotFoundUser))]
        [HttpGet]
        public IActionResult Login(LoginDTO loginDTO)
        {
            User user = _mapper.Map<User>(loginDTO);
            if (_userService.Login(user))
            {               
                return Ok();
            }
            else
            {
                return NoContent();
            }
            
        }
    }
}