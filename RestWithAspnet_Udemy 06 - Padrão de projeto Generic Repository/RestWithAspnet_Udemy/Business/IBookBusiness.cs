using RestWithAspnet_Udemy.Model;
using System.Collections.Generic;

namespace RestWithAspnet_Udemy.Business
{
    public interface IBookBusiness
    {
        Book Create(Book book);
        Book FindById(long id);
        List<Book> FindAll();
        Book Update(Book book);
        void Delete(long id);
    }
}
