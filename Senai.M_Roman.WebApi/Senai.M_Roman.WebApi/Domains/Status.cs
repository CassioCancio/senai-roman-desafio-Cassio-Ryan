using System;
using System.Collections.Generic;

namespace Senai.M_Roman.WebApi.Domains
{
    public partial class Status
    {
        public Status()
        {
            Temas = new HashSet<Temas>();
        }

        public int IdStatus { get; set; }
        public string Nome { get; set; }

        public ICollection<Temas> Temas { get; set; }
    }
}
