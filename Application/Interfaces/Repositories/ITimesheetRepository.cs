using Application.DTOs.Timesheet;
using Application.DTOs.Timesheet.Requests;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Interfaces.Repositories
{
    public interface ITimesheetRepository
    {
        Task<IEnumerable<TimesheetDTO>> GetAllAsync();
        Task<TimesheetCreateResponseDTO> CreateAsync(TimesheetCreateDTO createDTO);
        Task<bool> UpdateAsync(int id, TimesheetUpdateDTO updateDTO);
        Task<bool> DeleteAsync(int id);
    }
}
