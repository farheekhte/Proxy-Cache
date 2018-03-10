using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Session07.Exam.Model
{
    public class PersonRepository : IPersonRepository
    {
        private PersonContext _personContext;

        public PersonRepository(PersonContext personContext)
        {
            _personContext = personContext;
        }

        public void DeletePerson(int personID)
        {
            var person=_personContext.Persons.Find(personID);
            _personContext.Persons.Remove(person);
            _personContext.SaveChanges();
        }

        public IEnumerable<Person> GetPerson()
        {
            return _personContext.Persons.ToList();
        }

        public Person GetPersonByID(int personId)
        {
            return _personContext.Persons.Find(personId);
        }

        public void InsertPerson(Person person)
        {
            _personContext.Persons.Add(person);
            _personContext.SaveChanges();
        }

        public void Save()
        {
            _personContext.SaveChanges();
        }

        public void UpdatePerson(Person person)
        {
            _personContext.Update(person);
            _personContext.SaveChanges();
        }
    }

}
