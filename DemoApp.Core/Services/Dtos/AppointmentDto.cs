using System;
using System.Collections.Generic;
using System.Text;

namespace DemoApp.Core.Services.Dtos
{
    public class AppointmentDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime Created { get; set; }
        public string CreatedBy { get; set; }
        public DateTime? LastModified { get; set; }

        public string LastModifiedBy { get; set; }
    }
}
