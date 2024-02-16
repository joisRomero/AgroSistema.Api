using AgroSistema.Application.Common.Mappings;
using AgroSistema.Application.Sociedad.GetListaPaginadaSociedades;
using AgroSistema.Domain.Entities.GetListaBusquedaIntegranteAsync;
using AgroSistema.Domain.Entities.GetListaPaginadaSociedades;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AgroSistema.Application.Sociedad.ListaBusquedaIntegrante
{
    public class BusquedaIntegranteDTO : IMapFrom<ListaBusquedaIntegranteEntity>
    {
        public string? NombreCompleto { get; set; }
        public int IdUsuario { get; set; }
        public string? NombreUsuario { get; set; }
        public void Mapping(Profile profile)
        {
            profile.CreateMap<ListaBusquedaIntegranteEntity, BusquedaIntegranteDTO>();
        }
    }
}
