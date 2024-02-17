using AgroSistema.Domain.Common;
using AgroSistema.Domain.Entities.GetListaPaginadaCampaniasUsuarioAsync;
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
        Task<int> ValidarCampania(ValidarCampaniaEntity validarCampaniaEntity);
    }
}
