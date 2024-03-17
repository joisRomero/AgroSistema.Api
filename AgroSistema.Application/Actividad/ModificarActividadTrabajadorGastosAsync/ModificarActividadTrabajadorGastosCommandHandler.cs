using AgroSistema.Application.Common.Interface.Repositories;
using AgroSistema.Domain.Entities.AgregarAbonacionEntity;
using AgroSistema.Domain.Entities.AgregarFumigacionDetalleAsync;
using AgroSistema.Domain.Entities.AgregarGastoActividadAsync;
using AgroSistema.Domain.Entities.AgregarTrabajadorActividadAsync;
using AgroSistema.Domain.Entities.EliminarAbonacionListaAsync;
using AgroSistema.Domain.Entities.EliminarFumigacionDetalleListaAsync;
using AgroSistema.Domain.Entities.EliminarGastoDetalleAsync;
using AgroSistema.Domain.Entities.EliminarGastoDetalleListaAsync;
using AgroSistema.Domain.Entities.EliminarTrabajadorListaAsync;
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
using System.Xml.Linq;

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

                XElement xmlTrabajador = new XElement("DocumentElement");
                foreach (var item in listaTrabajador)
                {
                    if (!(item.IdTrabajador == 0 || item.IdTrabajador == null))
                    {
                        XElement xmlDetalleTrabajador = new XElement("Trabajador",
                        new XElement("IdTrabajador", item.IdTrabajador)
                        );
                        xmlTrabajador.Add(xmlDetalleTrabajador);
                    }            
                }

                var xml_Trabajador = xmlTrabajador.ToString();
                EliminarTrabajadorListaEntity eliminarTrabajadorListaEntity = new ()
                {
                    XML_TrabajadorLista = xml_Trabajador,
                    UsuarioElimina = request.UsuarioModifica
                };

                await _actividadRepository.EliminarTrabajadorListaAsync(eliminarTrabajadorListaEntity);


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
                XElement xmlGastos = new XElement("DocumentElement");
                foreach (var item in listaGasto)
                {
                    if (!(item.IdGasto == 0 || item.IdGasto == null))
                    {
                        XElement xmlDetalleGatos = new XElement("Gastos",
                            new XElement("IdGasto", item.IdGasto)
                        );
                        xmlGastos.Add(xmlDetalleGatos);
                    }                        
                }

                var xml_GastosDetalle = xmlGastos.ToString();
                EliminarGastoDetalleListaEntity eliminarGastoDetalleListaEntity = new()
                {
                    XML_GastoDetalleLista = xml_GastosDetalle,
                    UsuarioElimina = request.UsuarioModifica
                };
                await _actividadRepository.EliminarGastoDetalleListaAsync(eliminarGastoDetalleListaEntity);


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
                XElement xmlAbonacion = new XElement("DocumentElement");
                foreach (var itemabonacion in listaAbonacion)
                {
                    if (!(itemabonacion.IdAbono == 0 || itemabonacion.IdAbono == null))
                    {
                        XElement xmlDetalleAbonacion = new XElement("Abonacion",
                        new XElement("IdAbonacion", itemabonacion.IdAbonacion)
                        );
                        xmlAbonacion.Add(xmlDetalleAbonacion);
                    }                    
                }

                var xml_Abonacion = xmlAbonacion.ToString();
                EliminarAbonacionListaEntity eliminarAbonacionListaEntity = new()
                {
                    XML_AbonacionLista = xml_Abonacion,
                    UsuarioElimina = request.UsuarioModifica
                };
                await _actividadRepository.EliminarAbonacionListaAsync(eliminarAbonacionListaEntity);

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
                XElement xmlFumigacionDetalle = new XElement("DocumentElement");
                foreach (var itemFumigacionDetalle in listaFumigacionDetalle)
                {
                    if (!(itemFumigacionDetalle.IdFumigacionDetalle == 0 || itemFumigacionDetalle.IdFumigacionDetalle == null))
                    {
                        XElement xmlDetalle_FumigacionDetalle = new XElement("FumigacionDetalle",
                        new XElement("IdFumigacionDetalle", itemFumigacionDetalle.IdFumigacionDetalle)
                        );
                        xmlFumigacionDetalle.Add(xmlDetalle_FumigacionDetalle);
                    }                    
                }
                var xml_FumigacionDetalle = xmlFumigacionDetalle.ToString();
                EliminarFumigacionDetalleListaEntity eliminarFumigacionDetalleListaEntity = new()
                {
                    XML_FumigacionDetalleLista = xml_FumigacionDetalle,
                    UsuarioElimina = request.UsuarioModifica
                };
                await _actividadRepository.EliminarFumigacionDetalleListaAsync(eliminarFumigacionDetalleListaEntity);

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
