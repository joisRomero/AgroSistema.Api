using AgroSistema.Application.Common.Interface.Repositories;
using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AgroSistema.Application.Combos.GetUnidadAbonacion
{
    public class UnidadAbonacionQueryHandler : IRequestHandler<UnidadAbonacionQuery, IEnumerable<UnidadAbonacionDTO>>
    {
        private readonly ICombosRepository _combosRepository;
        private readonly IMapper _mapper;
        public UnidadAbonacionQueryHandler(ICombosRepository combosRepository,IMapper mapper)
        {
            _combosRepository = combosRepository;
            _mapper = mapper;
        }
        public Task<IEnumerable<UnidadAbonacionDTO>> Handle(UnidadAbonacionQuery request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
