using Application.DTOs.Employee;
using Application.DTOs.Timesheet;
using Application.Interfaces.Repositories;
using Infrastructure.Repositories.Base;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Repositories
{
    public class EmployeeRepository : BaseSqlRepository, IEmployeeRepository
    {
        public EmployeeRepository(IConfiguration configuration) : base(configuration)
        {
        }

        public async Task<IEnumerable<EmployeeDTO>> GetAllAsync()
        {
            List<EmployeeDTO> result = new List<EmployeeDTO>();
            using var connect = new SqlConnection(_connectionString);
            connect.Open();
            SqlCommand cmd = new SqlCommand("spGetEmployees", connect)
            {
                CommandType = System.Data.CommandType.StoredProcedure
            };
            using var reader = await cmd.ExecuteReaderAsync();
            {
                while (await reader.ReadAsync())
                {
                    result.Add(new EmployeeDTO
                    {
                        Id = Convert.ToInt32(reader["id"]),
                        LastName = reader["last_name"].ToString(),
                        FirstName = reader["first_name"].ToString()
                    });
                }
            }
            return result;
        }
    }
}
