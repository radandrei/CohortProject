using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BusinessLayer.Models;
using DataAccessLayer;
using DataAccessLayer.Models;
using Microsoft.AspNetCore.Mvc;

namespace Kosmos.Controllers
{
    [Route("api/[controller]")]
    public class MedicalChartController : Controller
    {
        private readonly MedicalDBContext _context;

        public MedicalChartController(MedicalDBContext medicalDBContext)
        {
            _context = medicalDBContext;
        }

        [HttpGet("[action]/{id}",Name ="GetMedicalChart")]
        public IActionResult GetById(int id)
        {
            var item = _context.MedicalCharts.FirstOrDefault(t => t.ID == id);
            if (item == null)
            {
                return NotFound();
            }
            return new ObjectResult(new MedicalChartModel(item));
        }

        [HttpPost]
        public IActionResult Create([FromBody] MedicalChart item)
        {
            if (item == null)
            {
                return BadRequest();
            }

            _context.MedicalCharts.Add(item);
            _context.SaveChanges();

            return CreatedAtRoute("GetMedicalChart", new { id = item.ID }, item);
        }


        [HttpPut("{id}")]
        public IActionResult Update(long id, [FromBody] MedicalChart item)
        {
            if (item == null || item.ID != id)
            {
                return BadRequest();
            }

            var medicalChart = _context.MedicalCharts.FirstOrDefault(t => t.ID == id);
            if (medicalChart == null)
            { 
                return NotFound();
            }

            //update the proprieties [...]

            _context.MedicalCharts.Update(medicalChart);
            _context.SaveChanges();
            return new NoContentResult();
        }


        [HttpDelete("{id}")]
        public IActionResult Delete(long id)
        {
            var medicalChart = _context.MedicalCharts.FirstOrDefault(t => t.ID == id);
            if (medicalChart == null)
            {
                return NotFound();
            }

            _context.MedicalCharts.Remove(medicalChart);
            _context.SaveChanges();
            return new NoContentResult();
        }


        [HttpGet("[action]")]
        public IEnumerable<MedicalChart> GetMedicalCharts()
        {
            return null;
            //queery;
        }


    }


}