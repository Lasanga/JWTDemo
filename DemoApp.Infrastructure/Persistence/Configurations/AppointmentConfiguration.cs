using DemoApp.Core.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace DemoApp.Infrastructure.Persistence.Configurations
{
    class AppointmentConfiguration: IEntityTypeConfiguration<Appointment>
    {
        public void Configure(EntityTypeBuilder<Appointment> builder)
        {
            builder.ToTable("Appointment");
            builder.HasKey(x => x.Id);
        }
    }
}
