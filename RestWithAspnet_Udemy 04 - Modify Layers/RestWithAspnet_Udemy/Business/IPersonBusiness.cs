using RestWithAspnet_Udemy.Model;
using System.Collections.Generic;

namespace RestWithAspnet_Udemy.Business
{
    public interface IPersonBusiness
    {
        Person Create(Person person);
        Person FindById(long id);
        List<Person> FindAll();
        Person Update(Person person);
        void Delet(long id);
    }
}
