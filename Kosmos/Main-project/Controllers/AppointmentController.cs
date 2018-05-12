using System;
using System.Collections.Generic;
using BusinessLayer.Models;
using BusinessLayer.Service;
using DataAccessLayer;
using MainProject.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Main_Project.Controllers
{
    [Route("api/[controller]")]
    public class AppointmentController : Controller
    {
        private readonly AppointmentService AppointmentService;
        private MedicalDBContext _context;
        private readonly UserService userService;

        public AppointmentController(MedicalDBContext context)
        {
            _context = context;
            this.AppointmentService = new AppointmentService(context);
            this.userService = new UserService(context);
        }

        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        [HttpGet("[action]/{id}")]
        [Authorize(Policy = "Patient")]
        public IActionResult GetByPerson(int id)
        {
            var item = AppointmentService.getAppointmentsByPerson(id);

            return new ObjectResult(item);
        }

        [HttpGet("[action]")]
        [AllowAnonymous]
        public IActionResult GetCabinets()
        {
            try
            {
                List<CabinetModel> item = AppointmentService.GetCabinets();
                return new OkObjectResult(item);
            }
            catch (Exception ex)
            {
                return new BadRequestObjectResult(ex);
            }
        }

        [HttpPost("[action]")]
        [AllowAnonymous]
        public IActionResult AddMedic([FromBody]MedicModel model)
        {
            try
            {
                var userId = userService.CreateUser(model.Username, model.password,3).ID;
                userService.CreatePerson(userId,model.CabinetId, model.FirstName,model.LastName);
                return new OkObjectResult(true);
            }
            catch(Exception ex)
            {
                return new BadRequestObjectResult(false);
            }
        }

        [HttpGet("[action]/{id}")]
        [AllowAnonymous]
        public IActionResult GetAllByPerson(int id)
        {
            var item = AppointmentService.getAllAppointmentsByPerson(id);

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