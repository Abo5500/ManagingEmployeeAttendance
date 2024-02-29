using Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Timesheet
    {
        public int Id { get; }
        public Employee Employee { get; set; }
        public AbsenceReasons Reason {  get; set; }
        public DateOnly StartDate { get; set; }
        public int Duration { get; set; }
        public bool Discounted { get; set; }
        public string Description { get; set; }
    }
}
