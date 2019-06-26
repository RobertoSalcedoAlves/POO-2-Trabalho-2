using POO2.Trabalho2.SistemaReservas.ClassesBase;
using POO2.Trabalho2.SistemaReservas.Interfaces;
using POO2.Trabalho2.Util;
using System.Collections.Generic;

namespace POO2.Trabalho2.SistemaReservas.Padroes.Composite
{
    public class Arquivo : ArquivoBase
    {
        public Arquivo(string nome, string conteudo, LinkedList<IObjeto> _itens) : base(nome, conteudo, _itens) { }
    }
}
