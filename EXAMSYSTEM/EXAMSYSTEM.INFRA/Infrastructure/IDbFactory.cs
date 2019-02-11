using EXAMSYSTEM.INFRA.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace EXAMSYSTEM.INFRA.Infrastructure
{
    public interface IDbFactory : IDisposable
    {
        ExamSystemEntities Init();
    }
}
