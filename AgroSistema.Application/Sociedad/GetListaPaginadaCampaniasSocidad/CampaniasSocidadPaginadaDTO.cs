using AgroSistema.Application.Common.Mappings;
using AgroSistema.Domain.Entities.GetListaPaginadaCampaniasSociedadAsync;
using AutoMapper;

namespace AgroSistema.Application.Sociedad.GetListaPaginadaCampaniasSocidad
{
    public class CampaniasSocidadPaginadaDTO : IMapFrom<CampaniasSociedadPaginadaEntity>
    {
        public int IdCampania { get; set; }
        public int Numero { get; set; }
        public string? Nombre { get; set; }
        public string? Terreno { get; set; }
        public string? Cultivo { get; set; }
        public string? Inicio { get; set; }
        public string? Fin { get; set; }
        public bool Estado { get; set; }
        public decimal AreaSembrar { get; set; }
        public string? Unidad { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<CampaniasSociedadPaginadaEntity, CampaniasSocidadPaginadaDTO>();
        }
    }
}
