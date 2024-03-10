using AgroSistema.Application.Common.Mappings;
using AgroSistema.Domain.Entities.GetAbonoPorIdAsync;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AgroSistema.Application.Abono.GetAbono
{
    public class ObtenerAbonoDTO : IMapFrom<ObtenerAbonoEntity>
    {
        public int IdAbono { get; set; }
        public string? NombreAbono { get; set; }
        public string? Descripcion { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<ObtenerAbonoEntity, ObtenerAbonoDTO>();
        }
    }
}
