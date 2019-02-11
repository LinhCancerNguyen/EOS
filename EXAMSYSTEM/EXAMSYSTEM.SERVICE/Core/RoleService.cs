using EXAMSYSTEM.CORE.Models;
using EXAMSYSTEM.INFRA.Infrastructure;
using EXAMSYSTEM.INFRA.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EXAMSYSTEM.SERVICE.Core
{
    public interface IRoleService
    {
        IEnumerable<Role> GetRoles(string RoleName = null);
        Role GetRole(int Id);
        void CreateRole(Role role);
        void SaveRole();
        void Update(Role role);
        void Delete(Role role);
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

        public IEnumerable<Role> GetRoles(string RoleName = null)
        {
            return roleRepository.GetAll();
        }

        public void SaveRole()
        {
            unitOfWork.Commit();
        }

        public void Update(Role role)
        {
            roleRepository.Edit(role);
            SaveRole();
        }
    }
}
