using NiftyCoders.Services.TraineeManagement.Business.Models;
using NiftyCoders.Services.TraineeManagement.Persistence.Entities;
using NiftyCoders.Services.TraineeManagement.Persistence.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NiftyCoders.Services.TraineeManagement.Business.Services;

public class TraineeServices : ITraineeServices
{
    private readonly TraineeRepository _traineeRepository;
    private readonly UniversityRepository _universityRepository;
    private readonly TrainningPeriodRepository _trainningPeriodRepository;

    public TraineeServices(TraineeRepository traineeRepository, UniversityRepository universityRepository, TrainningPeriodRepository trainningPeriodRepository)
    {
        _traineeRepository = traineeRepository;
        _universityRepository = universityRepository;
        _trainningPeriodRepository = trainningPeriodRepository;
    }

    private TraineeEntity MapToEntity(TraineeCreateRequestModel trainee)
    {
        var university = _universityRepository.GetUniversityObj(trainee.UniversityName);
        if (university == null)
        {
            university = new UniversityEntity(trainee.UniversityName);
        }
        var trainningPeriod = _trainningPeriodRepository.GetTrainningPeriodObj(trainee.TrainningPeriodStart, trainee.TrainningPeriodEnd);
        if (trainningPeriod == null)
        {
            trainningPeriod = new TrainningPeriodEntity(trainee.TrainningPeriodStart, trainee.TrainningPeriodEnd);
        }
        var traineeEntity = new TraineeEntity(trainee.Name, trainee.Email, trainningPeriod, university);
        return traineeEntity;
    }

    private TraineeResponseModel MapToResponseModel(TraineeEntity trainee)
    {
        var traineeResponseModel = new TraineeResponseModel
        {
            Id = trainee.Id,
            Name = trainee.Name,
            Email = trainee.Email,
            UniversityName = trainee.University.Name,
            TrainningPeriodStart = trainee.TrainningPeriod.StartDate,
            TrainningPeriodEnd = trainee.TrainningPeriod.EndDate
        };
        return traineeResponseModel;
    }

    public void AddTrainee(TraineeCreateRequestModel trainee)
    {
        _traineeRepository.AddTrainee(MapToEntity(trainee));
    }

    public void DeleteTrainee(int id)
    {
        throw new NotImplementedException();
    }

    public List<TraineeResponseModel> GetAllTrainees(int pageNum, int pageSize)
    {
        var trainees = _traineeRepository.GetAllTrainees().Select(t => MapToResponseModel(t)).ToList();

        var pageList = trainees.Skip((pageNum - 1) * pageSize).Take(pageSize).ToList();
        return pageList;
    }

    public TraineeResponseModel GetTraineeByEmail(EmailRequestModel email)
    {
        var t = _traineeRepository.GetTraineeByEmail(email.Email);
        if (t == null)
        {
            throw new Exception("No trainees found with this email address");
        }
        return MapToResponseModel(t);
    }

    public TraineeResponseModel GetTraineeById(int id)
    {
        var t = _traineeRepository.GetTraineeById(id);
        if (t == null)
        {
            throw new Exception("Trainee not found");
        }

        return MapToResponseModel(t);
    }

    public List<TraineeResponseModel> GetTraineesByTrainningPeriod(TrainningPeriodRequestModel trainningPeriod)
    {
        var trainningPeriodEntity = _trainningPeriodRepository.GetTrainningPeriodObj(trainningPeriod.StartDate, trainningPeriod.EndDate);
        if(trainningPeriodEntity == null)
        {
            throw new Exception("No trainning period found with these dates");
        }

        var t = _traineeRepository.GetTraineesByTrainningPeriod(trainningPeriodEntity);

        var trainees = t.Select(t => MapToResponseModel(t)).ToList();

        return trainees;
    }

    public List<TraineeResponseModel> GetTraineesByUniversity(string university)
    {
        var universityEntity = _universityRepository.GetUniversityObj(university);

        if(universityEntity == null)
        {
            throw new Exception("No university found with this name");
        }

        var t = _traineeRepository.GetTraineesByUniversity(universityEntity);
        var trainees = t.Select(t => MapToResponseModel(t)).ToList();

        return trainees;
    }

    public List<TraineeResponseModel> GetTrineesByYear(int year)
    {
        var trainees = _traineeRepository.GetTrineesByYear(year).Select(t => MapToResponseModel(t)).ToList();
        
        return trainees;
    }

    public void RemoveTrainee(EmailRequestModel email)
    {
        //get the user by email
        var trainee = _traineeRepository.GetTraineeByEmail(email.Email);
        if (trainee == null)
        {
            throw new Exception("Trainee not found with this email address");
        }
        _traineeRepository.RemoveTrainee(trainee);

    }

    public void UpdateNameOfTrainee(NameUpdateRequestModel nameUpdate)
    {
        _traineeRepository.UpdateNameOfTrainee(nameUpdate.Email, nameUpdate.Name);
    }

    public void UpdateTrainee(TraineeResponseModel trainee)
    {
        throw new NotImplementedException();
    }
}
