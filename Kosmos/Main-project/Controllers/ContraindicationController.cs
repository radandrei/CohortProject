using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BusinessLayer.Service;
using DataAccessLayer;
using Microsoft.AspNetCore.Mvc;

namespace Main_Project.Controllers
{
    [Route("api/[controller]")]
    public class ContraindicationController : Controller
    {
        private readonly ContraindicationService ContraindicationService;
        private MedicalDBContext _context;

        public ContraindicationController(MedicalDBContext context)
        {
            _context = context;
            this.ContraindicationService = new ContraindicationService(context);
        }

        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        [HttpGet("[action]/{id}")]
        public IActionResult GetByMedicalChart(int id)
        {
            var item = ContraindicationService.getAllergiesByMedicalChart(id);
            if (item == null)
            {
                return NotFound();
            }
            return new ObjectResult(item);
        }
    }
}