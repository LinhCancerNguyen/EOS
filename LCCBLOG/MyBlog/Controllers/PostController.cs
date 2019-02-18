using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core.ModelViews;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using MyBlog.Views;
using Service.Core;

namespace MyBlog.Controllers
{
    public class PostController : Controller
    {
        private readonly IConfiguration config;
        private readonly IPostService postService;

        public PostController(IConfiguration config, IPostService postService)
        {
            this.postService = postService;
            this.config = config;
        }

        public IActionResult Index()
        {
            return View();
        }

        public ViewResult Posts(int p = 1)
        {
            var viewModel = new ListPostsModel(postService, p);

            ViewBag.Title = "Latest Posts";
            return View("List", viewModel);
        }
    }
}