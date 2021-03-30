using DemoApp.Core.Services;
using DemoApp.Core.Services.Dtos;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DemoApp.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Authorize]
    public class AppointmentController: ControllerBase
    {
        private readonly IAppointmentService _appointmentService;
        public AppointmentController(IAppointmentService appointmentService)
        {
            _appointmentService = appointmentService;
        }

        [HttpGet("All")]
        [Authorize(Roles = "Company")]
        public async Task<IActionResult> GetAll()
        {
            var result = await _appointmentService.GetAll();
            return Ok(result);
        }

        [HttpGet("Own")]
        [Authorize(Roles = "Public")]
        public async Task<IActionResult> GetOwn()
        {
            var result = await _appointmentService.GetOwn();
            return Ok(result);
        }

        [HttpPost("Create")]
        [Authorize(Roles = "Public")]
        public async Task Create([FromBody] CreateAppointmentDto createAppointmentDto)
        {
            await _appointmentService.Create(createAppointmentDto);
        }

        [HttpPut("Edit")]
        [Authorize(Roles = "Public, Company")]
        public async Task Edit(EditAppointmentDto editAppointmentDto)
        {
            await _appointmentService.Edit(editAppointmentDto);
        }

        [HttpDelete("Delete-own")]
        [Authorize(Roles = "Public")]
        public async Task DeleteOwn(int id)
        {
            await _appointmentService.Delete(id);
        }

        [HttpPut("Assign")]
        [Authorize(Roles = "Company")]
        public async Task AssignAppointment(AssignAppointmentDto assignAppointmentDto)
        {
            await _appointmentService.Assign(assignAppointmentDto);
        }

        [HttpDelete("Delete")]
        [Authorize(Roles = "Company")]
        public async Task Delete(int id)
        {
            await _appointmentService.Delete(id);
        }
    }
}
