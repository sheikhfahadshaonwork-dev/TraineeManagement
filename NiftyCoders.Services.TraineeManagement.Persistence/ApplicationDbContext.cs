using Microsoft.EntityFrameworkCore;
using NiftyCoders.Services.TraineeManagement.Persistence.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NiftyCoders.Services.TraineeManagement.Persistence;

public class ApplicationDbContext: DbContext
{
    public DbSet<Trainee> Trainees { get; set; }
    public DbSet<University> Universities { get; set; }
    public DbSet<TrainningPeriod> TrainningPeriods { get; set; }

    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.ApplyConfigurationsFromAssembly(GetType().Assembly);
    }


}
