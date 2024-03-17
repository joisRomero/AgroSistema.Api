using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AgroSistema.Domain.Entities.AgregarCosechaAsync
{
    public class AgregarCosechaEntity
    {
        public DateTime? FechaCosecha { get; set; }
        public int IdCampania { get; set; }
        public string? Descripcion { get; set; }
        public string? UsuarioInserta { get; set; }
        public string? XML_ListaCosechaDetalle { get; set; }
    }
}
