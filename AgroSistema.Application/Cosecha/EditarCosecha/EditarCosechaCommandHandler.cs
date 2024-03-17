using AgroSistema.Application.Common.Interface.Repositories;
using AgroSistema.Application.Cosecha.AgregarCosecha;
using AgroSistema.Domain.Entities.EditarCosechaAsync;
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

        public EditarCosechaCommandHandler(ICosechaRepository cosechaRepository)
        {
            _cosechaRepository = cosechaRepository;
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
