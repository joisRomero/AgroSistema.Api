using AgroSistema.Application.Combos.GetCalidadesCosecha;
using AgroSistema.Application.Common.Mappings;
using AgroSistema.Domain.Entities.GetCalidadesCosechaAsync;
using AgroSistema.Domain.Entities.GetListaPaginadaCultivosAsync;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AgroSistema.Application.Cultivo.ListarCultivosAsync
{
    public class ListarCultivosDTO :IMapFrom<ListaPaginadaCultivoEntity>
    {
        public int Correlativo { get; set; }
        public int IdCultivo { get; set; }
        public string? NombreCultivo { get; set; }
        public string? Estado { get; set; }
        public string? NombreUsuario { get; set; }
        public int CantidadRegistros { get; set; }
        public void Mapping(Profile profile)
        {
            profile.CreateMap<ListaPaginadaCultivoEntity, ListarCultivosDTO>();
        }
    }
}
