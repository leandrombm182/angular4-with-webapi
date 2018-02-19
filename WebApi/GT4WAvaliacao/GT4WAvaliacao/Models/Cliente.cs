﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace GT4WAvaliacao.Models
{
    public class Cliente
    {
        public int Id { get; set; }

        public string Nome { get; set; }

        public string Cpf { get; set; }
       
        public DateTime DataNascimento { get; set; }

        public float Peso { get; set; }

        public string Estado { get; set; }
    }
}