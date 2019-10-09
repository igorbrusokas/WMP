using System.ComponentModel.DataAnnotations.Schema;

namespace WebMotorsProject.Repository.Entity
{
    public class BaseEntity
    {
        [Column("ID")]
        public long? Id { get; set; }
    }
}
