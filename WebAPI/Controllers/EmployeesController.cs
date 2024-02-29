using Application.Interfaces.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class EmployeesController: ControllerBase
    {
        private readonly IEmployeeRepository _employeeRepository;

        public EmployeesController(IEmployeeRepository employeeRepository)
        {
            _employeeRepository = employeeRepository;
        }
        [HttpGet]
        public async Task<IActionResult> GetALlAsync()
        {
            return Ok(await _employeeRepository.GetAllAsync());
        }
    }
}
