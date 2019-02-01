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
    public interface ISchoolService
    {
        IEnumerable<School> GetSchools(string Code = null);
        School GetSchool(int Id);
        School GetSchool(string Name);
        void CreateSchool(School School);
        void UpdateSchool(School School);
        void DeleteSchool(School School);
        void SaveSchool();
    }
    public class SchoolService : ISchoolService
    {
        private readonly ISchoolRepository SchoolRepository;
        private readonly IUnitOfWork unitOfWork;
        

        public SchoolService(ISchoolRepository SchoolRepository, IUnitOfWork unitOfWork)
        {
            this.SchoolRepository = SchoolRepository;
            this.unitOfWork = unitOfWork;
          
        }

        // Create
        public void CreateSchool(School School)
        {            
                SchoolRepository.Add(School);
                SaveSchool();                        
        }

        // Delete
        public void DeleteSchool(School School)
        {
            SchoolRepository.Delete(School);
            SaveSchool();
        }

        // Get by id
        public School GetSchool(int Id)
        {
            return SchoolRepository.GetById(Id);
        }

        // Get by name
        public School GetSchool(string Name)
        {
            return SchoolRepository.GetByName(Name);
        }

        // Get all
        public IEnumerable<School> GetSchools(string Code = null)
        {
            return SchoolRepository.GetAll();
        }

        // Save change
        public void SaveSchool()
        {
            unitOfWork.Commit();
        }

        // Update
        public void UpdateSchool(School School)
        {
            SchoolRepository.Update(School);
            SaveSchool();
        }
    }
}
