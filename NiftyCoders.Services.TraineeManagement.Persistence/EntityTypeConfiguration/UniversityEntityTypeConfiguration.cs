using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NiftyCoders.Services.TraineeManagement.Persistence.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NiftyCoders.Services.TraineeManagement.Persistence.EntityTypeConfiguration;

public class UniversityEntityTypeConfiguration : IEntityTypeConfiguration<University>
{
    public void Configure(EntityTypeBuilder<University> builder)
    {
        builder.ToTable("Universities").HasKey(u => u.Id);

        builder.Property(u => u.Id).ValueGeneratedOnAdd();
        builder.Property(u => u.Name).IsRequired().HasMaxLength(100);
        
        builder.HasMany(x => x.Trainees)
               .WithOne(t => t.University)
               .HasForeignKey(x => x.UniversityId)
               .OnDelete(DeleteBehavior.Cascade);

    }
}
