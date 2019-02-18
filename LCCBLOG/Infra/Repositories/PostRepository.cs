using Core.Models;
using Infra.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Infra.Repositories
{
    public class PostRepository : RepositoryBase<Post>, IPostRepository
    {
        public PostRepository(IDbFactory dbFactory) : base(dbFactory) { }

        public IList<Post> GetAllPosts(int pageNo, int pageSize)
        {
            var posts = this.DbContext.Posts.Where(p => p.Published)
                              .OrderByDescending(p => p.PostedOn)
                              .Skip(pageNo * pageSize)
                              .Take(pageSize)
                              .ToList();
            return posts;
        }

        public int TotalPosts()
        {
            return this.DbContext.Posts.Where(p => p.Published).Count();
        }
    }

    public interface IPostRepository : IRepository<Post>
    {
        IList<Post> GetAllPosts(int pageNo, int pageSize);
        int TotalPosts();
    }
}
