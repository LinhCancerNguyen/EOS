using Core.Models;
using Infra.Infrastructure;
using Infra.Repositories;
using System;
using System.Collections.Generic;
using System.Text;

namespace Service.Core
{
    public interface IPostService
    {
        IEnumerable<Post> GetPosts();
        IList<Post> GetAllPost(int pageNo, int pageSize);
        int TotalPosts();
        Post GetPost(int Id);
        void CreatePost(Post post);
        void SavePost();
        void UpdatePost(Post post);
        void DeletePost(Post post);
    }

    public class PostService : IPostService
    {
        private readonly IPostRepository postRepository;
        private readonly IUnitOfWork unitOfWork;

        public PostService(IPostRepository postRepository, IUnitOfWork unitOfWork)
        {
            this.postRepository = postRepository;
            this.unitOfWork = unitOfWork;
        }
        public void CreatePost(Post post)
        {
            throw new NotImplementedException();
        }

        public void DeletePost(Post post)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Post> GetPosts()
        {
            throw new NotImplementedException();
        }

        public Post GetPost(int Id)
        {
            throw new NotImplementedException();
        }

        public void SavePost()
        {
            throw new NotImplementedException();
        }

        public void UpdatePost(Post post)
        {
            throw new NotImplementedException();
        }

        public IList<Post> GetAllPost(int pageNo, int pageSize)
        {
            return postRepository.GetAllPosts(pageNo, pageSize);
        }

        public int TotalPosts()
        {
            return postRepository.TotalPosts();
        }
    }
}
