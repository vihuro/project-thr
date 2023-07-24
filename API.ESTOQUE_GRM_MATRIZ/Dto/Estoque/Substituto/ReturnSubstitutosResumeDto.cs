namespace API.ESTOQUE_GRM_MATRIZ.Dto.Estoque.Substituto
{
    public class ReturnSubstitutosResumeDto
    {
        public Guid Id { get; set; }
        public string Codigo { get; set; }
        public string Descricao { get; set; }
        public string Unidade { get; set; }
        public string LocalEstocagem { get; set; }
        public string TipoMaterial { get; set; }
        public double Quantidade { get; set; }
    }
}
