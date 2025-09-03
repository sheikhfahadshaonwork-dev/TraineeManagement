using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NiftyCoders.Services.TraineeManagement.Persistence.Entities;

public class University
{
    public int Id { get; set; }
    public string Name { get; set; }
    public List<Trainee> Trainees { get; set; }

}
