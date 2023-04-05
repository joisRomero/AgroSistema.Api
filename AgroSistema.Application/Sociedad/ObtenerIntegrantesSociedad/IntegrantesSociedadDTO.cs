using AgroSistema.Application.Common.Mappings;
using AgroSistema.Domain.Entities.ObtenerIntegrantesSociedadAsync;
using AutoMapper;

namespace AgroSistema.Application.Sociedad.ObtenerIntegrantesSociedad
{
    public class IntegrantesSociedadDTO : IMapFrom<IntegrantesSociedadEntity>
    {
        public string? NombreCompleto { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<IntegrantesSociedadEntity, IntegrantesSociedadDTO>();
        }
    }
}
