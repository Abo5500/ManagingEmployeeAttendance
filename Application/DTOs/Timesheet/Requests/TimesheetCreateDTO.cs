using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.DTOs.Timesheet.Requests
{
    public class TimesheetCreateDTO
    {
        public int EmployeeId { get; set; }
        public int Reason { get; set; }
        public string StartDate { get; set; }
        public int Duration { get; set; }
        public bool Discounted { get; set; }
        public string Description { get; set; }
    }
}
