using NiftyCoders.Services.TraineeManagement.Persistence.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NiftyCoders.Services.TraineeManagement.Persistence.Repositories;

public class UniversityRepository
{
    public UniversityEntity? GetUniversityObj(string name)
    {
        return Database.Universities.FirstOrDefault(u => u.Name.Equals(name));
    }
}
