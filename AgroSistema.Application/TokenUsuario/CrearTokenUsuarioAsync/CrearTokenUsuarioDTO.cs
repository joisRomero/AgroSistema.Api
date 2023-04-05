using AgroSistema.Application.Common.Mappings;
using AgroSistema.Domain.Entities.CrearTokenUsuarioAsync;
using AutoMapper;
using Newtonsoft.Json;

namespace AgroSistema.Application.TokenUsuario.CrearTokenUsuarioAsync
{
    public class CrearTokenUsuarioDTO : IMapFrom<TokenUsuarioEntity>
    {
        [JsonProperty(PropertyName = "access_token")]
        public string AccessToken { get; set; }
        [JsonProperty(PropertyName = "token_type")]
        public string TokenType { get; set; }
        [JsonProperty(PropertyName = "expires_in")]
        public long ExpiresIn { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<TokenUsuarioEntity, CrearTokenUsuarioDTO>();
        }
    }
}
