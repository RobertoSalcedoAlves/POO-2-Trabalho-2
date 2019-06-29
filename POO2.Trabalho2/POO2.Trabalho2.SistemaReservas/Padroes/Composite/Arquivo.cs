using POO2.Trabalho2.SistemaReservas.ClassesBase;
using POO2.Trabalho2.SistemaReservas.Interfaces;
using static POO2.Trabalho2.Util.FormataConsole;
using System.Collections.Generic;

namespace POO2.Trabalho2.SistemaReservas.Padroes.Composite
{
    public class Arquivo : ArquivoBase
    {
        public Arquivo(string nome, string conteudo, LinkedList<object> itens) : base(nome,  conteudo, itens) { }

        public override void ImprimirNoh(object noh, object current)
        {
            if (noh.Equals(current)) { Selecionar(noh.ToString()); }
            else { Imprimir(noh.ToString(), Cor); }
        }
    }
}
