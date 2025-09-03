using Microsoft.Identity.Client;
using NiftyCoders.Services.TraineeManagement.Business.TraineeServices.Models;
using NiftyCoders.Services.TraineeManagement.Persistence;
using NiftyCoders.Services.TraineeManagement.Persistence.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NiftyCoders.Services.TraineeManagement.Business.TraineeServices;

public class TraineeCreator(ApplicationDbContext db) : ITraineeCreator
{
    public int CreateNewTrainee(TraineeCreateRequestModel model)
    {
        if (db.Trainees.Where(t => t.Email == model.Email).FirstOrDefault() != null)
        {
            throw new Exception("An user with the same email address already exist. Try another.................");
        }

        var trainee = Map(model);

        db.Trainees.Add(trainee);
        db.SaveChanges();

        return trainee.Id;
    }

    private Trainee Map(TraineeCreateRequestModel trainee) {
        return new Trainee
        {
            Name = trainee.Name,
            Email = trainee.Email,
            UniversityId = trainee.UniversityId,
            TrainningPeriodId = trainee.TrainningPeriodId
        };
    }
}
