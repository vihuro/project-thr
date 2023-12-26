namespace API.ASSISTENCIA_TECNICA_OS.DTO.Orcamento
{
    public class ReturnOrcamentoResumidoDto
    {
        public int NumeroOrcamento { get; set; }
        public string DescricaoServico { get; set; }
        public double ValorOrcamento { get; set; }
        public string Status { get; set; }
        public bool Externo { get; set; }
        public string Observacao { get; set; }
        public InfoCadastroOuAlteracaoOrcamentoResumido Cadastro { get; set; }
        public InfoCadastroOuAlteracaoOrcamentoResumido Alteracao { get; set; }
        public InfoClienteOrcamentoResumidoDto Cliente { get; set; }
        public MaquinaOrcamentoResumidoDto Maquina { get; set; }
    }
    public class InfoCadastroOuAlteracaoOrcamentoResumido
    {

        public Guid UserId { get; set; }
        public string Nome { get; set; }
        public string Apelido { get; set; }
        public DateTime DataHora { get; set; }
    }
    public class InfoClienteOrcamentoResumidoDto
    {
        public Guid ClienteId { get; set; }
        public string CodigoRadar { get; set; }
        public string NomeCliente { get; set; }
        public string CEP { get; set; }
        public string Estado { get; set; }
        public string Cidade { get; set; }
        public string Regiao { get; set; }
        public string Rua { get; set; }
        public string NumeroEstabelecimento { get; set; }
        public string Cnpj { get; set; }
        public string ContatoTelefoneCliente { get; set; }
        public string ContatoNomeCliente { get; set; }
    }
    public class MaquinaOrcamentoResumidoDto
    {
        public Guid MaquinaId { get; set; }
        public string CodigoMaquina { get; set; }
        public string DescricaoMaquina { get; set; }
        public string NumeroSerie { get; set; }
    }
}
