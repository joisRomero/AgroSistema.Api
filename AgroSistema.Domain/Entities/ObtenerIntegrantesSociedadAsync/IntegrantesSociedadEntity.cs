namespace AgroSistema.Domain.Entities.ObtenerIntegrantesSociedadAsync
{
    public class IntegrantesSociedadEntity
    {
        public int Numero { get; set; }
        public string? NombreCompleto { get; set; }
        public int IdIntegrante { get; set; }
        public bool EsAdmin { get; set; }
        public int TotalRows { get; set; }
    }
}
