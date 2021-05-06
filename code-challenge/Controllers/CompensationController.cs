using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using challenge.Services;
using challenge.Models;

namespace challenge.Controllers
{
    [Route("api/compensation")]
    public class CompensationController : Controller
    {
        private readonly ILogger _logger;
        private readonly IEmployeeService _employeeService;
        private readonly ICompensationService _compensationService;

        public CompensationController(ILogger<EmployeeController> logger, IEmployeeService employeeService, ICompensationService compensationService)
        {
            _logger = logger;
            _employeeService = employeeService;
            _compensationService = compensationService;
        }

        [HttpPost]
        public IActionResult CreateCompensation([FromBody] Compensation compensation)
        {
            //Must have an unique existing employee ID inorder to create a compensation
            //Strongly connected, One to one relationship
            _logger.LogDebug($"Received compensation create request for '{compensation.EmployeeId}'");

            var existingEmployee = _employeeService.GetById(compensation.EmployeeId);
            if (existingEmployee == null)
                return NotFound();

            compensation.Employee = existingEmployee;
            _compensationService.Create(compensation);

            return CreatedAtRoute("getCompensationByEmployeeId", new { id = compensation.EmployeeId }, compensation);
        }

        [HttpGet("{id}", Name = "getCompensationByEmployeeId")]
        public IActionResult GetCompensationByEmployeeId(String id)
        {
            _logger.LogDebug($"Received compensation get request for '{id}'");

            var compensation = _compensationService.GetByEmployeeId(id);

            if (compensation == null)
                return NotFound();

            return Ok(compensation);
        }
    }
}
