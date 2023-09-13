using System.Text.Json.Serialization;

namespace API.ASSISTENCIA_TECNICA_OS.DTO.CEP
{
    public class CepDto
    {
        [JsonPropertyName("cep")]
        public string Cep { get; set; }
        [JsonPropertyName("state")]
        public string State { get; set; }
        [JsonPropertyName("city")]
        public string Cidade { get; set; }
        [JsonPropertyName("neighborhood")]
        public string Regiao { get; set; }
        [JsonPropertyName("street")]
        public string Rua { get; set; }
        [JsonPropertyName("service")]
        public string Service { get; set; }
    }
    public class ReturnCEPDto
    {
        public string Cep { get; set; }
        public string Estado { get; set; }
        public string Cidade { get; set; }
        public string Regiao { get; set; }
        public string Rua { get; set; }
        public string Service { get; set; }
    }
}
