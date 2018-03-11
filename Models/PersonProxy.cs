using Microsoft.Extensions.Caching.Memory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Session07.Exam.Model
{
    #region Using PersonRepository 
    //public class PersonRepositoryCacheProxy : IPersonRepository
    //{
    //    private readonly IMemoryCache _memoryCache;
    //    private IPersonRepository _personRepository { get; set; }

    //    public PersonRepositoryCacheProxy(IPersonRepository personRepository, IMemoryCache memoryCache)
    //    {
    //        _personRepository = personRepository;
    //        _memoryCache = memoryCache;
    //    }
    //    public void DeletePerson(int personID)
    //    {
    //        _personRepository.DeletePerson(personID);
    //    }

    //    public IEnumerable<Person> GetPerson()
    //    {
    //        if (_memoryCache.Get("Persons") is null || !(_memoryCache.Get("Persons") is IEnumerable<Person>))
    //        {
    //            var option = new MemoryCacheEntryOptions()
    //            {
    //                Priority = CacheItemPriority.High

    //            };
    //            _memoryCache.Set("Persons", _personRepository.GetPerson(), option);
    //        }
    //        return (IEnumerable<Person>)_memoryCache.Get("Persons");
    //    }

    //    public Person GetPersonByID(int personId)
    //    {
    //        return _personRepository.GetPersonByID(personId);
    //    }

    //    public void InsertPerson(Person person)
    //    {
    //        _personRepository.InsertPerson(person);
    //    }

    //    public void Save()
    //    {
    //        _personRepository.Save();
    //    }

    //    public void UpdatePerson(Person person)
    //    {
    //        _personRepository.UpdatePerson(person);
    //    }
    //}
    #endregion   Using PersonRepository 

    public class PersonRepositoryCacheProxy : IPersonRepository
    {
        private readonly IMemoryCache _memoryCache;
        private PersonContext _personContext { get; set; }

        public PersonRepositoryCacheProxy(PersonContext personContext, IMemoryCache memoryCache)
        {
            _personContext = personContext;
            _memoryCache = memoryCache;
        }
        public void DeletePerson(int personID)
        {
            var person = _personContext.Persons.Find(personID);
            _personContext.Persons.Remove(person);
            _personContext.SaveChanges();
        }

        public IEnumerable<Person> GetPerson()
        {
            if (_memoryCache.Get("Persons") is null || !(_memoryCache.Get("Persons") is IEnumerable<Person>))
            {
                var option = new MemoryCacheEntryOptions()
                {
                    Priority = CacheItemPriority.High

                };
                _memoryCache.Set("Persons",  _personContext.Persons.ToList(), option);
            }
            return (IEnumerable<Person>)_memoryCache.Get("Persons");
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
