using D2CMS.CORE.Models;
using D2CMS.INFRA.Infrastructure;
using D2CMS.INFRA.Repositories;
using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace D2CMS.SERVICE.Core
{
    public interface IDepartmentService
    {
        IEnumerable<Department> GetDepartments();
        Department GetDepartmentById(int Id);
        Department GetDepartmentByCode(string Code);
        Department GetDepartmentByName(string Name);
        void CreateDepartment(Department Department);
        void SaveDepartment();
        void UpdateDepartment(Department deparment);
        void DeleteDepartment(Department department);
    }


    public class DepartmentService : IDepartmentService
    {
        private readonly IDepartmentRepository DepartmentRepository;
        private readonly IUnitOfWork unitOfWork;

        public DepartmentService(IDepartmentRepository DepartmentRepository, IUnitOfWork unitOfWork)
        {
            this.DepartmentRepository = DepartmentRepository;
            this.unitOfWork = unitOfWork;
        }

        

        

        //Create
        public void CreateDepartment(Department Department)
        {            
            DepartmentRepository.Add(Department);
            SaveDepartment();
        }

        //Delete
        public void DeleteDepartment(Department department)
        {
            DepartmentRepository.Delete(department);
            SaveDepartment();
        }

        //Update
        public void UpdateDepartment(Department deparment)
        {
            DepartmentRepository.Update(deparment);
            SaveDepartment();
        }

        //Get by Id
        public Department GetDepartmentById(int Id)
        {
            return DepartmentRepository.GetById(Id);
        }

        //Get by Code
        public Department GetDepartmentByCode(string Code)
        {
            return DepartmentRepository.GetByCode(Code);
        }

        //Get by Name
        public Department GetDepartmentByName(string Name)
        {
            return DepartmentRepository.GetByName(Name);
        }

        //Get all
        public IEnumerable<Department> GetDepartments()
        {
            return DepartmentRepository.GetAll();
        }

        public void SaveDepartment()
        {
            unitOfWork.Commit();
        }
    }
}
