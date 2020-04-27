using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ToDoApp.API.DTOs;
using ToDoApp.API.Filters;
using ToDoApp.Core.Models;
using ToDoApp.Core.Services;

namespace ToDoApp.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;
        private readonly IMapper _mapper;
        public UserController(IUserService userService, IMapper mapper)
        {
            _userService = userService;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var user = await _userService.GetAllAsync();
            return Ok(_mapper.Map<IEnumerable<UserDTO>>(user));
        }

        [ServiceFilter(typeof(NotFoundFilter))]
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var user = await _userService.GetByIdAsync(id);
            return Ok(_mapper.Map<UserDTO>(user));
        }

        [ServiceFilter(typeof(NotFoundUser))]
        [HttpGet("{username}/{password}")]
        public async Task<IActionResult> Login(string username,string password)
        {
            var user = await _userService.Login(username, password);
            return Ok(_mapper.Map<UserDTO>(user));
        }
        
        [HttpPost]
        public async Task<IActionResult> Save(UserDTO userDTO)
        {
            var user = await _userService.AddAsync(_mapper.Map<User>(userDTO));
            return Created(string.Empty, _mapper.Map<UserDTO>(user));
        }
        [HttpPut]
        public IActionResult Update(UserDTO userDTO)
        {
            var user = _userService.Update(_mapper.Map<User>(userDTO));
            return NoContent();
        }
        [ServiceFilter(typeof(NotFoundFilter))]
        [HttpDelete("{id}")]
        public IActionResult Remove(int id)
        {
            var user = _userService.GetByIdAsync(id).Result;
            _userService.Remove(user);
            return NoContent();
        }
    }
}