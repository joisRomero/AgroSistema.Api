﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AgroSistema.Domain.Entities.EditarCosechaAsync
{
    public class EditarCosechaEntity
    {
        public int IdCosecha { get; set; }
        public DateTime? FechaCosecha { get; set; }
        public int IdCampania { get; set; }
        public string? Descripcion { get; set; }
        public string? UsuarioModifica { get; set; }
        public string? ListaCosechaDetalle { get; set; }
    }
}
