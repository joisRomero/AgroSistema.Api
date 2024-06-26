﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AgroSistema.Domain.Entities.GetListaPaginadaSociedades
{
    public class SociedadPaginadaEntity
    {
        public int Numero { get; set; }
        public int TotalRows { get; set; }
        public int IdSociedad { get; set; }
        public string? Nombre { get; set; }
        public bool EsAdministrador { get; set; }
    }
}
