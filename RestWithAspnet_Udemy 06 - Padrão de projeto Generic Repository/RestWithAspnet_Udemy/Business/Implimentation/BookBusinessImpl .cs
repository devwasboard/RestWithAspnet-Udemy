﻿using System.Collections.Generic;
using RestWithAspnet_Udemy.Model;
using RestWithAspnet_Udemy.Repository.Generic;

namespace RestWithAspnet_Udemy.Business.Implimentation
{
    public class BookBusinessImpl : IBookBusiness
    {

        private IRepository<Book> _repository;

        public BookBusinessImpl(IRepository<Book> repository)
        {
            _repository = repository;
        }

        public Book Create(Book book)
        {
            return _repository.Create(book);
        }

        public Book FindById(long id)
        {
            return _repository.FindById(id);
        }

        public List<Book> FindAll()
        {
            return _repository.FindAll();
        }

        public Book Update(Book book)
        {
            return _repository.Update(book);
        }

        public void Delete(long id)
        {
            _repository.Delete(id);
        }

        public bool Exists(long id)
        {
            return _repository.Exists(id);
        }
    }
}
