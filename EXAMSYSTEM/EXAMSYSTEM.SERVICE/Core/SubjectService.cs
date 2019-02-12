using EXAMSYSTEM.CORE.Models;
using EXAMSYSTEM.CORE.ModelViews;
using EXAMSYSTEM.INFRA.Infrastructure;
using EXAMSYSTEM.INFRA.Repositories;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EXAMSYSTEM.SERVICE.Core
{
    public interface ISubjectService
    {
        IEnumerable<Subject> GetSubjects();
        IEnumerable<SelectListItem> GetAllSubjects();
        Subject GetSubject(int Id);
        Subject GetSubjectByName(string name);
        void CreateSubject(Subject subject);
        void SaveSubject();
        void Update(Subject subject);
        void Delete(Subject subject);
    }

    public class SubjectService : ISubjectService
    {
        private readonly ISubjectRepository subjectRepository;
        private readonly IUnitOfWork unitOfWork;

        public SubjectService(ISubjectRepository subjectRepository, IUnitOfWork unitOfWork)
        {
            this.subjectRepository = subjectRepository;
            this.unitOfWork = unitOfWork;
        }

        public void CreateSubject(Subject subject)
        {
            subjectRepository.Add(subject);
            SaveSubject();
        }

        public void Delete(Subject subject)
        {
            subjectRepository.Delete(subject);
            SaveSubject();
        }

        public IEnumerable<SelectListItem> GetAllSubjects()
        {
            return subjectRepository.GetAllSubjects();
        }

        public Subject GetSubject(int Id)
        {
            return subjectRepository.GetById(Id);
        }

        public Subject GetSubjectByName(string name)
        {
            return subjectRepository.GetSubjectbyName(name);
        }

        public IEnumerable<Subject> GetSubjects()
        {
            return subjectRepository.GetAll().OrderByDescending(s => s.SubjectId);
        }

        public void SaveSubject()
        {
            unitOfWork.Commit();
        }

        public void Update(Subject subject)
        {
            subjectRepository.Edit(subject);
            SaveSubject();
        }
    }
}
