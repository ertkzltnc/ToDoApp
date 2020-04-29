using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using ToDoApp.Core.Models;
using ToDoApp.Core.Services;
using ToDoApp.Web.DTOs;

namespace ToDoApp.Web.Controllers
{
    public class LoginController : Controller
    {
        private readonly IUserService _userService;
        private readonly IMapper _mapper;
        public LoginController(IUserService userService, IMapper mapper)
        {
            _userService = userService;
            _mapper = mapper;
        }
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginDTO loginDTO)
        {
            if (_userService.Login(_mapper.Map<User>(loginDTO)))
            {
            //    var claims = new List<Claim>
            //{
            //    new Claim(ClaimTypes.Name, loginDTO.UserName)
            //};

            //    var userIdentity = new ClaimsIdentity(claims, "login");

            //    ClaimsPrincipal principal = new ClaimsPrincipal(userIdentity);
            //    await HttpContext.SignInAsync(principal);
                return RedirectToAction("Index", "User");
            }            
            return View();
        }
    }
}