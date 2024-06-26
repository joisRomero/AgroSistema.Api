﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AgroSistema.Application.Actividad.ModificarActividadTrabajadorGastosAsync
{
    public class GastoRequestDTO
    {
        public int? IdGasto { get; set; }
        public string? DescripcionGasto { get; set; }
        public int CantidadGasto { get; set; }
        public decimal CostoUnitario { get; set; }
        public decimal CostoTotal { get; set; }
        public int IdTipoGasto { get; set; }
    }
}
