using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NiftyCoders.Services.TraineeManagement.Business.TraineeServices.Models;

public class TrainningPeriodRequestModel
{
    public DateOnly StartDate { get; set; }
    public DateOnly EndDate { get; set; }
}
