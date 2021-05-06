using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace challenge.Models
{
    public class Compensation
    {
        //using a stand alone primary key instead of forcing the foreign key to also function as the primary key
        //for the sake of following convention over configuration
        public string CompensationId { get; set; }
        public float Salary { get; set; }
        public DateTime EffectiveDate { get; set; }

        //EmployeeId is the foreign key
        //compensation must have an exisisting EmployeeId it is related to
        public string EmployeeId { get; set; }

        public virtual Employee Employee { get; set; }
    }
}
