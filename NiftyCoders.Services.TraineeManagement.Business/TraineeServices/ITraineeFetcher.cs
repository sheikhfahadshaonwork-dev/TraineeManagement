using NiftyCoders.Services.TraineeManagement.Business.TraineeServices.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NiftyCoders.Services.TraineeManagement.Business.TraineeServices;

public interface ITraineeFetcher
{
    List<TraineeResponseModel> Search(string? searchText);
    TraineeResponseModel GetTrainee(int id);
    TraineeResponseModel GetTraineeWithEmail(string email);

    List<TraineeResponseModel> GetAllTrainee(int pageNumber, int pageSize);
    List<TraineeResponseModel> GetAllTraineeWithinPeriod(TrainningPeriodRequestModel period);
    List<TraineeResponseModel> GetAllTraineeByYear(int year);
}
