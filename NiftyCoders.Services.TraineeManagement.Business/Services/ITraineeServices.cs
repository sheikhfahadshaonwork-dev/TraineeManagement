using NiftyCoders.Services.TraineeManagement.Business.Models;
using NiftyCoders.Services.TraineeManagement.Persistence.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NiftyCoders.Services.TraineeManagement.Business.Services;

public interface ITraineeServices
{
    List<TraineeResponseModel> GetAllTrainees(int pageNum, int pageSize);
    TraineeResponseModel GetTraineeById(int id);
    TraineeResponseModel GetTraineeByEmail(EmailRequestModel email);
    List<TraineeResponseModel> GetTraineesByUniversity(string university);
    List<TraineeResponseModel> GetTrineesByYear(int year);
    List<TraineeResponseModel> GetTraineesByTrainningPeriod(TrainningPeriodRequestModel trainningPeriod);
    void AddTrainee(TraineeCreateRequestModel trainee);
    void RemoveTrainee(EmailRequestModel Email);
    void UpdateTrainee(TraineeResponseModel trainee);
    void UpdateNameOfTrainee(NameUpdateRequestModel nameUpdate);
    void DeleteTrainee(int id);
}
