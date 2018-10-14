using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RestWithAspnet_Udemy.Model
{
    public class Person
    {
        /// <summary>
        /// Id - Acept null, case  empty value.
        /// </summary>
        public long? Id { get; set; } //"?" -> Acept null, case  empty value.
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Adress { get; set; }
        public string Gender { get; set; }
    }
}
