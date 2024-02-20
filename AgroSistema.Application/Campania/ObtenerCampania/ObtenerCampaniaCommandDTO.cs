using AgroSistema.Application.Common.Mappings;
using AgroSistema.Domain.Entities.ObtenerCampaniaEntity;
using AutoMapper;

namespace AgroSistema.Application.Campania.ObtenerCampania
{
    public class ObtenerCampaniaCommandDTO : IMapFrom<ObtenerCampaniaEntity>
    {
        public int IdCampania { get; set; }
        public string? NombreTerreno { get; set; }
        public decimal AreaSembrar { get; set; }
        public int UnidadTerreno { get; set; }
        public string? NombreCampania { get; set; }
        public string? DescripcionCampania { get; set; }
        public DateTime FechaInicio { get; set; }
        public int IdCultivo { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<ObtenerCampaniaEntity, ObtenerCampaniaCommandDTO>();
        }
    }
}