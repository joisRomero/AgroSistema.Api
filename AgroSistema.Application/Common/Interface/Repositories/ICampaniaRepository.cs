using AgroSistema.Domain.Common;
using AgroSistema.Domain.Entities.EditarCampaniaAsync;
using AgroSistema.Domain.Entities.EliminarCampaniaAsync;
using AgroSistema.Domain.Entities.FinalizarCampaniaAsync;
using AgroSistema.Domain.Entities.GetListaPaginadaCampaniasUsuarioAsync;
using AgroSistema.Domain.Entities.ObtenerCampaniaEntity;
using AgroSistema.Domain.Entities.RegistrarCampaniaAsync;
using AgroSistema.Domain.Entities.ValidarCampaniaAsync;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AgroSistema.Application.Common.Interface.Repositories
{
    public interface ICampaniaRepository
    {
        Task<PaginatedEntity<IEnumerable<CampaniasUsuarioPaginadaEntity>>> GetListaPaginaCampaniasUsuarioAsync(ListaPaginadaCampaniasUsuarioEntity listaPaginadaCampaniasSociedadEntity);
        Task<ValidarCampaniaResponse> ValidarCampania(ValidarCampaniaEntity validarCampaniaEntity);
        Task RegistrarCampaniaAsync(RegistrarCampaniaEntity registrarCamapaniaEntity);
        Task EditarCampaniaAsync(EditarCampaniaEntity editarCampaniaEntity);
        Task EliminarCampaniaAsync(EliminarCampaniaEntity eliminarCampaniaEntity);
        Task FinalizarCampaniaAsync(FinalizarCampaniaEntity finalizarCampaniaEntity);
        Task<ObtenerCampaniaEntity> ObtenerCampaniaAsync(int idCampania);

    }
}
