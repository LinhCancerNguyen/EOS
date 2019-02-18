using Core.Models;
using Service.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyBlog.Views
{
    public class ListPostsModel
    {
        public ListPostsModel(IPostService _postService, int p)
        {
            Posts = _postService.GetAllPost(p - 1, 10);
            TotalPosts = _postService.TotalPosts();
        }
        public IList<Post> Posts { get; set; }
        public int TotalPosts { get; set; }
    }
}
