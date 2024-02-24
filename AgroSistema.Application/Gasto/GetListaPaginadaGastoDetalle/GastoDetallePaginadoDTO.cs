using AgroSistema.Application.Common.Mappings;
using AgroSistema.Application.Gasto.GetListaPaginadaTipoGasto;
using AgroSistema.Domain.Entities.GetListaPaginadaGastoDetalleAsync;
using AgroSistema.Domain.Entities.GetListaPaginadaTipoGastoAsync;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AgroSistema.Application.Gasto.GetListaPaginadaGastoDetalle
{
    public class GastoDetallePaginadoDTO : IMapFrom<GastoDetallePaginadoEntity>
    {
        public int Numero { get; set; }
        public int IdGastoDetalle { get; set; }
        public int IdTipoGasto { get; set; }
        public string? NombreTipoGasto { get; set; }
        public DateTime FechaGasto { get; set; }
        public int Cantidad { get; set; }
        public double CostoUnitario { get; set; }
        public double CostoTotal { get; set; }
        public string? Descripcion { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<GastoDetallePaginadoEntity, GastoDetallePaginadoDTO>();
        }
    }
}
