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
    public interface ITitleService
    {
        IEnumerable<Title> GetTitles(string Code = null);
        Title GetTitle(int Id);
        Title GetTitle(string Code);
        void CreateTitle(Title Title);
        void UpdateTitle(Title Title);
        void DeleteTitle(Title Title);
        void SaveTitle();
    }
    public class TitleService : ITitleService
    {
        private readonly ITitleRepository TitleRepository;
        private readonly IUnitOfWork unitOfWork;

        public TitleService(ITitleRepository TitleRepository, IUnitOfWork unitOfWork)
        {
            this.TitleRepository = TitleRepository;
            this.unitOfWork = unitOfWork;
        }

        // Create
        public void CreateTitle(Title Title)
        {
            TitleRepository.Add(Title);
            SaveTitle();
        }

        // Delete
        public void DeleteTitle(Title Title)
        {
            TitleRepository.Delete(Title);
            SaveTitle();
        }

        // Get by Id
        public Title GetTitle(int Id)
        {
            return TitleRepository.GetById(Id);
        }

        // Get by code
        public Title GetTitle(string Code)
        {
            return TitleRepository.GetByCode(Code);
        }

        // Get all titles
        public IEnumerable<Title> GetTitles(string Code = null)
        {
            return TitleRepository.GetAll();
        }

        // Save change
        public void SaveTitle()
        {
            unitOfWork.Commit();
        }

        // Update
        public void UpdateTitle(Title Title)
        {
            TitleRepository.Update(Title);
            SaveTitle();
        }
    }
}
