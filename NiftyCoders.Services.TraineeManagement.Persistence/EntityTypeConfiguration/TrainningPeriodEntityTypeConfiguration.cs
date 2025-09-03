using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NiftyCoders.Services.TraineeManagement.Persistence.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NiftyCoders.Services.TraineeManagement.Persistence.EntityTypeConfiguration;

public class TrainningPeriodEntityTypeConfiguration: IEntityTypeConfiguration<TrainningPeriod>
{
    public void Configure(EntityTypeBuilder<TrainningPeriod> builder)
    {
        builder.ToTable("TrainningPeriod").HasKey(t => t.Id);

        builder.Property(t => t.Id).ValueGeneratedOnAdd();

        builder.Property(t => t.StartDate).IsRequired();

    }
}
