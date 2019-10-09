using System.Collections.Generic;


namespace WebMotorsProject.Domain.Data.DTO
{
   // public class AnuncioDTO : ISupportsHyperMedia
    public class AnuncioDTO
    {
        public long? Id { get; set; }

        public string Marca { get; set; }

        public string Modelo { get; set; }

        public string Versao { get; set; }

        public int Ano { get; set; }

        public long KM { get; set; }

        public string Observacao { get; set; }
        
    }
}
