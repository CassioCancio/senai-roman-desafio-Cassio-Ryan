using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Senai.M_Roman.WebApi.Repositories;

namespace Senai.M_Roman.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]

    [Authorize]
    public class StatusController : ControllerBase
    {
        StatusRepository StatusRepository = new StatusRepository();

        [HttpGet]
        public IActionResult Listar()
        {
            return Ok(StatusRepository.Listar());
        }
    }
}