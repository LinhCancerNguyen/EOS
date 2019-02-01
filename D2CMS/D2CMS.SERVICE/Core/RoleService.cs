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
    public interface IRoleService
    {
        IEnumerable<Role> GetRoles(string Fullname = null);
        Role GetRole(int Id);    
        void CreateRole(Role role);
        void SaveRole();
        void Update(Role role);
        void Delete(Role role);
        Role GetRole(string Name);
    }

    public class RoleService : IRoleService
    {
        private readonly IRoleRepository roleRepository;
        private readonly IUnitOfWork unitOfWork;

        public RoleService(IRoleRepository roleRepository, IUnitOfWork unitOfWork)
        {
            this.roleRepository = roleRepository;
            this.unitOfWork = unitOfWork;
        }
        
        public void CreateRole(Role role)
        {
            roleRepository.Add(role);
            SaveRole();
        }

        public void Delete(Role role)
        {
            roleRepository.Delete(role);
            SaveRole();
        }

        public Role GetRole(int Id)
        {
            return roleRepository.GetById(Id);
        }

        public Role GetRole(string Name)
        {
            return roleRepository.GetByName(Name);
        }

        public IEnumerable<Role> GetRoles(string Fullname = null)
        {
            return roleRepository.GetAll();
        }

        public void SaveRole()
        {
            unitOfWork.Commit();
        }

        public void Update(Role role)
        {
            roleRepository.Update(role);
            SaveRole();
        }
    }
}
