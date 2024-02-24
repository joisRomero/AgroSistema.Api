﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AgroSistema.Domain.Entities.ListaPaginadaTipoActividadAsync
{
    public class RequestListaPaginadaTipoActividadEntity
    {
        public string? NombreTipoActividad { get; set; }
        public string? RealizadaPorTipoActividad { get; set; }
        public int IdUsuario { get; set; }
        public int PageSize { get; set; }
        public int PageNumber { get; set; }
    }
}
