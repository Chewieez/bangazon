using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;


namespace BangazonAPI.Models
{
    public class Department
    {
        [Key]
        public int DepartmentId { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public double ExpenseBudget {get; set;}

        public virtual ICollection<Employee> Employees { get; set; }

    }
}