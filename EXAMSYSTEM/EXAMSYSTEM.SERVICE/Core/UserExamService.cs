using EXAMSYSTEM.CORE.Models;
using EXAMSYSTEM.INFRA.Infrastructure;
using EXAMSYSTEM.INFRA.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EXAMSYSTEM.SERVICE.Core
{
    public interface IUserExamService
    {
        IEnumerable<UserExam> GetUserExams();
        UserExam GetUserExam(int Id);
        void CreateUserExam(UserExam userExam);
        void SaveUserExam();
        void Update(UserExam userExam);
        void Delete(UserExam userExam);
    }

    public class UserExamService : IUserExamService
    {
        private readonly IUserExamRepository userExamRepository;
        private readonly IUnitOfWork unitOfWork;

        public UserExamService(IUserExamRepository userExamRepository, IUnitOfWork unitOfWork)
        {
            this.userExamRepository = userExamRepository;
            this.unitOfWork = unitOfWork;
        }

        public void CreateUserExam(UserExam userExam)
        {
            userExamRepository.Add(userExam);
            SaveUserExam();
        }

        public void Delete(UserExam userExam)
        {
            userExamRepository.Delete(userExam);
            SaveUserExam();
        }

        public UserExam GetUserExam(int Id)
        {
            return userExamRepository.GetUserExam(Id);
        }

        public IEnumerable<UserExam> GetUserExams()
        {
            return userExamRepository.GetUserExams().OrderByDescending(u => u.UserExamId);
        }

        public void SaveUserExam()
        {
            unitOfWork.Commit();
        }

        public void Update(UserExam userExam)
        {
            userExamRepository.Edit(userExam);
            SaveUserExam();
        }
    }
}
