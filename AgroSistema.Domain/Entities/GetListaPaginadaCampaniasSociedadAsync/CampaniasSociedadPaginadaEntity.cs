﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AgroSistema.Domain.Entities.GetListaPaginadaCampaniasSociedadAsync
{
    public class CampaniasSociedadPaginadaEntity
    {
        public int IdCampania { get; set; }
        public int Numero { get; set; }
        public int TotalRows { get; set; }
        public string? Nombre { get; set; }
        public string? Terreno { get; set; }
        public string? Cultivo { get; set; }
        public string? Inicio { get; set; }
        public string? Fin { get; set; }
        public bool Estado { get; set; }
        public decimal AreaSembrar { get; set; }
        public string? Unidad { get; set; }
        public string? EstadoProceso { get; set; }
        public string? EstadoDescripcionProceso { get; set; }
    }
}
