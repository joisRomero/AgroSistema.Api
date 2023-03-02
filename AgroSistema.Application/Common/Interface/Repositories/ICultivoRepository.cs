using AgroSistema.Domain.Entities.AgregarCultivoAsync;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AgroSistema.Application.Common.Interface.Repositories
{
    public interface ICultivoRepository
    {
        Task AgregarCultivo(AgregarCultivoEntity agregarCultivoEntity);
    }
}
