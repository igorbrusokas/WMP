using Newtonsoft.Json;
namespace WebMotorsProject.Domain.Data.DTO
{
    public class ModeloDTO
    {
        [JsonProperty(PropertyName = "ID")]
        public long Id { get; set; }

        [JsonProperty(PropertyName = "MakeID")]
        public long MakeId { get; set; }

        [JsonProperty(PropertyName = "Name")]
        public string Name { get; set; }
    }
}
