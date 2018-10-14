using RestWithAspnet_Udemy.Model;
using System.Collections.Generic;

namespace RestWithAspnet_Udemy.Services.Implimentation
{
    public interface IPersonService
    {
        Person Create(Person person);
        Person FindById(long id);
        List<Person> FindAll();
        Person Update(Person person);
        void Delet(long id);
    }
}
