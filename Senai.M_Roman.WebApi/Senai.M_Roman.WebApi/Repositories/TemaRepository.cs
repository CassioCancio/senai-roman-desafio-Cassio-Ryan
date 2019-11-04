using Senai.M_Roman.WebApi.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Senai.M_Roman.WebApi.Repositories
{
    public class TemaRepository
    {
        public List<Temas> Listar()
        {
            using (RomanContext ctx = new RomanContext())
            {
                return ctx.Temas.ToList();
            }
        }

        public void Cadastrar(Temas tema)
        {
            using (RomanContext ctx = new RomanContext())
            {
                ctx.Temas.Add(tema);
                ctx.SaveChanges();
            }
        }

        public void Alterar(Temas tema)
        {
            using (RomanContext ctx = new RomanContext())
            {
                Temas TemaBuscado = ctx.Temas.FirstOrDefault(x => x.IdTema == tema.IdTema);
                TemaBuscado.Nome = tema.Nome;
                ctx.Temas.Update(TemaBuscado);
                ctx.SaveChanges();
            }
        }

        public Temas BuscarPorId(int id)
        {
            using (RomanContext ctx = new RomanContext())
            {
                return ctx.Temas.FirstOrDefault(x => x.IdTema == id);
            }
        }
    }
}
