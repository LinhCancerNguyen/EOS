using Infra.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Infra.Infrastructure
{
    public interface IDbFactory : IDisposable
    {
        MyBlogEntity Init();
    }
}
