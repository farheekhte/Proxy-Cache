using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;
using Session07.Exam.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Session07.Exam.ProxyClasses
{
    public abstract class PersonProxy : IPersonRepository
    {
        public void DeletePerson(int personID)
        {
            throw new NotImplementedException();
        }

        //public IActionResult ActionResult { get; set; }

        //public ActionResultProxy(IActionResult _actionResult)
        //{
        //    ActionResult = _actionResult;
        //}
        //public virtual Task ExecuteResultAsync(ActionContext context)
        //{
        //    throw new NotImplementedException();
        //}
        public abstract void DeleteStudent(int personID);
        public abstract IEnumerable<Person> GetPerson();

        public Person GetPersonByID(int personId)
        {
            throw new NotImplementedException();
        }

        public abstract Person GetStudentByID(int personId);

        public void InsertPerson(Person person)
        {
            throw new NotImplementedException();
        }

        public abstract void InsertStudent(Person person);
        public abstract void Save();

        public void UpdatePerson(Person person)
        {
            throw new NotImplementedException();
        }

        public abstract void UpdateStudent(Person person);
    }

    public class ActionResultCacheProxy : PersonProxy, IDisposable
    {
        public override void DeleteStudent(int personID)
        {
            throw new NotImplementedException();
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }

        public override IEnumerable<Person> GetPerson()
        {
            throw new NotImplementedException();
        }

        public override Person GetStudentByID(int personId)
        {
            throw new NotImplementedException();
        }

        public override void InsertStudent(Person person)
        {
            throw new NotImplementedException();
        }

        public override void Save()
        {
            throw new NotImplementedException();
        }

        public override void UpdateStudent(Person person)
        {
            throw new NotImplementedException();
        }
    }
}
