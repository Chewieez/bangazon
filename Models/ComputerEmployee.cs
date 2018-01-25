using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace BangazonAPI.Models
{
  public class ComputerEmployee
  {
    [Key]
    public int ComputerEmployeeId { get; set; }
    
    [Required]
    [DataType(DataType.Date)]
    public DateTime DateAssigned { get; set; }
   
    [DataType(DataType.Date)]
    public DateTime? DateRemoved { get; set; }

	public int EmployeeId { get; set; }
	public Employee Employee { get; set; }
	public int ComputerId { get; set; }
	public Computer Computer { get; set; }
  }
}