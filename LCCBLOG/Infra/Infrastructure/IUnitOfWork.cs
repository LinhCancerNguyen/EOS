using System;
using System.Collections.Generic;
using System.Text;

namespace Infra.Infrastructure
{
    public interface IUnitOfWork
    {
        void Commit();
    }
}
