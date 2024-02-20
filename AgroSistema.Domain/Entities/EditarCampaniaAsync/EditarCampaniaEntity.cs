using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AgroSistema.Domain.Entities.EditarCampaniaAsync
{
    public class EditarCampaniaEntity
    {
        public int IdCampania { get; set; }
        public string? NombreTerreno { get; set; }
        public decimal AreaSembrar { get; set; }
        public int UnidadTerreno { get; set; }
        public string? NombreCampania { get; set; }
        public string? DescripcionCampania { get; set; }
        public DateTime FechaInicio { get; set; }
        public int IdCultivo { get; set; }
        public int? IdSociedad { get; set; }
        public int? IdUsuario { get; set; }
        public string? UsuarioModifica { get; set; }
    }
}
