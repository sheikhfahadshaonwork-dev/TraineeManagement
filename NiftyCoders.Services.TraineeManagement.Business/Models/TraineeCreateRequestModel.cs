using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NiftyCoders.Services.TraineeManagement.Business.Models;

public class TraineeCreateRequestModel
{
    [Required]
    [MaxLength(100, ErrorMessage = "Name can not more than 100 characters")]
    public string Name { get; set; }

    [Required]
    [RegularExpression(@"^[^@\s]+@[^@\s]+\.[^@\s]+$",
        ErrorMessage = "Invalid email format")]
    public string Email { get; set; }

    [Required]
    [MaxLength(30, ErrorMessage = "University Name can not more than 30 characters")]
    public string UniversityName { get; set; }

    [Required]
    public DateTime TrainningPeriodStart { get; set; }

    [Required]
    public DateTime TrainningPeriodEnd { get; set; }
}
