using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NiftyCoders.Services.TraineeManagement.Business.TraineeServices.Models;

public class TraineeResponseModel
{
    public string Name { get; set; }
    public string Email { get; set; }  
    public string University { get; set; }
    public DateOnly StartDate { get; set; }
    public DateOnly EndDate { get; set;}
}
