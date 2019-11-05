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
    public class ProjetosController : ControllerBase
    {
        ProjetoRepository ProjetoRepository = new ProjetoRepository();

        [HttpGet]
        public IActionResult Listar()
        {
            return Ok(ProjetoRepository.Listar());
        }

        [HttpGet("{tema}")]
        public IActionResult ListarPorTema(string tema)
        {
            return Ok(ProjetoRepository.BuscarPorTema(tema));
        }

        [HttpPost]
        public IActionResult Cadastrar(Projetos projeto)
        {
            try
            {
                ProjetoRepository.Cadastrar(projeto);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(new { mensagem = ex.Message });
            }
        }
    }
}