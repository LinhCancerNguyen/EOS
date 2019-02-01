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
    public interface IEducationBackgroundService
    {
        IEnumerable<EducationBackground> GetEducationBackgrounds(string Fullname = null);
        EducationBackground GetEducationBackground(int Id);          
        void CreateEducationBackground(EducationBackground educationBackground);
        void SaveEducationBackground();
        void UpdateBackground(EducationBackground educationBackground);
        void Delete(EducationBackground educationBackground);
        EducationBackground GetEducationBackground(string Name);

    }
    public class EducationBackgroundService : IEducationBackgroundService
    {
        private readonly IEducationBackgroundRepository educationBackgroundRepository;
        private readonly IUnitOfWork unitOfWork;

        public EducationBackgroundService(IEducationBackgroundRepository educationBackgroundRepository, IUnitOfWork unitOfWork)
        {
            this.educationBackgroundRepository = educationBackgroundRepository;
            this.unitOfWork = unitOfWork;
        }

        public void CreateEducationBackground(EducationBackground educationBackground)
        {
            educationBackgroundRepository.Add(educationBackground);
            SaveEducationBackground();
        }

        public void Delete(EducationBackground educationBackground)
        {
            educationBackgroundRepository.Delete(educationBackground);
            SaveEducationBackground();
        }

        public EducationBackground GetEducationBackground(int Id)
        {
            return educationBackgroundRepository.GetById(Id);
        }

        public EducationBackground GetEducationBackground(string Name)
        {
            return educationBackgroundRepository.GetByName(Name);
        }

        public IEnumerable<EducationBackground> GetEducationBackgrounds(string Fullname = null)
        {           
                return educationBackgroundRepository.GetAll();           
        }

        public void SaveEducationBackground()
        {
            unitOfWork.Commit();
        }

        public void UpdateBackground(EducationBackground educationBackground)
        {
            educationBackgroundRepository.Update(educationBackground);
            SaveEducationBackground();
        }
    }
}
