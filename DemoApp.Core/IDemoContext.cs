using DemoApp.Core.Entity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace DemoApp.Core
{
    public interface IDemoContext
    {
        DbSet<Appointment> Appointments { get; set; }

        Task<int> SaveChangesAsync(CancellationToken cancellationToken = new CancellationToken());
    }
}
