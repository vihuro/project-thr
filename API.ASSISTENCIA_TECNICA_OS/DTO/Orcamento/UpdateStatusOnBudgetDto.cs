﻿namespace API.ASSISTENCIA_TECNICA_OS.DTO.Orcamento
{
    public class UpdateStatusOnBudgetDto
    {
        public Guid UsuarioId { get; set; }
        public int NumeroOrcamento { get; set; }
        public int StatusId { get; set; }
    }
}
