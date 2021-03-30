using DemoApp.Core;
using DemoApp.Core.Entity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace DemoApp.Infrastructure.Persistence
{
    public partial class DemoContext : IdentityDbContext
    {
        private readonly ISessionService _sessionService;
        private readonly IDateTime _dateTime;

        public DemoContext(DbContextOptions<DemoContext> options, ISessionService sessionService, IDateTime dateTime) : base(options)
        {
            _sessionService = sessionService;
            _dateTime = dateTime;
        }

        public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken = new CancellationToken())
        {
            foreach (Microsoft.EntityFrameworkCore.ChangeTracking.EntityEntry<AuditableEntity> entry in ChangeTracker.Entries<AuditableEntity>())
            {
                switch (entry.State)
                {
                    case EntityState.Added:
                        entry.Entity.CreatedBy = _sessionService.UserId;
                        entry.Entity.Created = _dateTime.Now;
                        break;

                    case EntityState.Modified:
                        entry.Entity.LastModifiedBy = _sessionService.UserId;
                        entry.Entity.LastModified = _dateTime.Now;
                        break;
                }
            }

            var result = await base.SaveChangesAsync(cancellationToken);

            return result;
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.ApplyConfigurationsFromAssembly(typeof(DemoContext).Assembly);
        }
    }
}
