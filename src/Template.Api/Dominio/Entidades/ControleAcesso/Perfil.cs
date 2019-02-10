using System;
using Microsoft.AspNetCore.Identity;

namespace Template.Api.Dominio.Entidades.ControleAcesso
{
    public class Perfil : IdentityRole<int>, IEntidade
    {
        public DateTime? DataExclusao { get; set; }
    }
}