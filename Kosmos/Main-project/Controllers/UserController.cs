using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BusinessLayer.Service;
using DataAccessLayer;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Main_Project.Controllers
{
    [Route("api/[controller]")]
    public class UserController : Controller
    {
        private readonly UserService userService;
        private MedicalDBContext _context;

        public UserController(MedicalDBContext context)
        {
            _context = context;
            this.userService = new UserService(context);
        }

        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        [HttpGet("[action]/{id}")]
        public IActionResult GetById(int id)
        {
            var item = userService.getUserById(id);
            if (item == null)
            {
                return NotFound();
            }
            return new ObjectResult(item);
        }

        [HttpGet("[action]")]
        public IActionResult GetAll()
        {
            var item = userService.getAllUsers();
            if (item == null)
            {
                return NotFound();
            }
            return new ObjectResult(item);
        }
    }
}