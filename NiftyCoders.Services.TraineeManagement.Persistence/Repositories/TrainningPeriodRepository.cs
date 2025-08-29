using NiftyCoders.Services.TraineeManagement.Persistence.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NiftyCoders.Services.TraineeManagement.Persistence.Repositories;

public class TrainningPeriodRepository
{
    public TrainningPeriodEntity? GetTrainningPeriodObj(DateTime startDate, DateTime endDate)
    {
        return Database.TrainningPeriods.FirstOrDefault(tp => tp.StartDate == startDate && tp.EndDate == endDate);
    }
}
