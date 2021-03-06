﻿using System;

namespace Template.Api.Dominio.Entidades.Logs
{
    public class Log : IEntidade
    {
        public int Id { get; set; }
        public DateTime DataOcorrencia { get; set; }
        public string Tipo { get; set; }
        public string Descricao { get; set; }
        public string Mensagem { get; set; }
    }
}