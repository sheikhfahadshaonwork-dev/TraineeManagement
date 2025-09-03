using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NiftyCoders.Services.TraineeManagement.Business.TraineeServices.Models;

public class TraineeUpdateRequestModel
{
    public string Name { get; set; }
    public int UniversityId { get; set; }
    public int TrainningPeriodId { get; set; }
}
