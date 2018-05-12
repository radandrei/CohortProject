using System;
using System.Collections.Generic;
using BusinessLayer.Models;
using BusinessLayer.Service;
using DataAccessLayer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Main_Project.Controllers
{
    [Route("api/[controller]")]
    public class AppointmentController : Controller
    {
        private readonly AppointmentService AppointmentService;
        private MedicalDBContext _context;

        public AppointmentController(MedicalDBContext context)
        {
            _context = context;
            this.AppointmentService = new AppointmentService(context);
        }

        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        [HttpGet("[action]/{id}")]
        [AllowAnonymous]
        public IActionResult GetByPerson(int id)
        {
            var item = AppointmentService.getAppointmentsByPerson(id);

            return new ObjectResult(item);
        }

        [HttpGet("[action]/{id}")]
        [AllowAnonymous]
        public IActionResult GetCabinets()
        {
            List<CabinetModel> item = AppointmentService.GetCabinets();

            return new ObjectResult(item);
        }

        [HttpPost("[action]")]
        [Authorize(Policy = "Patient")]
        public IActionResult Add([FromBody]AppointmentModel model)
        {
            try
            {
                var x = AppointmentService.CreateAppointment(model);
                return new OkObjectResult(x);
            }
            catch (Exception ex)
            {
                return new BadRequestObjectResult(ex);
            }
        }

        [HttpDelete("[action]/{id}")]
        [AllowAnonymous]
        public IActionResult Delete(int id)
        {
            try
            {
                AppointmentService.DeleteAppointment(id);
                return new OkObjectResult("Appointment deleted");
            }
            catch (Exception e)
            {
                return new BadRequestObjectResult(e);
            }
        }

    }
}