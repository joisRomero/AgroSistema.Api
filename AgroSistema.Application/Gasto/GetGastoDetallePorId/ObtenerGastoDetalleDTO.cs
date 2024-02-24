using AgroSistema.Application.Common.Mappings;
using AgroSistema.Application.Gasto.GetTipoGasto;
using AgroSistema.Domain.Entities.GetGastoDetallePorIdAsync;
using AgroSistema.Domain.Entities.GetTipoGastoPorIdAsync;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AgroSistema.Application.Gasto.GetGastoDetallePorId
{
    public class ObtenerGastoDetalleDTO : IMapFrom<ObtenerGastoDetalleEntity>
    {
        public int IdGastoDetalle { get; set; }
        public int IdTipoGasto { get; set; }
        public DateTime FechaGasto { get; set; }
        public int Cantidad { get; set; }
        public double CostoUnitario { get; set; }
        public double CostoTotal { get; set; }
        public string? Descripcion { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<ObtenerGastoDetalleEntity, ObtenerGastoDetalleDTO>();
        }
    }
}
