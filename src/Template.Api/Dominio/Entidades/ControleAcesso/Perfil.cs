using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Template.Api.Dominio.Entidades.ControleAcesso
{
    public class Perfil : EntidadeBase
    {
        public string Nome { get; set; }
        public DateTime? DataExclusao { get; set; }
    }
}
