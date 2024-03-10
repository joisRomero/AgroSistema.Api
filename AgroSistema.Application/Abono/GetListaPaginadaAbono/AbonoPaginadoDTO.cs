using AgroSistema.Application.Common.Mappings;
using AgroSistema.Domain.Entities.ListaPaginadaAbonoAsync;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AgroSistema.Application.Abono.GetListaPaginadaAbono
{
    public class AbonoPaginadoDTO : IMapFrom<AbonoPaginadoEntity>
    {
        public int Numero { get; set; }
        public int IdAbono { get; set; }
        public string? NombreAbono { get; set; }
        public string? Descripcion { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<AbonoPaginadoEntity, AbonoPaginadoDTO>();
        }
    }
}
