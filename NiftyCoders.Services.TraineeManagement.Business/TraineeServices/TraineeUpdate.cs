using Azure.Core;
using NiftyCoders.Services.TraineeManagement.Business.TraineeServices.Models;
using NiftyCoders.Services.TraineeManagement.Persistence;
using NiftyCoders.Services.TraineeManagement.Persistence.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace NiftyCoders.Services.TraineeManagement.Business.TraineeServices;

public class TraineeUpdate(ApplicationDbContext db) : ITraineeUpdate
{
    public void UpdateTraineeName(NameUpdateRequest request)
    {
        var trainee = db.Trainees.Where(t => t.Email == request.Email).FirstOrDefault();
        if (trainee == null)
        {
            throw new Exception("There is no user with this email.................");
        }

        trainee.Name = request.Name;

        db.SaveChanges();
    }

    public int UpdateTrainee(TraineeUpdateRequestModel model, string email)
    {
        var trainee = db.Trainees.Where(t => t.Email == email).FirstOrDefault();
        if (trainee == null)
        {
            throw new Exception("There is no user with this email.................");
        }
        trainee.Name = model.Name;
        trainee.UniversityId = model.UniversityId;
        trainee.TrainningPeriodId = model.TrainningPeriodId;

        db.SaveChanges();

        return trainee.Id;
    }
}
