using System;
using System.Threading.Tasks;
using Gosinfoproj.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace Gosinfoproj.Controllers
{
    [ApiController]
    [Route("[controller]")]
    [Produces("application/json")]
    public class EmployeeController : ControllerBase
    {
        private readonly ILogger<EmployeeController> _logger;
        private readonly IEmployeeService _employeeService;

        public EmployeeController(ILogger<EmployeeController> logger,
            IEmployeeService employeeService)
        {
            _employeeService = employeeService;
            _logger = logger;
        }

        [HttpGet]
        public async Task<ActionResult<Employee>> GetAsync(Guid? id, string name)
        {
            try
            {
                var result = await _employeeService.GetAsync(id, name);
                return Ok(result);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message, ex.StackTrace);
                return BadRequest(ex);
            }
        }

        [HttpGet]
        [Route("GetOne")]
        public async Task<ActionResult<Employee>> GetByIdAsync(Guid id)
        {
            try
            {
                var result = await _employeeService.GetByIdAsync(id);
                return Ok(result);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message, ex.StackTrace);
                return BadRequest(ex);
            }
        }

        [HttpPost]
        public async Task<ActionResult<Guid>> CreateAsync([FromBody] Employee employee)
        {
            try
            {
                var result = await _employeeService.CreateAsync(employee);
                return Ok(result);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message, ex.StackTrace);
                return BadRequest(ex);
            }
        }

        [HttpPut]
        public async Task<ActionResult<Guid>> UpdateAsync([FromBody] Employee employee)
        {
            try
            {
                var result = await _employeeService.UpdateAsync(employee);
                return Ok(result);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message, ex.StackTrace);
                return BadRequest(ex);
            }
        }

        [HttpDelete]
        public async Task<ActionResult> DeleteAsync(Guid id)
        {
            try
            {
                await _employeeService.DeleteAsync(id);
                return Ok();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message, ex.StackTrace);
                return BadRequest(ex);
            }
        }
    }
}
