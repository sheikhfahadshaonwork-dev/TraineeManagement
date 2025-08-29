using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NiftyCoders.Services.TraineeManagement.Business.Models;

public class TraineeResponseModel
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Email { get; set; }
    public string UniversityName { get; set; }
    public DateTime TrainningPeriodStart { get; set; }
    public DateTime TrainningPeriodEnd { get; set; }
}
