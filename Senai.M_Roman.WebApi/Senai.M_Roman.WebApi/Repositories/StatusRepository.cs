using Senai.M_Roman.WebApi.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Senai.M_Roman.WebApi.Repositories
{
    public class StatusRepository
    {
        public List<Status> Listar()
        {
            using (RomanContext ctx = new RomanContext())
            {
                return ctx.Status.ToList();
            }
        }
    }
}
