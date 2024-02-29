using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Repositories.Base
{
    public abstract class BaseSqlRepository
    {
        protected readonly string _connectionString;
        public BaseSqlRepository(IConfiguration configuration)
        {
            _connectionString = configuration.GetConnectionString("DefaultConnection")
                ?? throw new Exception("DefaultConnection is empty"); //Здесь должен быть кастомный exception с логгированием
        }
    }
}
