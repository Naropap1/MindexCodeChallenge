using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace challenge.Models
{
    public class Employee
    {
        public String EmployeeId { get; set; }
        public String FirstName { get; set; }
        public String LastName { get; set; }
        public String Position { get; set; }
        public String Department { get; set; }
        public List<Employee> DirectReports { get; set; }

        //created a Compensation item inorder to complete the one to one relationship
        //Every Employee does need to have a compensation, but every compensation needs to have an employee
        public Compensation Compensation { get; set; }
    }
}
