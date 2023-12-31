﻿using API.ASSISTENCIA_TECNICA_OS.DTO.Maquina;

namespace API.ASSISTENCIA_TECNICA_OS.Interface
{
    public interface IMaquinaService
    {
        Task<ReturnMaquinaComPecasDto> Insert(InsertMaquinaDto dto);
        Task<ReturnMaquinaComPecasDto> UpdateMaquina(UpdateMaquinaDto dto);
        Task<List<ReturnMaquinaComPecasDto>> GetAll();
        Task<List<ReturnMaquinaComPecasDto>> GetBySemAtribuicao();
        Task<ReturnMaquinaComPecasDto> AtribuirMaquina(AtribuicaoMaquinaDto dto);
        Task<ReturnMaquinaComPecasDto> DesatribuirMaquina(AtribuicaoMaquinaDto dto);
        Task<ReturnMaquinaComPecasDto> GetById(Guid id);
        Task<ReturnMaquinaComPecasDto> GetByNumeroSerie(string numeroSerie);
        Task<bool> DeleteAll();
        Task<ReturnMaquinaComPecasDto> GetByCodigo(string codigo);
        Task<bool> DeleteById(Guid id); 
    }
}
