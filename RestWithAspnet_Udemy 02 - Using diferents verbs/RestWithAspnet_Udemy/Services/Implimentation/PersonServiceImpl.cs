using System;
using System.Collections.Generic;
using System.Threading;
using RestWithAspnet_Udemy.Model;

namespace RestWithAspnet_Udemy.Services.Implimentation
{
    public class PersonServiceImpl : IPersonService
    {
        private volatile int count;

        public Person Create(Person person)
        {
            return person;
        }

        public void Delet(long id)
        {

        }

        public List<Person> FindAll()
        {
            List<Person> persons = new List<Person>();
            for (int i = 0; i < 8; i++)
            {
                Person person = MockPerson(i);
                persons.Add(person);
            }
            return persons;
        }

        private Person MockPerson(int i)
        {
            return new Person
            {
                Id = IncrementAndGet(),
                FirstName = "Person Name" + i.ToString(),
                LastName = "Person LastName" + i.ToString(),
                Adress = "Adress "+i.ToString(),
                Gender = "Male"
            };

        }

        private long IncrementAndGet()
        {
            return Interlocked.Increment(ref count);
        }

        public Person FindById(long id)
        {
            return new Person
            {
                Id = IncrementAndGet(),
                FirstName = "Wagner ",
                LastName = "Silva",
                Adress = "Sapucaias",
                Gender = "Male"
            };
        }

        public Person Update(Person person)
        {
            return person;
        }
    }
}
