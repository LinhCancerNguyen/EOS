using BookManagement.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookManagement.Core.Services
{
    public interface IAccount
    {
        Account GetAccount(string Username, string Password);
    }
}
