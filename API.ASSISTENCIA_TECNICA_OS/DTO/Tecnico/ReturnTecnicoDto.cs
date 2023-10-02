namespace API.ASSISTENCIA_TECNICA_OS.DTO.Tecnico
{
    public class ReturnTecnicoDto
    {
        public Guid IdTecnico { get; set; }
        public Guid IdUsuario { get; set; }
        public string Nome { get; set; }
        public string Apelido { get; set; }
    }
}
