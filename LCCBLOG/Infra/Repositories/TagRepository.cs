using Core.Models;
using Infra.Infrastructure;
using System;
using System.Collections.Generic;
using System.Text;

namespace Infra.Repositories
{
    public class TagRepository : RepositoryBase<Tag>, ITagRepository
    {
        public TagRepository(IDbFactory dbFactory) : base(dbFactory) { }
    }

    public interface ITagRepository : IRepository<Tag>
    {
    }
}
