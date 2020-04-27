using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ToDoApp.API.DTOs;
using ToDoApp.Core.Services;

namespace ToDoApp.API.Filters
{
    public class NotFoundUser: ActionFilterAttribute
    {
        private readonly IUserService _userService;
        public NotFoundUser(IUserService userService)
        {
            _userService = userService;
        }

        public override async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
        {
            
            string  userName = (string)context.ActionArguments["username"];

            var user = await _userService.SingleOrDefaultAsync(x => x.UserName == userName);
            if (user!= null)
            {
                await next();
            }
            else
            {
                ErrorDTO errorDTO = new ErrorDTO();
                errorDTO.Status = 404;
                errorDTO.Errors.Add($"kullanıcı adı {userName} olan kullanıcı bulunamadı");
                context.Result = new NotFoundObjectResult(errorDTO);
            }


        }
    }
}
