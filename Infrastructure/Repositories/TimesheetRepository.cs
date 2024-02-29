using Application.DTOs.Timesheet;
using Application.DTOs.Timesheet.Requests;
using Application.Interfaces.Repositories;
using Application.Validators;
using Infrastructure.Repositories.Base;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Repositories
{
    public class TimesheetRepository : BaseSqlRepository, ITimesheetRepository
    {
        public TimesheetRepository(IConfiguration configuration) : base(configuration)
        {
        }
        public async Task<IEnumerable<TimesheetDTO>> GetAllAsync()
        {
            List<TimesheetDTO> result = new List<TimesheetDTO>();
            using var connect = new SqlConnection(_connectionString);
            connect.Open();
            SqlCommand cmd = new SqlCommand("spGetTimesheet", connect)
            {
                CommandType = System.Data.CommandType.StoredProcedure
            };
            using var reader = await cmd.ExecuteReaderAsync();
            {
                while(await reader.ReadAsync())
                {
                    result.Add(new TimesheetDTO
                    {
                        Id = Convert.ToInt32(reader["t.id"]),
                        EmployeeId = Convert.ToInt32(reader["e.id"]),
                        Reason = Convert.ToInt32(reader["t.reason"]),
                        StartDate = reader["t.start_date"].ToString().Split(' ')[0], //база присылает в формате dd-mm-yyyy 0:00:00
                        Duration = Convert.ToInt32(reader["t.duration"]),
                        Discounted = (bool)reader["t.discounted"],
                        Description = reader["t.description"].ToString(),
                        EmployeeLastName = reader["e.last_name"].ToString(),
                        EmployeeFirstName = reader["e.first_name"].ToString()
                    });
                }
            }
            return result;
        }

        public async Task<TimesheetCreateResponseDTO> CreateAsync(TimesheetCreateDTO createDTO)
        {
            TimesheetDTOValidator.Validate(createDTO);
            using var connect = new SqlConnection(_connectionString);
            connect.Open();
            SqlCommand cmd = new SqlCommand("spCreateTimesheet", connect)
            {
                CommandType = System.Data.CommandType.StoredProcedure
            };
            cmd.Parameters.AddWithValue("@employee", createDTO.EmployeeId);
            cmd.Parameters.AddWithValue("@reason", createDTO.Reason);
            cmd.Parameters.AddWithValue("@start_date", createDTO.StartDate);
            cmd.Parameters.AddWithValue("@duration", createDTO.Duration);
            cmd.Parameters.AddWithValue("@discounted", createDTO.Discounted);
            cmd.Parameters.AddWithValue("@description", createDTO.Description);
            
            int id = Convert.ToInt32(await cmd.ExecuteScalarAsync());
            return new TimesheetCreateResponseDTO() { Id = id};
        }

        public async Task<bool> DeleteAsync(int id)
        {
            using var connect = new SqlConnection(_connectionString);
            connect.Open();
            SqlCommand cmd = new SqlCommand("spDeleteTimesheet", connect)
            {
                CommandType = System.Data.CommandType.StoredProcedure
            };
            cmd.Parameters.AddWithValue("@id", id);
            int count = await cmd.ExecuteNonQueryAsync();
            if (count == 0)
                return false;
            return true;
        }
        public async Task<bool> UpdateAsync(int id, TimesheetUpdateDTO updateDTO)
        {
            TimesheetDTOValidator.Validate(updateDTO);
            using var connect = new SqlConnection(_connectionString);
            connect.Open();
            SqlCommand cmd = new SqlCommand("spUpdateTimesheet", connect)
            {
                CommandType = System.Data.CommandType.StoredProcedure
            };
            cmd.Parameters.AddWithValue("@id", id);
            cmd.Parameters.AddWithValue("@employee", updateDTO.EmployeeId);
            cmd.Parameters.AddWithValue("@reason", updateDTO.Reason);
            cmd.Parameters.AddWithValue("@start_date", updateDTO.StartDate);
            cmd.Parameters.AddWithValue("@duration", updateDTO.Duration);
            cmd.Parameters.AddWithValue("@discounted", updateDTO.Discounted);
            cmd.Parameters.AddWithValue("@description", updateDTO.Description);

            int count = await cmd.ExecuteNonQueryAsync();
            if(count == 0)
                return false;
            return true;
        }
    }
}
