using Newtonsoft.Json;
namespace WebMotorsProject.Domain.Data.DTO
{
    public class MarcaDTO
    {
        [JsonProperty(PropertyName = "ID")]
        public long Id { get; set; }

        [JsonProperty(PropertyName = "Name")]
        public string Nome { get; set; }
    }
}
