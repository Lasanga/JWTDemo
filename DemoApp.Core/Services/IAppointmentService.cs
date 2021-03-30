using DemoApp.Core.Services.Dtos;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DemoApp.Core.Services
{
    public interface IAppointmentService
    {
        Task<List<AppointmentDto>> GetAll();
        Task<List<AppointmentDto>> GetOwn();
        Task Create(CreateAppointmentDto appointmentDto);
        Task Edit(EditAppointmentDto appointmentDto);
        Task Delete(int id);
        Task Assign(AssignAppointmentDto appointmentDto);
    }
}
