using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NiftyCoders.Services.TraineeManagement.Persistence.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NiftyCoders.Services.TraineeManagement.Persistence.EntityTypeConfiguration;

public class TraineeEntityTypeConfiguration : IEntityTypeConfiguration<Trainee>
{
    public void Configure(EntityTypeBuilder<Trainee> builder)
    {
        builder.ToTable("Trainees").HasKey(t => t.Id);

        builder.Property(x => x.Id).ValueGeneratedOnAdd();
        builder.Property(x => x.Name).IsRequired().HasMaxLength(40);
        builder.Property(x => x.Email).IsRequired().HasMaxLength(60);


        builder.HasOne(x => x.University)
            .WithMany(u => u.Trainees)
            .HasForeignKey(x => x.UniversityId)
            .HasConstraintName("FK_Trainee_University_UniversityId")
            .OnDelete(DeleteBehavior.SetNull);

        builder.HasOne(x => x.TrainningPeriod) 
               .WithMany(t => t.Trainees)
               .HasForeignKey(x => x.TrainningPeriodId)
               .HasConstraintName("FK_Trainee_TrainningPeriod_TrainningPeriodId")
               .OnDelete(DeleteBehavior.NoAction);
    }
}
