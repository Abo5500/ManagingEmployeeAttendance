using Application.Exceptions;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Enums;
using Application.DTOs.Timesheet.Requests;
using Application.DTOs.Timesheet;

namespace Application.Validators
{
    public static class TimesheetDTOValidator
    {
        public static void Validate(TimesheetCreateDTO dto)
        {
            ValidateDate(dto.StartDate);
            ValidateReason(dto.Reason);
            ValidateDuration(dto.Duration);
            ValidateDescription(dto.Description);
        }
        public static void Validate(TimesheetUpdateDTO dto)
        {
            ValidateDate(dto.StartDate);
            ValidateReason(dto.Reason);
            ValidateDuration(dto.Duration);
            ValidateDescription(dto.Description);
        }
        private static void ValidateDate(string date)
        {
            string format = "yyyy-MM-dd";
            if (!DateTime.TryParseExact(date, format, DateTimeFormatInfo.InvariantInfo, DateTimeStyles.None, out DateTime scheduleDate))
            {
                throw new ApiException("Некорректный формат даты");
            }
        }
        private static void ValidateReason(int reason)
        {
            if(reason < 1 || reason > Enum.GetValues(typeof(AbsenceReasons)).Length)
            {
                throw new ApiException();
            }
        }
        private static void ValidateDuration(int duration)
        {
            if(duration < 0)
            {
                throw new ApiException();
            }
        }
        private static void ValidateDescription(string description)
        {
            if(string.IsNullOrEmpty(description))
            {
                throw new ApiException("Комментарий не должен быть пустым");
            }
            if(description.Length > 1024)
            {
                throw new ApiException("Длина комментария должна быть не больше 1024 символов");
            }
        }
    }
}
