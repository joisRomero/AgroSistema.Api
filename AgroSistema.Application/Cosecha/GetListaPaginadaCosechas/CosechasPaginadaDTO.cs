using AgroSistema.Application.Common.Mappings;
using AgroSistema.Domain.Entities.GetListaPaginadaCosechasAsync;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AgroSistema.Application.Cosecha.GetListaPaginadaCosechas
{
    public class CosechasPaginadaDTO : IMapFrom<CosechaPaginadaEntity>
    {
        public int Numero { get; set; }
        public int IdCosecha { get; set; }
        public string? Fecha { get; set; }
        public string? Descripcion { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<CosechaPaginadaEntity, CosechasPaginadaDTO>();
        }
    }
}
