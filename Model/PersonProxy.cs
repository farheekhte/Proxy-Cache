using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Session07.Exam.Model
{
    public class PersonCatchProxy : IPersonRepository
    {
        private IPersonRepository _personRepository { get; set; }

        public PersonCatchProxy(IPersonRepository personRepository)
        {
            _personRepository = personRepository;
        }
        public void DeletePerson(int personID)
        {
            _personRepository.DeletePerson(personID);
        }

        public IEnumerable<Person> GetPerson()
        {

            return _personRepository.GetPerson();
        }

        public Person GetPersonByID(int personId)
        {
            return _personRepository.GetPersonByID(personId);
        }

        public void InsertPerson(Person person)
        {
            _personRepository.InsertPerson(person);
        }

        public void Save()
        {
            _personRepository.Save();
        }

        public void UpdatePerson(Person person)
        {
            _personRepository.UpdatePerson(person);
        }
    }
}
