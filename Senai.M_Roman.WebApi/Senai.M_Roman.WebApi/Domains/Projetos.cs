using System;
using System.Collections.Generic;

namespace Senai.M_Roman.WebApi.Domains
{
    public partial class Projetos
    {
        public int IdProjeto { get; set; }
        public string Nome { get; set; }
        public int? IdTema { get; set; }
        public int? IdUsuario { get; set; }

        public Temas IdTemaNavigation { get; set; }
        public Usuarios IdUsuarioNavigation { get; set; }
    }
}
