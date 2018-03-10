using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Session07.Exam.Model
{
    public interface IPersonRepository
    {
        IEnumerable<Person> GetPerson();
        Person GetPersonByID(int personId);
        void InsertPerson(Person person);
        void DeletePerson(int personID);
        void UpdatePerson(Person person);
        void Save();
    }
}
