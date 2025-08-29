using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NiftyCoders.Services.TraineeManagement.Persistence.Entities;

public class UniversityEntity
{
    private static int _availableId = 1;
    public int Id { get; set; }
    public string Name { get; set; }
    public UniversityEntity(string name)
    {
        Id = _availableId++;
        Name = name;
    }
}
