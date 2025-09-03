using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NiftyCoders.Services.TraineeManagement.Persistence.Entities;

public class TrainningPeriod
{
    private static int _availableId = 1;
    public int Id { get; set; }
    public DateOnly StartDate { get; set; }
    public DateOnly EndDate { get; set; }

    public List<Trainee> Trainees { get; set; }

    public void TainningPeriod() { }
    public TrainningPeriod(DateOnly startDate)
    {
        StartDate = startDate;
        EndDate = startDate.AddMonths(4);
    }
}
