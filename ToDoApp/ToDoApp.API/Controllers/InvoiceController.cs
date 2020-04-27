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
    public class InvoiceController : ControllerBase
    {
        private readonly IService<Invoice> _service;
        private readonly IMapper _mapper;
        public InvoiceController(IService<Invoice> service, IMapper mapper)
        {
            _service = service;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var invoice= await _service.GetAllAsync();
            return Ok(_mapper.Map<IEnumerable<InvoiceDTO>>(invoice));
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var invoice = await _service.GetByIdAsync(id);
            return Ok(_mapper.Map<InvoiceDTO>(invoice));
        }

        [HttpPost]
        public async Task<IActionResult> Save(InvoiceDTO invoiceDto)
        {
            var invoice = await _service.AddAsync(_mapper.Map<Invoice>(invoiceDto));
            return Created(string.Empty, _mapper.Map<InvoiceDTO>(invoice));
        }
        [HttpPut]
        public IActionResult Update(InvoiceDTO invoiceDTO)
        {
            var invoice = _service.Update(_mapper.Map<Invoice>(invoiceDTO));
            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult Remove(int id)
        {
            var invoice = _service.GetByIdAsync(id).Result;
            _service.Remove(invoice);
            return NoContent();
        }
    }
}