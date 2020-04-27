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
    public class ExpenseController : ControllerBase
    {
        private readonly IService<Expense> _service;
        private readonly IMapper _mapper;
        public ExpenseController(IService<Expense> service, IMapper mapper)
        {
            _service = service;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var expense = await _service.GetAllAsync();
            return Ok(_mapper.Map<IEnumerable<ExpenseDTO>>(expense));
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var expense = await _service.GetByIdAsync(id);
            return Ok(_mapper.Map<ExpenseDTO>(expense));
        }

        [HttpPost]
        public async Task<IActionResult> Save(ExpenseDTO expenseDTO)
        {
            var expense = await _service.AddAsync(_mapper.Map<Expense>(expenseDTO));
            return Created(string.Empty, _mapper.Map<ExpenseDTO>(expense));
        }
        [HttpPut]
        public IActionResult Update(ExpenseDTO expenseDTO)
        {
            var expense = _service.Update(_mapper.Map<Expense>(expenseDTO));
            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult Remove(int id)
        {
            var expense = _service.GetByIdAsync(id).Result;
            _service.Remove(expense);
            return NoContent();
        }
    }
}