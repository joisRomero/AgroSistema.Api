using AgroSistema.Application.Common.Mappings;
using AgroSistema.Domain.Entities.ListarCosechaDetalleAsync;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AgroSistema.Application.Cosecha.ObtenerCosecha
{
    public class DetalleCosechaDetalleDTO : IMapFrom<DetalleCosechaDetalleEntity>
    {
        public int IdCosechaDetalle { get; set; }
        public int Cantidad { get; set; }
        public int Unidad { get; set; }
        public int Calidad { get; set; }
        public string? Descripcion { get; set; }
        public string? UnidadDescripcion { get; set; }
        public string? CalidadDescripcion { get; set; }
        public void Mapping(Profile profile)
        {
            profile.CreateMap<DetalleCosechaDetalleEntity, DetalleCosechaDetalleDTO>();
        }
    }
}
