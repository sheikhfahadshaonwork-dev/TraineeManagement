using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NiftyCoders.Services.TraineeManagement.Business.TraineeServices.Models;

public class TraineeCreateRequestModel
{
    [MaxLength(40, ErrorMessage ="Name should not be more than 40 characters")]
    public string Name { get; set; }
    [Required]
    [MaxLength(100, ErrorMessage ="Email should be around 100 characters")]
    [RegularExpression(@"^[^@\s]+@[^@\s]+\.[^@\s]+$",
        ErrorMessage = "Invalid email format")]
    public string Email { get; set; }
    [Required]
    public int UniversityId { get; set; }
    public int TrainningPeriodId { get; set; }

}
