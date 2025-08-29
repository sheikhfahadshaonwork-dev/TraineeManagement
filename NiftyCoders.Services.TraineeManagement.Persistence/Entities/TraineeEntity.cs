using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NiftyCoders.Services.TraineeManagement.Persistence.Entities;

public class TraineeEntity
{
    private static int _availableId = 1;
    public int Id { get; set; }
    public string Name { get; set; }
    public string Email { get; set; }
    public TrainningPeriodEntity TrainningPeriod { get; set; }
    public UniversityEntity University { get; set; }

    public TraineeEntity(string name, string email, TrainningPeriodEntity trainningPeriod, UniversityEntity university)
    {
        Id = _availableId++;
        Name = name;
        Email = email;
        TrainningPeriod = trainningPeriod;
        University = university;
    }


}
