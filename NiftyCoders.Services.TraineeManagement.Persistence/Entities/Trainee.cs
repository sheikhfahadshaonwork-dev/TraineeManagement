using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NiftyCoders.Services.TraineeManagement.Persistence.Entities;

public class Trainee
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Email { get; set; }

    public int UniversityId { get; set; }
    public int TrainningPeriodId { get; set; }

    public virtual TrainningPeriod TrainningPeriod { get; set; }
    public virtual University University { get; set; }

}
