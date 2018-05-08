using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BusinessLayer.Models;
using BusinessLayer.Service;
using DataAccessLayer;
using DataAccessLayer.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Main_Project.Controllers
{
    [Route("api/[controller]")]
    public class PrescriptionController : Controller
    {
        private readonly PrescriptionService PrescriptionService;
        private MedicalDBContext _context;

        public PrescriptionController(MedicalDBContext context)
        {
            _context = context;
            this.PrescriptionService = new PrescriptionService(context);
        }

        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        [HttpGet("[action]/{id}")]
        public IActionResult GetByPerson(int id)
        {
            var item = PrescriptionService.GetAllergiesByMedicalChart(id);
            if (item == null)
            {
                return NotFound();
            }
            return new ObjectResult(item);
        }

        [HttpGet("[action]/{id}")]
        [Authorize(Policy ="Patient")]
        public IActionResult GetByMedicalChart(int id)
        {
            try
            {
                var item = PrescriptionService.GetPrescriptionsByMedicalChart(id);

                return new OkObjectResult(item);
            }
            catch (Exception ex)
            {
                return new BadRequestObjectResult(ex);
            }
        }

        [HttpPost("[action]")]
        [AllowAnonymous]
        public IActionResult Add([FromBody]PrescriptionModel model)
        {
            try
            {
                //var x = PrescriptionService.CreatePrescription(model);
                return new OkObjectResult("Prescription created");
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
                //PrescriptionService.DeletePrescription(id);
                return new OkObjectResult("Prescription deleted");
            }
            catch (Exception e)
            {
                return new BadRequestObjectResult(e);
            }
        }

    }
}