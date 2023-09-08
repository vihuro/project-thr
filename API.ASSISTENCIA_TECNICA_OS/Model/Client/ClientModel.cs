using API.ASSISTENCIA_TECNICA_OS.Model.Maquinas;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace API.ASSISTENCIA_TECNICA_OS.Model.Client
{
    [Table("tab_client")]
    public class ClientModel
    {
        public Guid Id { get; set; }
        [Required(ErrorMessage = "Nome do cliente obrigatório!")]
        [StringLength(100, MinimumLength = 3,
            ErrorMessage = "Nome do cliente deve conter de 3 a 100 caracteres!")]
        public string Nome { get; set; }
        public string CodigoRadar { get; set; }
        [Required(ErrorMessage = "Endereço do cliente é obrigatório!")]
        [StringLength(300, MinimumLength = 3,
            ErrorMessage = "Nome do cliente deve conter de 3 a 100 caracteres!")]
        public string Endereco { get; set; }
        [StringLength(14, MinimumLength = 14,
            ErrorMessage = "Um CNPJ precisa ter 14 caracteres!")]
        public string Cnpj { get; set; }
        public string NomeContatoClient { get; set; }
        public string ContatoTelefone { get; set; }

    }
}
