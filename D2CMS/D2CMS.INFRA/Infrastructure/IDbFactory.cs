using D2CMS.INFRA.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace D2CMS.INFRA.Infrastructure
{
    public interface IDbFactory : IDisposable
    {
        D2CMSEntities Init();
    }
}
