using Newtonsoft.Json;

namespace WebMotorsProject.Domain.Data.DTO
{
    public class VeiculoDTO
    {
        [JsonProperty(PropertyName = "ID")]
        public long Id { get; set; }

        [JsonProperty(PropertyName = "Make")]
        public string Marca { get; set; }

        [JsonProperty(PropertyName = "Model")]
        public string Modelo { get; set; }

        [JsonProperty(PropertyName = "Version")]
        public string Versao { get; set; }

        [JsonProperty(PropertyName = "Image")]
        public string Imagem { get; set; }

        [JsonProperty(PropertyName = "KM")]
        public long KM { get; set; }

        [JsonProperty(PropertyName = "Price")]
        public decimal Preco { get; set; }

        [JsonProperty(PropertyName = "YearModel")]
        public int AnoModelo { get; set; }

        [JsonProperty(PropertyName = "YearFab")]
        public int AnoFabricacao { get; set; }

        [JsonProperty(PropertyName = "Color")]
        public string Cor { get; set; }
    }
}
