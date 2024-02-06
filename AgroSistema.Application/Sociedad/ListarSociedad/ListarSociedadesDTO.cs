using AgroSistema.Application.Common.Mappings;
using AgroSistema.Domain.Entities.GetListaPaginadaSociedades;
using AgroSistema.Domain.Entities.ListaPaginadaSociedadAsync;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AgroSistema.Application.Sociedad.ListarSociedad
{
    public class ListarSociedadesDTO :IMapFrom<ListaPaginadaSociedadesEntity>
    {
        public int Correlativo { get; set; }
        public int IdSociedad { get; set; }
        public string? NombreSociedad { get; set; }
        public string? Estado { get; set; }
        public string? NombreUsuario { get; set; }
        public int CantidadRegistros { get; set; }
        public void Mapping(Profile profile)
        {
            profile.CreateMap<ListaPaginadaSociedadesEntity, ListarSociedadesDTO>();
        }
    }
}
