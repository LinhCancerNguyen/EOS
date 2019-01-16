using BookManagement.Core.Data;
using BookManagement.Core.Models;
using BookManagement.Core.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookManagement.Core.Repositories
{
    public class AccountRepository : IAccount
    {
        private BookDBContext Db;

        public AccountRepository(BookDBContext _Db)
        {
            Db = _Db;
        }

        public Account GetAccount(string Username, string Password)
        {
            return Db.Account.GetAccount();
        }
    }
}
