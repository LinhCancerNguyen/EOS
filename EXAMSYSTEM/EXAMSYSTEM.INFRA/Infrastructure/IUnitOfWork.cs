using System;
using System.Collections.Generic;
using System.Text;

namespace EXAMSYSTEM.INFRA.Infrastructure
{
    public interface IUnitOfWork
    {
        void Commit();
    }
}
