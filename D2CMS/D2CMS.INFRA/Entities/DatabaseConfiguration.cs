using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Text;

namespace D2CMS.INFRA.Entities
{
    public class DatabaseConfiguration : ConfigurationBase
    {
        private readonly string ConnectionString = "DBConnectionString";

        public string GetConnectionString()
        {
            return GetConfiguration().GetConnectionString(ConnectionString);
        }
    }
}
