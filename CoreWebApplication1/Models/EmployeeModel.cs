using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CoreWebApplication1.Models
{
    public class EmployeeModel
    {
        [Required(ErrorMessage = "Please enter Name")]
        [Display(Name = "Enter Name:")]
        public string Name { get; set; }
        [Required]
        public string Department { get; set; }
        [Required(ErrorMessage = "Please enter Salary")]
        [Range(2000, 10000, ErrorMessage = "Salary must be between 2k to 10K")]
        public int Salary { get; set; }
    }
}
