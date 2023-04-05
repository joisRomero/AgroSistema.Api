using AgroSistema.Application.Common.Interface;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace AgroSistema.Api.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class EncriptarController : ControllerBase
    {
        private readonly ICryptography cryptography;
        public EncriptarController(ICryptography cryptography)
        {
            this.cryptography = cryptography;
        }

        [HttpGet]
        [Route("encriptar")]
        public IActionResult EncryptAesAsync(string valor)
        {
            var encryptResult = cryptography.Encrypt(valor);

            return Ok(encryptResult);
        }

        [HttpGet]
        [Route("desencriptar")]
        public IActionResult DesencryptAesAsync(string valor)
        {
            var encryptResult = cryptography.Decrypt(valor);

            return Ok(encryptResult);
        }
    }
}
