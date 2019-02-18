using Core.Models;
using Infra.Infrastructure;
using System;
using System.Collections.Generic;
using System.Text;

namespace Infra.Repositories
{
    public class ContactRepository : RepositoryBase<Contact>, IContactRepository
    {
        public ContactRepository(IDbFactory dbFactory) : base(dbFactory) { }
    }

    public interface IContactRepository : IRepository<Contact>
    {
    }
}
