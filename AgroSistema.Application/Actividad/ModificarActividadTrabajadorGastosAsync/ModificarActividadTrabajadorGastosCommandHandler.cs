using AgroSistema.Application.Common.Interface.Repositories;
using AgroSistema.Domain.Entities.AgregarGastoActividadAsync;
using AgroSistema.Domain.Entities.AgregarTrabajadorActividadAsync;
using AgroSistema.Domain.Entities.ModificarActividadAsync;
using AgroSistema.Domain.Entities.ModificarGastosAsync;
using AgroSistema.Domain.Entities.ModificarTrabajadorAsync;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AgroSistema.Application.Actividad.ModificarActividadTrabajadorGastosAsync
{
    public class ModificarActividadTrabajadorGastosCommandHandler : IRequestHandler<ModificarActividadTrabajadorGastosCommand>
    {
        private readonly IActividadRepository _actividadRepository;
        public ModificarActividadTrabajadorGastosCommandHandler(IActividadRepository actividadRepository)
        {
            _actividadRepository = actividadRepository;
        }

        public async Task<Unit> Handle(ModificarActividadTrabajadorGastosCommand request, CancellationToken cancellationToken)
        {
            ModificarActividadEntity entity = new ModificarActividadEntity()
            {
                IdActividad = request.IdActividad,
                FechaActividad = request.FechaActividad,
                DescripcionActividad = request.DescripcionActividad,
                //CantidadSemillaActividad = request.CantidadSemillaActividad,
                //UnidadSemilla = request.UnidadSemilla,
                IdCampania = request.IdCampania,
                IdTipoActividad = request.IdTipoActividad,
                UsuarioModifica = request.UsuarioModifica,
            };

            await _actividadRepository.ModificarActividadAsync(entity);

            var listaTrabajador = request.ListaTrabajador;
            if (listaTrabajador != null)
            {
                foreach (var item in listaTrabajador)
                {
                    if (item.IdTrabajador == 0 || item.IdTrabajador == null)
                    {
                        AgregarTrabajadorActividadEntity agregarTrabajadorActividadEntity = new()
                        {
                            DescripcionTrabajador = item.DescripcionTrabajador,
                            CantidadTrabajador = item.CantidadTrabajador,
                            CostoUnitario = item.CostoUnitario,
                            CostoTotal = item.CostoTotal,
                            IdTipoTrabajador = item.IdTipoTrabajador,
                            IdActividad = request.IdActividad,
                            UsuarioInserta = request.UsuarioModifica
                        };
                        await _actividadRepository.AgregarTrabajadorAsync(agregarTrabajadorActividadEntity);
                    }
                    else
                    {
                        ModificarTrabajadorEntity modificarTrabajadorEntity = new()
                        {
                            IdTrabajador = item.IdTrabajador,
                            DescripcionTrabajador = item.DescripcionTrabajador,
                            CantidadTrabajador = item.CantidadTrabajador,
                            CostoUnitario = item.CostoUnitario,
                            CostoTotal = item.CostoTotal,
                            IdTipoTrabajador = item.IdTipoTrabajador,
                            UsuarioModifica = request.UsuarioModifica
                        };
                        await _actividadRepository.ModificarTrabajadorAsync(modificarTrabajadorEntity);
                    }
                }
            }

            var listaGasto = request.ListaGasto;

            if (listaGasto != null)
            {
                foreach (var item in listaGasto)
                {
                    if (item.IdGasto == 0 || item.IdGasto == null)
                    {
                        AgregarGastoActividadEntity agregarGastoActividadEntity = new()
                        {
                            DescripcionGasto = item.DescripcionGasto,
                            CantidadGasto = item.CantidadGasto,
                            CostoUnitario = item.CostoUnitario,
                            CostoTotal = item.CostoTotal,
                            FechaGasto = request.FechaActividad,
                            IdTipoGasto = item.IdTipoGasto,
                            IdActividad = request.IdActividad,
                            UsuarioInserta = request.UsuarioModifica
                        };
                        await _actividadRepository.AgregarGastoActividadAsync(agregarGastoActividadEntity);
                    }
                    else
                    {
                        ModificarGastosEntity modificarGastosEntity = new()
                        {
                            IdGasto = item.IdGasto,
                            DescripcionGasto = item.DescripcionGasto,
                            CantidadGasto = item.CantidadGasto,
                            CostoUnitario = item.CostoUnitario,
                            CostoTotal = item.CostoTotal,
                            FechaGasto = request.FechaActividad,
                            IdTipoGasto = item.IdTipoGasto,
                            UsuarioModifica = request.UsuarioModifica
                            
                        };
                        await _actividadRepository.ModificarGastoActividadAsync (modificarGastosEntity);
                    }
                }
            }

            return Unit.Value;
        }
    }
}
