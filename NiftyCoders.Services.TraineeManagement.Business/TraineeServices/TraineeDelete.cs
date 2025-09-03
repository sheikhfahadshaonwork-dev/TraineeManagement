using Azure.Core;
using NiftyCoders.Services.TraineeManagement.Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NiftyCoders.Services.TraineeManagement.Business.TraineeServices;

public class TraineeDelete(ApplicationDbContext db): ITraineeDelete
{
    public void DeleteTrainee(string email)
    {
        var trainee = db.Trainees.Where(t => t.Email == email).FirstOrDefault();
        if (trainee == null)
        {
            throw new Exception("There is no user with this email.................");
        }

        db.Trainees.Remove(trainee);
        db.SaveChanges();
    }
}
