using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ToDoApp.API.DTOs;
using ToDoApp.Core.Models;

namespace ToDoApp.API.Mapping
{
    public class MapProfile : Profile
    {
        public MapProfile()
        {
            CreateMap<Home, HomeDTO>();
            CreateMap<HomeDTO, Home>();
            CreateMap<Home, HomeUserDTO>();
            CreateMap<HomeUserDTO, Home>();
            CreateMap<User, UserDTO>();
            CreateMap<UserDTO, User>();
            CreateMap<Shopping, ShoppingDTO>();
            CreateMap<ShoppingDTO, Shopping>();
            CreateMap<Invoice, InvoiceDTO>();
            CreateMap<InvoiceDTO, Invoice>();
            CreateMap<Expense, ExpenseDTO>();
            CreateMap<ExpenseDTO, Expense>();
            CreateMap<User, LoginDTO>();
            CreateMap<LoginDTO, User>();
            CreateMap<UserDTO, LoginDTO>();
            CreateMap<LoginDTO, UserDTO>();

        }
    }
}
