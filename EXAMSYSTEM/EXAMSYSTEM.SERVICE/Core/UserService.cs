using EXAMSYSTEM.CORE.Models;
using EXAMSYSTEM.CORE.ModelViews;
using EXAMSYSTEM.INFRA.Infrastructure;
using EXAMSYSTEM.INFRA.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EXAMSYSTEM.SERVICE.Core
{
    public interface IUserService
    {
        IEnumerable<UserView> GetUsers();
        User GetUser(int id);
        User Login(string username, string password);
        User GetUserByName(string name);
        void CreateUser(User user);
        void SaveUser();
        void Update(User user);
        void Delete(User user);
    }

    public class UserService : IUserService
    {
        private readonly IUserRepository userRepository;
        private readonly IUnitOfWork unitOfWork;

        public UserService(IUserRepository userRepository, IUnitOfWork unitOfWork)
        {
            this.userRepository = userRepository;
            this.unitOfWork = unitOfWork;
        }

        public void CreateUser(User user)
        {
            userRepository.Add(user);
            SaveUser();
        }

        public void Delete(User user)
        {
            userRepository.Delete(user);
            SaveUser();
        }

        public User GetUser(int id)
        {
            return userRepository.GetDetailById(id);
        }

        public User GetUserByName(string name)
        {
            return userRepository.GetUserByName(name);
        }

        public IEnumerable<UserView> GetUsers()
        {
            return userRepository.GetUsers().OrderByDescending(u => u.UserId);
        }

        public User Login(string username, string password)
        {
            return userRepository.Login(username, password);
        }

        public void SaveUser()
        {
            unitOfWork.Commit();
        }

        public void Update(User user)
        {
            userRepository.Edit(user);
            SaveUser();
        }
    }
}
