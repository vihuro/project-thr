using API.ASSISTENCIA_TECNICA_OS.Model.Maquinas;
using API.ASSISTENCIA_TECNICA_OS.Model.User;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace API.ASSISTENCIA_TECNICA_OS.Model.Orcamento
{
    [Table("tab_sugestao")]
    public class SugestacaoManutencaoModel
    {
        public int Id { get; set; }
        [MaxLength(1000)]
        public string SugestacaoManutencao { get; set; }
        public Guid UsuarioSugestaoId { get; set; }
        public UserModel UsuarioSugestao { get; set; }
        public DateTime DataHoraSugestao { get; set; }
        public DateTime DataCobranca { get; set; }
        public string Status { get; set; }
        public Guid MaquinaClienteId { get; set; }
        public MaquinaClienteModel MaquinaCliente { get; set; }
        public EStatusSugestacao StatusSugestao { get; set; }
    }
    public enum EStatusSugestacao
    {
        EM_DIA,
        HOJE,
        ATRASADO,
        FINALIZADO
    }
}
