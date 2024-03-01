using AgroSistema.Application.Common.Interface.Repositories;
using AgroSistema.Domain.Entities.AgregarActividadTrabajadorGastosAsync;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Linq;
using System.Xml.Serialization;

namespace AgroSistema.Application.Actividad.AgregarActividadTrabajadorGastosAsync
{
    public class AgregarActividadTrabajadorGastosCommandHandler : IRequestHandler<AgregarActividadTrabajadorGastosCommand>
    {
        private readonly IActividadRepository _actividadRepository;
        public AgregarActividadTrabajadorGastosCommandHandler(IActividadRepository actividadRepository)
        {
            _actividadRepository = actividadRepository;
        }
        public async Task<Unit> Handle(AgregarActividadTrabajadorGastosCommand request, CancellationToken cancellationToken)
        {
            var listaTrabajador = request.ListaTrabajadores;
            var listaGastos = request.ListaGastos;

            XElement xmlTrabajador = new XElement("DocumentElement");
            foreach (var item in listaTrabajador)
            {
                XElement xmlDetalleTrabajador = new XElement("Trabajador",
                    new XElement("DescripcionTrabajador", item.DescripcionTrabajador),
                    new XElement("CantidadTrabajador", item.CantidadTrabajador),
                    new XElement("CostoUnitario", item.CostoUnitario),
                    new XElement("CostoTotal", item.CostoTotal),
                    new XElement("IdTipoTrabajador", item.IdTipoTrabajador)
                );
                xmlTrabajador.Add(xmlDetalleTrabajador);
            }

            XElement xmlGastos = new XElement("DocumentElement");
            foreach (var item in listaGastos)
            {
                XElement xmlDetalleGatos = new XElement("Gastos",
                    new XElement("Descripcion", item.DescripcionGasto),
                    new XElement("Cantidad", item.CantidadGasto),
                    new XElement("CostoUnitario", item.CostoUnitario),
                    new XElement("CostoTotal", item.CostoTotal),
                    new XElement("IdTipoGasto", item.IdTipoGasto)
                );
                xmlGastos.Add(xmlDetalleGatos);
            }

            var xml_Trabajador = xmlTrabajador.ToString();
            var xml_Gastos = xmlGastos.ToString();

            AgregarActividadTrabajadorGastosEntity entity = new()
            {
                FechaActividad = request.FechaActividad,
                DescripcionActividad = request.DescripcionActividad,
                //CantidadSemillaActividad = request.CantidadSemillaActividad,
                //UnidadSemilla = request.UnidadSemilla,
                IdCampania = request.IdCampania,
                IdTipoActividad = request.IdTipoActividad,
                UsuarioInserta = request.UsuarioInserta,
                XML_ListaTrabajadores = xml_Trabajador,
                XML_ListaGastos = xml_Gastos
            };

            await _actividadRepository.AgregarActividadTrabajadorGastosAsync(entity);

            return Unit.Value;
        }
    }
}
