using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Text;

namespace DemoApp.Core.Entity
{
    public class Appointment: AuditableEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string UserId { get; set; }
        public virtual IdentityUser User { get; set; }
    }
}
