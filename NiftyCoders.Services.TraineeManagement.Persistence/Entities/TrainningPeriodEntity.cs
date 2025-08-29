using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NiftyCoders.Services.TraineeManagement.Persistence.Entities;

public class TrainningPeriodEntity
{
    private static int _availableId = 1;
    public int Id { get; set; }
    public DateTime StartDate { get; set; }
    public DateTime EndDate { get; set; }
    public TrainningPeriodEntity(DateTime startDate, DateTime endDate)
    {
        Id = _availableId++;
        StartDate = startDate;
        EndDate = endDate;
    }
}
