using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace D2CMS.INFRA.Infrastructure
{
    public interface IUnitOfWork
    {
        void Commit();
    }
}
