using DemoApp.Core.Entity;
using DemoApp.Core.Services.Dtos;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoApp.Core.Services
{
    public class AppointmentService : IAppointmentService
    {
        private readonly IDemoContext _demoContext;
        private readonly ISessionService _sessionService;

        public AppointmentService(IDemoContext demoContext, ISessionService sessionService)
        {
            _demoContext = demoContext;
            _sessionService = sessionService;
        }

        public async Task Assign(AssignAppointmentDto appointmentDto)
        {
            var appointment = _demoContext.Appointments.Find(appointmentDto.AppointmentId);
            appointment.UserId = appointmentDto.UserId;
            await _demoContext.SaveChangesAsync();
        }

        public async Task Create(CreateAppointmentDto appointmentDto)
        {
            await _demoContext.Appointments.AddAsync(new Appointment
            {
                Name = appointmentDto.Name
            });

            await _demoContext.SaveChangesAsync();

        }

        public async Task Delete(int id)
        {
            var appointment = _demoContext.Appointments.Find(id);
            _demoContext.Appointments.Remove(appointment);
            await _demoContext.SaveChangesAsync();
        }

        public async Task Edit(EditAppointmentDto appointmentDto)
        {
            var appointment = _demoContext.Appointments.Find(appointmentDto.Id);
            appointment.Name = appointmentDto.Name;

            await _demoContext.SaveChangesAsync();
        }

        public async Task<List<AppointmentDto>> GetAll()
        {
            var result = await _demoContext.Appointments.AsNoTracking().ToListAsync();
            return Map(result);
        }

        public async Task<List<AppointmentDto>> GetOwn()
        {
            var result = await _demoContext.Appointments.AsNoTracking().Where(x => x.UserId == _sessionService.UserId).ToListAsync();
            return Map(result);
        }

        private List<AppointmentDto> Map(List<Appointment> appointments)
        {
            return appointments.Select(x => new AppointmentDto
            {
                Id = x.Id,
                Created = x.Created,
                CreatedBy = x.CreatedBy,
                LastModified = x.LastModified,
                LastModifiedBy = x.LastModifiedBy,
                Name = x.Name
            }).ToList();
        }
    }
}
