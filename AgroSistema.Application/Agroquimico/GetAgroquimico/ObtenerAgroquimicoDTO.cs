using AgroSistema.Application.Common.Mappings;
using AgroSistema.Domain.Entities.GetAgroquimicoPorIdAsync;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AgroSistema.Application.Agroquimico.GetAgroquimico
{
    public class ObtenerAgroquimicoDTO : IMapFrom<ObtenerAgroquimicoEntity>
    {
        public int IdAgroquimico { get; set; }
        public string? NombreAgroquimico { get; set; }
        public string? Descripcion { get; set; }
        public int IdTipoAgroquimico { get; set; }
        public string? NombreTipoAgroquimico { get; set; }
        public void Mapping(Profile profile)
        {
            profile.CreateMap<ObtenerAgroquimicoEntity, ObtenerAgroquimicoDTO>();
        }
    }
}
