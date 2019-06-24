﻿using POO2.Trabalho2.SistemaReservas.ClassesBase;
using POO2.Trabalho2.SistemaReservas.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POO2.Trabalho2.SistemaReservas.Padroes.Composite
{
    public class Arquivo : ArquivoBase<IObjeto>
    {
        public Arquivo(string nome, string conteudo = "") : base(nome, conteudo) { }
    }
}
