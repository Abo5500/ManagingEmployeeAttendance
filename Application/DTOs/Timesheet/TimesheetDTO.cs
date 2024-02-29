using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.DTOs.Timesheet
{
    public class TimesheetDTO
    {
        public int Id { get; set; }
        public int EmployeeId { get; set; } //Подумать над отображением Employee
        public string EmployeeFirstName { get; set; }
        public string EmployeeLastName { get; set; }
        public int Reason { get; set; }
        public string StartDate { get; set; }
        public int Duration { get; set; }
        public bool Discounted { get; set; }
        public string Description { get; set; }
    }
}
