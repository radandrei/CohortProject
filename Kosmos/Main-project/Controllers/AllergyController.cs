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
    public class AllergyController : Controller
    {
        private readonly AllergyService allergyService;
        private MedicalDBContext _context;

        public AllergyController(MedicalDBContext context)
        {
            _context = context;
            this.allergyService = new AllergyService(context);
        }

        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        [HttpGet("[action]/{id}")]
        public IActionResult GetByMedicalChart(int id)
        {
            var item = allergyService.getAllergiesByMedicalChart(id);
            if (item == null)
            {
                return NotFound();
            }
            return new ObjectResult(item);
        }
    }
}