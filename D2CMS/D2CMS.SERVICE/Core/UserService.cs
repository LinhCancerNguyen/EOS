using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using D2CMS.CORE.AuthenticationModel;
using D2CMS.CORE.Models;
using D2CMS.INFRA.Infrastructure;
using D2CMS.INFRA.Repositories;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;

namespace D2CMS.SERVICE.Core
{
    public interface IUserService
    {
        IEnumerable<User> GetUsers();
        User GetUser(int Id);
        User GetDetail(int Id);
        User GetUser(string Account);
        void CreateUser(User user);
        void SaveUser();
        User Authenticate(string loginUrl, LDAPLogin loginInfo);
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

        public User GetUser(int Id)
        {
            return userRepository.GetById(Id);
        }

        public User GetUser(string Account)
        {
            return userRepository.GetByAccount(Account);
        }        

        public void SaveUser()
        {
            unitOfWork.Commit();
        }

        // Call LDAP + Create New User for first login
        public User Authenticate(string loginUrl, LDAPLogin loginInfo)
        {
            try
            {
                using (HttpClient client = new HttpClient())
                {
                    client.BaseAddress = new Uri(loginUrl);
                    client.DefaultRequestHeaders.Accept.Clear();
                    client.DefaultRequestHeaders.Accept.Add(
                        new MediaTypeWithQualityHeaderValue("application/json"));
                    var authen = new
                    {
                        application = "che",
                        username = loginInfo.Username,
                        password = loginInfo.Password
                    };
                    var content = new StringContent(JsonConvert.SerializeObject(authen), Encoding.UTF8, "application/json");
                    var response = client.PostAsync("api/authen", content).Result;
                    
                    if (response.IsSuccessStatusCode)
                    {
                        var responseString = response.Content.ReadAsStringAsync();
                        responseString.Wait();
                        var authenRecord = JsonConvert.DeserializeObject<LDAPInfo>(responseString.Result);
                        var user = GetUser(loginInfo.Username);
                        if (user == null)
                        {
                            user = new User()
                            {
                                Account = loginInfo.Username,
                                Status = 1,
                                RoleId = 1,
                                SchoolId = 1,
                                DepartmentId = 1,
                                TitleId = 1,
                                EducationBackgroundId = 1,
                                DateCreated = DateTime.Now,
                                DateModified = DateTime.Now
                            };
                            userRepository.Add(user);
                            SaveUser();
                        }
                        return user;
                    }
                    else
                    {
                        System.Console.WriteLine(response);
                        return null;
                    }
                }
            }
            catch (Exception ex)
            {
                System.Console.WriteLine(ex.ToString());
                return null;
            }

        }

        public User GetDetail(int Id)
        {
            return userRepository.GetDetailById(Id);
        }

        public IEnumerable<User> GetUsers()
        {
            return userRepository.GetAll();
        }
    }
}
