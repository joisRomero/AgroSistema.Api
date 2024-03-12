using AgroSistema.Application.Common.Interface.Repositories;
using AgroSistema.Domain.Entities.AgregarAbonacionEntity;
using AgroSistema.Domain.Entities.AgregarFumigacionDetalleAsync;
using AgroSistema.Domain.Entities.AgregarGastoActividadAsync;
using AgroSistema.Domain.Entities.AgregarTrabajadorActividadAsync;
using AgroSistema.Domain.Entities.ModificarAbonacionAsync;
using AgroSistema.Domain.Entities.ModificarActividadAsync;
using AgroSistema.Domain.Entities.ModificarFumigacionAsync;
using AgroSistema.Domain.Entities.ModificarFumigacionDetalleAsync;
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
                CantidadSemillaActividad = request.CantidadSemillaActividad,
                UnidadSemilla = request.UnidadSemilla,
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
                        await _actividadRepository.ModificarGastoActividadAsync(modificarGastosEntity);
                    }
                }
            }

            var listaAbonacion = request.ListaAbonacion;
            if (listaAbonacion != null)
            {
                foreach (var item in listaAbonacion)
                {
                    if (item.IdAbono == 0 || item.IdAbono == null)
                    {
                        AgregarAbonacionEntity agregarAbonacionEntity = new()
                        {
                            IdActividad = request.IdActividad
                            ,CantidadAbonacion = item.CantidadAbonacion
                            ,UnidadAbonacion = item.UnidadAbonacion
                            ,IdAbono = item.IdAbono
                            ,UsuarioInserta = request.UsuarioModifica
                        };
                        await _actividadRepository.AgregarAbonacionAsync(agregarAbonacionEntity);
                    }
                    else
                    {
                        ModificarAbonacionEntity modificarAbonacionEntity = new()
                        {
                            IdAbonacion = item.IdAbonacion,
                            CantidadAbonacion = item.CantidadAbonacion,
                            UnidadAbonacion = item.UnidadAbonacion,
                            IdAbono = item.IdAbono,
                            UsuarioModifica = request.UsuarioModifica
                        };
                        await _actividadRepository.ModificarAbonacionAsync(modificarAbonacionEntity);

                    }
                }
            }

            var cantidadFumigacion = request.CantidadFumigacion;
            var unidadFumigacion = request.UnidadFumigacion;
            if ((cantidadFumigacion != 0 || cantidadFumigacion != null) && (unidadFumigacion != 0 || unidadFumigacion != null))
            {
                ModificarFumigacionEntity modificarFumigacionEntity = new()
                {
                    IdActividad = request.IdActividad,
                    CantidadFumigacion = cantidadFumigacion,
                    UnidadFumigacion = unidadFumigacion,
                    UsuarioModifica = request.UsuarioModifica
                };
                await _actividadRepository.ModificarFumigacionAsync(modificarFumigacionEntity);
            }
            var listaFumigacionDetalle = request.ListaFumigacionDetalle;
            if (listaFumigacionDetalle != null)
            {
                foreach (var item in listaFumigacionDetalle)
                {
                    if (item.IdFumigacionDetalle == 0 || item.IdFumigacionDetalle == null)
                    {
                        AgregarFumigacionDetalleEntity agregarFumigacionDetalleEntity = new()
                        {
                            IdFumigacion = item.IdFumigacionDetalle,
                            CantidadFumigacionDetalle = item.CantidadFumigacionDetalle,
                            UnidadFumigacionDetalle = item.UnidadFumigacionDetalle,
                            UsuarioInserta = request.UsuarioModifica
                        };
                        await _actividadRepository.AgregarFumigacionDetalleAsync(agregarFumigacionDetalleEntity);
                    }
                    else
                    {
                        ModificarFumigacionDetalleEntity modificarFumigacionDetalleEntity = new()
                        {
                            IdFumigacionDetalle = item.IdFumigacionDetalle,
                            CantidadFumigacionDetalle = item.CantidadFumigacionDetalle,
                            UnidadFumigacionDetalle = item.UnidadFumigacionDetalle,
                            UsuarioModifica = request.UsuarioModifica
                        };
                        await _actividadRepository.ModificarFumigacionDetalleAsync(modificarFumigacionDetalleEntity);
                    }
                }
            }





            return Unit.Value;
        }
    }
}
