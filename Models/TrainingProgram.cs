using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace BangazonAPI.Models
{
  public class TrainingProgram
  {
    [Key]
    public int TrainingProgramId { get; set; }

    [Required]
    [StringLength(55)]
    public string Name { get; set; }
    
    [Required]
    [DataType(DataType.Date)]
    public DateTime StartDate { get; set; }
   
    [Required]
    [DataType(DataType.Date)]
    public DateTime EndDate { get; set; }

    [Required]
    public int MaxAttendance { get; set; }

    IEnumerable<Employee> Employees;
  }
}