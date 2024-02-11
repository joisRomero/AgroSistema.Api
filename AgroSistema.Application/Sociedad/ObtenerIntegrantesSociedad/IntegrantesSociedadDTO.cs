using AgroSistema.Application.Common.Mappings;
using AgroSistema.Domain.Entities.ObtenerIntegrantesSociedadAsync;
using AutoMapper;

namespace AgroSistema.Application.Sociedad.ObtenerIntegrantesSociedad
{
    public class IntegrantesSociedadDTO : IMapFrom<IntegrantesSociedadEntity>
    {
        public int Numero { get; set; }
        public string? NombreCompleto { get; set; }
        public int IdIntegrante { get; set; }
        public bool EsAdmin { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<IntegrantesSociedadEntity, IntegrantesSociedadDTO>();
        }
    }
}
