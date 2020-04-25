using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using ToDoApp.Core.Repositories;

namespace ToDoApp.Core.UnitOfWorks
{
    public interface IUnitOfWork
    {
        IUserRepository Users { get; }
        IHomeRepository Housing { get; }
        IShoppingRepository Shoppings { get; }
        IInvoiceRepository Invoices { get; }
        IExpenseRepository Expenses { get; }


        Task CommitAsync();
        void Commit();
    }
}
