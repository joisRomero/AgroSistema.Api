﻿using AgroSistema.Domain.Entities.AgregarActividadTrabajadorGastosAsync;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AgroSistema.Application.Common.Interface.Repositories
{
    public interface IActividadRepository
    {
        Task AgregarActividadTrabajadorGastosAsync(AgregarActividadTrabajadorGastosEntity agregarActividadTrabajadorGastosEntity);
    }
}
