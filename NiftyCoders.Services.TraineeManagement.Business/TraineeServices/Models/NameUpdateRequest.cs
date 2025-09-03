using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NiftyCoders.Services.TraineeManagement.Business.TraineeServices.Models;

public class NameUpdateRequest
{
    [Required, MaxLength(40, ErrorMessage ="Name should not be more than 40 characters")]
    public string Name { get; set; }
    [Required]
    [RegularExpression(@"^[^@\s]+@[^@\s]+\.[^@\s]+$",
        ErrorMessage = "Invalid email format")]
    public string Email { get; set; }
}
