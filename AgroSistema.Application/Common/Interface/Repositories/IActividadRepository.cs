using AgroSistema.Domain.Common;
using AgroSistema.Domain.Entities.AgregarAbonacionEntity;
using AgroSistema.Domain.Entities.AgregarActividadTrabajadorGastosAsync;
using AgroSistema.Domain.Entities.AgregarFumigacionDetalleAsync;
using AgroSistema.Domain.Entities.AgregarGastoActividadAsync;
using AgroSistema.Domain.Entities.AgregarTrabajadorActividadAsync;
using AgroSistema.Domain.Entities.EliminarActividadAsync;
using AgroSistema.Domain.Entities.ListaPaginadoActividadesAsync;
using AgroSistema.Domain.Entities.ListarDetalleActividadAsync;
using AgroSistema.Domain.Entities.ModificarAbonacionAsync;
using AgroSistema.Domain.Entities.ModificarActividadAsync;
using AgroSistema.Domain.Entities.ModificarFumigacionAsync;
using AgroSistema.Domain.Entities.ModificarFumigacionDetalleAsync;
using AgroSistema.Domain.Entities.ModificarGastosAsync;
using AgroSistema.Domain.Entities.ModificarTrabajadorAsync;
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
        Task ModificarActividadAsync(ModificarActividadEntity modificarActividadEntity);
        Task AgregarTrabajadorAsync(AgregarTrabajadorActividadEntity agregarTrabajadorActividadEntity);
        Task ModificarTrabajadorAsync(ModificarTrabajadorEntity modificarTrabajadorEntity);
        Task AgregarGastoActividadAsync(AgregarGastoActividadEntity agregarGastoActividadEntity);
        Task ModificarGastoActividadAsync(ModificarGastosEntity modificarGastosEntity);
        Task<PaginatedEntity<IEnumerable<ListaPaginadoActividadesEntity>>> ListaPaginadoActividadesAsync (RequestListaPaginadoActividadesEntity entity);
        Task<ListarDetalleActividadEntity> ObtenerDetalleActividadAsync(int idActividad);
        Task<IEnumerable<TrabajadorActividadEntity>> ObtenerTrabajadoresActividadAsync(int idActividad);
        Task<IEnumerable<GastoActividadEntity>> ObtenerGatosActividadAsync(int idActividad);
        Task EliminarActividadAsync(EliminarActividadEntity eliminarActividadEntity);
        Task<IEnumerable<AbonacionActividadEntity>> ObtenerAbonacionActividadAsyn(int idActividad);
        Task<IEnumerable<FumigacionDetalleActividadEntity>> ObtenerFumigacionDetalleActividadAsync(int idFumigacion);
        Task AgregarAbonacionAsync(AgregarAbonacionEntity agregarAbonacionEntity);
        Task ModificarAbonacionAsync(ModificarAbonacionEntity modificarAbonacionEntity);
        Task ModificarFumigacionAsync(ModificarFumigacionEntity modificarFumigacionEntity);
        Task AgregarFumigacionDetalleAsync(AgregarFumigacionDetalleEntity agregarFumigacionDetalleEntity);
        Task ModificarFumigacionDetalleAsync(ModificarFumigacionDetalleEntity modificarFumigacionDetalleEntity);
    }
}
