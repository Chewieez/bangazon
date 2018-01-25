using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace BangazonAPI.Models
{
  public class Computer
  {
    [Key]
    public int ComputerId { get; set; }

    [Required]
    [StringLength(55)]
    public string Name { get; set; }

	[Required]
    [StringLength(55)]
    public string SerialNumber { get; set; }
    
    [Required]
    [DataType(DataType.Date)]
    public DateTime PurchaseDate { get; set; }
   
    [Required]
    [DataType(DataType.Date)]
    public DateTime DecommissionDate { get; set; }

    IEnumerable<ComputerEmployee> ComputerEmployees;
  }
}