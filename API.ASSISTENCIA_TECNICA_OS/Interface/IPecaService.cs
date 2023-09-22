﻿using API.ASSISTENCIA_TECNICA_OS.DTO.Pecas;

namespace API.ASSISTENCIA_TECNICA_OS.Interface
{
    public interface IPecaService
    {
        Task<ReturnPecasDto> InsertPecas(InsertPecaDto dto);
        Task<ReturnPecasDto> Update(UpdatePecaDto dto);
        Task<List<ReturnPecasDto>> GetAll();
        Task<ReturnPecasDto> GetById(Guid id);
        Task<bool> DeleteAll();
    }
}
