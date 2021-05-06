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
    [Route("api/numReports")]
    public class NumReportsController : Controller
    {
        private readonly ILogger _logger;
        private readonly IEmployeeService _employeeService;

        public NumReportsController(ILogger<EmployeeController> logger, IEmployeeService employeeService)
        {
            _logger = logger;
            _employeeService = employeeService;
        }

        //This reporting structure does not persist and only reference data within employees
        //So I decided to place the counterReports functions within the employeeService
        //The unique controller exists inorder to have a unique REST endpoint
        [HttpGet("{id}", Name = "getNumReportsById")]
        public IActionResult GetNumReportsById(String id)
        {
            _logger.LogDebug($"Received numReports get request for '{id}'");

            var employee = _employeeService.GetById(id);

            if (employee == null)
                return NotFound();

            var result = _employeeService.countReports(employee);
            return Ok(result);
        }
    }
}
