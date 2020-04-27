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
    public class HomeController : ControllerBase
    {
        private readonly IHomeService _homeService;
        private readonly IMapper _mapper;
        public HomeController(IHomeService homeService,IMapper mapper)
        {
            _homeService = homeService;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var home = await _homeService.GetAllAsync();
            return Ok(_mapper.Map<IEnumerable<HomeDTO>>(home));
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var home = await _homeService.GetByIdAsync(id);
            return Ok(_mapper.Map<HomeDTO>(home));
        }

        [HttpGet("{id}/user")]
        public async Task<IActionResult> GetWithUserById(int id)
        {
            var home = await _homeService.GetWithUserById(id);
            return Ok(_mapper.Map<HomeUserDTO>(home));
        }
       
        [HttpPost]
        public async Task<IActionResult> Save(HomeDTO homeDTO)
        {
            var home=await _homeService.AddAsync(_mapper.Map<Home>(homeDTO));
            return  Created(string.Empty,_mapper.Map<HomeDTO>(home));
        }
        [HttpPut] 
        public IActionResult Update(HomeDTO homeDTO)
        {
            var home = _homeService.Update(_mapper.Map<Home>(homeDTO));
            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult Remove (int id)
        {
            var home = _homeService.GetByIdAsync(id).Result;
            _homeService.Remove(home);
            return NoContent();
        }
       
    }
}