using System.ComponentModel.DataAnnotations.Schema;


namespace WebMotorsProject.Repository.Entity
{
    [Table("tb_AnuncioWebmotors")]
    public class Anuncio : BaseEntity
    {
        [Column("marca")]
        public string Marca { get; set; }
        [Column("modelo")]
        public string Modelo { get; set; }
        [Column("versao")]
        public string Versao { get; set; }
        [Column("ano")]
        public int Ano { get; set; }
        [Column("quilometragem")]
        public long KM { get; set; }
        [Column("observacao")]
        public string Observacao { get; set; }

    }
}
