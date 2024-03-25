using AgroSistema.Domain.Common;
using AgroSistema.Domain.Entities.AgregarCosechaAsync;
using AgroSistema.Domain.Entities.EditarCosechaAsync;
using AgroSistema.Domain.Entities.EliminarCosechaAsync;
using AgroSistema.Domain.Entities.GetCosechaPorIdAsync;
using AgroSistema.Domain.Entities.GetListaPaginadaCosechasAsync;
using AgroSistema.Domain.Entities.ListarCosechaDetalleAsync;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AgroSistema.Application.Common.Interface.Repositories
{
    public interface ICosechaRepository
    {
        Task<PaginatedEntity<IEnumerable<CosechaPaginadaEntity>>> GetListaPaginadaCosechasAsync(ListaPaginadaCosechasEntity listaPaginadaCosechasEntity);
        Task AgregarCosecha(AgregarCosechaEntity agregarCosechaEntity);
        Task EditarCosecha(EditarCosechaEntity editarCosechaEntity);
        Task EliminarCosecha(EliminarCosechaEntity eliminarCosechaEntity);
        Task<ObtenerCosechaEntity> GetCosechaPorIdAsync(int idCosecha);
        Task<IEnumerable<DetalleCosechaDetalleEntity>> GetCosechaDetallePorIdAsync(int idCosecha);
        Task EliminarCosechaDetalle(int idCosechaDetalle, string usuarioElimina);
    }
}
