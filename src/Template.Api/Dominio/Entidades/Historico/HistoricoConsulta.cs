﻿using System;
using Template.Api.Dominio.Entidades.ControleAcesso;

namespace Template.Api.Dominio.Entidades.Historico
{
    public class HistoricoConsulta : IEntidade
    {
        public int Id { get; set; }
        public DateTime DataExecucao { get; set; }
        public string NomeConsulta { get; set; }
        public string Sql { get; set; }
        public int UsuarioId { get; set; }

        public Usuario Usuario { get; set; }
    }
}