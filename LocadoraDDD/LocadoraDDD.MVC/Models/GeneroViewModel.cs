﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LocadoraDDD.MVC.Models
{
    public class GeneroViewModel
    {
        public int Id { get; set; }

        public string Nome { get; set; }

        public DateTime DataCriacao { get; set; }
        public bool Ativo { get; set; }
    }
}