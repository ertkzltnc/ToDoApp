using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using ToDoApp.Core.Services;
using ToDoApp.Web.DTOs;
using ToDoApp.Core.Models;
using ToDoApp.Web.Filters;

namespace ToDoApp.Web.Controllers
{
    public class UserController : Controller
    {
        private readonly IUserService _userService;
        private readonly IHomeService _homeService;
        private readonly IMapper _mapper;
        public UserController(IUserService userService,IHomeService homeService,IMapper mapper)
        {
            _userService = userService;
            _homeService = homeService;
            _mapper = mapper;
        }
        public async Task<IActionResult> Index()
        {
            var user = await _userService.GetAllAsync();
            return View(_mapper.Map<IEnumerable<UserDTO>>(user));
        }

        public async Task<IActionResult> Create()
        {
            var home = await _homeService.GetAllAsync();
            ViewBag.Home = home;
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create(UserDTO userDto)
        {
            
            await _userService.AddAsync(_mapper.Map<User>(userDto));
            return RedirectToAction("Index");
        }
        public async Task<IActionResult> Update(int id)
        {
            var home = await _homeService.GetAllAsync();
            ViewBag.Home = home;
            var user = await _userService.GetByIdAsync(id);            
            return View(_mapper.Map<UserDTO>(user));
        }

        [HttpPost]
        public IActionResult Update(UserDTO userDTO)
        {
            _userService.Update(_mapper.Map<User>(userDTO));
            return RedirectToAction("Index");
        }

        [ServiceFilter(typeof(NotFoundFilter))]
        public IActionResult Delete(int id)
        {
            var user = _userService.GetByIdAsync(id).Result;
            _userService.Remove(user);
            return RedirectToAction("Index");
        }
    }
}