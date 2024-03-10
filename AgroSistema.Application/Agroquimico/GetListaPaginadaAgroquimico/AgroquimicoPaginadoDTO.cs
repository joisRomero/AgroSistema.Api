using AgroSistema.Application.Common.Mappings;
using AgroSistema.Domain.Entities.GetListaPaginadaAgroquimicoAsync;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AgroSistema.Application.Agroquimico.GetListaPaginadaAgroquimico
{
    public class AgroquimicoPaginadoDTO : IMapFrom<AgroquimicoPaginadoEntity>
    {
        public int Numero { get; set; }
        public int IdAgroquimico { get; set; }
        public string? NombreAgroquimico { get; set; }
        public int IdTipoAgroquimico { get; set; }
        public string? NombreTipoAgroquimico { get; set; }
        public string? Descripcion { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<AgroquimicoPaginadoEntity, AgroquimicoPaginadoDTO>();
        }
    }
}
