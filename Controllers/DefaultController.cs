using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Session07.Exam.Model;

namespace Session07.Exam.Controllers
{
    public class DefaultController : Controller
    {
        IPersonRepository _personRepository { get; set; }

        public DefaultController(IPersonRepository personRepository)
        {
            _personRepository = personRepository;
        }
        public IActionResult Index()
        {
           var persons= _personRepository.GetPerson();
            return View(persons);
        }
    }
}