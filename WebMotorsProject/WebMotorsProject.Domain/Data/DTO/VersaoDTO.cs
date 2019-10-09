using Newtonsoft.Json;

namespace WebMotorsProject.Domain.Data.DTO
{
    public class VersaoDTO
    {
        [JsonProperty(PropertyName = "ID")]
        public long Id { get; set; }

        [JsonProperty(PropertyName = "ModelID")]
        public long ModelId { get; set; }

        [JsonProperty(PropertyName = "Name")]
        public string Nome { get; set; }
    }
}
