using AgroSistema.Application.Common.Mappings;
using AgroSistema.Application.Sociedad.GetListaPaginadaSociedades;
using AgroSistema.Domain.Entities.GetListaPaginadaSociedades;
using AgroSistema.Domain.Entities.GetListaPaginadaTipoGastoAsync;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AgroSistema.Application.Gasto.GetListaPaginadaTipoGasto
{
    public class TipoGastoPaginadoDTO : IMapFrom<TipoGastoPaginadoEntity>
    {
        public int Numero { get; set; }
        public int IdTipoGasto { get; set; }
        public string? NombreTipoGasto { get; set; }
        public string? Descripcion { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<TipoGastoPaginadoEntity, TipoGastoPaginadoDTO>();
        }
    }
}
