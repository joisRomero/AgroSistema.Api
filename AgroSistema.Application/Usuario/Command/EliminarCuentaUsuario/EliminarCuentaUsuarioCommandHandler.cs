using AgroSistema.Application.Common.Interface.Repositories;
using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AgroSistema.Application.Usuario.Command.EliminarCuentaUsuario
{
    public class EliminarCuentaUsuarioCommandHandler : IRequestHandler<EliminarCuentaUsuarioCommand>
    {
        private readonly IUsuarioRepository _usuarioRepository;
        private readonly IMapper _mapper;
        public EliminarCuentaUsuarioCommandHandler(IUsuarioRepository usuarioRepository, IMapper mapper)
        {
            _usuarioRepository = usuarioRepository;
            _mapper = mapper;
        }
        public async Task<Unit> Handle(EliminarCuentaUsuarioCommand request, CancellationToken cancellationToken)
        {
            await _usuarioRepository.EliminarCuentaUsuario(request.IdUsuario);
            return Unit.Value;
        }
    }
}
