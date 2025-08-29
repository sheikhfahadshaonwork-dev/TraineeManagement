using NiftyCoders.Services.TraineeManagement.Persistence.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NiftyCoders.Services.TraineeManagement.Persistence.Repositories;

public class TraineeRepository
{
    public List<TraineeEntity> GetAllTrainees()
    {
        return Database.Trainees;
    }
    public TraineeEntity? GetTraineeById(int id)
    {
        return Database.Trainees.FirstOrDefault(t => t.Id == id);
    }

    public TraineeEntity? GetTraineeByEmail(string email)
    {
        return Database.Trainees.FirstOrDefault(t => t.Email.Equals(email));
    }

    public List<TraineeEntity> GetTraineesByUniversity(UniversityEntity university)
    {
        return Database.Trainees.FindAll(u => u.University == university);
    }

    public List<TraineeEntity> GetTrineesByYear(int year)
    {
        return Database.Trainees.FindAll(t => t.TrainningPeriod.StartDate.Year >= year && t.TrainningPeriod.EndDate.Year <= year);
    }

    public List<TraineeEntity> GetTraineesByTrainningPeriod(TrainningPeriodEntity trainningPeriod)
    {
        return Database.Trainees.FindAll(t => t.TrainningPeriod == trainningPeriod);
    }

    public void AddTrainee(TraineeEntity trainee)
    {
        //check for duplicate email
        if (GetTraineeByEmail(trainee.Email) != null)
        {
            throw new Exception("Trainee with the same email already exists");
        }
        Database.Trainees.Add(trainee);
    }

    public void RemoveTrainee(TraineeEntity trainee)
    {
        Database.Trainees.Remove(trainee);
    }

    public void UpdateTrainee(TraineeEntity trainee)
    {
        var existingTrainee = GetTraineeById(trainee.Id);
        if (existingTrainee != null)
        {
            existingTrainee.Name = trainee.Name;
            existingTrainee.Email = trainee.Email;
            existingTrainee.TrainningPeriod = trainee.TrainningPeriod;
            existingTrainee.University = trainee.University;
        }
    }

    public void UpdateNameOfTrainee(string email, string newName)
    {
        var existingTrainee = GetTraineeByEmail(email);
        if (existingTrainee != null)
        {
            existingTrainee.Name = newName;
        }
        else
        {
            throw new Exception("Trainee not found with this email address");
        }
    }


}
