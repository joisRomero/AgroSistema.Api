using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AgroSistema.Domain.Entities.AgregarTrabajadorActividadAsync
{
    public class AgregarTrabajadorActividadEntity
    {
        public string? DescripcionTrabajador { get; set; }
        public int CantidadTrabajador { get; set; }
        public decimal CostoUnitario { get; set; }
        public decimal CostoTotal { get; set; }
        public int IdTipoTrabajador { get; set; }
        public int IdActividad { get; set; }
        public string? UsuarioInserta { get; set; }
    }
}
