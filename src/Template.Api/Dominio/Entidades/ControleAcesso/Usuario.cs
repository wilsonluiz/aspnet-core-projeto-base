﻿using System;
using Microsoft.AspNetCore.Identity;

namespace Template.Api.Dominio.Entidades.ControleAcesso
{
    public class Usuario : IdentityUser<int>, IEntidade
    {
        public string Nome { get; set; }
        public string Matricula { get; set; }
        public string Cpf { get; set; }
        public DateTime DataNascimento { get; set; }
        public DateTime? DataExclusao { get; set; }
    }
}