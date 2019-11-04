using Microsoft.EntityFrameworkCore;
using Senai.M_Roman.WebApi.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Senai.M_Roman.WebApi.Repositories
{
    public class ProjetoRepository
    {
        public List<Projetos> Listar()
        {
            using (RomanContext ctx = new RomanContext())
            {
                return ctx.Projetos.Include(x => x.IdTemaNavigation).ToList();
            }
        }
        public void Cadastrar(Projetos projeto)
        {
            using (RomanContext ctx = new RomanContext())
            {
                ctx.Projetos.Add(projeto);
                ctx.SaveChanges();
            }
        }
    }
}
