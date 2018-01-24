using System;
using System.ComponentModel.DataAnnotations;

namespace BangazonAPI.Models
{
  public class TrainingEmployee
  {
    [Key]
    public int TrainingEmployeeId { get; set; }

    [Required]
    public int TrainingProgramId { get; set; }
    public TrainingProgram TrainingProgram {get; set;}

    [Required]
    public int EmployeeId { get; set; }

    public Employee Employee {get; set;}

  }
}