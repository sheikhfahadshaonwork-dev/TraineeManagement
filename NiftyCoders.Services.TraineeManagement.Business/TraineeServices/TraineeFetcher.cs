using Microsoft.EntityFrameworkCore;
using NiftyCoders.Services.TraineeManagement.Business.TraineeServices.Models;
using NiftyCoders.Services.TraineeManagement.Persistence;
using NiftyCoders.Services.TraineeManagement.Persistence.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Intrinsics.Arm;
using System.Text;
using System.Threading.Tasks;

namespace NiftyCoders.Services.TraineeManagement.Business.TraineeServices;

public class TraineeFetcher(ApplicationDbContext db) : ITraineeFetcher
{
    public List<TraineeResponseModel> GetAllTrainee(int pageNumber, int pageSize)
    {
        return db.Trainees
            .AsNoTracking()
            .Include(t => t.University)
            .Include(t => t.TrainningPeriod)
            .Skip((pageNumber - 1) * pageSize)
            .Take(pageSize)
            .Select(t => Map(t))
            .ToList();
    }
    
    public TraineeResponseModel GetTrainee(int id)
    {
        var trainee = Map(
              db.Trainees
                .Where(t => t.Id == id)
                .Include(t => t.University)
                .Include(t => t.TrainningPeriod)
                .FirstOrDefault()
                    );

        return trainee;
    }

    public TraineeResponseModel GetTraineeWithEmail(string email)
    {
        var trainee = db.Trainees
                    .Where(t => t.Email == email)
                    .Include(t => t.University)
                    .Include(t => t.TrainningPeriod)
                    .Select(t => Map(t))
                    .FirstOrDefault();

        return trainee;
    }

    public List<TraineeResponseModel> Search(string? searchText)
    {
        var query = db.Trainees
                      .Include(t => t.University)
                      .Include(t => t.TrainningPeriod)
                      .AsNoTracking()
                      .AsQueryable();

        if(!string.IsNullOrEmpty(searchText))
        {
            query = query.Where(x => x.Name.Contains(searchText));
        }

        query = query.OrderBy(x => x.Name);

        var trainees = query.ToList();

        return trainees.Select(Map).ToList();
    }

    public List<TraineeResponseModel> GetAllTraineeWithinPeriod(TrainningPeriodRequestModel period)
    {
        var trainees = db.Trainees
                        .Include(t => t.University)
                        .Include(t => t.TrainningPeriod)
                        .AsNoTracking()
                        .Where(t => t.TrainningPeriod.StartDate >= period.StartDate && t.TrainningPeriod.EndDate <= period.EndDate)
                        .Select(Map)
                        .ToList();
        return trainees;
    }

    public List<TraineeResponseModel> GetAllTraineeByYear(int year)
    {
        int nextYear = year + 1;
        var trainees = db.Trainees
                        .Include(t => t.University)
                        .Include(t => t.TrainningPeriod)
                        .AsNoTracking()
                        .Where(t => t.TrainningPeriod.StartDate.Year >= year && t.TrainningPeriod.StartDate.Year < nextYear)
                        .Select(Map)
                        .ToList();

        return trainees;
    }

    private static TraineeResponseModel Map(Trainee trainee)
    {
        return new TraineeResponseModel()
        {
            Name = trainee.Name,
            Email = trainee.Email,
            University = trainee.University.Name,
            StartDate = trainee.TrainningPeriod.StartDate,
            EndDate = trainee.TrainningPeriod.EndDate,
        };
    }
}
