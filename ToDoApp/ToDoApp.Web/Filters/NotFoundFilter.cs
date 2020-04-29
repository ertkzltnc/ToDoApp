using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ToDoApp.Core.Services;
using ToDoApp.Web.DTOs;

namespace ToDoApp.Web.Filters
{
    public class NotFoundFilter : ActionFilterAttribute
    {       
        
        private readonly IUserService _userService;
        public NotFoundFilter(IUserService userService)
        {
            _userService = userService;

        }      

        public override async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
        {
            int id = (int)context.ActionArguments["id"];
            var user = await _userService.GetByIdAsync(id);           
            if (user!=null)
            {
                 await next();
            }
            else
            {
                ErrorDTO errorDTO = new ErrorDTO();
                errorDTO.Errors.Add($"id'si {id} olan kullanıcı bulunamadı");
                context.Result = new RedirectToActionResult("Error", "Home", errorDTO);
            }   
        }
    }
}
