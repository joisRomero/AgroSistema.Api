using AgroSistema.Application.Common.Interface.Repositories;
using AgroSistema.Application.Cosecha.AgregarCosecha;
using AgroSistema.Domain.Entities.EditarCosechaAsync;
using AgroSistema.Domain.Entities.ListarCosechaDetalleAsync;
using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace AgroSistema.Application.Cosecha.EditarCosecha
{
    public class EditarCosechaCommandHandler : IRequestHandler<EditarCosechaCommand>
    {
        private readonly ICosechaRepository _cosechaRepository;
        private readonly IMapper _mapper;

        public EditarCosechaCommandHandler(ICosechaRepository cosechaRepository, IMapper mapper)
        {
            _cosechaRepository = cosechaRepository;
            _mapper = mapper;
        }

        public async Task<Unit> Handle(EditarCosechaCommand request, CancellationToken cancellationToken)
        {
            string xmlDetalleCosecha;

            XmlSerializer serializer = new XmlSerializer(typeof(List<CosechaDetalleRequestDTO>));

            using (StringWriter writer = new StringWriter())
            {
                foreach (var detalle in request.ListaCosechaDetalle)
                {
                    if (!detalle.IdCosechaDetalle.HasValue)
                    {
                        detalle.IdCosechaDetalle = 0;
                    }
                }

                serializer.Serialize(writer, request.ListaCosechaDetalle);
                xmlDetalleCosecha = writer.ToString();
            }

            var listaDetalleCosechaActual = await _cosechaRepository.GetCosechaDetallePorIdAsync(request.IdCosecha);
            var listaDetalleCosechaEditar = request.ListaCosechaDetalle;

            var listaDetalleCosechaEliminar = listaDetalleCosechaActual
                .Where(item => !listaDetalleCosechaEditar.Any(detalle => detalle.IdCosechaDetalle == item.IdCosechaDetalle))
                .ToList();

            foreach (var detalleCosecha in listaDetalleCosechaEliminar)
            {
                await _cosechaRepository.EliminarCosechaDetalle(detalleCosecha.IdCosechaDetalle, request.UsuarioModifica);
            }

            EditarCosechaEntity entity = new()
            {
                IdCosecha = request.IdCosecha,
                FechaCosecha = request.FechaCosecha,
                IdCampania = request.IdCampania,
                Descripcion = request.Descripcion,
                UsuarioModifica = request.UsuarioModifica,
                ListaCosechaDetalle = xmlDetalleCosecha
            };

            await _cosechaRepository.EditarCosecha(entity);

            return Unit.Value;
        }
    }
}
