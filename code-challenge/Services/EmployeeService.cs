using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using challenge.Models;
using Microsoft.Extensions.Logging;
using challenge.Repositories;

namespace challenge.Services
{
    public class EmployeeService : IEmployeeService
    {
        private readonly IEmployeeRepository _employeeRepository;
        private readonly ILogger<EmployeeService> _logger;

        public EmployeeService(ILogger<EmployeeService> logger, IEmployeeRepository employeeRepository)
        {
            _employeeRepository = employeeRepository;
            _logger = logger;
        }

        public Employee Create(Employee employee)
        {
            if(employee != null)
            {
                _employeeRepository.Add(employee);
                _employeeRepository.SaveAsync().Wait();
            }

            return employee;
        }

        public Employee GetById(string id)
        {
            if(!String.IsNullOrEmpty(id))
            {
                return _employeeRepository.GetById(id);
            }

            return null;
        }

        public Employee Replace(Employee originalEmployee, Employee newEmployee)
        {
            if(originalEmployee != null)
            {
                _employeeRepository.Remove(originalEmployee);
                if (newEmployee != null)
                {
                    // ensure the original has been removed, otherwise EF will complain another entity w/ same id already exists
                    _employeeRepository.SaveAsync().Wait();

                    _employeeRepository.Add(newEmployee);
                    // overwrite the new id with previous employee id
                    newEmployee.EmployeeId = originalEmployee.EmployeeId;
                }
                _employeeRepository.SaveAsync().Wait();
            }

            return newEmployee;
        }


        //keep track of visited ID's to avoid infinite loops and duplicates
        //the nature of direct reports implies that there should never be any infinite loops - potentially making this check unnecessary 
        //direct reports also can imply exclusively one superior - which would mean duplicates never occur
        private HashSet<String> vistedIds = new HashSet<string>();

        public ReportingStructure countReports(Employee employee)
        {
            ReportingStructure result = new ReportingStructure();

            result.employee = employee;

            vistedIds.Clear();
            result.numberOfReports = countReportsRecur(employee);

            //The above function populates employee.DirectReports
            //Making DirectReports null is done for readability's sake
            result.employee.DirectReports = null;

            return result;
        }

        //simple recursive method to count reports
        private int countReportsRecur(Employee employee)
        {
            //direct reports creates a list of employees using GetById
            //the recursive method works nicely if my input expects this type of employee
            //and the first thing I do is querry a get command that includes direct reports
            var EmployeeWithDirectReports = _employeeRepository.GetByIdIncludeDirectReports(employee.EmployeeId);
            int reports = 0;

            if (!(EmployeeWithDirectReports.DirectReports is null))
            {
                foreach (Employee e in EmployeeWithDirectReports.DirectReports)
                {
                    if (!vistedIds.Contains(e.EmployeeId))
                    {
                        reports++;
                        vistedIds.Add(e.EmployeeId);
                        reports += countReportsRecur(e);
                    }
                }
            }
                
            return reports;
        }
    }
}
