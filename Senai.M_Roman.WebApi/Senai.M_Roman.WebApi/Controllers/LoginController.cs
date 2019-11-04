using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using Senai.M_Roman.WebApi.Domains;
using Senai.M_Roman.WebApi.Repositories;
using Senai.M_Roman.WebApi.ViewModels;

namespace Senai.M_Roman.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        UsuarioRepository UsuarioRepository = new UsuarioRepository();

        public IActionResult Login(LoginViewModel login)

        {

            try

            {

                Usuarios usuarioBuscado = UsuarioRepository.BuscarPorEmailESenha(login);

                if (usuarioBuscado == null)

                    return NotFound(new { mensagem = "Eita, deu ruim." });



                var claims = new[]

                {

                    new Claim(JwtRegisteredClaimNames.Email, usuarioBuscado.Email),

                    new Claim(JwtRegisteredClaimNames.Jti, usuarioBuscado.IdUsuario.ToString()),
        
                };



                var key = new SymmetricSecurityKey(System.Text.Encoding.UTF8.GetBytes("roman-chave-autenticacao"));



                var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);



                var token = new JwtSecurityToken(

                    issuer: "Senai.M_Roman.WebApi",

                    audience: "Senai.M_Roman.WebApi",

                    claims: claims,

                    expires: DateTime.Now.AddDays(30),

                    signingCredentials: creds);



                return Ok(new

                {

                    token = new JwtSecurityTokenHandler().WriteToken(token)

                });

            }

            catch (System.Exception ex)

            {

                return BadRequest(new { mensagem = ex.Message });

            }

        }
    }
}