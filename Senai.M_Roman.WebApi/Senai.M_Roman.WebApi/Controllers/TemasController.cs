using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Senai.M_Roman.WebApi.Domains;
using Senai.M_Roman.WebApi.Repositories;

namespace Senai.M_Roman.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]

    [Authorize]
    public class TemasController : ControllerBase
    {
        TemaRepository TemaRepository = new TemaRepository();

        [HttpGet]
        public IActionResult Listar()
        {
            return Ok(TemaRepository.Listar());
        }


        [HttpPost]
        public IActionResult Cadastrar(Temas tema)
        {
            try
            {
                TemaRepository.Cadastrar(tema);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(new { mensagem = ex.Message });
            }
        }

        [HttpPut]
        public IActionResult Alterar(Temas tema)
        {
            try
            {
                Temas temaBuscado = TemaRepository.BuscarPorId(tema.IdTema);
                if (temaBuscado == null)
                    return NotFound();
                TemaRepository.Alterar(tema);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(new { mensagem = ex.Message });
            }
        }
    }
}