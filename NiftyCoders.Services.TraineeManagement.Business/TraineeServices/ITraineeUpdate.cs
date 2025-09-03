using NiftyCoders.Services.TraineeManagement.Business.TraineeServices.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NiftyCoders.Services.TraineeManagement.Business.TraineeServices;

public interface ITraineeUpdate
{
    void UpdateTraineeName(NameUpdateRequest request);
    int UpdateTrainee(TraineeUpdateRequestModel model, string email);
}
