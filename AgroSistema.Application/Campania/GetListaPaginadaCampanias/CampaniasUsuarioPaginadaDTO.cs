using AgroSistema.Application.Common.Mappings;
using AgroSistema.Domain.Entities.GetListaPaginadaCampaniasUsuarioAsync;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AgroSistema.Application.Campania.GetListaPaginadaCampanias
{
    public class CampaniasUsuarioPaginadaDTO : IMapFrom<CampaniasUsuarioPaginadaEntity>
    {
        public int IdCampania { get; set; }
        public int Numero { get; set; }
        public string? Nombre { get; set; }
        public string? Terreno { get; set; }
        public string? Cultivo { get; set; }
        public string? Inicio { get; set; }
        public string? Fin { get; set; }
        public bool Estado { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<CampaniasUsuarioPaginadaEntity, CampaniasUsuarioPaginadaDTO>();
        }
    }
}
