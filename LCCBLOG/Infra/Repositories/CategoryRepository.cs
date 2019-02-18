using Core.Models;
using Infra.Infrastructure;
using System;
using System.Collections.Generic;
using System.Text;

namespace Infra.Repositories
{
    public class CategoryRepository : RepositoryBase<Category>, ICategoryRepository
    {
        public CategoryRepository(IDbFactory dbFactory) : base(dbFactory) { }
    }

    public interface ICategoryRepository : IRepository<Category>
    {
    }
}
