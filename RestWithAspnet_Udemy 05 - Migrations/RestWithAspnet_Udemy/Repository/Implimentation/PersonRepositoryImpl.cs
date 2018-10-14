using System;
using System.Collections.Generic;
using System.Linq;
using RestWithAspnet_Udemy.Model;
using RestWithAspnet_Udemy.Model.Context;

namespace RestWithAspnet_Udemy.Repository.Implimentation
{
    public class PersonRepositorympl : IPersonRepository
    {
        /// <summary>
        /// variable responsible  in connect MySql
        /// </summary>
        private MySQLContext _context;

        public PersonRepositorympl(MySQLContext context)
        {
            _context = context;
        }
        /// <summary>
        /// Create person in db persons
        /// </summary>
        /// <param name="person"></param>
        /// <returns>person</returns>
        public Person Create(Person person)
        {
            try
            {
                _context.Add(person);
                _context.SaveChanges();
            }
            catch (Exception ex)
            {

                throw ex;
            }
            return person;
        }
        /// <summary>
        /// Delete person in db person
        /// </summary>
        /// <param name="id"></param>
        public void Delet(long id)
        {
            var result = _context.Persons.SingleOrDefault(p => p.Id.Equals(id));
            try
            {
                if (result != null)
                {
                    _context.Persons.Remove(result);
                    _context.SaveChanges();
                }
                
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        /// <summary>
        /// List all persons in db persons.
        /// </summary>
        /// <returns>List<Person></returns>
        public List<Person> FindAll()
        {
            return _context.Persons.ToList();
        }
        /// <summary>
        /// List person find by id.
        /// </summary>
        /// <param name="id"></param>
        /// <returns>Person</returns>
        public Person FindById(long id)
        {
            return _context.Persons.SingleOrDefault(p => p.Id.Equals(id));
  
        }
        /// <summary>
        /// Upadate db persons 
        /// </summary>
        /// <param name="person"></param>
        /// <returns>Person after update</returns>
        public Person Update(Person person)
        {
            if (!Exist(person.Id)) return new Person();

            var result = _context.Persons.SingleOrDefault(p => p.Id.Equals(person.Id));
            try
            {
                _context.Entry(result).CurrentValues.SetValues(person);
                _context.SaveChanges();
            }
            catch (Exception ex)
            {

                throw ex;
            }
            return person;
        }
        /// <summary>
        /// Verify person exists in db persons
        /// </summary>
        /// <param name="id"></param>
        /// <returns>bool</returns>
        public bool Exist(long? id)
        {
            return _context.Persons.Any(p => p.Id.Equals(id));
        }
    }
}
