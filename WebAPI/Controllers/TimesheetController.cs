using Application.DTOs.Timesheet;
using Application.DTOs.Timesheet.Requests;
using Application.Interfaces.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class TimesheetController: ControllerBase
    {
        private readonly ITimesheetRepository _timesheetRepository;

        public TimesheetController(ITimesheetRepository timesheetRepository)
        {
            _timesheetRepository = timesheetRepository;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllAsync()
        {
            return Ok(await _timesheetRepository.GetAllAsync());
        }
        [HttpPost]
        public async Task<IActionResult> CreateAsync(TimesheetCreateDTO dto)
        {
            return CreatedAtRoute(GetAllAsync(), await _timesheetRepository.CreateAsync(dto));
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateAsync([FromRoute]int id,TimesheetUpdateDTO dto)
        {
            if(await _timesheetRepository.UpdateAsync(id, dto))
                return NoContent();
            return NotFound();
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAsync([FromRoute]int id)
        {
            if(await _timesheetRepository.DeleteAsync(id))
                return NoContent();
            return NotFound();
        }
    }
}
