using System;
using System.Collections.Generic;
using System.Linq;
using RestWithAspnet_Udemy.Model;
using RestWithAspnet_Udemy.Model.Context;
using RestWithAspnet_Udemy.Repository;

namespace RestWithAspnet_Udemy.Business.Implimentation
{
    public class PersonBusinessImpl : IPersonBusiness
    {
        /// <summary>
        /// variable responsible  in connect MySql
        /// </summary>
        private IPersonRepository _repository;

        public PersonBusinessImpl(IPersonRepository repository)
        {
            _repository = repository;
        }
        /// <summary>
        /// Create person in db persons
        /// </summary>
        /// <param name="person"></param>
        /// <returns>person</returns>
        public Person Create(Person person)
        {
            
            return _repository.Create(person);
        }
        /// <summary>
        /// Delete person in db person
        /// </summary>
        /// <param name="id"></param>
        public void Delet(long id)
        {
            _repository.Delet(id);
        }
        /// <summary>
        /// List all persons in db persons.
        /// </summary>
        /// <returns>List<Person></returns>
        public List<Person> FindAll()
        {
            return _repository.FindAll();
        }
        /// <summary>
        /// List person find by id.
        /// </summary>
        /// <param name="id"></param>
        /// <returns>Person</returns>
        public Person FindById(long id)
        {
            return _repository.FindById(id);
  
        }
        /// <summary>
        /// Upadate db persons 
        /// </summary>
        /// <param name="person"></param>
        /// <returns>Person after update</returns>
        public Person Update(Person person)
        {
            return _repository.Update(person);
        }
    }
}
