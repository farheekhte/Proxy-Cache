using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Session07.Exam.Model;

namespace Session07.Exam.Controllers
{
    public class HomeController : Controller
    {
  

        IPersonRepository _personRepository { get; set; }

        public HomeController(IPersonRepository personRepository)
        {
            _personRepository = personRepository;
        }
        public IActionResult Index()
        {
            var persons = _personRepository.GetPerson();
            return View(persons);
        }
    }
}