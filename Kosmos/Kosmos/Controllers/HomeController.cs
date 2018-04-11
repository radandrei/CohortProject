using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using BusinessLayer;
using BusinessLayer.Interfaces;
using BusinessLayer.Models;
using DataAccessLayer;
using DataAccessLayer.Repository;
using DataAccessLayer.RepositoryInterfaces;
using Microsoft.AspNetCore.Mvc;

namespace Kosmos.Controllers
{
    public class HomeController : Controller
    {
        private MedicalDBContext _context;
        private IUserRepository userRepository;
        private IRoleRepository roleRepository;

        public HomeController(MedicalDBContext context)
        {
            _context = context;
            userRepository = new UserRepository(_context);
            roleRepository = new RoleRepository(_context);
        }

        public IActionResult Index()
        {  
            try
            {
                var listOfUsers = userRepository.GetAll();
                var newRole = new RoleModel()
                {
                    Name = "Adrian"
                };
                roleRepository.AddOrUpdate(newRole);

                roleRepository.Delete(2);
            }
            catch (Exception ex)
            {
                throw (ex);
            }

            return View();
        }

        public IActionResult Error()
        {
            ViewData["RequestId"] = Activity.Current?.Id ?? HttpContext.TraceIdentifier;
            return View();
        }
    }
}
