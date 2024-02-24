using AgroSistema.Application.Common.Mappings;
using AgroSistema.Application.Gasto.GetListaPaginadaTipoGasto;
using AgroSistema.Domain.Entities.GetListaPaginadaTipoGastoAsync;
using AgroSistema.Domain.Entities.GetTipoGastoPorIdAsync;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AgroSistema.Application.Gasto.GetTipoGasto
{
    public class ObtenerTipoGastoDTO : IMapFrom<ObtenerTipoGastoEntity>
    {
        public int IdTipoGasto { get; set; }
        public string? NombreTipoGasto { get; set; }
        public string? Descripcion { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<ObtenerTipoGastoEntity, ObtenerTipoGastoDTO>();
        }
    }
}
