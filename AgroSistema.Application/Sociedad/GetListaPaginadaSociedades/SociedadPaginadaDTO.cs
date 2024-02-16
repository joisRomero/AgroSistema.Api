using AgroSistema.Application.Common.Mappings;
using AgroSistema.Domain.Entities.GetListaPaginadaSociedades;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AgroSistema.Application.Sociedad.GetListaPaginadaSociedades
{
    public class SociedadPaginadaDTO : IMapFrom<SociedadPaginadaEntity>
    {
        public int Numero { get; set; }
        public int IdSociedad { get; set; }
        public string? Nombre { get; set; }
        public bool EsAdministrador { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<SociedadPaginadaEntity, SociedadPaginadaDTO>();
        }
    }
}
