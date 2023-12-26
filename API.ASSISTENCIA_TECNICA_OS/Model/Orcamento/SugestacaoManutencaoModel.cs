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
        public Guid UsuarioSugestacaoId { get; set; }
        public UserModel UsuarioSugestacao { get; set; }
        public DateTime DataHoraSugestacao { get; set; }
        public DateTime DataCobranca { get; set; }
        public string StatusSugestacao { get; set; }
        public Guid MaquinaId { get; set; }
        public MaquinaModel Maquina { get; set; }
        public EStatusSugestacao StatusSugestao { get; set; }
    }
    public enum EStatusSugestacao
    {
        EM_DIA,
        ATRASADO,
        FINALIZADO
    }
}
