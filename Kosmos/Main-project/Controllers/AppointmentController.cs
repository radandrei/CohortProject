using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BusinessLayer.Models;
using BusinessLayer.Service;
using DataAccessLayer;
using DataAccessLayer.Models;
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
        public IActionResult GetByPerson(int id)
        {
            var item = AppointmentService.getAppointmentsByPerson(id);
            if (item == null)
            {
                return NotFound();
            }
            return new ObjectResult(item);
        }

        [HttpPost("[action]")]
        [AllowAnonymous]
        public IActionResult Add([FromBody]AppointmentModel model)
        {
            try
            {
                var x = AppointmentService.CreateAppointment(model);
                return new OkObjectResult("Appointment created");
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
            catch(Exception e)
            {
                return new BadRequestObjectResult(e);
            }
        }

    }
}