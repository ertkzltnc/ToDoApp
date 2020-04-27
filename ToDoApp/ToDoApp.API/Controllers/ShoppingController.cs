using System;
using System.Collections.Generic;
using System.Linq;
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
    public class ShoppingController : ControllerBase
    {
        private readonly IService<Shopping> _service;
        private readonly IMapper _mapper;
        public ShoppingController(IService<Shopping> service, IMapper mapper)
        {
            _service = service;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var shopping = await _service.GetAllAsync();
            return Ok(_mapper.Map<IEnumerable<ShoppingDTO>>(shopping));
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var shopping = await _service.GetByIdAsync(id);
            return Ok(_mapper.Map<ShoppingDTO>(shopping));
        }      

        [HttpPost]
        public async Task<IActionResult> Save(ShoppingDTO shoppingDTO)
        {
            var shopping = await _service.AddAsync(_mapper.Map<Shopping>(shoppingDTO));
            return Created(string.Empty, _mapper.Map<ShoppingDTO>(shopping));
        }
        [HttpPut]
        public IActionResult Update(ShoppingDTO shoppingDTO)
        {
            var shopping = _service.Update(_mapper.Map<Shopping>(shoppingDTO));
            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult Remove(int id)
        {
            var shopping = _service.GetByIdAsync(id).Result;
            _service.Remove(shopping);
            return NoContent();
        }

    }
}