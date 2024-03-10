using AgroSistema.Domain.Common;
using AgroSistema.Domain.Entities.AgregarAbonoAsync;
using AgroSistema.Domain.Entities.EditarAbonoAsync;
using AgroSistema.Domain.Entities.EliminarAbonoAsync;
using AgroSistema.Domain.Entities.GetAbonoPorIdAsync;
using AgroSistema.Domain.Entities.ListaPaginadaAbonoAsync;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AgroSistema.Application.Common.Interface.Repositories
{
    public interface IAbonoRepository
    {
        Task<PaginatedEntity<IEnumerable<AbonoPaginadoEntity>>> GetListaPaginadaAbonoAsync(ListaPaginadaAbonoEntity listaPaginadaAbonoEntity);
        Task AgregarAbono(AgregarAbonoEntity agregarAbonoEntity);
        Task EditarAbono(EditarAbonoEntity editarAbonoEntity);
        Task EliminarAbono(EliminarAbonoEntity eliminarAbonoEntity);
        Task<ObtenerAbonoEntity> GetAbonoPorIdAsync(int idAbono);
    }
}
