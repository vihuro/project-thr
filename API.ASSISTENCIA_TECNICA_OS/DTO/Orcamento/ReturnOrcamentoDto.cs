namespace API.ASSISTENCIA_TECNICA_OS.DTO.Orcamento
{
    public class ReturnOrcamentoDto
    {
        public int NumeroOrcamento { get; set; }
        public string DescricaoServico { get; set; }
        public double ValorOrcamento { get; set; }
        public string Status { get; set; }
        public List<StatusOrcamentoDto> StatusSituacao { get; set; }
        public UserOrcamentoDto Cadastro {get;set;}
        public UserOrcamentoDto Alteracao { get; set; }
        public MaquinaOrcamentoDto Maquina { get; set; }
        public ClienteOrcamentoDto Cliente { get; set; }
    }
    public class ClienteOrcamentoDto
    {
        public Guid ClienteId { get; set; }
        public string CodigoRadar { get; set; }
        public string NomeCliente { get; set; }
        public string CEP { get; set; }
        public string Estado { get;set; }
        public string Cidade { get; set; }
        public string Regiao{ get; set; }
        public string Rua { get; set; }
        public string NumeroEstabelecimento { get; set; }
        public string Cnpj { get; set; }
        public string ContatoTelefoneCliente { get; set; }
        public string ContatoNomeCliente { get; set; }
    }
    public class StatusOrcamentoDto
    {
        public int StatusId {  get; set; }
        public string Status { get; set; }
        public string Observacao { get; set; }
        
        public DateTime DataHoraInicio { get; set; }
        public DateTime DataHoraFim { get; set; }
        public UsuarioApontamentoOrcamentoDto UsuarioApontamentoInicio { get; set; }
        public UsuarioApontamentoOrcamentoDto UsuarioApontamentoFim { get; set; }

    }
    public class UsuarioApontamentoOrcamentoDto
    {
        public string UsuarioApotamentoNome { get; set; }
        public string UsuarioApontamentoApelido { get; set; }
    }
    public class UserOrcamentoDto 
    {
        public Guid UserId { get; set; }
        public string Apelido { get; set; }
        public string Nome { get; set; }
        public DateTime DataHora { get; set; }
    }
    public class MaquinaOrcamentoDto
    {
        public Guid MaquinaId { get; set; }
        public string CodigoMaquina { get; set; }
        public string DescricaoMaquina { get; set; }
        public string NumeroSerie { get; set; }
        public List<PecasMaquinaOrcamentoDto> Pecas { get; set; }
    }
    public class PecasMaquinaOrcamentoDto
    {
        public Guid PecaId { get; set; }
        public string CodigoPeca { get; set; }
        public string DescricaoPeca { get; set; }
        public double Preco { get; set; }
        public string EnderecoImagem { get; set; }
        public bool Troca { get; set; }
        public bool Conserto { get; set; }
    }
}
