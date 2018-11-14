using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.Serialization;
namespace RestWithAspnet_Udemy.Model.Base
{
    // Contrato entre atributos
    // e a estrutura da tabela
    // [DataContract]
    public class BaseEntity
    {
        [Column("id")]
        public long? Id { get; set; }
    }
}
