using Microsoft.EntityFrameworkCore;
using EXAMSYSTEM.CORE.Models;
using EXAMSYSTEM.INFRA.Infrastructure;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace EXAMSYSTEM.INFRA.Repositories
{
    public class UserExamRepository : RepositoryBase<UserExam>, IUserExamRepository
    {
        public UserExamRepository(IDbFactory dbFactory) : base(dbFactory) { }

        public UserExam GetUserExam(int Id)
        {
            var userexam = (from ue in this.DbContext.UserExams
                             join u in this.DbContext.Users
                             on ue.UserId equals u.UserId
                             join s in this.DbContext.Subjects
                             on ue.SubjectId equals s.SubjectId
                             where ue.UserExamId == Id
                             select new UserExam
                             {
                                 UserExamId = ue.UserExamId,
                                 Score = ue.Score,
                                 UserId = u.UserId,
                                 SubjectId = s.SubjectId,
                                 User = u,
                                 Subject = s
                             }).FirstOrDefault();
            return userexam;
        }

        public IEnumerable<UserExam> GetUserExams()
        {
            var userexams =(from ue in this.DbContext.UserExams
                            join u in this.DbContext.Users
                            on ue.UserId equals u.UserId
                            join s in this.DbContext.Subjects
                            on ue.SubjectId equals s.SubjectId
                            select new UserExam
                            {
                                UserExamId = ue.UserExamId,
                                Score = ue.Score,
                                UserId = u.UserId,
                                SubjectId = s.SubjectId,
                                User = u,
                                Subject = s
                            }).ToList();
            return userexams;
        }
    }
    public interface IUserExamRepository : IRepository<UserExam>
    {
        IEnumerable<UserExam> GetUserExams();
        UserExam GetUserExam(int Id);
    }
}
