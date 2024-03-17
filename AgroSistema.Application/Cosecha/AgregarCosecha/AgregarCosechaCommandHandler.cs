using AgroSistema.Application.Common.Interface.Repositories;
using AgroSistema.Domain.Entities.AgregarCosechaAsync;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using System.Xml.Serialization;

namespace AgroSistema.Application.Cosecha.AgregarCosecha
{
    public class AgregarCosechaCommandHandler : IRequestHandler<AgregarCosechaCommand>
    {
        private readonly ICosechaRepository _cosechaRepository;

        public AgregarCosechaCommandHandler(ICosechaRepository cosechaRepository)
        {
            _cosechaRepository = cosechaRepository;
        }

        public async Task<Unit> Handle(AgregarCosechaCommand request, CancellationToken cancellationToken)
        {
            //XElement xmlCosechaDetalle = new XElement("DocumentElement");
            //foreach (var item in request.ListaCosechaDetalle)
            //{
            //    Xml
            //}

            string xmlDetalleCosecha;

            XmlSerializer serializer = new XmlSerializer(typeof(List<CosechaDetalleDTO>));

            using (StringWriter writer = new StringWriter())
            {
                serializer.Serialize(writer, request.ListaCosechaDetalle);
                xmlDetalleCosecha = writer.ToString();
            }

            AgregarCosechaEntity entity = new()
            {
                FechaCosecha = request.FechaCosecha,
                IdCampania = request.IdCampania,
                Descripcion = request.Descripcion,
                UsuarioInserta = request.UsuarioInserta,
                XML_ListaCosechaDetalle = xmlDetalleCosecha
            };

            await _cosechaRepository.AgregarCosecha(entity);

            return Unit.Value;
        }
    }
}
