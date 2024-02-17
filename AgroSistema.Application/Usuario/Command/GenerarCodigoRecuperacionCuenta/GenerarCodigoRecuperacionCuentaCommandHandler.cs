using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Mail;
using System.Net.Mime;
using System.Net;
using AgroSistema.Application.Common.Exceptions;
using AgroSistema.Application.Common.Dtos;
using AgroSistema.Application.Common.Settings;
using Microsoft.Extensions.Options;
using AgroSistema.Application.Common.Interface.Repositories;
using AgroSistema.Domain.Entities.GuardarTokenRecuperacion;

namespace AgroSistema.Application.Usuario.Command.GenerarCodigoRecuperacionCuenta
{
    public class GenerarCodigoRecuperacionCuentaCommandHandler : IRequestHandler<GenerarCodigoRecuperacionCuentaCommand>
    {
        private IUsuarioRepository _usuarioRepository;
        private readonly CredencialesCorreo _credencialesCorreo;
        public GenerarCodigoRecuperacionCuentaCommandHandler(IUsuarioRepository usuarioRepository, IOptions<CredencialesCorreo> credencialesCorreo)
        {
            _usuarioRepository  = usuarioRepository;
            _credencialesCorreo = credencialesCorreo.Value;
        }

        public async Task<Unit> Handle(GenerarCodigoRecuperacionCuentaCommand request, CancellationToken cancellationToken)
        {
            var validateExits = await _usuarioRepository.ValidateExistsCorreoAsync(request.Correo);
            if (validateExits)
            {
                MailMessage mailMessage = new MailMessage();
                SmtpClient smtpClient = new SmtpClient();

                mailMessage.From = new MailAddress(_credencialesCorreo.Usuario);
                mailMessage.To.Add(new MailAddress(request.Correo));

                mailMessage.Subject = "Agrosistema - Código de verificación por correo electrónico";
                int codigoVerificacion = new Random().Next(99999, 1000000);
                var nombre = await _usuarioRepository.ObtenerNombreCompletoCorreoAsync(request.Correo);
                string cuerpoCorreo = $"<div style=\" width: 400px; font-family: \'Arial\'; padding: 1rem; border-radius: 0.75rem; box-shadow: rgba(149, 157, 165, 0.2) 0px 8px 24px; transition: all 0.3s ease-in-out; position: relative; border: solid .5px #998d8d; margin: 0 auto; color:black \" > <h1 style=\"text-align: center;\">Agrosistema</h1> <p style=\"text-align: center;\">Recuperar tu cuenta</p> <hr/> <p>Hola {nombre} Agrosistema recibió una solicitud para poder recuperar su cuenta.</p> <p>Usa este código para completar la recuperación de cuenta:</p> <p style=\"text-align: center; font-size: xx-large; font-weight: bold;\">{codigoVerificacion}</p> <p>No compartas este código con nadie.</p> </div>";

                AlternateView alternateView = AlternateView.CreateAlternateViewFromString(cuerpoCorreo, Encoding.UTF8, MediaTypeNames.Text.Html);

                mailMessage.AlternateViews.Add(alternateView);

                smtpClient.Host = "smtp.gmail.com";
                smtpClient.Port = 587;
                smtpClient.Credentials = new NetworkCredential(_credencialesCorreo.Usuario, _credencialesCorreo.Clave);
                smtpClient.EnableSsl = true;

                try
                {
                    GuardarTokenRecuperacionEntity entity = new ()
                    {
                        Correo  = request.Correo,
                        Token   = codigoVerificacion.ToString(),
                    };
                    await _usuarioRepository.GuardarTokenRecuperacionAsync(entity);
                    smtpClient.Send(mailMessage);
                }
                catch (Exception ex)
                {
                    throw new BadRequestException(new MensajeUsuarioDTO() { Descripcion = "Se produjo un error al enviar el correo." });
                }
            }
            else
            {
                throw new BadRequestException(new MensajeUsuarioDTO() { Descripcion = "El correo no existe." });
            }

            

            return Unit.Value;
        }
    }
}
