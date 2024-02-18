using API.ASSISTENCIA_TECNICA_OS.DTO.Orcamento;
using API.ASSISTENCIA_TECNICA_OS.Model.Orcamento;
using AutoMapper;

namespace API.ASSISTENCIA_TECNICA_OS.Service.Mapper.Orcamento
{
    public class OrcamentoMapping : Profile
    {
        public OrcamentoMapping()
        {
            CreateMap<InsertOrcamentoDto, OrcamentoModel>()
                .ForMember(x => x.DescricaoServico, map => map.MapFrom(src => src.DescricaoServico))
                .ForMember(x => x.ValorOrcamento, map => map.MapFrom(src => src.ValorOrcamento))
                .ForMember(x => x.DataHoraCadastro, map => map.MapFrom(src => DateTime.UtcNow))
                .ForMember(x => x.UsuarioCadastroId, map => map.MapFrom(src => src.UserId))
                .ForMember(x => x.DataHoraAlteracao, map => map.MapFrom(src => DateTime.UtcNow))
                .ForMember(x => x.UsuarioAlteracaoId, map => map.MapFrom(src => src.UserId))
                .ForMember(x => x.MaquinaId, map => map.MapFrom(src => src.MaquinaId))
                .ForMember(x => x.TempoEstimadoManutencao, map => map.MapFrom(src => 0))
                .ForMember(x => x.TempoEstimadoOrcamento, map => map.MapFrom(src => 0))
                .ForMember(x => x.Externo, map => map.MapFrom(src => src.Externo));

            CreateMap<OrcamentoModel, ReturnOrcamentoResumidoDto>()
                .ForMember(x => x.NumeroOrcamento, map => map.MapFrom(src => src.Id))
                .ForMember(x => x.Status, map => map.MapFrom(src => VerifyStatus(src.Status)))
                .ForMember(x => x.ValorOrcamento, map => map.MapFrom(src => src.ValorOrcamento))
                .ForMember(x => x.Externo, map => map.MapFrom(src => src.Externo))
                .ForMember(x => x.Observacao, map => map.MapFrom(src => src.Observacao))
                .ForPath(x => x.Cadastro, map => map.MapFrom(src => new InfoCadastroOuAlteracaoOrcamentoResumido
                {
                    Apelido = src.UsuarioCadastro.Apelido,
                    Nome = src.UsuarioCadastro.Nome,
                    DataHora = src.DataHoraCadastro,
                    UserId = src.UsuarioCadastro.Id
                }))
                .ForPath(x => x.Alteracao, map => map.MapFrom(src => new InfoCadastroOuAlteracaoOrcamentoResumido
                {
                    Apelido = src.UsuarioAlteracao.Apelido,
                    Nome = src.UsuarioAlteracao.Nome,
                    DataHora = src.DataHoraAlteracao,
                    UserId = src.UsuarioAlteracao.Id
                }))
                .ForPath(x => x.Cliente, map => map.MapFrom(src => new InfoClienteOrcamentoResumidoDto
                {
                    ClienteId = src.MaquinaCliente.ClienteId,
                    CEP = src.MaquinaCliente.Cliente.CEP,
                    Cidade = src.MaquinaCliente.Cliente.Cidade,
                    Cnpj = src.MaquinaCliente.Cliente.Cnpj,
                    CodigoRadar = src.MaquinaCliente.Cliente.CodigoRadar,
                    ContatoNomeCliente = src.MaquinaCliente.Cliente.NomeContatoClient,
                    ContatoTelefoneCliente = src.MaquinaCliente.Cliente.ContatoTelefone,
                    Estado = src.MaquinaCliente.Cliente.Estado,
                    NomeCliente = src.MaquinaCliente.Cliente.Nome,
                    NumeroEstabelecimento = src.MaquinaCliente.Cliente.NumeroEstabelecimento,
                    Regiao = src.MaquinaCliente.Cliente.Regiao,
                    Rua = src.MaquinaCliente.Cliente.Rua
                }))
                .ForPath(x => x.Maquina, map => map.MapFrom(src => new MaquinaOrcamentoResumidoDto
                {
                    MaquinaClienteId = src.MaquinaClienteId,
                    CodigoMaquina = src.MaquinaCliente.Maquina.CodigoMaquina,
                    DescricaoMaquina = src.MaquinaCliente.Maquina.DescricaoMaquina,
                    MaquinaId = src.MaquinaCliente.Maquina.Id,
                    NumeroSerie = src.MaquinaCliente.Maquina.NumeroSerie,
                }));


            CreateMap<OrcamentoModel, ReturnOrcamentoDto>()
                .ForMember(x => x.NumeroOrcamento, map => map.MapFrom(src => src.Id))
                .ForMember(x => x.DescricaoServico, map => map.MapFrom(src => src.DescricaoServico))
                .ForMember(x => x.Status, map => map.MapFrom(src => VerifyStatus(src.Status)))
                .ForMember(x => x.Externo, map => map.MapFrom(src => src.Externo))
                .ForMember(x => x.Observacao, map => map.MapFrom(src => src.Observacao))
                .ForMember(x => x.TempoEstimadoManutencao, map => map.MapFrom(src => src.TempoEstimadoManutencao))
                .ForMember(x => x.TempoEstimadoOrcamento, map => map.MapFrom(src => src.TempoEstimadoOrcamento))
                .ForMember(x => x.TecnicoManutencao, map => map.MapFrom(src => ValidateTechnicianMaintenance(src.TecnicoManutenco)))
                .ForMember(x => x.TecnicoOrcamento, map => map.MapFrom(src => ValidateTechnicianBudget(src.TecnicoOrcamento)))
                .ForPath(x => x.Cadastro, map => map.MapFrom(src => new UserOrcamentoDto
                {
                    Apelido = src.UsuarioCadastro.Apelido,
                    Nome = src.UsuarioCadastro.Nome,
                    DataHora = src.DataHoraCadastro,
                    UserId = src.UsuarioCadastro.Id
                }))
                .ForPath(x => x.Alteracao, map => map.MapFrom(src => new UserOrcamentoDto
                {
                    Apelido = src.UsuarioAlteracao.Apelido,
                    Nome = src.UsuarioAlteracao.Nome,
                    DataHora = src.DataHoraAlteracao,
                    UserId = src.UsuarioAlteracao.Id
                }))
                .ForPath(x => x.StatusSituacao, map => map.MapFrom(src => src.StatusOrcamento.Select(c => new StatusOrcamentoDto
                {
                    Status = c.Status.Status,
                    StatusId = c.StatusId,
                    DataHoraInicio = c.DataHoraInicio,
                    DataHoraFim = c.DataHoraFim,
                    Observacao = c.Observacao,
                    UsuarioApontamentoInicio = ValidateUserApontamentoInicio(c.UsuarioApontamentoInicio),
                    UsuarioApontamentoFim = ValidateUserApontamentoFim(c.UsuarioApontamentFim)

                })))
                .ForPath(x => x.Maquina, map => map.MapFrom(src => new MaquinaOrcamentoDto
                {
                    CodigoMaquina = src.MaquinaCliente.Maquina.CodigoMaquina,
                    DescricaoMaquina = src.MaquinaCliente.Maquina.DescricaoMaquina,
                    MaquinaId = src.MaquinaCliente.Maquina.Id,
                    NumeroSerie = src.MaquinaCliente.Maquina.NumeroSerie,
                    MaquinaClienteId = src.MaquinaClienteId,
                    
                    Pecas = src.Pecas.Select(c => new PecasMaquinaOrcamentoDto
                    {
                        Id = c.Id,
                        Troca = c.Troca,
                        CodigoPeca = c.Peca.CodigoRadar,
                        DescricaoPeca = c.Peca.Descricao,
                        EnderecoImagem = c.Peca.EnderecoImagem,
                        PecaId = c.Peca.Id,
                        Preco = c.Peca.Preco,
                        Quantidade = c.Quantidade
                    }).ToList()
                    /*Pecas = src.MaquinaCliente.Maquina.Pecas.Select(c => new PecasMaquinaOrcamentoDto
                    {
                        CodigoPeca = c.Peca.CodigoRadar,
                        DescricaoPeca = c.Peca.Descricao,
                        EnderecoImagem = c.Peca.EnderecoImagem,
                        PecaId = c.Peca.Id,
                        Preco = c.Peca.Preco
                    }).ToList()*/
                }))
                .ForPath(x => x.Cliente, map => map.MapFrom(src => new ClienteOrcamentoDto
                {
                    ClienteId = src.MaquinaCliente.ClienteId,
                    CEP = src.MaquinaCliente.Cliente.CEP,
                    Cidade = src.MaquinaCliente.Cliente.Cidade,
                    Cnpj = src.MaquinaCliente.Cliente.Cnpj,
                    CodigoRadar = src.MaquinaCliente.Cliente.CodigoRadar,
                    ContatoNomeCliente = src.MaquinaCliente.Cliente.NomeContatoClient,
                    ContatoTelefoneCliente = src.MaquinaCliente.Cliente.ContatoTelefone,
                    Estado = src.MaquinaCliente.Cliente.Estado,
                    NomeCliente = src.MaquinaCliente.Cliente.Nome,
                    NumeroEstabelecimento = src.MaquinaCliente.Cliente.NumeroEstabelecimento,
                    Regiao = src.MaquinaCliente.Cliente.Regiao,
                    Rua = src.MaquinaCliente.Cliente.Rua
                }))
                .ForPath(x => x.Diario, map => map.MapFrom(src => src.Diario.Select(c => new DiarioOrcamentoDto
                {
                    ApelidoUsuario = c.UsuarioApontamento.Apelido,
                    Observacao = c.Informacao,
                    Privado = c.Privado,
                    DataHoraApontamento = c.DataHoraApontamento,
                    UsuarioId = c.UsuarioApontamentoId,
                    Tag = c.Tag,
                    NumeroApontamento = c.Id,
                    UsuarioApontamento = c.UsuarioApontamento.Nome
                })));
        }
        private static string VerifyStatus(StatusSituacaoModel status)
        {
            switch (status)
            {
                case StatusSituacaoModel.AGUARDANDO_ATRIBUICAO:
                    return "AGUARDANDO ATRIBUIÇÃO";
                case StatusSituacaoModel.AGUARDANDO_ORCAMENTO:
                    return "AGUARDANDO ORÇAMENTO";
                case StatusSituacaoModel.ORCANDO:
                    return "ORÇANDO";
                case StatusSituacaoModel.AGUARDANDO_LIBERACAO_ORCAMENTO:
                    return "AGUARDANDO LIBERAÇÃO DO ORÇAMENTO";
                case StatusSituacaoModel.AGUARDANDO_MANUTENCAO:
                    return "AGUARDANDO MANUTENÇÃO";
                case StatusSituacaoModel.ORCAMENTO_RECUSADO:
                    return "ORÇAMENTO RECUSADO";
                case StatusSituacaoModel.MANUTENCAO_INICIADA:
                    return "MANUTENÇÃO INICIADA";
                case StatusSituacaoModel.AGUARDANDO_PECAS:
                    return "AGUARDANDO PEÇAS";
                case StatusSituacaoModel.PECAS_SEPARADAS:
                    return "PEÇAS SEPARADAS";
                case StatusSituacaoModel.MANUTENCAO_FINALIZADA:
                    return "MANUTENÇÃO FINALIZADA";
                case StatusSituacaoModel.LIMPEZA:
                    return "REALIZANDO LIMPEZA";
                case StatusSituacaoModel.FINALIZADO:
                    return "FINALIZADO";
                default:
                    return "STATUS NÃO ENCONTRADO!";
            }
        }
        private static TecnicoNoOrcamento ValidateTechnicianBudget(TecnicoOrcamentoModel techicianBudget)
        {
            if (techicianBudget == null) return null;

            var technician = new TecnicoNoOrcamento
            {
                Apelido = techicianBudget.Tecnico.Usuario.Apelido,
                Nome = techicianBudget.Tecnico.Usuario.Nome,
                Id = techicianBudget.Tecnico.Usuario.Id
            };

            return technician;
        }
        private static TecnicoNoOrcamento ValidateTechnicianMaintenance(TecnicoManutencaoModel technicianMaintenance)
        {
            if (technicianMaintenance == null) return null;

            var technician = new TecnicoNoOrcamento
            {
                Apelido = technicianMaintenance.Tecnico.Usuario.Apelido,
                Nome = technicianMaintenance.Tecnico.Usuario.Nome,
                Id = technicianMaintenance.Tecnico.Usuario.Id
            };

            return technician;
        }
        private static UsuarioApontamentoOrcamentoDto ValidateUserApontamentoInicio(UsuarioApontamentoInicioStatusModel dto)
        {
            if (dto == null) return null;

            var item = new UsuarioApontamentoOrcamentoDto
            {
                UsuarioApotamentoNome = dto.UsuarioApontamentoInicio.Nome,
                UsuarioApontamentoApelido = dto.UsuarioApontamentoInicio.Apelido
            };

            return item;
        }
        private static UsuarioApontamentoOrcamentoDto ValidateUserApontamentoFim(UsuarioApontamentoFimStatusModel dto)
        {
            if (dto == null) return null;

            var item = new UsuarioApontamentoOrcamentoDto
            {
                UsuarioApotamentoNome = dto.UsuarioApontamentoFim.Nome,
                UsuarioApontamentoApelido = dto.UsuarioApontamentoFim.Apelido
            };

            return item;
        }

    }
}
