using POO2.Trabalho2.SistemaReservas.ClassesBase;
using POO2.Trabalho2.SistemaReservas.Interfaces;
using System.Collections.Generic;

namespace POO2.Trabalho2.SistemaReservas.Padroes.Composite
{
    public class Pasta : PastaBase
    {
        public Pasta(string nome, string conteudo, LinkedList<IObjeto> _itens) : base(nome, conteudo, _itens) { }

    }
}
