using DemoApp.Core;
using DemoApp.Core.Entity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace DemoApp.Infrastructure.Persistence
{
    public partial class DemoContext : IDemoContext
    {
        public DbSet<Appointment> Appointments { get; set; }
    }
}
